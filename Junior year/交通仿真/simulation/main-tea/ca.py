from random import random

GAP_MAX = 1000
SPEED_MAX = 7
P = 0.1

class Car:
    def __init__(self, position, speed):
        self.position = position
        self.speed = speed

    def sense(self, lane, idx):
        if idx == len(lane.cars) - 1:
            self.gap = GAP_MAX
        else:
            front_car = lane.cars[idx+1]
            self.gap = front_car.position - self.position - 1

    def plan(self):
        if self.speed < SPEED_MAX:
            self.speed += 1

        self.speed = min(self.speed, self.gap)

        if self.speed > 0 and random() < P:
            self.speed -= 1

    def act(self):
        self.position += self.speed

class Lane:
    def __init__(self, length):
        self.length = length
        self.cars = []

    def add_car(self, car):
        self.cars.append(car)

    def sense(self):
        for idx, car in enumerate(self.cars):
            car.sense(self, idx)

    def plan(self):
        for car in self.cars:
            car.plan()

    def act(self):
        for car in self.cars:
            car.act()

        self.cars = [car for car in self.cars if car.position < self.length]

    def get_state(self):
        state = ["-"] * self.length
        for car in self.cars:
            state[car.position] = "o"

        return "".join(state)
    
class World:
    def __init__(self):
        self.time = 0.0
        self.lanes = []

    def add_lane(self, length):
        lane = Lane(length)
        self.lanes.append(lane)

    def step(self, dt=1.0):
        for lane in self.lanes:
            lane.sense()
        
        for lane in self.lanes:
            lane.plan()
        
        for lane in self.lanes:
            lane.act()

    def get_state(self):
        return [lane.get_state() for lane in self.lanes]


world = World()
world.add_lane(30)
car = Car(0, 2)
world.lanes[0].add_car(car)

for i in range(100):
    world.step()
    print(world.get_state()[0])


