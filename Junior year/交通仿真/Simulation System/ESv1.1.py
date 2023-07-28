# Easy Simulation V1.1
# 本项目改进了一些东西，如car generation\lane changing,增加了qt可视化传参部分
# 有非常多可改进的地方，因为时间因素，今后有缘再做吧 By Liu


from PyQt5.QtWidgets import *

import time

import matplotlib
matplotlib.use('QtAgg')
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas

from Body.Simulation_World import *
from Body.uiv1 import *

class MainWindow(QMainWindow):

    def __init__(self):
        super().__init__()
        # 使用ui文件导入定义界面类
        self.ui = Ui_MainWindow()
        # 初始化界面
        self.ui.setupUi(self)
        self.stop = False
        self.convas = Plotroadfigure(world_create())
        self.ui.gridLayout.addWidget(self.convas, 0, 1)
        self.convas_2 = Plotflowfigure(world_create())
        self.ui.gridLayout_2.addWidget(self.convas_2, 0, 1)

        self.maxtime = float(self.ui.lineEdit.text())
        self.speed = float(self.ui.lineEdit_2.text())
        # 写代码写累了，abc就是那几个参数，不想命名了
        self.a = float(self.ui.lineEdit_3.text())
        self.b = float(self.ui.lineEdit_4.text())
        self.c = float(self.ui.lineEdit_5.text())

        # 设置执行点击判断
        self.ui.Start.clicked.connect(self.start_plot)
        self.ui.Pause.clicked.connect(self.Pause_plot)
        self.ui.Clear.clicked.connect(self.reset)
        self.ui.Get.clicked.connect(self.flow_plot)
        self.ui.Output.clicked.connect(self.flow_Output)




    def start_plot(self):
        self.stop = False
        self.maxtime = float(self.ui.lineEdit.text())
        self.speed = float(self.ui.lineEdit_2.text())

        self.a = float(self.ui.lineEdit_3.text())
        self.b = float(self.ui.lineEdit_4.text())
        self.c = float(self.ui.lineEdit_5.text())
        while self.convas.world.time <= self.maxtime: #当小于仿真时间时
            self.ui.progressBar.setProperty("value", self.convas.world.time / self.maxtime * 100)
            if self.stop == True:
                break
            print(self.convas.world.get_state()[0])  # 输出第一条道路的状态
            self.convas.get_fig(self.convas.world)
            time.sleep(0.5/self.speed)
            self.convas.world.step(self.b,self.c)  # 模拟时间的推进
            # self.ui.gridLayout.addWidget(self.convas, 0, 1)

    def Pause_plot(self):
        self.stop = True

    def reset(self):
        # 初始化图层

        self.stop = False
        self.convas = Plotroadfigure(world_create())
        self.ui.gridLayout.addWidget(self.convas, 0, 1)
        self.convas_2 = Plotflowfigure(world_create())
        self.ui.gridLayout_2.addWidget(self.convas_2, 0, 1)

        # 重置状态
        self.ui.lineEdit.setText("10")
        self.ui.lineEdit_2.setText("2")
        self.ui.lineEdit_3.setText("5")
        self.ui.lineEdit_4.setText("2")
        self.ui.lineEdit_5.setText("2")

        self.ui.progressBar.setProperty("value",0)

    def flow_plot(self):

        self.maxtime = float(self.ui.lineEdit.text())
        self.a = float(self.ui.lineEdit_3.text())
        self.b = float(self.ui.lineEdit_4.text())
        self.c = float(self.ui.lineEdit_5.text())
        self.convas_2.get_fig(self.maxtime,self.b,self.c)

    # 此处可继续优化，利用os检测文件夹来进行更好的管理，同时可添加弹窗以表示成功
    def flow_Output(self):
        self.convas_2.figs.savefig('output\\1.png')



