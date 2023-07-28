# -*- coding: utf-8 -*-
"""
Created on Wed Sep 28 19:08:05 2022

@author: 86159
"""


import osmnx as ox 
import pandas as pd

ox.config(log_console=True, use_cache=True)
#利用经纬度
G = ox.graph_from_bbox(30.5371845,30.5653842,104.0167202,104.0695693, network_type='drive')
#利用地理位置
#G = ox.graph_from_address('西南交通大学犀浦校区, 成都市', network_type='drive')
G = ox.project_graph(G)
fig, ax = ox.plot_graph(G, bgcolor='w', node_size=5, node_color='k', node_edgecolor='none', node_zorder=2,
                        edge_color='#555555', edge_linewidth=1, edge_alpha=1)
ox.save_graph_shapefile(G,filepath="..//data//")


