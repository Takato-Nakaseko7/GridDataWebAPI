USE grid_data

-- Script to record data for a week

-- Declare variables
DECLARE @StartDate DATETIME;
DECLARE @EndDate DATETIME;
DECLARE @CurrentDate DATETIME;
DECLARE @NodeId INT = 1;

-- Set start and end dates (1 week duration)
SET @StartDate = Convert(DateTime, DATEDIFF(DAY, 0, GETDATE()));
SET @EndDate = DATEADD(DAY, 7, @StartDate);

-- Initialize current date to start date
SET @CurrentDate = @StartDate;

INSERT INTO Regions (RegionName) 
	   VALUES 
		('Region1'),
		('Region2'),
		('Region3');

INSERT INTO Grid (GridName, RegionId)
       VALUES
		('Grid1', 1),
		('Grid2', 2),
		('Grid3', 3);
		
INSERT INTO Nodes (NodeName, RegionId)
	   VALUES
		('Node1', 1),
		('Node2', 2),
		('Node3', 3);


WHILE @NodeId <= 3
BEGIN
	SET @CurrentDate = @StartDate

	WHILE @CurrentDate < @EndDate
	BEGIN
		DECLARE @value FLOAT = FLOOR(RAND()*(100-50+1)+50);
		DECLARE @TargetDate DATETIME = DATEADD(DAY, 1, FORMAT(@CurrentDate, 'yyyy-MM-dd 00:00:00'))
		SET @TargetDate = DATEADD(HOUR, 23, @TargetDate)
		--DECLARE @value FLOAT = 100; Uncomment for 1 by 1 decrement
		INSERT INTO Measures (NodeId, "Value", RecordTime, TargetTime)
		VALUES(@NodeID, @value, @CurrentDate, @TargetDate);

		SET @CurrentDate = DATEADD(HOUR, 1, @CurrentDate);
		
		--SET @value = @value - 1; Uncomment for 1 by 1 decrement
	END;
	SET @NodeId = @NodeId + 1;
END;