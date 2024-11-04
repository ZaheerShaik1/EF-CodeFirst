//using System.Diagnostics;
//using System.Net.Http.Headers;
//using System.Linq;

//namespace EFCodeFirst
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            using (EFCodeFirstContext context = new EFCodeFirstContext())
//            {
//                //Console.WriteLine("Enter the Food item ");
//                //string input = Console.ReadLine();

//                //Product product = new Product()
//                //{
//                //    Name = input,
//                //    Price = 120.34M

//                //};

//                //context.Products.Add(product);
//                //context.SaveChanges();



//                Console.WriteLine("All Products");

//                foreach(var item in context.Products)
//                {
//                    Console.WriteLine($"Id : {item.Id}, Name :{item.Name}, Price :{item.Price}\n");

//                }
//            }
//        }
//    }
//}
using EFCodeFirst;
using System.Net.Http.Headers;
using EFCodeFirstContext context = new EFCodeFirstContext();

//var products = context.Products
//                .Where(p=>p.Price<120.00M)
//                .OrderBy(p =>p.Name);   fluent api
var pizza = context.Products
            .Where (p => p.Name == "Veggie Special Pizza")
            .FirstOrDefault ();
if(pizza is Product)
{
    pizza.Price = 80.56M;
}
context.SaveChanges();

var deleteItem = context.Products
            .Where(p => p.Name == "Veggie Special Pizza")
            .FirstOrDefault();
if (deleteItem is Product)
{
    context.Remove(deleteItem);
}
context.SaveChanges();


var updatedprice = context.Products.FirstOrDefault(p => p.Name == "Burger");
if(updatedprice != null)
{
    updatedprice.Price = 210;
    context.SaveChanges();
    Console.WriteLine($"The updated price of Burger is : {updatedprice.Price}");
}


var products = from product in context.Products
               where product.Price > 100
               orderby product.Name
               select product;

// similar to sql --> linq (language integrated query)


foreach (var p in products)
{
    Console.WriteLine($"Id : {p.Id}, Name : {p.Name}, Price : {p.Price}");
    Console.WriteLine(new string('-',20));
 
}