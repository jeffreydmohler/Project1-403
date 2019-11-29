drop table Users;

CREATE TABLE Users (
	UserEmail VARCHAR (50) NOT NULL,
	UserFName VARCHAR (15) NOT NULL,
	UserLName VARCHAR (20) NOT NULL,
	UserPassword VARCHAR (20) NOT NULL,
	ComparePassword VARCHAR (20) NOT NULL
	PRIMARY KEY CLUSTERED (UserEmail ASC)
	);