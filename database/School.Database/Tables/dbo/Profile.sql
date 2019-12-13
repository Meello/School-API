CREATE TABLE [Profile] 
(
	ProfileId tinyint not null,
	Name varchar(20) not null,
	CONSTRAINT PK_Profile PRIMARY KEY(ProfileId),
	CONSTRAINT UN_Profile_Name UNIQUE(Name)
);