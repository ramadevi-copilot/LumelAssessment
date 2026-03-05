CREATE PROCEDURE [dbo].[GetReliableDrivers]
AS
BEGIN
	
	DECLARE @SeptemberDeliverables INT


	select Id,driver_id,count(1) As Cnt into #DeliverableRate from Packages 
	WHERE MONTH(attempt_timestamp)=09 and YEAR(attempt_timestamp)=2024 
	GROUP BY driver_id
	having count(1) > 5

	select * into #DeliverablePercentage from  
	(
		select Id,driver_id,case when delivery_status='Completed' THEN 1 else 0 As Cnt from Packages 
		WHERE MONTH(attempt_timestamp)=09 and YEAR(attempt_timestamp)=2024 and delivery_status='Completed'
		GROUP BY driver_id
		having count(1) > 90
	)a

	select driver_id,count(1) over() from Packages 
	WHERE driver_id in (select driver_id from #DeliverablePercentage)
	AND driver_id in (select driver_id from #DeliverablePercentage)	
	group by driver_id 

END
