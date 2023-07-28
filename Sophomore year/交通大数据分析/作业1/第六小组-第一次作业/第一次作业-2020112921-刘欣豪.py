#SVM线性拟合软边界的sklearn实现
#刘欣豪 2022-4-15

from sklearn import svm
import matplotlib.pyplot as plt
import numpy as np

#读取输入数据集
X=np.array([[-1,-1],[-1,1],[2,2],[1,-1]])
Y=np.array([-1,1,-1,1])

#画出散点
for i in range(0,4):
    if(Y[i]==1):
        plt.scatter(X[i,0], X[i,1],c='r')
    else:
        plt.scatter(X[i,0], X[i,1],c='b')

#线性核函数分类
clf = svm.SVC(C=0.1,kernel='linear')
clf.fit(X, Y)

#求得并画出超平面
w = clf.coef_[0]
a = -w[0]/w[1]
xx = np.linspace(-2.5, 2.5)
yy = a * xx - (clf.intercept_[0]) / w[1]
b = clf.support_vectors_[1]
yy_down = a * xx + (b[1] - a * b[0])
b = clf.support_vectors_[-1]
yy_up = a * xx + (b[1] - a * b[0])
plt.plot(xx, yy, 'k-')
plt.plot(xx, yy_down, 'k--')
plt.plot(xx, yy_up, 'k--')

#调节坐标轴
ax = plt.gca()
ax.xaxis.set_ticks_position('bottom')
ax.spines['bottom'].set_position(('data',0))
ax.yaxis.set_ticks_position('left')
ax.spines['left'].set_position(('data',0))
#隐藏上右两边的坐标轴
ax.spines['top'].set_color('none')
ax.spines['right'].set_color('none')
#限制输出边界
plt.xlim(-2.5,2.5)
plt.ylim(-2.5,2.5)
plt.grid()#画出网格
plt.gca().set_aspect(1)#统一坐标轴尺度

plt.show()