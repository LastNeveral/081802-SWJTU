import matplotlib.pyplot as plt

import numpy as np
import math
from scipy import stats
from random import random

GAP_MAX = 1000  # 最大车辆间距
SPEED_MAX = 7  # 最大车速
P = 0.1  # 减速概率
SAFE_GAP_FRONT = 1  # 前方安全间距
SAFE_GAP_BACK = 2  # 后方安全间距


class Car:
    def __init__(self, position, speed, lc_target=0):
        self.position = position  # 车辆当前位置
        self.speed = speed  # 车辆当前速度
        self.lc_target = lc_target  # 车辆换道目标
        self.lc_safe = False  # 换道是否安全

    def cf_sense(self, lane, idx):
        if idx == len(lane.cars) - 1:
            self.gap = GAP_MAX  # 如果是最后一辆车，设置间距为最大值
        else:
            front_car = lane.cars[idx + 1]
            self.gap = front_car.position - self.position - 1  # 计算与前车之间的间距

    def cf_plan(self):
        if self.speed < SPEED_MAX:
            self.speed += 1  # 加速

        self.speed = min(self.speed, self.gap)  # 限制速度不能超过与前车的间距

        if self.speed > 0 and random() < P:
            self.speed -= 1  # 以概率P减速

    def cf_act(self):
        self.position += self.speed  # 更新车辆位置

    def lc_sense(self, target_lane):
        for car in target_lane.cars:
            if car.position == self.position:
                self.front_gap = -1
                self.back_gap = -1
                return

        front_gaps = [car.position - self.position - 1 for car in target_lane.cars]
        self.front_gap = min([gap for gap in front_gaps if gap >= 0], default=GAP_MAX)  # 计算换道后前方的间距
        back_gaps = [self.position - car.position - 1 for car in target_lane.cars]
        self.back_gap = min([gap for gap in back_gaps if gap >= 0], default=GAP_MAX)  # 计算换道后后方的间距

    def lc_plan(self):  # 换道模型改进————TRANSIMS+协同换道##########################################################
        if self.gap < self.speed and self.front_gap > self.gap:
            weight1 = 1  # 权重1：当前前方gap较小，另一车道前方gap大于当前gap
        else:
            weight1 = 0
        weight2 = self.speed-self.front_gap  # 权重2：目标车道前方安全性
        weight3 = SPEED_MAX-1-self.back_gap  #权重3：考虑后车减速的目标车道后方安全性
        if weight1 > weight2 and weight1 > weight3:
            self.lc_safe = True
        else:
            self.lc_safe = False

    def lc_act(self):
        pass  # 暂时没有实现换道的动作


class Lane:
    def __init__(self, length):
        self.length = length  # 车道长度
        self.cars = []  # 车道上的车辆列表

    def add_car(self, car):
        self.cars.append(car)  # 添加车辆到车道
        self.cars.sort(key=lambda car: car.position)  # 根据车辆位置排序

    def cf_sense(self):
        for idx, car in enumerate(self.cars):
            car.cf_sense(self, idx)  # 调用车辆的感知函数

    def cf_plan(self):
        for car in self.cars:
            car.cf_plan()  # 调用车辆的规划函数

    def cf_act(self):
        for car in self.cars:
            car.cf_act()  # 调用车辆的执行动作函数

        self.cars = [car for car in self.cars if car.position < self.length]  # 移除超出车道长度的车辆

    def get_state(self):
        state = [" "] * self.length
        for car in self.cars:
            state[car.position] = "o"  # 在车道上对应位置放置车辆表示

        return "".join(state)  # 返回车道的状态字符串

