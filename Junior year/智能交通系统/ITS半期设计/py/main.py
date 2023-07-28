from simulate import *

import sys
from PyQt5.QtCore import *
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *


def create_window():

    return


if __name__ == "__main__":
    # create_window()
    time = 551
    s1 = simulatation(time)
    beta = 0.1
    is_event = 0
    is_feedback = 0

    is_feedback_0 = []
    is_feedback_1 = []

    for beta in range(0,0.05,1.01):
        s1.start(beta, 0, is_feedback)
        s1.evaluation()
        is_feedback_0.append(s1.avg_delay)

        s1.start(beta, 1, is_feedback)
        s1.evaluation()
        is_feedback_1.append(s1.avg_delay)
    print()
    # s1.export_table()
    # s1.plot()
