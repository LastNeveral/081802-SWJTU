# -*- coding: utf-8 -*-
"""
Created on Sun Dec  2 15:28:34 2018
@author: Jun Xie

Covered on Fri Oct 14 9:06:10 2022
@cover:Xinhao Liu
"""

import math
"""
类名：首字母大写 Node Link Origin Destination
承载类的对象的容器：全部字母大写 NODE LINK ORIGIN
其中NODE、LINK为list，0位置废掉，下标代表编号
ORIGIN为dictionary，下标代表编号
ORIGIN[i].destination为装载Destination对象的字典，ORIGIN[i].destination[j]代表以i为O，
以j为D的Destination对象
"""
##################################
#建立Node,Link,Origin,Destination类
##################################
"""
属性：
node_id 节点编号; l_in 流入节点的路段对象构成的列表; l_out 流出节点的路段对象构成的列表; 
u 最短路中该节点cost标号; p 最短路中该节点前序节点标号
方法：
set_l_in 向流入路段列表末尾添加一个路段对象; set_l_out 向流出路段列表末尾添加一个路段对象;
set_SPP_u 设置cost标号; set_SPP_p 设置前序节点标号
"""
#import time
class Node:
    def __init__(self, node_id, l_in_empty, l_out_empty):
        self.node_id = node_id
        self.l_in = l_in_empty
        self.l_out = l_out_empty
    def set_l_in(self, l_in):
        self.l_in.append(l_in)
    def set_l_out(self, l_out ):
        self.l_out.append(l_out)
    def set_SPP_u(self, u):
        self.u = u
    def set_SPP_p(self,p):
        self.p = p
    def set_X(self, X):
        self.X = X
    def set_Y(self, Y):
        self.Y = Y
    def set_Astar_g(self, g):
        self.g = g
    def set_Astar_h(self, h):
        self.h = h
    def set_Astar_f(self, f):
        self.f = f

class Link:
    def __init__(self, link_id, tail_node, head_node, capacity, \
                 length, free_flow_time, b, power, speed_limit, \
                 toll, link_type, x_flow):
        self.liAnk_id = link_id
        self.tail_node = tail_node
        self.head_node = head_node
        self.capacity = capacity
        self.length = length
        self.free_flow_time = free_flow_time
        self.b = b
        self.power = power
        self.speed_limit = speed_limit
        self.toll = toll
        self.link_type = link_type
        self.x_flow = x_flow
        
##################################
#读取网络文件
##################################
def read_net_create_LINK_NODE(network):
    with open('%s_net.txt'%network, 'r') as f1:
        l1 = f1.readlines()
    #去除空行
    length=len(l1)
    x=0
    while x < length:
        if l1[x] == '\n':
            del l1[x]
            x -= 1
            length -= 1
        x += 1
    for i in range(len(l1)):
        if '~' in l1[i]:
            l1_START_LINE = i+1
            break
    # str modify
    for i in range(5):
        l1[i] = l1[i].split(' ')
    NODE_COUNT = eval(l1[1][-1])
    LINK_COUNT = eval(l1[3][-1])
    for i in range(l1_START_LINE, len(l1)):
        l1[i] = l1[i].rstrip('\n')
        l1[i] = l1[i].rstrip(';')
        l1[i] = l1[i].rstrip('\t')
        l1[i] = l1[i].lstrip('\t')
        l1[i] = l1[i].split('\t')
    readlist = l1[l1_START_LINE:]
##################################
#建立 Link与Node对象，并放入LINK与NODE容器
##################################
    LINK = [Link(i+1,eval(readlist[i][0]),eval(readlist[i][1]),\
                 eval(readlist[i][2]),eval(readlist[i][3]),\
                 eval(readlist[i][4]),eval(readlist[i][5]),\
                 eval(readlist[i][6]),eval(readlist[i][7]),\
                 eval(readlist[i][8]),eval(readlist[i][9]),0) for i in range(LINK_COUNT)]
    LINK.insert(0, 0)#in order to avoid different meanings between index and id
    # create node object and put them into NODE_LIST
    NODE = [Node(i+1,[],[]) for i in range(NODE_COUNT)]
    NODE.insert(0, 0)
    # rectify l_in and l_out
    for i in range (1, LINK_COUNT+1):
        NODE[LINK[i].tail_node].set_l_out(LINK[i])
        NODE[LINK[i].head_node].set_l_in(LINK[i])
    return ( LINK, NODE, NODE_COUNT, LINK_COUNT)
