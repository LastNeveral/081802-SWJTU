clc,clear;

dum=[21];

den=[1 2 21];

sys=tf(dum, den);

[y, t, x]=step(sys);
mp=max(y);

%峰值时间
tp=spline(y, t, mp)

cs=length(t);
%稳态值
yss=y(cs)

%超调量
ct=(mp - yss)/yss

step(sys)