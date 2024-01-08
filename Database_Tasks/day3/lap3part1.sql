-----------------lap3 part 1---------------
--* Try to create the following Queries:

--1.	Display the Department id, name and id and the name of its manager.
--2.	Display the name of the departments and the name of the projects under its control.
--3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
--4.	Display the Id, name and location of the projects in Cairo or Alex city.
--5.	Display the Projects full data of the projects with a name starts with "a" letter.
--6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
--7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
--8.	Find the names of the employees who directly supervised with Kamel Mohamed.
--9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
--10.	For each project located in Cairo City , find the project number, the controlling department name ,""the department manager"" last name ,address and birthdate.
--11.	Display All Data of the managers   soooooooooooooooalllllllllllll
--12.	Display All Employees data and the data of their dependents even if they have no dependents
--13.	Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
--14.	Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
--15.	Upgrade your salary by 20 % 

--------------------1------------------
select Dname,Dnum,ESSN,Dependent_name
from Departments , Dependent
where ESSN=MGRSSN;
--------------------2------------------
select Dname,Pname
from Departments left outer join Project
on Departments.Dnum=Project.Dnum;
--------------------3------------------
select * 
from Employee, Dependent
where Employee.SSN= Dependent.ESSN;
--------------------4-----------------
select Pnumber,Pname,Plocation
from Project
where Plocation in ('cairo','alex');
-------------------5------------------
select*
from Project
where Pname like 'a%';
-------------------6------------------
select *
from Employee
where DNO=30 AND Salary between 1000 and 2000;
-------------------7-------------------
select E.Fname +''+E.Lname As FullName
from Employee E , Project p , Works_for W
where E.SSN = W.ESSn and W.Pno = p.Pnumber
and
p.Pname = 'AL Rabwah' and W.Hours >= 10
--------------------------------------------
select e.Fname from Employee e inner join Departments d  on d.Dnum=e.Dno and e.Dno=10 
inner join Works_for w on w.ESSn =e.SSN and w.Hours>=10
inner join Project p  on p.Pnumber = w.Pno and p.Pname ='Al Rabwah'
---------------------------------------------
select Fname
from Employee inner join  Project on Employee.Dno=Project.Dnum  
where Dno>=10 and Pname='AL Rabwah';
---------------------8------------------

select e.Fname , e.Lname  , s.Superssn
from Employee e inner join Employee s
on  s.SSN = e.Superssn and s.Fname='Kamel'and s.Lname='Mohamed'
--------------------9--------------------
select e.Fname , p.Pname
from Employee e full outer join Works_for w 
on e.SSN= w.ESSn 
full outer join Project p
on p.Pnumber = w.Pno order by p.Pname
---------------------10-------------------
select p.Pnumber , d.Dname , e.Lname , e.Address , e.Bdate 
from Project p inner join Departments d 
on p.Dnum = d.Dnum and p.City ='Cairo'
inner join Employee e  on e.SSN = d.MGRSSN
----------------------11-------------------
select e.* , d.Dname 
from  Employee e inner join Departments d
on d.MGRSSN = e.SSN
----------------------12-------------------
select e.* , d.*
from Employee e left outer join Dependent d 
on d.ESSN = e.SSN
------------------------13-------------------
insert into Employee values ('hagar','hwary',111111,'1/1/2000','menofya','F',6000,112233,30)
------------------------14--------------------

--insert into Employee values ('eman' ,'pepars',102660 ,' 03-11-2002', 'Menoufia', 'F',NULL,NULL  , 30)
--delete Employee where SSN=102660
insert into Employee values ('eman' ,'pepars',102660 ,' 03-11-2002', 'Menoufia', 'F',NULL,NULL  , 30)

------------------------15-------------------
update Employee set Salary=Salary+Salary*.02 
where SSN=111111;
