using System;
using System.Collections.Generic;
using System.Text;
namespace Day6
{
    // Employee class represent an employee in the company
    class Employee
    {
        // Event employee layoff
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        // invoke the EmployeeLayOff event
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        // Properties of employee
        public int EmployeeID { get; set; }
        
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }

        // Method for an employee to request vacation
        public bool RequestVacation(DateTime From, DateTime To)
        {
            throw new NotImplementedException();
        }

        // Method called at the end of the year to check for layoff conditions
        public void EndOfYearOperation()
        {
            if (VacationStock < 0 || CalculateAge()> 60)
            {
                LayOffCause cause = VacationStock < 0 ? LayOffCause.Vacation : LayOffCause.Age;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = cause });
                Console.WriteLine("Employee Layoff Processed");
            }

        }

        // Method to calculate the age of an employee
        public int CalculateAge()
        {
            DateTime date = DateTime.Now;
            int age = date.Year - BirthDate.Year;
            if (date.Month < BirthDate.Month || (date.Month == BirthDate.Month && date.Day < BirthDate.Day))
            {
                age--;
            }
            return age;
        }

        // Override ToString method to provide a string representation of the employee
        public override string ToString()
        {
            return $"{EmployeeID} -> has {VacationStock} days As VacationStock and {CalculateAge()} years old";
        }
    }

    // Enum representing the causes for employee layoff
    public enum LayOffCause
    {
        Vacation,
        Age,
    }

    // EventArgs class for the EmployeeLayOff event
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }

    // Department class representing a department in a company
    class Department
    {
        // Properties of a department
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public List<Employee> Staff;

        // Constructor to initialize the Staff list
        public Department()
        {
            Staff = new List<Employee>();
        }

        // Method to add an employee to the department
        public void AddStaff(Employee E)
        {
            E.EmployeeLayOff += RemoveStaff;
            Staff.Add(E);
        }

        // Callback method for employee layoff event
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                Staff.Remove(employee);
                Console.WriteLine($"Employee {employee.EmployeeID} laid off from Department {DeptName} due to {e.Cause}.");
            }
            else
            {
                Console.WriteLine("Invalid sender type for RemoveStaff callback.");
            }
        }

        // Override ToString method to provide a string representation of the department
        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder($"{DeptID} - {DeptName} have\n");
            foreach (Employee e in Staff)
            {
                returnString.Append($"{e}\n");
            }
            return returnString.ToString();
        }
    }

    // Club class representing a club in a company
    class Club
    {
        // Properties of a club
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public List<Employee> Members;

        // Constructor to initialize the Members list
        public Club()
        {
            Members = new List<Employee>();
        }

        // Method to add an employee to the club
        public void AddMember(Employee E)
        {
            E.EmployeeLayOff += RemoveMember;
            Members.Add(E);
        }

        // Callback method for employee layoff event in the club
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                if (e.Cause == LayOffCause.Vacation && employee.CalculateAge() <= 60)
                {
                    Members.Remove(employee);
                    Console.WriteLine($"Employee {employee.EmployeeID} removed from Club {ClubName} due to {e.Cause}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid sender type for RemoveMember callback.");
            }
        }

        // Override ToString method to provide a string representation of the club
        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder($"{ClubID} - {ClubName} have\n");
            foreach (Employee e in Members)
            {
                returnString.Append($"{e}\n");
            }
            return returnString.ToString();
        }
    }

    // Main program
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create objects for employee
            Employee emp1 = new Employee { EmployeeID = 1, BirthDate = new DateTime(1970, 2, 23), VacationStock = 4 };
            Employee emp2 = new Employee { EmployeeID = 2, BirthDate = new DateTime(1950, 4, 17), VacationStock = -3 };

            // Create  objects for department and club
            Department department = new Department { DeptID = 16, DeptName = "fyiytrfutjdrjy" };
            Club club = new Club { ClubID = 17, ClubName = "guykftfuc" };

            // Add employees to department and club
            department.AddStaff(emp1);
            department.AddStaff(emp2);
            club.AddMember(emp1);
            club.AddMember(emp2);

           

            // Perform end-of-year operations for employees
            emp1.EndOfYearOperation();
            emp2.EndOfYearOperation();

          
          
            
        }
    }
}

