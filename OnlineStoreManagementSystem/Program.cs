using OnlineStoreManagementSystem;
using ToolBox;

#region test

#region Products

#region Clothes

// Create instances with constructors
Product p1 = new Clothes("skirt", 39.99, EnumClothes.Skirt, EnumColor.Pink);
p1.ShowContents();

#endregion

Tool.AddLine();

#region Food

// Create instances with constructors
Product p2 = new Food("Hamburger", 2.99, EnumAllergy.Pork, EnumAllergy.Beef, EnumAllergy.Sesame, EnumAllergy.Wheat, EnumAllergy.Milk);
p2.ShowContents();

#endregion

Tool.AddLine();

#region Personal care

// Create instances with constructors (no color, 1 color, 2 colors, 3 colors)
Product p3 = new PersonalCare("Body cream", 5.99, EnumPersonalCare.Body_care, EnumAllergy.Avocado, EnumAllergy.Milk);
Product p4 = new PersonalCare("Mascara", 12.99, EnumPersonalCare.Make_up, EnumColor.Black, EnumAllergy.None);
Product p5 = new PersonalCare("Nail polish", 3.99, EnumPersonalCare.Nail_care, EnumColor.Purple, EnumColor.Black, EnumAllergy.None);
Product p6 = new PersonalCare("Eyeshadow", 12.99, EnumPersonalCare.Make_up, EnumColor.Pink, EnumColor.Brown, EnumColor.Red, EnumAllergy.None);

p3.ShowContents();
Tool.AddLine();

p4.ShowContents();
Tool.AddLine();

p5.ShowContents();
Tool.AddLine(); 

p6.ShowContents();
Tool.AddLine();

#endregion

Tool.AddLine();

#endregion

Tool.AddLine();

#region Customer

// Create instances with constructors
Customer c1 = new Customer("Mickey", "Mouse", "123 Disney Lane");
Customer c2 = new Customer("Donald", "Duck", "456 Quack Street");
Customer c3 = new Customer("Goofy", "Goof", "789 Silly Circle");

c1.ShowContents();
c2.ShowContents();
c3.ShowContents();

#endregion

Tool.AddLine();



#region Managers

Tool.AddLine();

#region Product manager

// Create instances to stock the products
ProductManager productManager = new ProductManager();

// Add products
productManager.Add(p1);
productManager.Add(p2);
productManager.Add(p3);
productManager.Add(p4);
productManager.Add(p5);
productManager.Add(p6);

// Error test OK
//productManager.Add(p6);

// Count the number of registered products
Console.WriteLine($"There are {productManager.Count()} elements in the list");

// Remove products
productManager.Remove(p5.ProductId);
productManager.Remove(p6);
Console.WriteLine($"There are {productManager.Count()} elements in the list");

// Error test OK
//productManager.Remove(p6.ProductId);
//productManager.Remove(p6);

// Indexer
Console.WriteLine($"P1's name : {productManager[p1.ProductId].Name}");

// Error test OK
//Console.WriteLine($"P1's name : {productManager[p6.ProductId].Name}");

// Product factory
//productManager.AddProductStep1();

#endregion

Tool.AddLine();

#region Customer manager

// Create instances to stock the customers
CustomerManager customerManager = new CustomerManager();

// Add products
customerManager.Add(c1);
customerManager.Add(c2);
customerManager.Add(c3);

//Error test OK
//customerManager.Add(c3);

// Count the number of registered customers
Console.WriteLine($"There are {customerManager.Count} elements in the list");

// Remove products
customerManager.Remove(c2.CustomerId);
customerManager.Remove(c3);
Console.WriteLine($"There are {customerManager.Count} elements in the list");

// Error test OK
//customerManager.Remove(c2.CustomerId);
//customerManager.Remove(c3);

// Indexer
Console.WriteLine($"P1's name : {customerManager[c1.CustomerId].FirstName}");

// Error test OK
//Console.WriteLine($"P1's name : {customerManager[c2.CustomerId].FirstName}");

// Product factory
//customerManager.AddProductStep1();

#endregion

#endregion

#endregion



OrderManager orderManager = new OrderManager();
Order o1 = new Order();
orderManager.Add(o1);

orderManager.PaymentProceeded += (order) => // ce n'est pas o1 que je dois envoyer?
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Le paiment de l'order n° {order.OrderId} a effectué");
    Console.ResetColor();
};

//orderManager.Orders = [new Order(), new Order()];

orderManager.ChoosePayment(o1.OrderId);
await orderManager.Pay(o1.OrderId);


//foreach (var order in orderManager.Orders)
//{
//    orderManager.ChoosePayment(order.OrderId);
//    await orderManager.Pay(order.OrderId);


//}

while (true) ;