# -*- coding: utf-8 -*-
"""
Created on Wed Sep 28 19:08:05 2022

@author: 86159
"""
import osmnx as ox 
# import pandas as pd

ox.config(log_console=True, use_cache=True)
# 利用经纬度
G = ox.graph_from_bbox(30.7147, 30.9649, 103.7139, 104.0543, network_type='drive')
G = ox.project_graph(G)
fig, ax = ox.plot_graph(G, bgcolor='w', node_size=5, node_color='k', node_edgecolor='none', node_zorder=2,
                        edge_color='#555555', edge_linewidth=1, edge_alpha=1)
# 保存路网文件
ox.save_graph_shapefile(G, filepath="..//data//")


