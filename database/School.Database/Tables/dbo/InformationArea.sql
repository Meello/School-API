CREATE TABLE [InformationArea]
(
	AreaId smallint not null,
	Name varchar(20) not null,
	CONSTRAINT PK_InformationArea PRIMARY KEY(AreaId),
	CONSTRAINT UN_InformationArea_Name UNIQUE(Name)
);