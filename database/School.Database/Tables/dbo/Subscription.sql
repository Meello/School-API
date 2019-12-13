CREATE TABLE [Subscription]
(
	StudentId bigint not null,
	ClassId tinyint not null,
	CONSTRAINT PK_Sub PRIMARY KEY(StudentId,ClassId),
	CONSTRAINT FK_Subscription_Student FOREIGN KEY(StudentId)
	REFERENCES [Student],
	CONSTRAINT FK_Subscription_Class FOREIGN KEY (ClassId)
	REFERENCES [Class]
);