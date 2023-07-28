import matplotlib.pyplot as plt

GRAVITY = -9.8
RADIUS = 0.1

class Ball:
    def __init__(self, height, speed=0.0):
        self.height = height
        self.speed = speed

    def step(self, dt):
        self.speed += GRAVITY * dt
        self.height += self.speed * dt

        if self.height <= RADIUS:
            self.speed *= -0.9
            self.height = RADIUS
        print(self.height)

class World:
    def __init__(self, num_ball=1):
        self.time = 0.0
        self.balls = []

        for i in range(num_ball):
            ball = Ball(3)
            self.balls.append(ball)

    def step(self, dt=0.1):
        self.time += dt

        for ball in self.balls:
            ball.step(dt)

    def get_state(self):
        state = (self.time,)
        state += tuple([ball.height for ball in self.balls])
        return state


states = []
world = World(1)
for i in range(100):
    world.step()
    states.append(world.get_state())

Ts, Hs = zip(*states)
plt.plot(Ts, Hs)
plt.show()