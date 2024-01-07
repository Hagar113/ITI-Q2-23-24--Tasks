
namespace day3
{
        public class POINTS:IComparable<POINTS> ,ICloneable
        {
        public object Clone()
        {
            return new POINTS(X, Y, Z) as object;
        }
        public int CompareTo(POINTS other)
        {
            int result= X.CompareTo(other.X);
            if(result== 0)
            {
                Y.CompareTo(other.Y);
            }
            return result;
        }
        public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public POINTS(int x) : this(x, 0) { }
            public POINTS(int x, int y) : this(x, y, 0) { }
            public POINTS(int X, int Y, int Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }


            public override string ToString()
            {
                return $"Point Coordinates:   ({X}, {Y}, {Z})";
            }
            public override bool Equals(object? obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                POINTS design = (POINTS)obj;
                return this.X == design.X;
            }

            public static bool operator >(POINTS a, POINTS b)
            {
                if (a.X > b.X)
                {
                    return true;
                }
                else if (a.Y > b.Y && a.X == b.X)
                {
                    return true;
                }

                else { return false; }
            }
            public static bool operator <(POINTS a, POINTS b)
            {
                if (a.X < b.X)
                {
                    return true;
                }
                else if (a.Y < b.Y && a.X == b.X)
                {
                    return true;
                }
                else { return false; }
            }


        }

        public enum NetworkType
        {
            Ethernet,
            TokenRing
        }

        public sealed class NIC
        {
            private static NIC instance = null;
            public string Manufacture { get; private set; }
            public string MACAddress { get; private set; }
            public NetworkType Type { get; private set; }


            private NIC()
            {
                Manufacture = "Your Manufacturer";
                MACAddress = "00-000-000-000-000-000";
                Type = NetworkType.Ethernet;
            }


            public static NIC GetInstance()
            {
                if (instance == null)
                {
                    instance = new NIC();
                }
                return instance;
            }
        }

        public class Duration
        {
            public int Hours { get; }
            public int Minutes { get; }
            public int Seconds { get; }

            public Duration(int hours, int minutes, int seconds)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }

            public override string ToString()
            {
                if (Hours > 0)
                {
                    return $"Hours: {Hours}, Minutes: {Minutes:D2}, Seconds: {Seconds:D2}";
                }
                else if (Minutes > 0)
                {
                    return $"Minutes: {Minutes}, Seconds: {Seconds:D2}";
                }
                else
                {
                    return $"Seconds: {Seconds}";
                }
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Duration other = (Duration)obj;
                return Hours == other.Hours &&
                       Minutes == other.Minutes &&
                       Seconds == other.Seconds;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Hours, Minutes, Seconds);
            }

            public Duration(int Sec)
            {
                Hours = Sec / 3600;
                Minutes = (Sec % 3600) / 60;
                Seconds = Sec % 60;
            }


            public static Duration operator +(Duration d1, Duration d2)
            {
                int totalSeconds = d1.Seconds + d2.Seconds;
                return new Duration(totalSeconds);
            }

            public static Duration operator +(Duration d1, int seconds)
            {
                int totalSeconds = d1.Seconds + seconds;
                return new Duration(totalSeconds);
            }
            public static Duration operator -(Duration d1, Duration d2)
            {
                int totalSeconds = d1.Seconds - d2.Seconds;
                return new Duration(totalSeconds);
            }

            public static Duration operator -(Duration d1, int seconds)
            {
                int totalSeconds = d1.Seconds - seconds;
                return new Duration(totalSeconds);
            }


        }

        internal class Program
        {
            static void Main(string[] args)
            {
            #region lab1
            POINTS p1 = new POINTS(5);
            POINTS p2 = new POINTS(10, 15);
            POINTS p3 = new POINTS(20, 25, 30);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            POINTS P = new POINTS(10, 10, 10);
            Console.WriteLine(P);

            string pointString = P.ToString();
            Console.WriteLine(pointString);
            /////////////////////////////////////////////////
            int x, y, z;

            Console.WriteLine(" Enter X , Y and Z ");
            if (!int.TryParse(Console.ReadLine(), out x) || !int.TryParse(Console.ReadLine(), out y) || !int.TryParse(Console.ReadLine(), out z))
            {
                Console.WriteLine("Invalid input. Please enter a valid number");
            }
            else
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.WriteLine(z);
            }
            ///////////////////////////////////////////////////
            POINTS point1 = new POINTS(5);
            POINTS point2 = new POINTS(5);
            if (point1.Equals(point2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");

            }
            ////////////////////////////////////////////////////
            POINTS[] points = new POINTS[]{
                new POINTS(3, 5),
                new POINTS(1, 4),
                new POINTS(2, 3),
                new POINTS(1, 6)};

            //for (int i = 0; i < points.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < points.Length; j++)
            //    {
            //        if (points[i].X > points[j].X)
            //        {
            //            POINTS temp = points[i];
            //            points[i] = points[j];
            //            points[j] = temp;
            //        }
            //        else if (points[i].X == points[j].X && points[i].Y > points[j].Y)
            //        {
            //            POINTS temp = points[i];
            //            points[i] = points[j];
            //            points[j] = temp;
            //        }
            //    }
            //}

            List<POINTS> point = new List<POINTS>();

            point.Add(new POINTS(5, 2, 2));
            point.Add(new POINTS(9, 1, 6));
            point.Add(new POINTS(2, 7, 10));

            point.Sort();

            Console.WriteLine("\nSorted Points:");

            for (int i = 0; i < point.Count; i++)
            {
                Console.WriteLine(point[i]);
            }

            //Console.WriteLine("Sorted Points:");
            //foreach (var point in points)
            //{
            //    Console.WriteLine();
            //}
            ////////////////////////////////////////////////////////////// 

            NIC myNIC = NIC.GetInstance();
            Console.WriteLine($"Manufacture: {myNIC.Manufacture}");
            Console.WriteLine($"MAC Address: {myNIC.MACAddress}");
            Console.WriteLine($"Type: {myNIC.Type}");

            #endregion

            #region lab2
            Duration d = new Duration(1, 3, 20);
                Duration d1 = new Duration(3600);
                Duration d2 = new Duration(666);

                Console.WriteLine(d);
                Console.WriteLine(d1);
                Console.WriteLine(d2);
                Console.WriteLine(d + 30);
                #endregion

            }
        }
    }
