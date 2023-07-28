
import time
import math
import sys
from qgis.core import *

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
DEBUGMODE=True 
#import time
class Node:
    def __init__(self, node_id, l_in_empty, l_out_empty, X, Y):
        self.node_id = node_id
        self.l_in = l_in_empty
        self.l_out = l_out_empty
        self.X = X
        self.Y = Y
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
    def __init__(self, link_id, tail_node, head_node, length):
        self.liAnk_id = link_id
        self.tail_node = tail_node
        self.head_node = head_node
        self.length = length
        
##################################
#读取网络文件
##################################
def read_shpFile(Link_layer, Node_layer, Nfilename, Lfilename):
    #补充完整代码
    Link_layer = QgsVectorLayer(Link_layer, Lfilename,'ogr')
    Node_layer = QgsVectorLayer(Node_layer, Nfilename, 'ogr')

    Link_features = Link_layer.getFeatures()
    Node_features = Node_layer.getFeatures()

    NODE_COUNT = 0
    list2 = []
    for feature in Node_features:
        NODE_COUNT = NODE_COUNT + 1
        geom = feature.geometry()
        x = geom.asPoint()
        list2.append(x)

    NODE = [Node(i + 1, [], [], list2[i][0],list2[i][1]) for i in range(NODE_COUNT)]
    NODE.insert(0,0)

    LINK_COUNT = 0
    list = []
    for feature in Link_features:
        LINK_COUNT = LINK_COUNT + 1
        geom = feature.geometry()
        x = geom.asMultiPolyline()

        find_tail = False
        find_head = False
        for node in NODE[1:]:
            if (x[0][0][0] == node.X and x[0][0][1]==node.Y):
                find_tail = True
                tail_id = node.node_id
            if (x[0][1][0] == node.X and x[0][1][1]==node.Y):
                find_head = True
                head_id = node.node_id
            if (find_tail and find_head):
                break
        list.append([tail_id, head_id, geom.length()])

    LINK = [Link(i+1, list[i][0],list[i][1], list[i][2]) for i in range(LINK_COUNT)]
    LINK.insert(0,0)

    for i in range(1,LINK_COUNT+1):
        NODE[LINK[i].tail_node].set_l_out(LINK[i])
        NODE[LINK[i].head_node].set_l_in(LINK[i])
    return (LINK,NODE,NODE_COUNT,LINK_COUNT)

def SPP_CA(o_id, node):
    node_num = len(node)
    node[o_id].set_SPP_u(0)
    for t in node[1:]:
        t.set_SPP_p(-1)
        if t.node_id != o_id:
            t.set_SPP_u(float('inf'))
    for n in range(node_num):#和LC算法区别在于，计算复杂度为O(mn)
        for i in node[1:node_num+1]:
            for ij in i.l_out:
                j = node[ij.head_node]
                if j.u > (i.u+ij.length):
                    j.u = (i.u+ij.length)
                    j.p = i#id还是对象
    shortestpath_p_list = [0]
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    return shortestpath_p_list

def SPP_LC(o_id,node):
    #initialize
    node[o_id].set_SPP_u(0)
    for t in node[1:]:
        t.set_SPP_p(-1)
        if t.node_id != o_id:
            t.set_SPP_u(float('inf'))
    #mainloop
    Q = [node[o_id]]
    while len(Q) != 0:
        i = Q[0]
        del Q[0]
        for ij in i.l_out:
            j = node[ij.head_node]
            if j.u > (i.u+ij.length):
                j.u = (i.u+ij.length)
                j.p = i#id还是对象
                if j not in Q:
                    Q.append(j)
    shortestpath_p_list = [0]
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    return shortestpath_p_list
 


