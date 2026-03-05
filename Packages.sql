CREATE TABLE [dbo].[Packages]
(
	[Id] INT NOT NULL PRIMARY KEY,
	driver_id INT,
	delivery_status varchar,
	attempt_timestamp datetime
)
