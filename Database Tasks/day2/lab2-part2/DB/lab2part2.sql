--1.	Display all the employees Data.
--2.	Display the employee First name, last name, Salary and Department number.
--3.	Display all the projects names, locations and the department which is responsible about it.
--4.	If you know that the company policy is to pay an annual commission for each employee with specific percent equals 10% of his/her annual salary .Display each employee full name and his annual commission in an ANNUAL COMM column (alias).
--5.	Display the employees Id, name who earns more than 1000 LE monthly.
--6.	Display the employees Id, name who earns more than 10000 LE annually.
--7.	Display the names and salaries of the female employees 
--8.	Display each department id, name which managed by a manager with id equals 968574.
--9.	Dispaly the ids, names and locations of  the pojects which controled with department 10.
use Company_SD

select * from Employee;
select Fname ,Lname,Salary,Dno
from Employee
select Pname,Plocation,Dnum
from Project;
select Pname,Plocation,Dname
from Project , Departments
where project.Dnum=Departments.Dnum;
select Fname+' '+Lname as fullName , Salary * .12 as "ANNUAL COMM"
from Employee;
Select Fname,SSN
from Employee
where Salary >1000;
Select Fname,SSN
from Employee
where Salary*12 >10000;
select Fname,Salary
from Employee
where Sex='f';
select Dnum,Dname
from Departments
where MGRSSN=968574;
select Pname,Plocation,Pnumber
from Project
where Dnum=10;
