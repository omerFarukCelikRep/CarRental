Create Database CarRental
Create Table CarColors
(
	CarColorID		int				Not Null	Primary Key	Identity(1,1)
	,CarColorName	nvarchar(20)	Not Null
);

Create Table Brands
(
	BrandID		int				Not Null	Primary Key	Identity(1,1)
	,BrandName	nvarchar(30)	Not Null
);

Create Table Cars
(
	CarID			int				Not Null	Primary Key	Identity(1,1)
	,BrandID		int				Not Null	references Brands(BrandID)
	,CarColorID		int				Not Null	references CarColors(CarColorID)
	,ModelYear		int				Not Null
	,DailyPrice		money			Not Null
	,Description	nvarchar(max)	Null
);

Insert Into Brands
Values('BMW'),('Mercedes'),('Toyota'),('Mitsubishi');

Insert Into CarColors
Values('Mavi'),('Beyaz'),('Siyah');

Insert Into Cars
Values(1,1,2020,70,'Az Yakar Çok Kaçar'),(2,1,2020,90,'Az Yakar Çok Kaçar'),(3,2,2020,120,'Az Yakar Çok Kaçar'),(3,3,2021,95,'Az Yakar Çok Kaçar'),(4,2,2021,75,'Az Yakar Çok Kaçar');

Select *
From Cars