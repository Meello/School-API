DROP PROCEDURE IF EXISTS Procedure_ChangeHistoryDetail
GO
CREATE PROCEDURE Procedure_ChangeHistoryDetail
@ChangeHistoryId varchar(max),
@PropertyName varchar(20),
@PreviousValue varchar(max),
@NewValue varchar(max)

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [ChangeHistoryDetail]
	(
		ChangeHistoryId,
		PropertyName,
		PreviousValue,
		NewValue
	)
	VALUES
	(
		@ChangeHistoryId,
		@PropertyName,
		@PreviousValue,
		@NewValue
	)
END