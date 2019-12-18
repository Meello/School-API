DROP TRIGGER IF EXISTS Trigger_Teacher
GO
CREATE TRIGGER Trigger_Teacher 
ON [Teacher]
AFTER INSERT, DELETE, UPDATE AS
BEGIN
	DECLARE @ChangeOperationType char
	DECLARE @TrackedEntityId INT = 2
	DECLARE @TrackedEntityRecordId varchar(max)
	DECLARE @Description varchar(max)
	DECLARE @ChangeDateUTC datetime2
	DECLARE @T_ChangeHistoryId varchar(max)
	DECLARE @TeacherId varchar(max)
	
	DECLARE @PropertyName varchar(20)
	DECLARE @PreviousValue varchar(max)
	DECLARE @NewValue varchar(max)

	SET @ChangeDateUTC = GETUTCDATE()	
	IF (
		EXISTS(SELECT 1 FROM INSERTED)
		AND EXISTS (SELECT 1 FROM DELETED)
		AND NOT EXISTS
			(	
			SELECT * FROM INSERTED
			INTERSECT
			SELECT * FROM DELETED
			)
		)
	BEGIN     
		SELECT @TrackedEntityRecordId = TeacherId
		FROM INSERTED
		SET @ChangeOperationType = 'U'
		SET @Description = CONCAT('The teacher ',@TrackedEntityRecordId,' was updated')
	END

	ELSE
	BEGIN
		IF (EXISTS(SELECT 1 FROM INSERTED))
		BEGIN
			SELECT @TrackedEntityRecordId = TeacherId
			FROM INSERTED
			SET @ChangeOperationType = 'I'
			SET @Description = CONCAT('The teacher ',@TrackedEntityRecordId,' was created')
		END
		IF (EXISTS (SELECT 1 FROM DELETED)) 
		BEGIN
			SELECT @TrackedEntityRecordId = TeacherId
			FROM DELETED
			SET @ChangeOperationType = 'D'
			SET @Description = CONCAT('The teacher ',@TrackedEntityRecordId,' was deleted')
		END
	END
	EXEC Procedure_ChangeHistory 
		@ChangeOperationType,
		@TrackedEntityId,
		@TrackedEntityRecordId,
		@Description,
		@ChangeDateUTC,
		@T_ChangeHistoryId OUTPUT
	
	IF (@ChangeOperationType = 'U')
	BEGIN	
		SELECT 
			@TeacherId = TeacherId
		FROM INSERTED

		IF UPDATE(Name)
		BEGIN
			SELECT @NewValue = Name FROM INSERTED
			SELECT @PreviousValue = Name FROM DELETED
			SET @PropertyName = 'Name'
			IF(@NewValue<>@PreviousValue)
			BEGIN
				EXEC Procedure_ChangeHistoryDetail
					@T_ChangeHistoryId,
					@PropertyName,
					@PreviousValue,
					@NewValue
			END
		END

		IF UPDATE(LevelId)
		BEGIN
			SELECT @NewValue = LevelId FROM INSERTED
			SELECT @PreviousValue = LevelId FROM DELETED
			SET @PropertyName = 'LevelId'
			IF(@NewValue<>@PreviousValue)
			BEGIN
				EXEC Procedure_ChangeHistoryDetail
					@T_ChangeHistoryId,
					@PropertyName,
					@PreviousValue,
					@NewValue
			END
		END

		IF UPDATE(Salary)
		BEGIN
			SELECT @NewValue = Salary FROM INSERTED
			SELECT @PreviousValue = Salary FROM DELETED
			SET @PropertyName = 'Salary'
			IF(@NewValue<>@PreviousValue)
			BEGIN
				EXEC Procedure_ChangeHistoryDetail
					@T_ChangeHistoryId,
					@PropertyName,
					@PreviousValue,
					@NewValue
			END
		END

		IF UPDATE(AdmitionDate)
		BEGIN
			SELECT @NewValue = AdmitionDate FROM INSERTED
			SELECT @PreviousValue = AdmitionDate FROM DELETED
			SET @PropertyName = 'AdmitionDate'
			IF(@NewValue<>@PreviousValue)
			BEGIN
				EXEC Procedure_ChangeHistoryDetail
					@T_ChangeHistoryId,
					@PropertyName,
					@PreviousValue,
					@NewValue
			END
		END
	END
END
GO
