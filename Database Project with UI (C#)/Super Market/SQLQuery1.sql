insert into Admin
values (2323,null,null,'hesham','abdelatty',null,'adimn',21/5/2020,'01065131189','cairo','maadi','zidan','male','h.ahemd','password')
insert into Empolyee
values (23232,22,null,'hesham','abdelatty',null,'adimn',21/5/2020,'01065131189','cairo','maadi','zidan','male')
insert into Branche
values (22,'cairo','maadi','zidan','Egypt','01010101010')

select userName,password from Admin
Union
select * from Customer

update Product set P_name = '',p_Scale = ''

select *from Product

insert into Product
values (2209,55,77,'mobile','piece',5,2000)

select * from Product where P_name like '%%'
 
select * from Product where P_ID not in(select P_ID from [Order],OrderDetails where O_date like '%_6-%')

insert into [Order]
values (1107,5252,'18-12-15 ','Delivery')

select * from Customer where Cust_ID not in ( select Customer.Cust_ID from [Order],Customer where Customer.Cust_ID = [Order].Cust_ID And O_date like '%_21%')

insert into OrderDetails
values (2209,1107,2,4000)


 select top 1 count(*)
 from [order],OrderDetails 
 where [order].O_id = OrderDetails.O_id  
 group by P_ID
 order by count(*)desc


select * 
from Customer
insert into Customer
values (2202,88,77,'pepsi','cane',223,7)


 select * from Product where P_ID in (select top 1 P_ID from [order] ,OrderDetails where [order].O_id = OrderDetails.O_id group by P_ID order by count(*)desc) 


 select top 1 count(*)
 from [order],OrderDetails 
 where [order].O_id = OrderDetails.O_id  
 group by P_ID
 order by count(*)desc

select * from Customer,[Order] where Customer.Cust_ID = [Order].Cust_ID And [Order].O_id in ( 
select top 1 OrderDetails.O_id from  OrderDetails, [Order] 
where [Order].O_id = OrderDetails.O_id
group by OrderDetails.O_id order by Sum(Price)desc) 

 
 select product.*, count(b.NumOfCustomers)as numOfCustomers
from Product ,(select P_ID as NumOfCustomers from [order] ,OrderDetails where [order].O_id = OrderDetails.O_id   )as b
 where Product.P_ID in 
 (select  P_ID 
 from [order] ,OrderDetails 
 where [order].O_id = OrderDetails.O_id ) And b.NumOfCustomers = P_ID
 group by Product.P_ID,Product.P_name,Product.P_scale,Product.quantity_in_store,Product.buy_price,Product.C_ID,Product.S_ID



 select top 1 Category.C_ID,Category.C_name,Category.D_ID ,sum(quantity) as NumOfSold 
 from (select Product.*,quantity from OrderDetails,Product where OrderDetails.P_ID = Product.P_ID)as f,Category 
 where f.C_ID = Category.C_ID group by Category.C_ID,Category.C_name,Category.D_ID order by NumOfSold desc


 select Customer.*,c as numberOfOreders
 from Customer ,(select Customer.Cust_ID ,COUNT(*)as c from Customer ,[Order]
 where Customer.Cust_ID = [Order].Cust_ID
 group by Customer.Cust_ID)as t
 where Customer.Cust_ID = t.Cust_ID and c>=2
 select * from Product where P_name like '%c%'


 select *from Supplier

select *from Category
select *from Department
select *from Product where quantity_in_store = 0
select *from [Order]
select *from OrderDetails
select *from Customer
update Customer set
Cust_fname='',Cust_lname ='',cust_city ='',cust_street= '',cust_state='',cust_userName='',cust_pasword='',cust_gender=''
where Cust_ID = 0

select * from Customer,[Order] where Customer.Cust_ID = [Order].Cust_ID And [Order].O_id in (select top 1 OrderDetails.O_id from  OrderDetails, [Order]  where [Order].O_id = OrderDetails.O_id group by OrderDetails.O_id order by Sum(Price)desc)