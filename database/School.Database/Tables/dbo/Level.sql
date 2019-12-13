CREATE TABLE [Level] 
(
	LevelId char(1) not null,
	Name varchar(10) not null,
	CONSTRAINT PK_Level PRIMARY KEY(LevelId),
	CONSTRAINT UN_Level_Name UNIQUE(Name)
);
