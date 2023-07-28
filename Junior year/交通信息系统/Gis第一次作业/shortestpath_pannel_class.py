import time
import random
import matplotlib.pyplot as plt
from shortestpath_obj_class import  read_net_create_LINK_NODE,read_nod,SPP_LC,SPP_LS,SPP_GLC

#根据link list获取路径长度
def get_length(Astarsp):
    sum_length = 0
    for i in Astarsp:
        sum_length += i.length #sum the link cost
    print('length = ',sum_length)

#test general lable correcting algorithm
def Test_SPP_GLC(o_id,d_id):
    Lc_node = [] # store node list between o_id and d_id
    shortestpath_link = []  # store link list between o_id and d_id
    shortestpath_p_list = SPP_GLC(o_id,NODE,LINK) # call glc function to calculate the shortest path tree
    if shortestpath_p_list[o_id] == -1: # check correctness
        pass
    else:
        print('shortestpath_p_list is wrong!')

    #identify the shortest path from destination node to origin node
    head_n = NODE[d_id]
    Lc_node.append(d_id)
    tail_n = shortestpath_p_list[d_id] #get the predecessor
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id: #get the exact link by predecessor
                shortestpath_link.insert(0,l)
        head_n = tail_n
        Lc_node.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id]
    Lc_node.reverse()
    return (shortestpath_link,Lc_node)
    

    
#test the lable correcting algorithm
def Test_SPP_LC(o_id,d_id):
    Lc_node = [] # store node list between o_id and d_id
    shortestpath_link = []  # store link list between o_id and d_id
    shortestpath_p_list = SPP_LC(o_id,NODE)  # call LC function to calculate the shortest path tree
    if shortestpath_p_list[o_id] == -1:
        pass
    else:
        print('shortestpath_p_list is wrong!')

    # identify the shortest path from destination node to origin node
    head_n = NODE[d_id]
    Lc_node.append(d_id)
    tail_n = shortestpath_p_list[d_id] #get the predecessor
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id:#get the exact link by predecessor
                shortestpath_link.insert(0,l)
        head_n = tail_n
        Lc_node.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id] #get the predecessor
    Lc_node.reverse()
    return (shortestpath_link,Lc_node)

#test the lable setting algorithm
def Test_SPP_LS(o_id,d_id):
    Lc_node = []  # store node list between o_id and d_id
    shortestpath_link = []  # store link list between o_id and d_id
    shortestpath_p_list = SPP_LS(o_id, NODE)  # call LC function to calculate the shortest path tree
    if shortestpath_p_list[o_id] == -1:
        pass
    else:
        print('shortestpath_p_list is wrong!')

    # identify the shortest path from destination node to origin node
    head_n = NODE[d_id]
    Lc_node.append(d_id)
    tail_n = shortestpath_p_list[d_id]  # get the predecessor
    while tail_n != -1:
        for l in head_n.l_in:
            if l.tail_node == tail_n.node_id:  # get the exact link by predecessor
                shortestpath_link.insert(0, l)
        head_n = tail_n
        Lc_node.append(tail_n.node_id)
        tail_n = shortestpath_p_list[head_n.node_id]  # get the predecessor
    Lc_node.reverse()
    return (shortestpath_link, Lc_node)

# 最短路可视化
def Visual_path(node,short_node):
    # 底图绘制
    for i in node[1:]:
        # plt.scatter(i.X,i.Y,s='.',c='b')
        for j in i.l_out:
            out = j.head_node
            x = [i.X,node[out].X]
            y = [i.Y,node[out].Y]
            plt.plot(x,y,marker='',color='lightgray',zorder=1)
    # 起讫点绘制
    o = short_node[0]
    d = short_node[-1]
    plt.scatter(node[o].X,node[o].Y,s=50,c='skyblue',label='ori:'+str(o),zorder=3)
    plt.scatter(node[d].X,node[d].Y,s=50,c='yellowgreen',label='des:'+str(d),zorder=3)
    # 线路绘制
    for i in range(0,len(short_node)-1):
        o = short_node[i]
        d = short_node[i+1]
        x = [node[o].X, node[d].X]
        y = [node[o].Y, node[d].Y]
        plt.plot(x, y, marker='', color='tomato',zorder=2)

    plt.legend()
    plt.show()

def al_rand20():
    random.seed(4)  # 设置随机数seed
    # 生成随机od表
    m = len(NODE)-1 # m为标号的上界
    o_id = [random.randint(1, m) for i in range(20)]
    d_id = [random.randint(1, m) for i in range(20)]
    # 循环打印每次的结果
    for i in range(0,20):
        Astarsp, Astarspnode = Test_SPP_LS(o_id[i], d_id[i])
        print(Astarspnode)
        get_length(Astarsp)
        # 进行可视化绘图
        if i == 0:
            Visual_path(NODE, Astarspnode)

def glc_time_tests():
    glc_time = []
    for i in range(1,10):
        start = time.time() #开始运行时间
        SPP_GLC(o_id[i],NODE,LINK)
        end = time.time() #结束运行时间
        glc_time.append(end-start)
    print('glc_time:', end='')
    print(glc_time)

def lc_time_tests():
    lc_time = []
    for i in range(1,10):
        start = time.time() #开始运行时间
        SPP_LC(o_id[i], NODE)
        end = time.time() #结束运行时间
        lc_time.append(end-start)
    print('lc_time:', end='')
    print(lc_time)

def ls_time_tests():
    ls_time = []
    for i in range(1,10):
        start = time.time() #开始运行时间
        SPP_LS(o_id[i], NODE)
        end = time.time() #结束运行时间
        ls_time.append(end-start)
    print('ls_time:',end='')
    print(ls_time)

if __name__ =='__main__':
    network = ['sf', 'cs', 'chi']
    print('随机抽取OD输出测试：')
    for i in network:
        NETWORK = i# sf = SiousFall;cs = ChicagoSketch; chi=ChicagoRegional
        print(i)
        LINK, NODE, NODE_COUNT, LINK_COUNT = read_net_create_LINK_NODE(NETWORK)
        read_nod(NETWORK, NODE, NODE_COUNT)
        al_rand20()

    print('运行时间测试：')
    for i in ['cs', 'chi']:
        # 读取网络
        NETWORK = i
        LINK, NODE, NODE_COUNT, LINK_COUNT = read_net_create_LINK_NODE(NETWORK)
        read_nod(NETWORK, NODE, NODE_COUNT)
        #随机生成od对
        random.seed(4)
        m = len(NODE) - 1
        o_id = [random.randint(1, m) for i in range(10)]
        d_id = [random.randint(1, m) for i in range(10)]
        #打印基本信息
        print(i)
        print(list(zip(o_id,d_id)))

        glc_time_tests()    # glc测试
        lc_time_tests() # lc测试
        ls_time_tests() # ls测试



