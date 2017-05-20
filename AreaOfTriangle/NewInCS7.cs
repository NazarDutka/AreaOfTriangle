using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AreaOfTriangle
{
    class NewInCS7
    {
        int[] numbers = { 1, 2, 4, 8, 16, 3_2 };
        int[] binNumbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };
        private static int[] numers;

        public static int[] GetNumers()
        {
            return numers;
        }

        private static void SetNumers(int[] value)
        {
            numers = value;
        }

        //0b
        //_
        //Tuples: 
        //if you using NET Framework 4.6.x Install-Package "System.ValueTuple" or use NET Framework 4.7.

        static void Main(string[] args) {
            var t = Tally(GetNumers());
            //WriteLine($"Sum {t.Item1}, count: {t.Item2}");
            WriteLine($"Sum {t.sum}, count: {t.count}");

            var (sum, count) = Tally(GetNumers());
            WriteLine($"Sum {sum}, count: {count}");


            //(int, int) Tally(int[] values)
            (int sum, int count) Tally(int[] values)
            {
                //var r = (0, 0);
                var r = (s: 0, c: 0);
                foreach(var v in values)
                {
                    //r = (r.s + v, r.c + 1);
                    //r.s += v; r.c++;
                    Add(v,1);
                }
                return r;
                //Local functions
                void Add(int s, int c) { r.s += s; r.c += c; }
            }
            
            


        }
        //Patern maching
        public void PrintStatus(object o)
        {
            if (o is null) return;
            if (!(o is int i)) return;
            WriteLine(new string('*', i));
        }
        public void Do()
        {
            //Switch statements with patterns
            Shape shape = new Rectangle();
            switch (shape)
            {
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
        }
        static void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
    internal class Shape
    {
    }
    internal class Circle: Shape
    {
        public Circle()
        {
        }

        public object Radius { get; internal set; }
    }

    internal class Rectangle : Shape
    {
        public Rectangle()
        {
        }

        public object Length { get; internal set; }
        public object Height { get; internal set; }
    }
}
