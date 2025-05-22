CREATE DATABASE С#;
GO

USE С#;
GO

CREATE TABLE Role_u (
    RoleID INT PRIMARY KEY IDENTITY (1,1),
    Role_name VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Users (
    User_ID INT PRIMARY KEY IDENTITY (1,1),
	Name_u VARCHAR(50) NOT NULL,
	Surname VARCHAR(50) NOT NULL,
	Lastname VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Password_u  VARCHAR(50) NOT NULL,
	phone_number varchar(12) NOT NULL CHECK(LEN(phone_number) = 11),
	Address_u VARCHAR(100) NOT NULL,
	Bank_card VARCHAR(16) NOT NULL CHECK(LEN(Bank_card) = 16),
	RoleID INT NOT NULL,
	FOREIGN KEY (RoleID) REFERENCES Role_u(RoleID),
	UNIQUE (Email)
);
GO

CREATE TABLE Categories (
    Category_ID INT PRIMARY KEY IDENTITY (1,1),
    Category_name VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Product_t (
    Product_ID INT PRIMARY KEY IDENTITY (1,1),
    Category_ID INT NOT NULL,
	FOREIGN KEY (Category_ID) REFERENCES Categories(Category_ID),
    name_p VARCHAR(50) NOT NULL,
	Size VARCHAR(50) NOT NULL,
	Description_p VARCHAR(50) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	Stock_quantity INT NOT NULL
);
GO

CREATE TABLE Status_order(
    Status_order_ID INT PRIMARY KEY IDENTITY (1,1),
    Status_name VARCHAR(10)NOT NULL,
    Status_descriotion VARCHAR(50)NOT NULL,
);
GO

CREATE TABLE Payment_Method(
    Payment_method_ID INT PRIMARY KEY IDENTITY (1,1),
    Method_name VARCHAR(50)NOT NULL UNIQUE
);
GO

CREATE TABLE Reviews(
    Review_ID INT PRIMARY KEY IDENTITY (1,1),
	User_ID INT NOT NULL,
	FOREIGN KEY (User_ID) REFERENCES Users(User_ID),
	Product_ID INT NOT NULL,
	FOREIGN KEY (Product_ID) REFERENCES Product_t(Product_ID),
	Rating INT NOT NULL CHECK(Rating > 0 and Rating < 6),
	Review_Date DATE  NOT NULL,
	Comment VARCHAR(50) NOT NUll
);
GO

CREATE TABLE Orders(
    Order_ID INT PRIMARY KEY IDENTITY (1,1),
	User_ID INT NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES Users(User_ID),
	Product_ID INT NOT NULL,
    FOREIGN KEY (Product_ID) REFERENCES Product_t(Product_ID),
    Order_Date  DATE  NOT NULL, 
    Quantity INT NOT NULL,
    Status_order_ID INT NOT NULL,
    FOREIGN KEY (Status_order_ID) REFERENCES Status_order(Status_order_ID)
);
GO

CREATE TABLE Payments(
    Payment_ID INT PRIMARY KEY IDENTITY (1,1),
	Order_ID INT NOT NULL,
    FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID),
	Payment_method_ID INT NOT NULL,
    FOREIGN KEY (Payment_method_ID) REFERENCES Payment_Method(Payment_method_ID),
    Payment_status  VARCHAR(50)NOT NULL,
    Payment_date DATE  NOT NULL
);
GO

INSERT INTO Role_u (Role_name) VALUES 
('Admin'),
('Customer'),
('Manager');
GO

SELECT * FROM Role_u;
GO

INSERT INTO Users (Name_u, Surname, Lastname, Email, Password_u, phone_number, Address_u, Bank_card, RoleID) VALUES 
('Иван', 'Иванов', 'Иванович', 'ivan@mail.com', 'pass123', '79001234567', 'ул. Ленина, 10', '1234567812345678', 1),
('Петр', 'Петров', 'Петрович', 'petr@mail.com', 'qwerty', '79007654321', 'ул. Пушкина, 5', '8765432187654321', 2),
('Сергей', 'Сидоров', 'Сергеевич', 'sergey@mail.com', 'asdfgh', '79005556677', 'ул. Гагарина, 15', '1122334455667788', 2);
GO

SELECT * FROM Users;
GO

INSERT INTO Categories (Category_name) VALUES 
('Одежда'),
('Обувь'),
('Аксессуары');
GO

SELECT * FROM Categories;
GO


INSERT INTO Product_t (Category_ID, name_p, Size, Description_p, Price, Stock_quantity) VALUES 
(1, 'Футболка', 'L', 'Хлопковая футболка', 1500.00, 50),
(2, 'Кроссовки', '42', 'Спортивные кроссовки', 5000.00, 30),
(3, 'Ремень', 'M', 'Кожаный ремень', 2500.00, 20);
GO

SELECT * FROM Product_t;
GO


INSERT INTO Status_order (Status_name, Status_descriotion) VALUES 
('Новый', 'Заказ создан'),
('В работе', 'Заказ в обработке'),
('Доставка', 'Заказ в пути');
GO

SELECT * FROM Status_order;
GO

INSERT INTO Payment_Method (Method_name) VALUES 
('Карта'),
('Наличные'),
('Онлайн-платеж');
GO

SELECT * FROM Payment_Method;
GO

INSERT INTO Reviews (User_ID, Product_ID, Rating, Review_Date, Comment) VALUES 
(2, 1, 5, '2023-01-15', 'Отличная футболка!'),
(3, 2, 4, '2023-01-20', 'Хорошие кроссовки, но маломерят'),
(2, 3, 3, '2023-02-01', 'Нормальный ремень, но дорогой');
GO

SELECT * FROM Reviews;
GO

INSERT INTO Orders (User_ID, Product_ID, Order_Date, Quantity, Status_order_ID) VALUES 
(2, 1, '2023-01-10', 2, 1),
(3, 2, '2023-01-18', 1, 2),
(2, 3, '2023-01-25', 1, 3);
GO

SELECT * FROM Orders;
GO

INSERT INTO Payments (Order_ID, Payment_method_ID, Payment_status, Payment_date) VALUES 
(1, 1, 'Оплачено', '2023-01-10'),
(2, 3, 'Оплачено', '2023-01-18'),
(3, 2, 'Ожидание', '2023-01-25');
GO

SELECT * FROM Payments;
GO


DROP TABLE Payments
GO

DROP TABLE Orders
GO

DROP TABLE Reviews
GO

DROP TABLE Payment_Method
GO

DROP TABLE Status_order
GO

DROP TABLE Product_t
GO

DROP TABLE Categories
GO

DROP TABLE Users
GO

DROP TABLE Role_u
GO

USE master
GO 

DROP DATABASE С#;
GO