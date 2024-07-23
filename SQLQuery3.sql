
create table Employees (
   Id                   int                  identity,
   FirstName            nvarchar(40)         not null,
   LastName             nvarchar(40)         not null,
   Age					int					 not null,
   StartOfWorkYear      int					 not null,
   City					nvarchar(40)		not null,
   Street				nvarchar(40)		not null,
   RoleInCompany		nvarchar(40)		not null,
   PhoneNumber			nvarchar(40)		not null,
   Email				nvarchar(40)		not null,
)
go


create table Candidates (
   Id                   int                  identity,
   FirstName            nvarchar(40)         not null,
   LastName             nvarchar(40)         not null,
   ScoreInSortedTest	int					 null,
)
go


create table Interviews (
   InterviewNumber      int                  identity,
   InterviewerId        int                  not null,
   CandidateId			int                  not null,
   InterviewDate		date		 null,
   RoleInCompany		nvarchar(40)		 not null,
   ScoreInInterview		int					 null,
)
go

	

SET IDENTITY_INSERT Employees ON 
INSERT INTO [Employees] ([Id],[FirstName],[LastName],[Age],[StartOfWorkYear],[City],[Street],[RoleInCompany],[PhoneNumber],[Email])VALUES(208378456,'Avrahaam','Menachem',34,2012,'Haifa','Herztel','Developer','0587658763','Avrahaam3@gmail.com')
INSERT INTO [Employees] ([Id],[FirstName],[LastName],[Age],[StartOfWorkYear],[City],[Street],[RoleInCompany],[PhoneNumber],[Email])VALUES(209879653,'Tzvi','Vais',57,1996,'Haifa','Barzily','Electronics Engineer','0545673689','054567@gmail.com')
INSERT INTO [Employees] ([Id],[FirstName],[LastName],[Age],[StartOfWorkYear],[City],[Street],[RoleInCompany],[PhoneNumber],[Email])VALUES(204678265,'Shimon','Cohen',45,2005,'Q.Moztkin','Bar Elan','QA Tester','0538769456','Shim05@gmail.com')
INSERT INTO [Employees] ([Id],[FirstName],[LastName],[Age],[StartOfWorkYear],[City],[Street],[RoleInCompany],[PhoneNumber],[Email])VALUES(206989067,'Moshe','Dobolsky',24,2016,'Nesher','Shita','QA Tester','0589087345','Mosh90@gmail.com')
INSERT INTO [Employees] ([Id],[FirstName],[LastName],[Age],[StartOfWorkYear],[City],[Street],[RoleInCompany],[PhoneNumber],[Email])VALUES(207876845,'David','Tal',30,2009,'Haifa','Prachim','Electronics Engineer','0578906745','05789@gmail.com')

   
SET IDENTITY_INSERT Candidates ON
INSERT INTO [Candidates] ([Id],[FirstName],[LastName],[ScoreInSortedTest])VALUES(203879564,'Haim','Buzaglo',95)
INSERT INTO [Candidates] ([Id],[FirstName],[LastName],[ScoreInSortedTest])VALUES(204567898,'Yaakov','Genut',100)
INSERT INTO [Candidates] ([Id],[FirstName],[LastName],[ScoreInSortedTest])VALUES(204578982,'Shalom','Levinsky',85)
INSERT INTO [Candidates] ([Id],[FirstName],[LastName],[ScoreInSortedTest])VALUES(204567876,'Meir','Frid',80)
INSERT INTO [Candidates] ([Id],[FirstName],[LastName],[ScoreInSortedTest])VALUES(212589874,'shalom','cohen',89)

   
SET IDENTITY_INSERT Interviews ON
INSERT INTO [Interviews] ([InterviewNumber],[InterviewerId],[CandidateId],[InterviewDate],[RoleInCompany],[ScoreInInterview])VALUES(1,208378456,203879564,'2022-01-02','Developer',8)
INSERT INTO [Interviews] ([InterviewNumber],[InterviewerId],[CandidateId],[InterviewDate],[RoleInCompany],[ScoreInInterview])VALUES(2,209879653,204567898,'2022-04-05','Electronics Engineer',10)
INSERT INTO [Interviews] ([InterviewNumber],[InterviewerId],[CandidateId],[InterviewDate],[RoleInCompany],[ScoreInInterview])VALUES(3,204678265,204578982,'2022-06-03','QA Tester',8)
INSERT INTO [Interviews] ([InterviewNumber],[InterviewerId],[CandidateId],[InterviewDate],[RoleInCompany],[ScoreInInterview])VALUES(4,206989067,204567876,'2022-01-02','QA Tester',9)
INSERT INTO [Interviews] ([InterviewNumber],[InterviewerId],[CandidateId],[InterviewDate],[RoleInCompany],[ScoreInInterview])VALUES(5,207876845,212589874,'2022-04-02','Electronics Engineer',9)
