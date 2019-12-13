CREATE TABLE [Class]
(
	ClassId tinyint not null identity(10,10),
	Local varchar(40),
	CourseId tinyint not null,
	TeacherId bigint not null,
	[Shift] char(1) not null,
	StartDate date not null,
	EndDate date not null,
	StartTime time not null,
	EndTime time not null,
	CONSTRAINT PK_Class PRIMARY KEY(ClassId),
	CONSTRAINT FK_Class_Teacher FOREIGN KEY (TeacherId)
	REFERENCES [Teacher],
	CONSTRAINT FK_Class_Course FOREIGN KEY (CourseId)
	REFERENCES [Course],
	CONSTRAINT CK_Class_Shift CHECK ([Shift] IN ('M','T','N')),
	CONSTRAINT CK_StartDate_EndDate CHECK (StartDate < EndDate),
	CONSTRAINT CK_StartTime_EndTime CHECK (StartTime < EndTime)
);