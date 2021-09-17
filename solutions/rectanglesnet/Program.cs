using System;
using System.Collections.Generic;

namespace rectanglesnet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> totalRectangles = new List<Rectangle>();
            Dictionary<int, List<Line>> pointSegments = new Dictionary<int, List<Line>>();
            Point[] points = new Point[] {
                new Point(1,1),
                new Point(2,1),
                new Point(1,3),
                new Point(4,1),
                new Point(4,5),
                new Point(2,5),
                new Point(4,6),
                new Point(1,6),
                new Point(3,3),
                new Point(2,3),
                new Point(3,1),
                new Point(2,6)
            };

            // Get all unique X Axis points
            List<int> unique_x = LinqUtils.GetUniqueXAxisFromCollection(points);
            foreach (int x in unique_x)
            {
                // Get all points per X Axis and create line unique segments. Work 
                // through each item and pair it ONLY if the Y value is higher than 
                // the current Y value
                List<Point> axis_filtered = LinqUtils.FilterCollectionByXAxis(points, x);
                foreach (Point lower in axis_filtered)
                {
                    foreach (Point higher in axis_filtered)
                    {
                        if (higher.Y > lower.Y)
                        {
                            if (pointSegments.ContainsKey(x) == false)
                            {
                                pointSegments.Add(x, new List<Line>());
                            }
                            pointSegments[x].Add(new Line(lower, higher));
                        }
                    }
                }
            }

            // Now pair up line segments, only look at X axis values HIGHER than 
            // the current. 
            foreach( int x_start in pointSegments.Keys)
            {
                foreach(Line left_segment in pointSegments[x_start])
                {
                    foreach(int x_end in pointSegments.Keys)
                    {
                        if( x_end <= x_start)
                        {
                            continue;
                        }

                        Line right_segment = LinqUtils.GetParallelLine(left_segment, pointSegments[x_end]);
                        if( right_segment != null)
                        {
                            totalRectangles.Add(new Rectangle(left_segment, right_segment));
                        }
                    }
                }
            }

            Console.WriteLine(String.Format("There are {0} rectangles", totalRectangles.Count));
            foreach(Rectangle rect in totalRectangles)
            {
                Console.WriteLine(rect);
            }
        }
    }
}
