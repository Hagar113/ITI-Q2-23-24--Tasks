namespace DAy2
{
    using System;

    //2.	Design and implement class for the employees in a company
    //3.	Employee is identified by an ID, salary, hire date and Gender.
    //4.	Develop a Structure to represent the HiringDate Data Type consisting of fields to hold the day, month and Years.
    //5.	We need to restrict the Gender field to be only M or F[Male of Female]
    //6.	We want to provide the Employee class with the standard capabilities to represent Employee data in a string Form(override ToString ()), display employee salary in a currency format. [use String.Format Function, do you need additional using Directive ] 
    //7.	Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions, (Employee[] EmpArr;) 
    //8.	Implement All the Necessary Member Functions on the class (Getters, Setters)
    //9.	Define all the Necessary Constructors for the Structure
    //10.	Read ALL Data from End User
    //11.	Allow NO RUNTIME errors if the user inputs any data
    //12.	Sort the employees based on their hire date
    //14.	Print the sorted array.
    //15.	While sorting (how many times Boxing and Unboxing process has occurred)
    namespace day02
    {
        public class Logger
        {
            private readonly string logFilePath;

            public Logger(string filePath)
            {
                logFilePath = filePath;
            }

            public void Log(string message)
            {
                try
                {
                    using (StreamWriter writer = File.AppendText(logFilePath))
                    {
                        writer.WriteLine($"{DateTime.Now} - {message}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log them, or display an error message
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }
        }
        class invalidAgeEx : Exception
        {
            public invalidAgeEx() : base("age is not valid")
            {
            }
        }
        class GenderEx : Exception
        {
            public GenderEx() : base("Gender is not valid")
            {

            }
        }
        class dataEx : Exception
        {
            public dataEx() : base("data is not valid")
            {
            }
        }
        enum Gender
        {
            male, female
        }
        struct datatime
        {
            int _day;
            int _month;
            int _year;
            public int day
            {
                get
                {
                    return _day;
                }
                set
                {
                    if (value < 0
                      || value > 30)
                    {
                        throw new dataEx();
                    }
                    _day = value;
                }
            }
            public int month
            {
                get
                {
                    return _month;
                }
                set
                {
                    if (value < 0 || value > 30)
                    {
                        throw new dataEx();
                    }
                    _month = value;
                }
            }
            public int year
            {
                get
                {
                    return _year;
                }
                set
                {
                    if (value < 2000)
                    {
                        throw new dataEx();
                    }
                    _year = value;
                }
            }

            public datatime(int day, int month, int year)
            {
                this.month = month;
                this.day = day;
                this.year = year;
            }
            public override string ToString()
            {
                return $"{day},{month},{year}";
            }

            public static bool operator <(datatime a, datatime b)
            {

                if (a.year < b.year)
                {
                    return true;

                }
                else if (a.month < b.month && a.year == b.year)
                {
                    return true;
                }
                else if (a.day < b.day && a.month == b.month && a.year == b.year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >(datatime a, datatime b)
            {

                if (a.year > b.year)
                {
                    return true;

                }
                else if (a.month > b.month && a.year == b.year)
                {
                    return true;
                }
                else if (a.day > b.day && a.month == b.month && a.year == b.year)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class employees
        {
            public Gender gender { get; set; }
            public int id { get; set; }
            public decimal salary { get; set; }

            public datatime hireDate { get; set; }

            public employees(int id, decimal salary, datatime hiredate, Gender gender)
            {
                this.id = id;
                this.salary = salary;
                this.hireDate = hiredate;
                this.gender = gender;
            }

            public override string ToString()
            {
                return $"id : {id} , salary : {salary} , hiredata {hireDate.ToString()} , gender {gender}";
            }


        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Logger logger = new Logger("D:/New Text Document.txt");

                // Example usage
                string text = Console.ReadLine();
                logger.Log(text);
                employees[] em = new employees[3];
                datatime t = new datatime();
                employees em1 = new employees(1, 1000, t, Gender.male);
                datatime t2 = new datatime();
                Gender g = new Gender();

                for (int i = 0; i < em.Length; i++)
                {

                    em[i] = new employees(1, 1, t2, g);

                }


                for (int i = 0; i < em.Length; i++)
                {
                    Console.WriteLine($"emp numb  {i + 1}");
                    Console.WriteLine($"id for em number {i + 1}");
                    em[i].id = int.Parse(Console.ReadLine());
                    Console.WriteLine($"enter salary for em {i + 1}");
                    em[i].salary = int.Parse(Console.ReadLine());
                    try
                    {
                        Console.WriteLine("enter hireDate day");
                        t2.day = int.Parse(Console.ReadLine());
                        //em[i].hireDate = t2;       
                        Console.WriteLine("enter hireDate month");
                        t2.month = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter hireDate year");
                        t2.year = int.Parse(Console.ReadLine());
                        em[i].hireDate = t2;

                    }
                    catch (dataEx ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for day, month, and year.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                    Console.WriteLine("enter Gender");
                    string newGender = Console.ReadLine();
                    if (Enum.TryParse(newGender, true, out Gender userGender))
                    {
                        em[i].gender = userGender;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Male, Female");

                    }
                }
                for (int i = 0; i < em.Length - 1; i++)
                {
                    for (int j = 1; j < em.Length; j++)
                    {
                        if (em[i].hireDate > em[j].hireDate)
                        {
                            employees temp = em[i];
                            em[i] = em[j];
                            em[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < em.Length; i++)
                {
                    Console.WriteLine(em[i].ToString());

                }



            }
        }
    }
}
    
