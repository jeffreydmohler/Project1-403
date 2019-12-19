--Eric Louis
--403-Project 2 DB Schema

USE master;
​
IF (NOT EXISTS(SELECT name
FROM master.sys.databases
WHERE name LIKE 'RestaurantDB'))
​
BEGIN
CREATE DATABASE RestaurantDB;
​
END;
​
GO
​
USE RestaurantDB;

CREATE TABLE [RestaurantTypes](
	RestTypeCode VARCHAR(12) NOT NULL PRIMARY KEY,
	RestTypeDesc VARCHAR(50) NOT NULL
	);

INSERT INTO RestaurantTypes
VALUES('FAST', 'Fast Food'),
('SITDOWN', 'Sit Down Restaurant'),
('ORDERATBAR', 'Order At The Bar');


CREATE TABLE [FoodTypes](
	RestFoodTypeCode VARCHAR(12) NOT NULL PRIMARY KEY,
	FoodTypeDesc VARCHAR(50) NOT NULL
	);

INSERT INTO FoodTypes
VALUES
('AME', 'American'),
('KOR', 'Korean'),
('JPN', 'Japanese');

 CREATE TABLE [Restaurants](
	[RestID] INT IDENTITY NOT NULL PRIMARY KEY,
	RestName VARCHAR(50) NOT NULL,
	RestOverallRating DECIMAL NOT NULL,
	RestDateFriendly BIT NOT NULL,
	RestCleanliness DECIMAL NOT NULL,
	RestTypeCode VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES RestaurantTypes(RestTypeCode),
	RestFoodTypeCode VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES FoodTypes(RestFoodTypeCode),
	RestAvgMealPrice DECIMAL NOT NULL,
	RestPhone VARCHAR(12) NOT NULL,
	RestAddress VARCHAR(30) NOT NULL,
	RestCity VARCHAR(30) NOT NULL,
	RestState VARCHAR(15) NOT NULL,
	RestZipCode VARCHAR(12) NOT NULL
	);

CREATE TABLE [Reviews](
	ReviewCode INT IDENTITY NOT NULL PRIMARY KEY,
	RestID INT NOT NULL FOREIGN KEY REFERENCES Restaurants(RestID) ON DELETE CASCADE,
	ReviewOverallRating DECIMAL NOT NULL,
	ReviewDateFriendly BIT NOT NULL,
	ReviewCleanliness DECIMAL NOT NULL,
	ReviewDate DATETIME NOT NULL,
	ReviewDesc VARCHAR(800) NOT NULL
	);



	INSERT INTO Restaurants
	(	[RestName]
		,[RestFoodTypeCode]
		,[RestOverallRating]
		,[RestTypeCode]
		,[RestDateFriendly]
		,[RestAvgMealPrice]
		,[RestCleanliness]
		,[RestPhone]
		,[RestAddress]
		,[RestCity]
		,[RestState]
		,[RestZipCode])
	VALUES(
'Wendys',
'AME',
3,
'FAST',
0,
8,
3,
'801-377-8063',
'122 E 1230 N St',
'Provo',
'UT',
'84604'),

(

'The Corner Restaurant',
'AME',
4,
'SITDOWN',
1,
13,
5,
'801-377-8063',
'195 W Main St, Midway',
'Provo',
'UT',
'84604'),

(
'Koko Lunchbox',
'KOR',
4,
'ORDERATBAR',
1,
11,
2,
'801-850-4358',
'3420, 1175 N Canyon Rd',
'Provo',
'UT',
'84604')


	INSERT INTO Reviews(
	 [RestID]
      ,[ReviewOverallRating]
      ,[ReviewDateFriendly]
      ,[ReviewCleanliness]
      ,[ReviewDate]
      ,[ReviewDesc])
	  VALUES
	  (1, 1.5, 1, 2.2, 12/1/2019, 'OK Service'),
	  (1, 2.5, 1, 2.2, 12/2/2019, 'Sonewhat Good Service'),
	  (2, 3.5, 1, 2.2, 12/3/2019, 'Better Service'),
	  (2, 4.5, 1, 2.2, 12/4/2019, 'Getting There Service'),
	  (3, 4.0, 1, 2.2, 12/5/2019, 'Good Service'),
	  (3, 5.0, 1, 2.2, 12/6/2019, 'Great Service');

