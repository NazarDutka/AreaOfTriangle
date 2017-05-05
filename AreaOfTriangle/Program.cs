﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing methods");
            double[] A = new double[] { 0, 0, 6 };
            double[] B = new double[] { 0, 6, 0 };
            Program p = new Program();
            double s = p.FindArea(A, B);
            Console.WriteLine($"S={s}");
            Console.ReadLine();
        }
        public double FindArea(double[] x, double[] y)
        {
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
    }
}