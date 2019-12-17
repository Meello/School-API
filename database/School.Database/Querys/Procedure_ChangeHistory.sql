USE school;  
GO  
DROP PROCEDURE IF EXISTS Procedure_ChangeHistory
GO  
CREATE PROCEDURE Procedure_ChangeHistory  
@ChangeOperationType char, 
@TrackedEntityId tinyint,
@TrackedEntityRecordId bigint,
@Description varchar(max),
@ChangeDateUTC datetime2,
@ChangeHistoryId varchar(max) OUTPUT  
AS    
    SET NOCOUNT ON; 
	SET @ChangeHistoryId = NEWID()
	IF	
	@ChangeOperationType IS NOT NULL
	AND @TrackedEntityId IS NOT NULL
	AND @TrackedEntityRecordId IS NOT NULL
	AND @Description IS NOT NULL
	BEGIN
		INSERT 	INTO [ChangeHistory]
		(
			ChangeHistoryId,
			ChangeOperationType,
			TrackedEntityId,
			TrackedEntityRecordId,
			Description,
			ChangeDateUTC
		)
		SELECT
			@ChangeHistoryId,
			@ChangeOperationType,
			@TrackedEntityId,
			@TrackedEntityRecordId,
			@Description,
			@ChangeDateUTC
	END	
RETURN  
GO  