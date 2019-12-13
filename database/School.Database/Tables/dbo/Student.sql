CREATE TABLE [Student]
(
	StudentId bigint not null,
	Name varchar(20) not null,
	Gender char(1) not null,
	BirthDate date not null,
	City varchar(20) not null,
	CreatedAt datetime2 not null,
	Active bit not null,
	CONSTRAINT PK_Student PRIMARY KEY(StudentId),
	CONSTRAINT CK_Student_Gender CHECK (Gender IN('M','F'))
);