class Plotflowfigure(FigureCanvas):
    def __init__(self,World):
        self.world = World  # 存储原始世界
        self.figs, self.axes = plt.subplots(figsize=(10, 10))
        self.axes.set_xlabel('T')
        self.axes.set_ylabel('X')
        self.axes.set_title('Double Lanes Spatio-Temporal Graph')
        self.axes.grid(True)

        super(Plotflowfigure, self).__init__(self.figs)  # 在父类种激活self.fig，

    def get_fig(self,maxtime,b,c):
        # 绘制道路状态
        road_states = []  # 存储道路状态的列表
        world = self.world
        for i in range(int(maxtime)):
            road_state = world.get_state()[0]  # 获取道路状态
            road_states.append(road_state)  # 将道路状态添加到列表中
            world.step(b,c)

        outlook_str = '\n'.join(road_states)  # 将保存的道路状态列表合并为一个字符串

        lines = outlook_str.splitlines()

        positions_dict = {}

        for i, line in enumerate(lines):
            if line.strip():  # 检查是否为空行
                positions = [idx for idx, char in enumerate(line) if char != ' ']
                if positions:  # 检查是否存在非空格元素
                    positions_dict[i] = positions

        # 提取坐标
        coordinates = []
        for y, x_list in positions_dict.items():
            for x in x_list:
                coordinates.append((x, y))

        x_values = [coord[1] for coord in coordinates]
        y_values = [coord[0] for coord in coordinates]
        plt.scatter(x_values, y_values, c='red', marker='.', s=5)
        self.axes.set_xlabel('T')
        self.axes.set_ylabel('X')
        self.axes.set_title('Double Lanes Spatio-Temporal Graph')
        self.axes.grid(True)

        # self.conva = FigureCanvas(self.figs)
        self.figs.canvas.draw()  # 这里注意是画布重绘，self.figs.canvas
        self.figs.canvas.flush_events()

class Plotroadfigure(FigureCanvas):
    def __init__(self,World):

        self.world = World  #存储原始世界
        self.figs,self.axes = plt.subplots(figsize=(100, 10))
        for idx, road in enumerate(World.roads):
            self.axes.set_title(f"Road {idx+1}")
            self.axes.set_ylim(-1, len(road.lanes)) #y轴为车道数
            self.axes.set_xlim(-2, road.length+2) #x轴为道路长
            # plt.gca().invert_yaxis() #y轴反转
            # self.axes.set_xticks([])
            self.axes.set_yticks(range(len(road.lanes)))#隐藏坐标轴刻度
            self.axes.grid(True, color='gray') #灰色的网格
            for lane_idx, lane in enumerate(road.lanes):
                state = lane.get_state() #获取车道状态
                for car_idx, car_state in enumerate(state):
                    if car_state == "o":
                        self.axes.scatter(car_idx, lane_idx, color='red', marker='o', s=100)
        super(Plotroadfigure, self).__init__(self.figs)  # 在父类种激活self.fig，

    def get_fig(self,World):
        # 绘制道路状态
        self.figs.clf()  # 清理画布，这里是clf()
        self.axes = self.figs.add_subplot(111)
        for idx, road in enumerate(World.roads):
            self.axes.set_title(f"Road {idx+1}")
            self.axes.set_ylim(-1, len(road.lanes)) #y轴为车道数
            self.axes.set_xlim(-1, road.length+2) #x轴为道路长
            # plt.gca().invert_yaxis() #y轴反转
            # self.axes.set_xticks([])
            self.axes.set_yticks(range(len(road.lanes)))#隐藏坐标轴刻度
            self.axes.grid(True, color='gray') #灰色的网格
            for lane_idx, lane in enumerate(road.lanes):
                state = lane.get_state() #获取车道状态
                for car_idx, car_state in enumerate(state):
                    if car_state == "o":
                        self.axes.scatter(car_idx, lane_idx, color='red', marker='o', s=100)
        # self.conva = FigureCanvas(self.figs)
        self.figs.canvas.draw()  # 画布重绘
        self.figs.canvas.flush_events()


def world_create():
    world = World()
    world.add_road(100, 2)  # 添加一条长度为40的道路和2个车道

    # world.roads[0].add_car(Car(0, 3), 0)  # 在第一个车道上添加一辆速度为3的车辆
    # world.roads[0].add_car(Car(6, 5, -1), 1)  # 在第二个车道上添加一辆速度为5、换道目标为左边的车辆
    # world.roads[0].add_car(Car(15, 0), 0)  # 在第一个车道上添加一辆速度为0的车辆
    # world.Car_generation()
    return world

if __name__=="__main__":
    app = QApplication([])

    mainw = MainWindow()
    mainw.show()
    app.exec_()
