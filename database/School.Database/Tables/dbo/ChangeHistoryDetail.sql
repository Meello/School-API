CREATE TABLE [ChangeHistoryDetail]
(
	ChangeHistoryDetailId int not null identity(1,1),
	ChangeHistoryId UNIQUEIDENTIFIER NOT NULL,
	PropertyName varchar(100) not null,
	PreviousValue varchar(MAX) not null,
	NewValue varchar(MAX) not null,
	CONSTRAINT FK_ChangeHistoryDetail_ChangeHistory FOREIGN KEY(ChangeHistoryId)
	REFERENCES [ChangeHistory]
);