###################################
##设置nod文件
###################################
def read_nod(network, node, node_count):
    with open('%s_nod.txt'%network, 'r') as f3:
        l3 = f3.readlines()
    #去除空行
    length=len(l3)
    x=0
    while x < length:
        if l3[x] == '\n':
            del l3[x]
            x -= 1
            length -= 1
        x += 1
    #添加到Node属性
    for i in range(1, len(l3)):
        l3[i] = l3[i].rstrip('\n')
        if network == 'sf':
            l3[i] = l3[i].rstrip(';')
            l3[i] = l3[i].rstrip('\t')
        l3[i] = l3[i].split('\t')
    readlist3 = l3 #0位置使用题头占用
    if node_count != (len(readlist3)-1):
        print('data missing!')
    for jj in range(1,node_count+1):
        if node[jj].node_id - eval(readlist3[jj][0])==0:
            node[jj].set_X(eval(readlist3[node[jj].node_id][1]))
            node[jj].set_Y(eval(readlist3[node[jj].node_id][2]))        

def SPP_GLC(o_id,node,link):
    #initialize
    node[o_id].set_SPP_u(0) #initial label cost for origin
    for t in node[1:]:
        t.set_SPP_p(-1)
        if t.node_id != o_id:
            t.set_SPP_u(float('inf')) #each label sets infinity except origin
    #mainloop
    for k in node[1:]: # loop by num of nodes
        for ij in link[1:]: # loop by num of links
            j = node[ij.head_node]
            i = node[ij.tail_node]
            if j.u > (i.u+ij.length):#update label and  predecessor if label cost can be reduced
                j.u = (i.u+ij.length)
                j.p = i#id还是对象
    shortestpath_p_list = [0] #store predecessor list of each node
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    return shortestpath_p_list
   

#label correcting algorithm
def SPP_LC(o_id,node):
    node[o_id].set_SPP_u(0) # 初始化起点权值
    for t in node[1:]:
        t.set_SPP_p(-1) # 初始化点的前置节点为-1
        if t.node_id != o_id:
            t.set_SPP_u(float('inf'))   # 初始化其他点权值为‘inf’

    C = [node[o_id]] # C为SEL集，将初始点位放入
    while len(C)!=0:    # 循环结束条件：当SEL集为空时
        i = C[0]
        # 遍历以i节点为起点的边
        for l in i.l_out:
            n = node[l.head_node]
            if i.u+l.length<n.u: # 更新条件
                n.u = i.u+l.length
                n.p = i
                if n not in C: # 若n节点不在C中，将n放入C
                    C.append(n)
        del C[0] # 将C[0]从SEL中删除
    shortestpath_p_list = [0]
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    return shortestpath_p_list

#label setting algorithm
def SPP_LS(o_id,node):
    node[o_id].set_SPP_u(0)# 初始化起点权值
    for t in node[1:]:
        t.set_SPP_p(-1) # 初始化点的前置节点为-1
        if t.node_id != o_id:
            t.set_SPP_u(float('inf'))   # 初始化其他点权值为‘inf’

    C = list(range(1,len(node))) # 将初始点位编号放入C集
    while len(C)!=0:
        mmin = float('inf')
        minpos = -1
        # 寻找最小值所在位置
        for i in C:
            if node[i].u<mmin:
                mmin = node[i].u
                minpos = i
        # 检验条件，当存在不可达集时退出
        if minpos == -1:
            break
        C.remove(minpos)
        # 遍历以编号为minpos节点为起点的边
        for j in node[minpos].l_out:
            n = node[j.head_node]
            if n.u > mmin + j.length: # 更新条件
                n.u = mmin + j.length
                n.p = node[minpos]

    shortestpath_p_list = [0]
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    return shortestpath_p_list

    
    


     
    
















