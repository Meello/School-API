INSERT INTO [Profile] (ProfileId, Name)
VALUES
(1,'Coordenador'),
(2,'Diretor'),
(3,'Professor');

INSERT INTO [Level] (LevelId, Name)
VALUES
('J','Junior'),
('P','Pleno'),
('S','Sênior');

INSERT INTO [Teacher] (TeacherId, Name, Gender, LevelId, Salary, AdmitionDate)
VALUES
(74775784935,'Steven','M','S',2500,'2000-01-29'),
(31697199984,'Neena','F','P',1850,'1999-01-14'),
(77899731348,'Lex De Haan','M','J',1730,'1996-07-18'),
(34919150903,'Alexander','M','S',2000,'1998-11-15'),
(98890485310,'Trenna','F','P',1730,'1999-12-07');

INSERT INTO [Student] (StudentId, Name, Gender, BirthDate, City, CreatedAt, Active)
VALUES
--(11163766917,'David','M','2020-06-25','Acre','2013-02-01 11:50',1),  --teste
(81163766917,'David','M','1997-06-25','Acre','2013-02-01 11:50',1),
(31627648402,'Valli','F','1998-02-05','São Paulo','2014-03-01 17:30',1),
(94891604743,'Diana','F','1999-02-07','Rio de Janeiro','2014-04-01 9:10',0),
(9689282425,'Nancy','F','1994-08-17','Roraima','2014-01-02 20:35',1),
(79952245750,'Daniel','M','1994-08-16','Sao Paulo','2014-02-03 12:50',1);

INSERT INTO [TeacherProfile] (TeacherId, ProfileId)
VALUES
(74775784935,1),
(31697199984,2),
(77899731348,3),
(34919150903,2),
(98890485310,3);  --Alterada de (34919150903,3) para (98890485310,3) porque não funcionava no exercício

INSERT INTO [InformationArea] (AreaId,Name)
VALUES
(100,'Informática'),
(200,'Gastronomia'),
(300,'Petróleo & Gás'),
(400,'Segurança');

INSERT INTO [Course] (AreaId, Name, Workload)
VALUES
(100,'Admin. de Redes',280),
(200,'Auxiliar de Cozinha',200),
(300,'Frentista',205);

INSERT INTO [Class] (Local,CourseId,TeacherId,[Shift], StartDate,EndDate,StartTime,EndTime)
VALUES
('Volta Redonda',1,74775784935,'M','2013-09-12','2014-06-19','08:00','11:50'),
(NULL,1,31697199984,'T','2013-10-19','2014-05-09','13:00','17:00'),
('Botafogo',2,98890485310,'N','2013-08-12','2013-12-09','19:00','22:30');
 
INSERT INTO [Subscription](StudentId, ClassId)
VALUES
(81163766917,10),
(81163766917,20),
(81163766917,30),
(31627648402,10),
(31627648402,30),
(94891604743,30),
(79952245750,10),
(79952245750,20),
(79952245750,30);

-- Ver a tabela
SELECT * FROM [Class];
--Deletar os dados da tabela
DELETE [Class];

DROP PROCEDURE Exists_BirthDate2

-- Procedures
EXEC Exists_BirthDate;
EXEC Exists_BirthDate2;
EXEC Workday_Class;			--Não funciona
EXEC Verifying_Times;
EXEC Verifying_Class;