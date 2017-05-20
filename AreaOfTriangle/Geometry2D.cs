using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Lib
{
    public interface ITask //bad name but whatever
    {
        double Area(double[] x, double[] y);
    }
    public struct Point2D 
    {
        public double X { get;}
        public double Y { get;}
        public Point2D(double x, double y) { X = x; Y = y; }
        public override string ToString() => $"{base.ToString()}. X={X}, Y={Y}";
        //public JObject ToJson() => new JObject() { ["x"]=X, ["y"] = Y };
        //public static Point2D FromJson(JObject json)
        //{
        //    //if (json != null &&
        //    //    json["x"]!=null &&
        //    //    json["x"].Type == JTokenType.Integer &&
        //    //    json["y"] != null &&
        //    //    json["y"].Type == JTokenType.Integer)
        //    //{
        //    //    return new Point2D((int)json["x"], (int)json["y"]);
        //    //}
        //    //throw new ArgumentNullException(nameof(json));
        //    //return null;
        //    if (json?["x"]?. Type == JTokenType.Integer &&
        //        json?["y"]?. Type == JTokenType.Integer)
        //    {
        //        return new Point2D((int)json["x"], (int)json["y"]);
        //    }
        //}
    }
    public class Geometry2D:ITask
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            double[] X = { 0, 0, 6 };
            double[] Y = { 0, 6, 0 };
            var geometry = new Geometry2D();

            try
            {
                var r = geometry.Area(X, Y);
                Console.WriteLine("r={0}", r);//як вивести дробну частину
                Console.WriteLine("r.type: " + r.GetType());
            }
            catch (Exception e) when(e.HelpLink=="3")
            {
                //await LogAsync( e.Message);
                //throw;
            }
            finally
            {
                //await CloseAsynk();
            }
            
           
            Console.ReadLine();
        }
        public double FindTiangleArea(Point2D[] points)
        {
            if (points==null)
            {
                throw new ArgumentNullException(nameof(points));
            }
            if (points.Length!=3)
            {
                throw new ArgumentException($"Argument must contain coordinates of 3 points. Received {points.Length} points");
            }
            double LengthA = FindLineLegth(points[0].X, points[1].X, points[0].Y, points[1].Y);
            double LengthB = FindLineLegth(points[1].X, points[2].X, points[1].Y, points[2].Y);
            double LengthC = FindLineLegth(points[2].X, points[0].X, points[2].Y, points[0].Y);
            double p = (LengthA + LengthB + LengthC) / 2d;
            double S = Math.Sqrt(p * (p - LengthA) * (p - LengthB) * (p - LengthC));
            return S;
        }
        private double FindLineLegth(double x1, double x2, double y1, double y2) =>
                Math.Sqrt(Math.Pow((x1 - x2), 2d) + Math.Pow((y1 - y2), 2d));    
        
        public double FindPolygonArea(Point2D[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }
            //todo цікава задача зробити перевірку чи багатокутник правильний (опуклий)
            switch (points.Length)
            {
                case 0://думаю такого не буває. Провірити
                    return 0;
                case 1:
                case 2:
                    return 0;// or throw new ArgumentException();
                case 3:
                    return FindTiangleArea(points);
                default:
                    double S=0;
                    int L = points.Length - 1;
                    for (int i = 2; i < L; i++)
                    {
                        S += FindTiangleArea(new Point2D[]{ points[0], points[i-1], points[i] });
                    }
                    S += FindTiangleArea(new Point2D[] { points[0], points[L-1], points[L] });
                    return S;
            }
        }
        public double Area(double[] x, double[] y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            if (x.Length != y.Length)
            {
                throw new ArgumentException($"Argument must contain equal number of coordinates. Received x.Length= {x.Length}, y.Length= {y.Length}");
            }
            Point2D[] points = new Point2D[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                points[i] = new Point2D(x[i], y[i]);
            }
            return FindPolygonArea(points);
        }
    }
}
