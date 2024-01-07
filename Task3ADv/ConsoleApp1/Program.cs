using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {

         static void Main(string[] args)
            {
                //Design p1 = new Design(5);
                //Design p2 = new Design(10, 15);
                //Design p3 = new Design(20, 25, 30);

                //Console.WriteLine(p1);
                //Console.WriteLine(p2);
                //Console.WriteLine(p3);

                //Design P = new Design(10, 10, 10);
                //Console.WriteLine(P);

                //string pointString = P.ToString();
                //Console.WriteLine(pointString);
                //////////////////////////////////////////////////////////////////////////
                //int x, y, z;

                //    Console.WriteLine(" Enter X , Y and Z ");
                //    if (!int.TryParse(Console.ReadLine(), out x) || !int.TryParse(Console.ReadLine(), out y) || !int.TryParse(Console.ReadLine(), out z))
                //    {
                //        Console.WriteLine("Invalid input. Please enter a valid number");
                //    }
                //    else
                //    {
                //    Console.WriteLine(x);
                //    Console.WriteLine(y);
                //    Console.WriteLine(z);
                //    }
                /////////////////////////////////////////////////////
                //Design point1 = new Design(5);
                //Design point2 = new Design(5);
                //if (point1.Equals(point2))
                //{
                //    Console.WriteLine("true");
                //}
                //else
                //{
                //    Console.WriteLine("false");

                //}
                //////////////////////////////////////////////////////
                Point[] points = new Point[]{
                new Point(3, 5),
                new Point(1, 4),
                new Point(2, 3),
                new Point(1, 6)};

                Array.Sort(points);

                Console.WriteLine("Sorted Points:");
                foreach (var point in points)
                {
                    Console.WriteLine(point);
                }




            }
        }
    }
}
}
