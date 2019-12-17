CREATE TABLE [TrackedEntity]
(
	TrackedEntityId int not null,
	Name varchar(20) not null,
	CONSTRAINT PK_TrackedEntity PRIMARY KEY(TrackedEntityId)
);
INSERT INTO
	[TrackedEntity]
	(
		TrackedEntityId,
		Name
	)
VALUES
(1,'Course'),
(2,'Teacher'),
(3,'Student'),
(4,'Class');

CREATE TABLE [ChangeHistory]
(
	ChangeHistoryId UNIQUEIDENTIFIER,
	[User] nchar(50) DEFAULT SYSTEM_USER,
	ChangeOperationType char(1) not null,
	TrackedEntityId int not null,
	TrackedEntityRecordId varchar(20) not null,
	Description varchar(max) not null,
	ChangeDateUTC datetime2 not null,
	CONSTRAINT CK_ChangeHistory_ChangeOperationType CHECK(ChangeOperationType IN ('I','U','D')),
	CONSTRAINT PK_ChangeHistory PRIMARY KEY(ChangeHistoryId),
	CONSTRAINT FK_ChangeHistory_TrackedEntity FOREIGN KEY(TrackedEntityId)
	REFERENCES [TrackedEntity]
);

CREATE TABLE [ChangeHistoryDetail]
(
	ChangeHistoryDetailId int not null identity(1,1),
	ChangeHistoryId UNIQUEIDENTIFIER,
	PropertyName varchar(100) not null,
	PreviousValue varchar(MAX) not null,
	NewValue varchar(MAX) not null,
	CONSTRAINT FK_ChangeHistoryDetail_ChangeHistory FOREIGN KEY(ChangeHistoryId)
	REFERENCES [ChangeHistory]
);