import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

plt.rcParams['font.sans-serif'] = ['Microsoft YaHei']

#以下交通量单位为pcu/h
CODE = 278
basic_flow = CODE/200 * 1800
demand_p1 = CODE/175*1800
demand_p2 = CODE/130*1800
capacity_p1 = CODE/100*2200
capacity_p2 = CODE/100*2200

L_p1 = 30 #路径1长度，单位为km
L_p2 = 27 #路径2长度，单位为km
len_car = 5 #车辆长度，单位为m
Tfree_p1 = 18 #路径1自由流时间，单位为min
Tfree_p2 = 16 #路径2自由流时间，单位为min

class simulatation(object):
    def __init__(self, time):
        self.time = time  # 仿真时间
        # 以下交通量单位为pcu/h
        self.basic_flow = basic_flow
        self.demand_p1 = demand_p1
        self.demand_p2 = demand_p2
        self.capacity_p1 = capacity_p1
        self.capacity_p2 = capacity_p2

        self.L_p1 = L_p1  # 路径1长度，单位为km
        self.L_p2 = L_p2  # 路径2长度，单位为km
        self.len_car = len_car  # 车辆长度，单位为m
        self.Tfree_p1 = Tfree_p1  # 路径1自由流时间，单位为min
        self.Tfree_p2 = Tfree_p2  # 路径2自由流时间，单位为min

        self.length = self.time + max(self.Tfree_p1, self.Tfree_p2) + 1

        self.table = -1

        self.beta = 0  # 敏感度
        self.is_feedback = 0  # 默认不是反馈控制
        self.is_event = 0  # 默认不发生事件
        self.pre_time = 20  # 默认事件持续时间为20min

        # 结果参数
        self.delay = -1  # 延误
        self.avg_delay = -1  # 平均延误
        self.queue_length = -1  # 总排队长度
        self.avg_performance = -1  # 平均性能
        self.delay_variability_p1 = -1  # 路径一延误可变性
        self.delay_variability_p2 = -1  # 路径二延误可变性
        return

    # 生成初始条件
    def generate_traffic_demand(self):
        table = pd.DataFrame([[i for i in range(self.length)]] + [[0] * (self.length)] * 16,
                             index=['Time (min)', 'i(t)', 'p1(t)', 'p2(t)',
                                    'i1(t)', 'i2(t)', 'C1(t)', 'C2(t)', 'r1(t)', 'r2(t)',
                                    'L1(t)', 'L2(t)', 'D1(t)', 'D2(t)', 'sp(t)', 'Dtot', 'Ptot'])
        self.table = table.T
        s = []
        for i in range(self.length):
            if i < 60:
                j = (self.basic_flow)
            elif i < 100:
                j = (self.capacity_p1)
            elif i < 200:
                j = (0.8 * self.capacity_p1)
            elif i < 300:
                j = (self.basic_flow + (0.7 * self.capacity_p1 - self.basic_flow)
                     * (0.05 * self.capacity_p1 - i) / 100)
            else:
                j = (0.1 * self.basic_flow)
            s.append(j)
        self.table['i(t)'] = s
        self.table['p1(t)'] = self.demand_p1
        self.table['p2(t)'] = self.demand_p2
        self.table['C1(t)'] = self.capacity_p1
        self.table['C2(t)'] = self.capacity_p2
        return

    # 开始仿真
    def start(self, beta=0, is_event=0, is_feedback=1):
        self.beta = beta
        self.is_event = is_event
        self.is_ = is_feedback

        self.generate_traffic_demand()

        if is_event:
            if self.time > 170:
                self.table.loc[150:169, 'C2(t)'] = 0.1 * self.table.loc[150:169, 'C2(t)']
            else:
                self.is_event = 0
                print('conflict between time and is_event')
                return -1

        table = self.table
        for i in range(self.Tfree_p1):
            table.loc[i, 'r1(t)'] = 0
            table.loc[i, 'L1(t)'] = 0.005 * table.loc[i, 'r1(t)']
            table.loc[i, 'D1(t)'] = 60 * table.loc[i, 'r1(t)'] / table.loc[i, 'C1(t)']
        for i in range(self.Tfree_p2):
            table.loc[i, 'r2(t)'] = 0
            table.loc[i, 'L2(t)'] = 0.005 * table.loc[i, 'r2(t)']
            table.loc[i, 'D2(t)'] = 60 * table.loc[i, 'r2(t)'] / table.loc[i, 'C2(t)']

        for i in range(self.time + 1):
            if is_feedback:
                table.loc[i, 'sp(t)'] = min(1,
                                            max(0, 0.58 - self.beta * (table.loc[i, 'D1(t)'] - table.loc[i, 'D2(t)'])))

            else:
                if i >= 150 and i <= 169 and self.is_event:
                    table.loc[i, 'sp(t)'] = min(1, max(0, 0.58 - self.beta * (
                                table.loc[i + self.Tfree_p1, 'D1(t)'] - table.loc[
                            i + self.Tfree_p2, 'D2(t)'] - self.pre_time)))
                else:
                    table.loc[i, 'sp(t)'] = min(1, max(0, 0.58 - self.beta * (
                                table.loc[i + self.Tfree_p1, 'D1(t)'] - table.loc[i + self.Tfree_p2, 'D2(t)'])))

            table.loc[i, 'i1(t)'] = table.loc[i, 'i(t)'] * table.loc[i, 'sp(t)']
            table.loc[i, 'i2(t)'] = table.loc[i, 'i(t)'] - table.loc[i, 'i1(t)']

            table.loc[i + self.Tfree_p1 + 1, 'r1(t)'] = max(0, table.loc[i + self.Tfree_p1, 'r1(t)'] + (
                        table.loc[i, 'i1(t)'] + table.loc[i + self.Tfree_p1, 'p1(t)'] - table.loc[
                    i + self.Tfree_p1, 'C1(t)']) / 60)
            table.loc[i + self.Tfree_p2 + 1, 'r2(t)'] = max(0, table.loc[i + self.Tfree_p2, 'r2(t)'] + (
                        table.loc[i, 'i2(t)'] + table.loc[i + self.Tfree_p2, 'p2(t)'] - table.loc[
                    i + self.Tfree_p2, 'C2(t)']) / 60)

            table.loc[i + self.Tfree_p1 + 1, 'L1(t)'] = 0.005 * table.loc[i + self.Tfree_p1 + 1, 'r1(t)']
            table.loc[i + self.Tfree_p2 + 1, 'L2(t)'] = 0.005 * table.loc[i + self.Tfree_p2 + 1, 'r2(t)']

            table.loc[i + self.Tfree_p1 + 1, 'D1(t)'] = 60 * table.loc[i + self.Tfree_p1 + 1, 'r1(t)'] / table.loc[
                i + self.Tfree_p1 + 1, 'C1(t)']
            table.loc[i + self.Tfree_p2 + 1, 'D2(t)'] = 60 * table.loc[i + self.Tfree_p2 + 1, 'r2(t)'] / table.loc[
                i + self.Tfree_p2 + 1, 'C2(t)']

            table.loc[i, 'Dtot'] = table.loc[i + self.Tfree_p1, 'D1(t)'] * table.loc[i, 'i1(t)'] + table.loc[
                i + self.Tfree_p2, 'D2(t)'] * table.loc[i, 'i2(t)']
            table.loc[i, 'Ptot'] = self.L_p1 * table.loc[i, 'i1(t)'] + self.L_p2 * table.loc[i, 'i2(t)']

        self.table = table.loc[:self.time, :]
        #             self.table = table
        return

        # 进行评估

    def evaluation(self):
        self.delay = sum(self.table['D1(t)']) + sum(self.table['D2(t)'])  # 延误
        self.avg_delay = sum(self.table['Dtot']) / sum(self.table['i(t)'])  # 平均延误
        self.queue_length = (sum(self.table['r1(t)']) + sum(self.table['r2(t)'])) / (self.time + 1)  # 总排队长度
        self.avg_performance = sum(self.table['Ptot']) / sum(self.table['i(t)'])  # 平均性能
        self.delay_variability_p1 = self.table['D1(t)'].std(ddof=1)  # 路径一延误可变性
        self.delay_variability_p2 = self.table['D2(t)'].std(ddof=1)  # 路径二延误可变性
        return

    # 打印评估结果
    def print_eva(self):
        print('totle time:', self.time)
        print('delay:', self.delay)
        print('avg_delay:', self.avg_delay)
        print('queue_length:', self.queue_length)
        print('avg_performance:', self.avg_performance)
        print('Delay variability (Path 1)', self.delay_variability_p1)
        print('Delay variability (Path 2)', self.delay_variability_p2)

    # 导出表
    def export_table(self):
        self.table.to_excel('test1.xlsx', index=False)
        return

    def plot_r(self):
        plt.plot(self.table['Time (min)'], self.table['r1(t)'], label='r1(t)')
        plt.plot(self.table['Time (min)'], self.table['r2(t)'], label='r2(t)')
        plt.xlabel('时间(min)')
        plt.ylabel('排队长度')

        plt.legend()
        plt.show()
        return

    def plot_D(self):
        plt.plot(self.table['Time (min)'], self.table['D1(t)'], label='D1(t)')
        plt.plot(self.table['Time (min)'], self.table['D2(t)'], label='D2(t)')
        plt.xlabel('时间(min)')
        plt.ylabel('延误(min)')

        plt.legend()
        plt.show()
        return

    def plot_i(self):
        plt.plot(self.table['Time (min)'], self.table['i1(t)'], label='i1(t)')
        plt.plot(self.table['Time (min)'], self.table['i2(t)'], label='i2(t)')
        plt.plot(self.table['Time (min)'], self.table['i(t)'], label='i(t)')
        plt.xlabel('时间(min)')
        plt.ylabel('交通需求量(veh/h)')

        plt.legend()
        plt.show()
        return

    def plot_sp(self):
        plt.plot(self.table['Time (min)'], self.table['sp(t)'], label='sp(t)')
        plt.xlabel('时间(min)')
        plt.ylabel('历经1的选择率')
        plt.ylim(-0.05, 1.05)

        plt.legend()
        plt.show()
        return

    def plot(self):
        self.plot_r()
        self.plot_D()
        self.plot_i()
        self.plot_sp()

    def export_plot(self):
        return