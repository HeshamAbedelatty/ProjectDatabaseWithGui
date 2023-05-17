/*
	The 6 Queries in the project
*/
/*
	a-> The most Bought Product
*/
select * from Product where P_ID in 
(select top 1 P_ID from [order] ,OrderDetails where [order].O_id = OrderDetails.O_id group by P_ID order by count(*)desc) 
/*
	b-> Products are that has no customer in specific Month. "like June '6'"
	Note: the month is enterd by user....!!!!!!!!!!!!!!!!!!!!
*/
select * 
from Product 
where P_ID not in
(select P_ID from [Order],OrderDetails where O_date like '%_6-%')

/*
	c-> The customer who did not buy any product since 1 Year
*/
select * 
from Customer 
where Cust_ID not in 
( select Customer.Cust_ID from [Order],Customer where Customer.Cust_ID = [Order].Cust_ID And O_date like '2022-%')

/*
	d-> The customer who has the highest Purchase 
*/
select * 
from Customer,[Order] 
where Customer.Cust_ID = [Order].Cust_ID 
And [Order].O_id in 
(select top 1 OrderDetails.O_id from  OrderDetails, [Order]  where [Order].O_id = OrderDetails.O_id group by OrderDetails.O_id order by Sum(Price)desc)

/*
	e-> Which category is selling more 
*/
select top 1 Category.C_ID,Category.C_name,Category.D_ID ,sum(quantity) as NumOfSold 
 
 from (select Product.*,quantity from OrderDetails,Product where OrderDetails.P_ID = Product.P_ID)as f , Category 
 
 where f.C_ID = Category.C_ID group by Category.C_ID,Category.C_name,Category.D_ID order by NumOfSold desc


 /*
	f-> All products information and the number of customer who bought it 
*/
 
 select Product.P_ID,C_ID,S_ID,P_name,P_scale,quantity_in_store,buy_price,NumOFCustomer
from Product left join 
(select P_ID  , Count (*)as NumOFCustomer from [order] ,OrderDetails where [order].O_id = OrderDetails.O_id group by P_ID )as b
on Product.P_ID = b.P_ID


