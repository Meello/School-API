CREATE TABLE [Teacher]
(
	TeacherId bigint not null,
	Name varchar(32) not null,
	Gender char(1) not null,
	LevelId char(1) not null,
	Salary decimal(10,2) not null,
	AdmitionDate date not null,
	CONSTRAINT PK_Teachers PRIMARY KEY(TeacherId),
	CONSTRAINT FK_Teacher_Level FOREIGN KEY (LevelId)
	REFERENCES [Level],
	CONSTRAINT CK_Teacher_Gender CHECK (Gender IN ('M','F'))
);
