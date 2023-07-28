library(ggplot2)

w = read.csv('bus_activity.csv')

ggplot(w)+
  geom_line(aes(x=start,y = bus_y,color=status,group = bus_y))+
  scale_color_manual(values = c('white','gray','blue'))+
  theme(panel.grid.minor = element_blank())

w['line']==37
w1

