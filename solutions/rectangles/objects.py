"""
A set of classes to help with organizing our graph data into 

- Individual points
    - X/Y coordinates
- Line segments
    - A set of 2 points
- Rectanges
    - A set of 2 lines
"""

class Point:
    """
    An individual point on a graph with X/Y coordinates
    """
    def __init__(self, x:int, y:int):
        self.X = x
        self.Y = y

    def __str__(self):
        return "({},{})".format(self.X, self.Y)

class Line:
    """
    A line segment from a graph with two points

    low = Point with lowest x/y coordinates
    high = Point with highest x/y coordinates
    """
    def __init__(self, low: Point, high: Point):
        self.low = low
        self.high = high

    def __str__(self):
        return "LINE {}- {}".format(self.low, self.high)

class Rectangle:
    """
    Consists of two parallel lines that construct a rectangle
    """
    def __init__(self, left: Line, right: Line):
        self.left = left
        self.right = right

    def __str__(self):
        return "RECT:  left({})- right({})".format(self.left, self.right)
