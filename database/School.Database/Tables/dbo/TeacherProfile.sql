CREATE TABLE [TeacherProfile]
(
	TeacherId bigint not null,
	ProfileId tinyint not null,
	CONSTRAINT PK_TeacherProfile PRIMARY KEY(TeacherId,ProfileId),
	CONSTRAINT FK_TeacherProfile_Profile FOREIGN KEY(ProfileId)
	REFERENCES [Profile],
	CONSTRAINT FK_TeacherProfile_Teacher FOREIGN KEY (TeacherId)
	REFERENCES [Teacher]
);
