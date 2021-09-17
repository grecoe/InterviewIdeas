"""
Given a random number of points from a graph, determine how many 
unique rectanges exist.
"""
import json
import typing
from objects import Point, Line, Rectangle

# Stats
running_stats = {
    "total_points" : 0,
    "total_line_segments" : 0,
    "x_axis_range" : ""
}

# All points in graph - example
graph:typing.List[Point] = [
    Point(1,1), Point(2,1), Point(1,3), 
    Point(4,1), Point(4,5), Point(2,5), 
    Point(4,6), Point(1,6), Point(3,3),
    Point(2,3), Point(3,1), Point(2,6)
]

# All points in graph - ladder
"""
graph:typing.List[Point] = [
    Point(1,1), Point(2,1), 
    Point(1,2), Point(2,2), 
    Point(1,3), Point(2,3), 
    Point(1,4), Point(2,4), 
    Point(1,5), Point(2,5), 
    Point(1,6), Point(2,6), 
]
"""

running_stats["total_points"] = len(graph)

# All line segments key=x val=Line
line_collection:typing.Dict[int,Line] = {}
# Found collection of rectangles
rect_collection:typing.List[Rectangle] = []

# Get the range of x and sort from low to high 
x_range = [p.X for p in graph]
x_range = sorted(list(set(x_range)))
running_stats["x_axis_range"] = "{} - {}".format(x_range[0], x_range[-1])

# Now get individual line segments per x point
# all segments for points at that x 
for x in x_range:
    line_collection[x] = []

    # All points at specified X
    x_points = [p for p in graph if p.X == x]
    # Get segments
    for point1 in x_points:
        for point2 in x_points:
            if point2.Y > point1.Y:
                running_stats["total_line_segments"] += 1
                line_collection[x].append(Line(point1, point2))

# With the line segment collection from each X point
# find rectagles.
for x1 in line_collection:
    for leftseg in line_collection[x1]:
        for x2 in line_collection:
            # Only lines at higher x points to ensure uniqueness
            if x2 <= x1:
                continue

            # Match on equal Y1 and Y2 points, produces 0|1 matches
            rightseg = [seg for seg in line_collection[x2] if leftseg.low.Y == seg.low.Y and leftseg.high.Y == seg.high.Y]
            if len(rightseg):
                rect_collection.append(Rectangle(leftseg, rightseg[0]))


# Dump out the results for the points given
print("General Stats")
print(json.dumps(running_stats, indent=4))
print("Total rectangles = ", len(rect_collection))
square_count = 0
for r in rect_collection:
    print(r)
