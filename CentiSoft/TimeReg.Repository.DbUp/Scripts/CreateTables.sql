CREATE TABLE Client(
	[Id] int not null PRIMARY KEY IDENTITY(1,1), 
	[Name] varchar(50) not null, 
	[Token] nvarchar(50)
);

CREATE TABLE Customer(
	[Id] int not null PRIMARY KEY IDENTITY(1,1), 
	[Name] varchar(50) not null, 
	[Address] nvarchar(50), 
	[Address2] nvarchar(50), 
	[Zip] nvarchar(10), 
	[City] nvarchar(50), 
	[Country] nvarchar(50), 
	[Email] nvarchar(100), 
	[Phone] nvarchar(20), 
	[ClientId] int foreign key references Client(Id)
);

CREATE TABLE Developer(
	[Id] int not null PRIMARY KEY IDENTITY(1,1), 
	[Name] varchar(50) not null, 
	[Email] nvarchar(100)
);
	

CREATE TABLE Project(
	[Id] int not null PRIMARY KEY IDENTITY(1,1), 
	[Name] varchar(50) not null, 
	[DueDate] datetime, 
	[CustomerId] int foreign key references Customer(Id)
);

CREATE TABLE Task(
	[Id] int not null PRIMARY KEY IDENTITY(1,1), 
	[Name] nvarchar(50) not null, 
	[Description] nvarchar(max), 
	[Duration] decimal(10, 2),
	[Created] datetime not null,
	[ProjectId] int foreign key references Project(Id), 
	[DeveloperId] int foreign key references Developer(Id)
);
