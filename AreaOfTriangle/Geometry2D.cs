using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    interface ITask //bad name but whatever
    {
        double Area(double[] x, double[] y);
    }
    public struct Point2D 
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public class Geometry2D:ITask
    {
        static void Main(string[] args)
        {

            double[] A = new double[] { 0, 0, 6 };
            double[] B = new double[] { 0, 6, 0 };

        }
        public double FindTiangleArea(Point2D[] A)
        {
            if (A==null)
            {
                throw new ArgumentNullException();
            }
            if (A.Length!=3)
            {
                throw new ArgumentException($"Argument must contain coordinates of 3 points. Received {A.Length} points");
            }
            double LengthA = FindLineLegth(A[0].X, A[1].X, A[0].Y, A[1].Y);
            double LengthB = FindLineLegth(A[1].X, A[2].X, A[1].Y, A[2].Y);
            double LengthC = FindLineLegth(A[2].X, A[0].X, A[2].Y, A[0].Y);
            double p = (LengthA + LengthB + LengthC) / 2d;
            double S = Math.Sqrt(p * (p - LengthA) * (p - LengthB) * (p - LengthC));
            return S;
        }
        private double FindLineLegth(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2d) + Math.Pow((y1 - y2), 2d));           
        }
        public double FindPolygonArea(Point2D[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            //todo цікава задача зробити перевірку чи багатокутник правильний (опуклий)
            switch (points.Length)
            {
                case 0://думаю такого не буває. Провірити
                    return 0;
                case 1:
                case 2:
                    return 0;// or throw new ArgumentNullException();
                case 3:
                    return FindTiangleArea(points);
                default:
                    double S=0;
                    for (int i = 2; i < points.Length-1; i++)
                    {
                        S += FindTiangleArea(new Point2D[]{ points[0], points[i-1], points[i] });
                    }
                    S += FindTiangleArea(new Point2D[] { points[0], points[points.Length - 1], points[points.Length] });
                    return S;

            }

        }

        public double Area(double[] x, double[] y)
        {
            if (x == null && y == null)
            {
                throw new ArgumentNullException();
            }
            if (x.Length != y.Length)
            {
                throw new ArgumentException($"Argument must contain equal number of coordinates. Received x.Length= {x.Length}, y.Length= {y.Length}");
            }
            Point2D[] points = new Point2D[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                points[i].X = x[i];
                points[i].Y = y[i];
            }
            return FindPolygonArea(points);
        }
    }
}
