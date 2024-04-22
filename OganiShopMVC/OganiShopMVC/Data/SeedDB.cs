using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Data
{
    public class SeedDB
    {
        //public static void SeedData(ApplicationDbContext context)
        //{
        //    if (context.Products.Count() <= 0)
        //    {
        //        var Product1 = new Product()
        //        {
        //            id = 1,
        //            CategoryId = 1,
        //            Name = "MEAT",
        //            Description = "Presh Beef",
        //            Image = "product-1.jpg",
        //            Price = 200,
        //            Rating = 1,
        //            Quantity = 20,
        //            CreatedDate = DateTime.Now


        //        };
        //        var Product2 = new Product()
        //        {
        //            id = 2,
        //            CategoryId = 2,
        //            Name = "PRESH FRUIT",
        //            Description = "Banana",
        //            Image = "product-2.jpg",
        //            Price = 50,
        //            Rating = 2,
        //            Quantity = 10,
        //            CreatedDate = DateTime.Now
        //        };
        //        var Product3 = new Product()
        //        {
        //            id = 3,
        //            CategoryId = 3,
        //            Name = "PRESH FRUIT",
        //            Description = "grape",
        //            Image = "product-4.jpg",
        //            Price = 100,
        //            Rating = 6,
        //            Quantity = 100,
        //            CreatedDate = DateTime.Now

        //        };
        //        var Product4 = new Product()
        //        {
        //            id = 4,
        //            CategoryId = 4,
        //            Name = "Fast Food",
        //            Description = "Burger",
        //            Image = "product-5.jpg",
        //            Price = 250,
        //            Rating = 3,
        //            Quantity = 50,
        //            CreatedDate = DateTime.Now

        //        };
        //        var Product5 = new Product()
        //        {
        //            id = 5,
        //            CategoryId = 2,
        //            Name = "Xoai",
        //            Description = "Xoai ngot",
        //            Image = "product-6.jpg",
        //            Price = 50,
        //            Rating = 7,
        //            Quantity = 50,
        //            CreatedDate = DateTime.Now

        //        };
        //        var Product6 = new Product()
        //        {

        //            id = 6,
        //            CategoryId = 3,
        //            Name = "Dua hau",
        //            Description = "Dua hau",
        //            Image = "product-7.jpg",
        //            Price = 100,
        //            Rating = 10,
        //            Quantity = 30,
        //            CreatedDate = DateTime.Now

        //        };
        //        var Product7 = new Product()
        //        {

        //            id = 7,
        //            CategoryId = 1,
        //            Name = "Tao",
        //            Description = "Tao ngon vcl",
        //            Image = "product-8.jpg",
        //            Price = 150,
        //            Rating = 6,
        //            Quantity = 100,
        //            CreatedDate = DateTime.Now

        //        };
        //        var Product8 = new Product()
        //        {


        //            id = 8,
        //            CategoryId = 4,
        //            Name = "Ga ran",
        //            Description = "Ga ran ngon",
        //            Image = "product-10.jpg",
        //            Price = 300,
        //            Rating = 5,
        //            Quantity = 100,
        //            CreatedDate = DateTime.Now
        //        };
        //        var Product9 = new Product()
        //        {

        //            id = 9,
        //            CategoryId = 1,
        //            Name = "Nuoc cam",
        //            Description = "Nuoc cam ngon",
        //            Image = "product-11.jpg",
        //            Price = 200,
        //            Rating = 10,
        //            Quantity = 100,
        //            CreatedDate = DateTime.Now
        //        };
        //        var Product10 = new Product()
        //        {

        //            id = 10,
        //            CategoryId = 3,
        //            Name = "Hoa qua say",
        //            Description = "hoa qua say ngon",
        //            Image = "product-12.jpg",
        //            Price = 200,
        //            Rating = 11,
        //            Quantity = 50,
        //            CreatedDate = DateTime.Now
        //        };


        //        context.Products.Add(Product1);
        //        context.Products.Add(Product2);
        //        context.Products.Add(Product3);
        //        context.Products.Add(Product4);
        //        context.Products.Add(Product5);
        //        context.Products.Add(Product6);
        //        context.Products.Add(Product7);
        //        context.Products.Add(Product8);
        //        context.Products.Add(Product9);
        //        context.Products.Add(Product10);

        //        context.SaveChanges();
        //    }
        //    //if (context.GetOderDetails.Count() <= 0)
        //    //{
        //    //    var OderDetail1 = new OderDetail()
        //    //    {

        //    //        ProductId = 1,
        //    //        Price = 200,
        //    //        Quantity = 20,
        //    //        CreatedDate = DateTime.Now

        //    //    };
        //    //    var OderDetail2 = new OderDetail()
        //    //    {

        //    //        ProductId = 2,
        //    //        Price = 50,
        //    //        Quantity = 10,
        //    //        CreatedDate = DateTime.Now
        //    //    };
        //    //    var OderDetail3 = new OderDetail()
        //    //    {

        //    //        ProductId = 1,
        //    //        Price = 100,
        //    //        Quantity = 100,
        //    //        CreatedDate = DateTime.Now

        //    //    };
        //    //    var OderDetail4 = new OderDetail()
        //    //    {

        //    //        ProductId = 1,
        //    //        Price = 250,
        //    //        Quantity = 50,
        //    //        CreatedDate = DateTime.Now

        //    //    };


        //    //    context.GetOderDetails.Add(OderDetail1);
        //    //    context.GetOderDetails.Add(OderDetail2);
        //    //    context.GetOderDetails.Add(OderDetail3);
        //    //    context.GetOderDetails.Add(OderDetail4);

        //    //    context.SaveChanges();
        //    //}
        //    if (context.News.Count() <= 0)
        //    {
        //        var News1 = new New()
        //        {

        //            Title = "6 ways to prepare breakfast ",
        //            Description = "Breakfast is essential for health",
        //            Image = "blog-2.jpg",
        //            CreatedDate = DateTime.Now

        //        };
        //        var News2 = new New()
        //        {

        //            Title = "Visit the clean farm in the US",
        //            Description = "How farms in America produce safe and healthy food",
        //            Image = "blog-3.jpg",
        //            CreatedDate = DateTime.Now
        //        };
        //        var News3 = new New()
        //        {

        //            Title = "6 ways to prepare breakfast ",
        //            Description = "Breakfast is essential for health",
        //            Image = "blog-1.jpg",
        //            CreatedDate = DateTime.Now

        //        };
        //        var News4 = new New()
        //        {

        //            Title = "6 ways to prepare breakfast ",
        //            Description = "Breakfast is essential for health",
        //            Image = "blog-4.jpg",
        //            CreatedDate = DateTime.Now

        //        };
        //        var News5 = new New()
        //        {

        //            Title = "6 ways to prepare breakfast ",
        //            Description = "Breakfast is essential for health",
        //            Image = "blog-4.jpg",
        //            CreatedDate = DateTime.Now

        //        };
        //        var News6 = new New()
        //        {

        //            Title = "6 ways to prepare breakfast ",
        //            Description = "Breakfast is essential for health",
        //            Image = "blog-4.jpg",
        //            CreatedDate = DateTime.Now

        //        };


        //        context.News.Add(News1);
        //        context.News.Add(News2);
        //        context.News.Add(News3);
        //        context.News.Add(News4);
        //        context.News.Add(News5);
        //        context.News.Add(News6);

        //        context.SaveChanges();
        //    }
        //    //if (context.Categorys.Count() <= 0)
        //    //{

        //    //    var Category1 = new Category()
        //    //    {
        //    //        id = 1,
        //    //        CategoryName = "fruit",
        //    //    };
        //    //    var Category2 = new Category()
        //    //    {
        //    //        id = 2,
        //    //        CategoryName = "Fresh Meat",
        //    //    };
        //    //    var Category3 = new Category()
        //    //    {
        //    //        id = 3,
        //    //        CategoryName = "Organic food",
        //    //    };
        //    //    var Category4 = new Category()
        //    //    {
        //    //        id = 4,
        //    //        CategoryName = " Fastfood",
        //    //    };

        //    //    context.Categorys.Add(Category1);
        //    //    context.Categorys.Add(Category2);
        //    //    context.Categorys.Add(Category3);
        //    //    context.Categorys.Add(Category4);



        //    //    context.SaveChanges();
        //    //}
        //}
    }
}

