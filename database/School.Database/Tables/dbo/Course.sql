CREATE TABLE [Course]
(
	CourseId INT not null identity(1,1),
	AreaId smallint not null,
	Name varchar(30) not null,
	Workload smallint not null,
	CONSTRAINT PK_Course PRIMARY KEY(CourseId),
	CONSTRAINT FK_Course_InformationArea FOREIGN KEY (AreaId)
	REFERENCES [InformationArea]
);
