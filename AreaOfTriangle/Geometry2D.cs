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

    public class Geometry2D:ITask
    {
        static void Main(string[] args)
        {

            double[] A = new double[] { 0, 0, 6 };
            double[] B = new double[] { 0, 6, 0 };

        }
        public double FindTiangleArea(double[] x, double[] y)
        {
            if (x==null && y== null)
            {
                throw new ArgumentNullException();
            }
            if (x.Length!=3 || y.Length!=3)
            {
                throw new ArgumentException($"Argument must contain coordinates of 3 points. Received x.Length= {x.Length}, y.Length= {y.Length}");
            }
            double LengthA = FindLineLegth(x[0], x[1], y[0], y[1]);
            double LengthB = FindLineLegth(x[1], x[2], y[1], y[2]);
            double LengthC = FindLineLegth(x[2], x[0], y[2], y[0]);
            double p = (LengthA + LengthB + LengthC) / 2d;
            double S = Math.Sqrt(p * (p - LengthA) * (p - LengthB) * (p - LengthC));
            return S;
        }
        private double FindLineLegth(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2d) + Math.Pow((y1 - y2), 2d));           
        }
        public double FindPolygonArea(double[] x, double[] y)
        {
            if (x == null && y == null)
            {
                throw new ArgumentNullException();
            }

            //todo etc.

            switch (switch_on)
            {
                default:
            }

        }

        public double Area(double[] x, double[] y)
        {
            throw new NotImplementedException();
        }
    }
}
