CREATE PROCEDURE InsertSchoolClass
@ClassId tinyint,
@Local varchar(40),
@CourseId tinyint,
@TeacherId bigint,
@Shift char(1),
@StartDate date,
@EndDate date,
@StartTime time,
@EndTime time
AS
    SET IDENTITY_INSERT dbo.Class OFF
    INSERT INTO dbo.Class
    (
        Local,
        CourseId, 
        TeacherId,
        Shift,
        StartDate,
        EndDate,
        StartTime,
        EndTime
    )
    VALUES
    (
        @Local,
        @CourseId,
        @TeacherId,
        @Shift,
        @StartDate,
        @EndDate,
        @StartTime,
        @EndTime
    )
    SET IDENTITY_INSERT dbo.Class ON;