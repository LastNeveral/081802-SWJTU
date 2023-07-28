

library(ggplot2)
path <- read.csv('../data/line_path.csv')
w <- read.csv('../data/terminal-and-depots.csv')
depot <- w[w$type=='depot', ]


p1 <- ggplot(path, aes(lng, lat, color=line)) +
  geom_path(show.legend = FALSE) +
  theme_bw(); p1


p2 <- ggplot(w[nrow(w):1, ], aes(lng, lat, color=type)) +
  geom_point(aes(shape=type), size=3) +
  theme_bw(); p2


p3 <- ggplot(depot, aes(lng, lat, color=type)) +
  geom_point(shape=16, size=4) +
  geom_path(data = path, 
            aes(lng, lat, color=line)) +
  guides(color='none') +
  theme_bw(); p3


ggsave('../fig/terminals-only.pdf', plot=p2, width = 8, height = 5, units = 'in')
ggsave('../fig/terminals+lines.pdf', plot=p3, width = 8, height = 5, units = 'in')

ggsave('../fig/terminals.pdf', width = 8, height = 5, units = 'in')


