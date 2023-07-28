# -*- coding: utf-8 -*-
"""
Created on Mon Sep 26 20:38:42 2022

@author: 86159
"""



#获取shp文件
import osmnx as ox 
import networkx as nx
import pandas as pd
ox.config(log_console=True, use_cache=True)
# G = ox.graph_from_address(['西南交通大学犀浦校区，成都市'], network_type = 'drive') #利用地理位置
G = ox.graph_from_bbox(30.5371845,30.5653842,104.0167202,104.0695693, network_type='drive') #利用经纬度
G = ox.project_graph(G)



#计算拓扑性质
print(nx.density(G))   #网络密度
print(nx.degree_centrality(G))   #度中心性
print(nx.closeness_centrality(G))  #接近中心性
print(nx.degree(G))   #节点度
print(nx.edge_betweenness(G))  #边介数
print(nx.edge_betweenness_centrality(G)) #介数中心性
print(nx.clustering(nx.Graph(G)))  #聚类系数
print(nx.shortest_path_length(G,source=None, target=None, weight=None, method='dijkstra')) #最短路径长度


#一.保存边数据(以边介数为例)
dict_info=nx.edge_betweenness(G)
new_list=[]
for k,v in dict_info.items():
    one=k[0]
    two=k[1]
    new_list.append([one,two,v])
pf=pd.DataFrame(new_list)
pf.to_csv("D:/qgis/edge.csv",index=False,header=False)

#二.保存节点数据(以节点度为例)
dict_info = dict(nx.degree(G))
new_list=[[key,values] for key,values in dict_info.items()]
pf=pd.DataFrame(new_list)
pf.to_csv("D:/qgis/node.csv",index=False,header=False)