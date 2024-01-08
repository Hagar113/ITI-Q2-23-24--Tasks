--•	All foreign keys have cascade rule on delete and update
--•	Age and Netsalary are calculated attributes but it will be on instructor table creation
--•	Netsalary=salary+overtime
--•	Age=current year – birthdate year./.,GB
--•	Address has only cairo or alex value
--•	All salaries in the range from 1000 to 5000
--•	Salary has a default value = 3000
--•	Overtime is unique
--•	Capacity of each lab under 20 seats
--•	Lab is weak entity
--•	Hiredate has a default value= current system data
--•	Duration of each course is unique

 --------------Courses table---------------------
CREATE TABLE Courses (
  CID INT PRIMARY KEY,
  CName VARCHAR(20),
  Duration INT,
  CONSTRAINT unique_duration UNIQUE(Duration)
);

------------------ Lab table-----------------------------
CREATE TABLE Labs (
  LID INT PRIMARY KEY,
  Location VARCHAR(50),
  Capacity INT,
  CID INT,
  CONSTRAINT fk_course FOREIGN KEY (CID) REFERENCES Courses(CID) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT check_capacity CHECK (Capacity < 20)
);

-----------------  Instructor table--------------------------
CREATE TABLE Instructors (
  ID INT PRIMARY KEY,
  Address VARCHAR(50) CHECK (Address IN ('cairo', 'alex')),
  Salary INT DEFAULT 3000 CHECK (Salary BETWEEN 1000 AND 5000),
  Hiredate DATE DEFAULT GETDATE(),
  BD DATE,
  OverTime INT,
  Fname VARCHAR(20),
  Lname VARCHAR(20),
  Age AS YEAR(GETDATE() - YEAR(BD)),
  NetSalary AS Salary + OverTime,
  CONSTRAINT unique_overtime UNIQUE(OverTime)
);

-- -----------------------Tech table---------------------------------
CREATE TABLE Tech (
  IID INT,
  LID INT,
  CONSTRAINT fk_instructor FOREIGN KEY (IID) REFERENCES Instructors(ID) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_lab FOREIGN KEY (LID) REFERENCES Labs(LID) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT pk_tech PRIMARY KEY (IID, LID)
);