def SPP_LS(o_id,d_id,node):
#   #initialize
    node[o_id].set_SPP_u(0)
    for t in node[1:]:
        t.set_SPP_p(-1)
        if t.node_id != o_id:
            t.set_SPP_u(float('inf'))
    #mainloop
    Q = [node[o_id]]
    while len(Q) != 0:
        Q.sort(key = lambda qq:qq.u)
        i = Q[0]
        if i.node_id == d_id:
            break
        del Q[0]
        for ij in i.l_out:
            j = node[ij.head_node]
            if j.u > (i.u+ij.length):
                j.u = (i.u+ij.length)
                j.p = i#id还是对象
                if j not in Q:
                    Q.append(j)
    shortestpath_p_list = [0]
    for t in node[1:]:
        shortestpath_p_list.append(t.p)
    spath = []
    snode = []
    head_n = node[d_id]
    snode.append(d_id)
    tail_n = shortestpath_p_list[d_id]
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id:
                spath.insert(0,l)
        head_n = tail_n
        snode.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id]
    snode.reverse()
    return (spath,snode)
#find the path and node list
    
    



def get_length(Astarsp):
    sum_length = 0
    for i in Astarsp:
        sum_length += i.length
    print('length = ',sum_length)


#test the lable setting algorithm
def Test_SPP_LS(o_id, d_id):
    spath, snode = SPP_LS(o_id,d_id,NODE)
    return(spath, snode)

#test the continuous approximation algorithm
def Test_SPP_CA(o_id,d_id):
    Lc_node = []
    shortestpath_p_list = SPP_CA(o_id,NODE)
    if shortestpath_p_list[o_id] == -1:
        pass
    else:
        print('shortestpath_p_list is wrong!')
    shortestpath_link=[]
    head_n = NODE[d_id]
    Lc_node.append(d_id)
    tail_n = shortestpath_p_list[d_id]
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id:
                shortestpath_link.insert(0,l)
        head_n = tail_n
        Lc_node.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id]
    Lc_node.reverse()
    return (shortestpath_link,Lc_node)

#test the lable correcting algorithm
def Test_SPP_LC(o_id,d_id):
    Lc_node = []
    shortestpath_p_list = SPP_LC(o_id,NODE)
    if shortestpath_p_list[o_id] == -1:
        pass
    else:
        print('shortestpath_p_list is wrong!')
    shortestpath_link=[]
    head_n = NODE[d_id]
    Lc_node.append(d_id)
    tail_n = shortestpath_p_list[d_id]
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id:
                shortestpath_link.insert(0,l)
        head_n = tail_n
        Lc_node.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id]
    Lc_node.reverse()
    return (shortestpath_link,Lc_node)


##################################
# 创建结果的shp文件
##################################
def writeShp(splink, spnode):
    # 补充完整代码
    layerFields = QgsFields()
    layerFields.append(QgsField('id',QVariant.Int))
    layerFields.append(QgsField('tail', QVariant.Int))
    layerFields.append(QgsField('head', QVariant.Int))

    addr = sys.path[0]
    writer = QgsVectorFileWriter('','UTF-8',layerFields,\
                                QgsWkbTypes.LineString, QgsCoordinateReferenceSystem('EPSG:4326'),'ESRI Shapefile')

    count = 0
    for link in splink:
        count = count+1
        feat = QgsFeature()
        tailnode = QgsPoint(NODE[link.tail_node].X, NODE[link.tail_node].Y)
        headnode = QgsPoint(NODE[link.head_node].X, NODE[link.head_node].Y)
        feat.setGeometry(QgsGeometry.fromPolyline([tailnode, headnode]))
        feat.setAttributes([count,link.tail_node-1,link.head_node-1])

        writer.addFeature(feat)
    del(writer)

    return "Success for creating shpfile!"

#find the path and node list
#设置文件名称
##################################
Link_layer = ""
Node_layer = ""
Node_filename = "ChicagoSketch-ex1_nod_s" #ChicagoSketch-ex1_nod_s , sf-ex1_nod_s
Link_filename = "ChicagoSketch-ex1_lnk_s" #ChicagoSketch-ex1_lnk_s , sf-ex1_lnk_s
##################################
#调用函数
##################################
LINK, NODE, NODE_COUNT, LINK_COUNT = read_shpFile(Link_layer, Node_layer, Node_filename, Link_filename)
###
start = time.perf_counter()


o = 100
d = 300
sp, spnode = Test_SPP_LS(o, d)
    
end = time.perf_counter()
print('run time =', end - start)

print (spnode)
get_length(sp)

print(writeShp(sp, spnode))

     
    


















