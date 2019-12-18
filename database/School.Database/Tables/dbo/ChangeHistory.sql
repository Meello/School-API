CREATE TABLE [ChangeHistory]
(
	ChangeHistoryId UNIQUEIDENTIFIER,
	[User] nchar(50) DEFAULT SYSTEM_USER NOT NULL,
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
