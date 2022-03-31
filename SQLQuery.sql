create database Bakery_Mangement_System

create table Items(
Item_Id int identity(1,1) primary key,
Item_Name varchar(250) not null,
Category varchar(250) not null,
Item_Price bigint not null
)

select * from Items


create table Employee(
Emp_Id int identity(1,1) primary key,
Emp_Name varchar(250) not null,
Emp_Address varchar(500) not null,
Emp_P_Num bigint not null,
Emp_City varchar(20),
Emp_Salary int not null
)

insert into Employee values ('Muhammad Sohail','House 15 North karachi',03446578234,'Karachi',45000),
                            ('Muhammad Shazil','House 67 North karachi',03766578234,'Multan',50000),
							('Haroon','street 4 main bazaar sargodha',03446578234,'Sargodha',33000)
insert into Employee values ('Muhammad ','House 15 North karachi',03446578234,'Karachi',45000),
                            ('Muhammad Ahmed','House 67 North karachi',03766578234,'Multan',50000),
							('Adeel','street 4 main bazaar sargodha',03446578234,'Sargodha',33000)
Select * from Employee

create table Supplier(
Sup_Id int identity(1,1) primary key,
Sup_Name varchar(250) not null,
Sup_Address varchar(500) ,
Sup_P_Num bigint not null,
Sup_City varchar(20),
Sup_CompanyName varchar(250) not null,
Item_Id int foreign key references Items(Item_Id)
)

insert into Supplier values ('Umer','Street-5 Gulbar',03446762382,'Larkana','Best Suppliers',7),
							('Ahmed','',03486762382,'Karachi','Dawood Suppliers',4)
insert into Supplier values ('Umer jani','Street-5 RK',03446762382,'Karachi','Good Suppliers',10),
							('Sajaad','s-56/614 Majeed',03010225403,'Islamabad','Halal Suppliers',12),
							('Sajaad','s-56/614 Majeed',03010225403,'Islamabad','Halal Suppliers',20)
Select * from Supplier

Create Table Customer(
Cus_Id int identity(1,1) primary key,
Item_Id int foreign key references Items(Item_Id),
Emp_Id int foreign key references Employee(Emp_Id),
Purchase_date datetime not null
)

Insert into Customer values (3,2,'6-27-2021')
Insert into Customer values (5,1,'8-23-2020 5:45')
select * from Customer

Create table Order_Details(
Ord_Id int identity(1,1) primary key,
Ord_Date datetime not null,
Delivery_Date datetime not null,
Bill_Amount int not null,
Item_Id int foreign key references Items(Item_Id),
Emp_Id int foreign key references Employee(Emp_Id),
Sup_Id int foreign key references Supplier(Sup_Id)
)

insert into Order_Details values ('1-22-2020','4-22-2020',4500,4,2,1),
                                 ('11-01-2019 6:45','11-11-2019 5:15',2300,34,1,2)
insert into Order_Details values ('1-21-2020','4-22-2020',4500,10,2,1),
                                 ('11-01-2019 6:45','11-11-2019 5:15',2300,34,1,2)
insert into Order_Details values ('1-21-2020','4-22-2020',4500,10,3,1)
select * from Order_Details

create table Received_By(
Rec_Id int identity(1,1) primary key,
Ord_Id int foreign key references Order_Details(Ord_Id),
Sup_Id int foreign key references Supplier(Sup_Id)
)


select Emp_Id,Total_Ordered as 'Total Orders'
from 
     (select Employee.Emp_Id,COUNT(Employee.Emp_Id) as Total_Ordered
       from Order_Details
       inner join Employee
       on Employee.Emp_Id=Order_Details.Emp_Id
       where datepart(Month,Ord_Date)  = 1
       group by Employee.Emp_Id)as t1 where Total_Ordered =
                                         (select MAX(Total_Ordered) from
                                         (select Employee.Emp_Id,COUNT(Employee.Emp_Id) as Total_Ordered
										 from Order_Details
										 inner join Employee
                                         on Employee.Emp_Id=Order_Details.Emp_Id
                                         where datepart(Month,Ord_Date)  = 1
                                         group by Employee.Emp_Id)as t1)

select Sup_Id,Total_Ordered as 'Total Orders'
from 
(select Supplier.Sup_Id,COUNT(Items.Item_Id) as Total_Ordered
from Supplier
inner join Items
on Supplier.Item_Id=Items.Item_Id
group by Items.Item_Id)as t1 where Total_Ordered =
(select min(Total_Ordered) from
(select Supplier.Sup_Id,COUNT(Items.Item_Id) as Total_Ordered
from Supplier
inner join Items
on Supplier.Item_Id=Items.Item_Id
group by Items.Item_Id)as t1)