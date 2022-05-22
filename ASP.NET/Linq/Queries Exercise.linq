<Query Kind="Program">
  <Connection>
    <ID>a60d4801-cc39-4de6-b9d4-0fcc5c2881f1</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>GroceryList</Database>
  </Connection>
</Query>

void Main()
{
//Create a product list which indicates what products are purchased by our customers
//and how many times that product was purchased. Order the list by most popular
//product then by alphabetic description.
	//Query 1
	
	var Query1 = Products
		.OrderByDescending(x => x.OrderLists.Count)
		.ThenBy(x => x.Description)
		
		.Select(x => new
		{
			Products = x.Description,
			TimesPurchased = x.OrderLists.Count
		});
		Query1.Dump();
		
//We want a mailing list for a Valued Customers flyer that is being sent out. 
//List the customer addresses for customers who have shopped at each store. List by the store. 
//Include the store location as well as the customer's address. Do NOT include the customer name in the results.

	//Query 2		
	var Query2 = Stores
		.OrderBy(x => x.Location)
		.Select(x => new
		{
			Location = x.Location,
			Clients = x.Orders
						.Select(y => new
						{
							Address = y.Customer.Address,
							City = y.Customer.City,
							Provice = y.Customer.Province
						}).Distinct()
		});
	Query2.Dump();
	
	
//Create a Daily Sales per Store request for a specified month.
//Order stores by city by location. For Sales, show order date, 
//number of orders, total sales without GST tax and total GST tax.
//Query 3
	
	var Query3 = Stores
		.OrderBy(x => x.City)
		.ThenBy(x => x.Location)
		.Select(x => new
		{
			City = x.City,
			Location = x.Location,
			Sales = x.Orders
						
						.Where(x => x.OrderDate >= DateTime.Parse("2017-12-1") && x.OrderDate <= DateTime.Parse("2017-12-31"))
						.GroupBy(x => x.OrderDate)
						.Select(x => new
						{
							Date = x.Key,
							NumberOfOrders = x.Count(),
							ProductSales = x.Sum(x => x.SubTotal),
							GST = x.Sum(x => x.GST)
						})
		});
		
	
	Query3.Dump();
	
//Print out all product items on a requested order (use Order #33). Group by Category and order by Product Description.
//You do not need to format money as this would be done at the presentation level. Use the QtyPicked in your calculations.
//Hint: You will need to using type casting (decimal). Use of the ternary operator will help.	
	//Query 4 
	var Query4 = OrderLists
		.GroupBy(OrderList => new {OrderList.Product.Category.Description})
		.OrderBy(OrderList => OrderList.Key.Description)
		.Select(OrderListcategory => new
		{
			Category = OrderListcategory.Key.Description,
			OrderProducts = OrderListcategory
							.Where(OrderListcategory => OrderListcategory.Order.OrderID == 33) 
							.Select(OrderListcategory => new
							{
								Product = OrderListcategory.Product.Description,
								Price = OrderListcategory.Price,
								PickedQty = OrderListcategory.QtyPicked,
								Discount = OrderListcategory.Discount,
								Subtotal = (OrderListcategory.Product.Price * (decimal)OrderListcategory.QtyPicked)
														- OrderListcategory.Product.Discount,
								Tax = OrderListcategory.Product.Taxable ?
									(OrderListcategory.Product.Price * (decimal)0.05)
														: (decimal)0.00,
								ExtendedPrice = ((OrderListcategory.Product.Price * (decimal)OrderListcategory.QtyPicked)
																- OrderListcategory.Product.Discount)									
														+ (OrderListcategory.Product.Taxable ?											
																(OrderListcategory.Product.Price * (decimal)0.05) : (decimal)0.00)
								
								
							})
							
		});
		
	
	Query4.Dump();
	
//Generate a report on store orders and sales. Group this report by store.
//Show the total orders, the average order size (number of items per order) and average pre-tax revenue.
	//Query 5
	var Query5 = Stores
		.OrderBy(StoreOrder => StoreOrder.Location)
		.Select(StoreOrder => new
		{
			Location = StoreOrder.Location,
			Orders =StoreOrder.Orders.Count(),
			AvgSize = (from AvgSize in StoreOrder.Orders
						select AvgSize.OrderLists.Count).Average(),
			AvgRevenue = StoreOrder.Orders.Average(y => y.SubTotal)
		});
		
	Query5.Dump();
//List all the products a customer (use Customer #1) 
//has purchased and the number of times the product was purchased. 
//Order by number of times purchased then description.	
	//Query 6
	var Query6 = Customers
	.Where(x => x.CustomerID == 1)	
	.Select(x => new
	{
		Customer = x.LastName + " , " + x.FirstName,
		OrdersCount = x.Orders.Count(),
		Items = x.Orders
				.SelectMany(Purchased => Purchased.OrderLists, (Purchased, Lists) => new
				
				{
					Description = Lists.Product.Description,
					TimesBought = Lists.QtyOrdered
					
				})
				.OrderByDescending(Lists => Lists.TimesBought)
				.ThenBy(Lists => Lists.Description)
	});
	Query6.Dump();
}




	

