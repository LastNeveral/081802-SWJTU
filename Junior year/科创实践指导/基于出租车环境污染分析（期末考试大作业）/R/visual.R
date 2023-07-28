library(ggplot2)
data<-read.csv(file="../jupyter/data_NO.csv",encoding = "uft-8")

ggplot(data = aaa)+
  geom_bar(mapping = aes(rate,y = count),
           stat = "identity",color='white')+
  labs(x='Effective driving ratio',
       y='Number of taxi',
       caption = 'Xinhao Liu,2020112921',
       title = "Effective driving ratio of taxi",
       subtitle = "1/10 data in Chengdu on August 15, 2014",)+
  theme(axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))





ggplot(bbb,aes(x=hours,y=distance))+
  geom_line(linewidth=0.75)+
  geom_point(size=2)+
  scale_x_continuous(breaks = seq(0,24,6))+
  labs(x='hours/h',
       y='distance/km',
       title = "The distance of each hour",
       subtitle = "1/10 data In Chengdu on August 15, 2014",
       caption = 'Xinhao Liu,2020112921')+
  theme(axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))
  
ggplot(bbb,aes(x=hours,y=CO))+
  geom_line(linewidth=0.75)+
  geom_point(size=2)+
  scale_x_continuous(breaks = seq(0,24,6))+
  labs(x='hours/h',
       y='emissions/g',
       title = "The CO emissions of each hour",
       subtitle = "1/10 data in Chengdu on August 15, 2014",
       caption = 'Xinhao Liu,2020112921')+
  theme(axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))

ggplot(bbb)+
  geom_line(aes(x=hours,y=NO,color='NO'),linewidth=0.75)+
  geom_point(aes(x=hours,y=NO,color='NO'),size=2)+
  scale_x_continuous(breaks = seq(0,24,6))+
  labs(x='hours/h',
       y='NO emissions/g',
       title = "The NOx and CO emissions of each hour",
       subtitle = "1/10 data in Chengdu on August 15, 2014",
       caption = 'Xinhao Liu,2020112921')+
  theme(legend.title = element_blank(),
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))+
  scale_y_continuous(limits = c(1000,3500),
                     breaks = seq(0,4000,500),
                     expand = c(0,0),
                     sec.axis = sec_axis(~.*15,
                                         name = 'CO emissions/g',
                                         breaks = seq(20000,70000,10000)))+
  geom_line(aes(x=hours,y=CO/15,color='CO'),linewidth=0.75)+
  geom_point(aes(x=hours,y=CO/15,color='CO'),size=2)+
  scale_color_manual(values = c('#27408B','#EEB422'))



library(dplyr)
group_by(data_NO,id)

ggplot(sample,aes(langitude,latitude,color=factor(id)))+
  geom_point(size = 0.5)+
  geom_path(linewidth=0.5,alpha=0.5)+
  labs(x='longitude',
       title = "The driving trajectory of the taxi",
       subtitle = "The sample taxi in Chengdu on August 15, 2014",
       caption = 'Xinhao Liu, 2020112921',
       color = "ID_taxi")+
  theme(axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11),
        legend.title = element_text(size = 10,face = "bold"),
        legend.text = element_text(size = 10, face = "bold"),
        strip.text = element_text(size = 11, face = "bold"))+
  guides(color = guide_legend(override.aes = list(size = 4)))+
  scale_x_continuous(breaks = seq(103,105,0.1))+
  scale_y_continuous(breaks = seq(30,31,0.1))
 

ggplot(sample,aes(langitude,latitude))+
  geom_point(aes(color=factor(Carrying)),size = 0.8,alpha=2)+
  geom_path(linewidth=0.1,color='#7F7F7F',alpha=0.7)+
  facet_wrap(~id,nrow=2)+
  labs(title = "The driving trajectory of the taxi",
       x='longitude',
       subtitle = "The sample taxi in Chengdu on August 15, 2014",
       caption = 'Xinhao Liu, 2020112921',
       color = "Carrying")+
  theme(axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11),
        legend.title = element_text(size = 10,face = "bold"),
        legend.text = element_text(size = 10, face = "bold"),
        strip.text = element_text(size = 11, face = "bold"))+
  guides(color = guide_legend(override.aes = list(size = 5)))+
  scale_x_continuous(breaks = seq(103,105,0.1))+
  scale_y_continuous(breaks = seq(30,31,0.1))+
  scale_color_manual(values = c('#36648B','#90EE90'))





library(tidyverse)
library(sf)
library(ggspatial)
library(amapGeocode)
library(gstat)
library(RColorBrewer)
library(ggtext)

chengdu_map <- st_read('https://geo.datav.aliyun.com/areas_v3/bound/510100_full.json')[c('adcode','name','geometry')]
p1<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = data_NO,
                 aes(x=langitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  labs(title = "TRACE",
       x='longitude',
       subtitle = "in Chengdu on August 15, 2014",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                       breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                       breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))


p2 <-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = no_0,
                 aes(x=langitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "NOx",
       x='longitude',
       subtitle = "in Chengdu on August 15, 2014",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))

p3 <-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = no_0,
                 aes(x=langitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "CO",
       x='longitude',
       subtitle = "in Chengdu on August 15, 2014",
       caption = 'Xinhao Liu,2020112921',
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18),
        plot.subtitle = element_text(size = 11))


library(patchwork)
p1+p2+p3




h6<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X6,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 geom = "polygon")+
  scale_fill_continuous(high="#CA91C3",low="#E683FD")+
  labs(title = "6:00-7:00",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

h9<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X9,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "9:00-10:00",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

h12<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X12,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "12:00-13:00",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

h15<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X15,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "15:00-16:00",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

h18<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X18,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#CA91C3",low="#E683FD")+
  labs(title = "18:00-19:00",
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

h21<-ggplot()+
  geom_sf(data = chengdu_map,fill='white')+
  stat_density2d(data = X21,
                 aes(x=longitude,y=latitude,fill=..level..,alpha=..level..),
                 size=4,
                 geom = "polygon")+
  scale_fill_continuous(high="#3B0700",low="#E683FD")+
  labs(title = "21:00-22:00",
       caption = 'Xinhao Liu,2020112921',
       plot.caption = element_markdown(face='bold'))+
  scale_x_continuous(limits = c(104,104.15),
                     breaks = seq(103,105,0.1))+
  scale_y_continuous(limits = c(30.575,30.725),
                     breaks = seq(30,31,0.1))+
  theme(legend.position = "none",
        axis.title = element_text(size = 14, color = "firebrick"),
        plot.title = element_text(size = 18))

(h6+h9+h12)/(h15+h18+h21)

s






ggsave("distance.png",plot = last_plot(),dpi=300,path="C:/Users/Mr.Liu/Desktop/基于出租车环境污染分析/img")

