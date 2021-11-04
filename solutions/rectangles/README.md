# Rectangles solution - Python

Every developer knows there is more than one way to solve a problem. The solution here is straight forward. Can you come up with something better?

## Step 1
Get a collection of all x points from the points collection and organize them in lowest to highest order. 

This will be used when creating line segment collections.

Should create something like a dictionary where the key is the X value and the value is a list of points (X1,Y1), (X1, Y2), etc 

## Step 2
Create a collection of vertical lines at each x point. 

Ensure that the line segments to not repeat.

>    P1 = x1, y1 <br>
>    P2 = x2, y2 <br>
>    x1 == x2 <br>
>    y1 < y2 <br>

## Step 3

Create a collection of parallel lines which will form a rectangle. 

Ensure that each collection of lines are not a repeat.

>    line1.x < line2.x <br>
>    line1.y1 == line2.y1 <br>
>    line1.y2 == line2.y2 <br>

## Step 4
Get count of rectangle collection to answer the question.
