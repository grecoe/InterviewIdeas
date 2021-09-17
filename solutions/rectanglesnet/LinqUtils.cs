using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace rectanglesnet
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", this.X, this.Y);
        }
    }

    class Line
    {
        public Point Low { get; set; }
        public Point High { get; set; }

        public Line(Point low, Point high)
        {
            this.Low = low;
            this.High = high;
        }
        public override string ToString()
        {
            return String.Format("Line: {0} - {1}", this.Low, this.High);
        }
    }

    class Rectangle
    {
        public Line Left { get; set; }
        public Line Right { get; set; }

        public Rectangle(Line left, Line right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override string ToString()
        {
            return String.Format("RECT: {0} : {1}", this.Left, this.Right);
        }
    }

    class LinqUtils
    {
        public static Line GetParallelLine(Line leftSeg, List<Line> collection)
        {
            IEnumerable<Line> rightSeg =
                from x in collection
                where leftSeg.Low.Y == x.Low.Y && leftSeg.High.Y == x.High.Y
                select x;

            return rightSeg.FirstOrDefault();
        }


        public static List<int> GetUniqueXAxisFromCollection(IEnumerable<Point> points)
        {
            IEnumerable<int> results =
                from x in points
                where x != null
                orderby x.X ascending
                select x.X;

            HashSet<int> set = new HashSet<int>();
            set.UnionWith(results);

            return set.ToList();
        }

        public static List<Point> FilterCollectionByXAxis(IEnumerable<Point> points, int axis)
        {
            IEnumerable<Point> results =
                from x in points
                where x.X == axis
                orderby x.Y ascending
                select x;

            HashSet<Point> set = new HashSet<Point>();
            set.UnionWith(results);

            return set.ToList();
        }
    }
}