class Road:
    def __init__(self, length, num_lane):
        self.length = length  # 道路长度
        self.lanes = [Lane(self.length) for i in range(num_lane)]  # 创建指定数量的车道

    def add_car(self, car, idx_lane):
        self.lanes[idx_lane].add_car(car)  # 添加车辆到指定的车道

    def get_state(self):
        # sideline = "-" * self.length
        state = ""
        # state += sideline
        # state += "\n"
        for lane in self.lanes:
            state += lane.get_state()  # 获取车道的状态字符串
            state += "\n"
        # state += sideline
        # state += "\n"

        return state

    def cf_sense(self):
        for lane in self.lanes:
            lane.cf_sense()  # 调用车道的感知函数

    def cf_plan(self):
        for lane in self.lanes:
            lane.cf_plan()  # 调用车道的规划函数

    def cf_act(self):
        for lane in self.lanes:
            lane.cf_act()  # 调用车道的执行动作函数

    def lc_sense(self):
        for lane_idx, lane in enumerate(self.lanes):
            for car in lane.cars:
                target_idx = lane_idx + car.lc_target
                target_lane = self.lanes[target_idx]
                car.lc_sense(target_lane)  # 调用车辆的换道感知函数

    def lc_plan(self):
        for lane in self.lanes:
            for car in lane.cars:
                car.lc_plan()  # 调用车辆的换道规划函数

    def lc_act(self):
        for lane_idx, lane in enumerate(self.lanes):
            for car in lane.cars:
                if car.lc_target != 0 and car.lc_safe:
                    target_idx = lane_idx + car.lc_target
                    target_lane = self.lanes[target_idx]
                    lane.cars.remove(car)  # 从当前车道移除车辆
                    target_lane.add_car(car)  # 添加车辆到目标车道


class World:
    def __init__(self):
        self.time = 0.0
        self.roads = []  # 道路列表

    def add_road(self, length, num_lane):
        road = Road(length, num_lane)  # 创建新的道路
        self.roads.append(road)  # 添加道路到世界

    def step(self,m,s,dt=1.0):
        self.time = self.time + dt
        self.Car_generation(m,s)
        for road in self.roads:
            road.cf_sense()  # 感知阶段

        for road in self.roads:
            road.cf_plan()  # 规划阶段

        for road in self.roads:
            road.cf_act()  # 执行动作阶段

        for road in self.roads:
            road.lc_sense()  # 换道感知阶段

        for road in self.roads:
            road.lc_plan()  # 换道规划阶段

        for road in self.roads:
            road.lc_act()  # 换道执行动作阶段

    def Car_generation(self,mean=2,std=2,p=0.6):
        pp = np.random.uniform(0, 1)
        if pp < 0.6:
            lin = np.random.choice([0, 1])
            prob = np.random.uniform(0, 1)
            speed = int(stats.norm.ppf(prob, loc=mean, scale=std))
            self.roads[0].add_car(Car(0, speed), lin)


    def get_state(self):
        return [road.get_state() for road in self.roads]  # 返回所有道路的状态

def get_fig(world):

    # 绘制道路状态
    for idx, road in enumerate(world.roads):
        fig,ax = plt.subplots()
        ax.set_title(f"Road {idx+1}")
        ax.set_ylim(-1, len(road.lanes)) #y轴为车道数
        ax.set_xlim(-2, road.length+2) #x轴为道路长
        # plt.gca().invert_yaxis() #y轴反转
        ax.set_xticks([])
        ax.set_yticks(range(len(road.lanes)))#隐藏坐标轴刻度
        ax.grid(True, color='gray') #灰色的网格
        for lane_idx, lane in enumerate(road.lanes):
            state = lane.get_state() #获取车道状态
            for car_idx, car_state in enumerate(state):
                if car_state == "o":
                    ax.scatter(car_idx, lane_idx, color='red', marker='o', s=100)
    return fig
    plt.pause(0.25)

# def world_create():
#     world = World()
#     world.add_road(50, 2)  # 添加一条长度为40的道路和2个车道
#
#     world.roads[0].add_car(Car(0, 3), 0)  # 在第一个车道上添加一辆速度为3的车辆
#     world.roads[0].add_car(Car(6, 5, -1), 1)  # 在第二个车道上添加一辆速度为5、换道目标为左边的车辆
#     world.roads[0].add_car(Car(15, 0), 0)  # 在第一个车道上添加一辆速度为0的车辆
#     for i in range(15):
#         print(world.get_state()[0])  # 输出第一条道路的状态
#         img_show(world)
#         world.step()  # 模拟时间的推进
#
# if __name__ == "__main__":
#     world_create()
#     # anim = FuncAnimation(fig, update, frames=range(10), interval=250)
