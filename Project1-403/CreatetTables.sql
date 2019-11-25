CREATE TABLE Company (
	CompanyName VARCHAR (50) NOT NULL,
	CompanyAddress VARCHAR (30) NOT NULL,
	CompanyCity VARCHAR (30) NOT NULL,
	CompanyState VARCHAR (15) NOT NULL,
	CompanyZipCode VARCHAR (9) NOT NULL,
	CompanyEmail VARCHAR (30) NOT NULL,
	CompanyPhone VARCHAR (15) NOT NULL,
	OwnerFirstName VARCHAR (30) NOT NULL,
	OwnerLastName VARCHAR (30) NOT NULL,
	CompanyDescription VARCHAR (1000) NOT NULL
	PRIMARY KEY CLUSTERED (CompanyName ASC)
	);

CREATE TABLE FoodType (
	RestFoodTypeCode VARCHAR (5) NOT NULL,
	FoodTypeDesc VARCHAR (15) NOT NULL
	PRIMARY KEY CLUSTERED (RestFoodTypeCode ASC)
	);

CREATE TABLE RestaurantType (
	RestTypeCode VARCHAR (5) NOT NULL,
	RestTypeDesc VARCHAR (15) NOT NULL
	PRIMARY KEY CLUSTERED (RestTypeCode ASC)
	);

CREATE TABLE Restaurant (
	RestCode INT IDENTITY (1,1) NOT NULL,
	RestName VARCHAR (50) NOT NULL,
	RestOverallRating DECIMAL (4,2) NOT NULL,
	RestDateFriendly BIT NULL,
	RestCleanliness DECIMAL (4,2) NULL,
	RestTypeCode VARCHAR (5) NOT NULL FOREIGN KEY REFERENCES RestaurantType(RestTypeCode),
	RestFoodTypeCode VARCHAR (5) NOT NULL FOREIGN KEY REFERENCES FoodType(RestFoodTypeCode),
	RestAvgMealPrice DECIMAL (5,2) NULL,
	RestPhone VARCHAR (15) NOT NULL,
	RestAddress VARCHAR (30) NOT NULL,
	RestCity VARCHAR (30) NOT NULL,
	RestState VARCHAR (15) NOT NULL,
	RestZipCode VARCHAR (9) NOT NULL
	PRIMARY KEY CLUSTERED (RestCode ASC)
);

CREATE TABLE Review (
	ReviewCode INT IDENTITY (1,1) NOT NULL,
	RestCode INT NOT NULL FOREIGN KEY REFERENCES Restaurant(RestCode),
	ReviewOverallRating DECIMAL (4,2) NOT NULL,
	ReviewDateFriendly BIT NULL,
	ReviewCleanliness DECIMAL (4,2) NULL,
	ReviewDate DATE NOT NULL,
	ReviewDesc VARCHAR(1000) NOT NULL
	PRIMARY KEY CLUSTERED (ReviewCode ASC)
	);