using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BreadsBakery.Models;


namespace BreadsBakery
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
               .AddDbContext<BreadsBakeryDbContext>(options =>
                   options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            var context = app.ApplicationServices.GetService<BreadsBakeryDbContext>();
            AddTestData(context);

            app.UseStaticFiles();
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
            app.Run(async (error) =>
            {
                await error.Response.WriteAsync("You should not see this message. An error has occured.");
            });
        }

        private static void AddTestData(BreadsBakeryDbContext context)
        {
            context.Database.ExecuteSqlCommand("Delete From CateringProducts");
            context.Database.ExecuteSqlCommand("Delete From StoreProducts");
            context.Database.ExecuteSqlCommand("Delete From Departments");
            context.Database.ExecuteSqlCommand("Delete From Users");

            //Add deparments to database

            var department1 = new Department();
            department1.Name = "Kitchen";
            context.Departments.Add(department1);

            var department2 = new Department();
            department2.Name = "Cake";
            context.Departments.Add(department2);

            var department3 = new Department();
            department3.Name = "Pastry";
            context.Departments.Add(department3);

            var department4 = new Department();
            department4.Name = "Bread";
            context.Departments.Add(department4);

            var department5 = new Department();
            department5.Name = "Cafe";
            context.Departments.Add(department5);

            //Add storeProducts to database
           
            var storeProduct1 = new StoreProduct();
            storeProduct1.Name = "Cheese Straws";
            storeProduct1.Description = "A puff pastery stick with three different cheeses.";
            storeProduct1.ImageUrl = "Kitchen";
            storeProduct1.Price = 1;
            storeProduct1.Category = "SavoryPastry";
            storeProduct1.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct1);

            var storeProduct2 = new StoreProduct();
            storeProduct2.Name = "Chocolate Babka";
            storeProduct2.Description = "Chocolate Babka is a sweet, swirly, brioche-meets-cake loaf rooted in Eastern European Jewish traditions.";
            storeProduct2.ImageUrl = "Kitchen";
            storeProduct2.Price = 12;
            storeProduct2.Category = "SweetPastry";
            storeProduct2.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct2);

            var storeProduct3 = new StoreProduct();
            storeProduct3.Name = "Passion Fruit Concord Cake ";
            storeProduct3.Description = "Passion Fruit Concord Cake";
            storeProduct3.ImageUrl = "https://www.instagram.com/p/BStoJbylkx8/?hl=en";
            storeProduct3.Price = 20;
            storeProduct3.Category = "Cake";
            storeProduct3.DepartmentId = department2.DepartmentId;
            context.StoreProducts.Add(storeProduct3);

            var storeProduct4 = new StoreProduct();
            storeProduct4.Name = "Matzo Soup";
            storeProduct4.Description = "Matzah balls are an Ashkenazi Jewish soup dumpling made from a mixture of matzah meal, eggs, water, and a fat, such as oil, margarine, or chicken fat. Matzah balls are traditionally served in chicken soup.";
            storeProduct4.ImageUrl = "https://www.instagram.com/p/BSeceYSlem5/?taken-by=breadsbakery&hl=en";
            storeProduct4.Price = 4;
            storeProduct4.Category = "Soup";
            storeProduct4.DepartmentId = department1.DepartmentId;
            context.StoreProducts.Add(storeProduct4);

            var storeProduct5 = new StoreProduct();
            storeProduct5.Name = "Foccacia";
            storeProduct5.Description = "Focaccia is a flat oven-baked Italian bread product similar in style and texture to pizza doughs. It may be topped with herbs or other ingredients";
            storeProduct5.ImageUrl = "https://www.instagram.com/p/BSJrRMmgJqD/?taken-by=breadsbakery&hl=en";
            storeProduct5.Price = 4;
            storeProduct5.Category = "Bread";
            storeProduct5.DepartmentId = department4.DepartmentId;
            context.StoreProducts.Add(storeProduct5);


            //Add CateringProducts to database
   
        var cateringProduct1 = new CateringProduct();
            cateringProduct1.Name = "Mini Sandwiches";
            cateringProduct1.Description = "Tuna Salad & Hard-Boiled Egg; Gouda & Vegetable; Freshly Made Egg Salad & Tomato; Smoked Salmon & Cream Cheese.";
            cateringProduct1.ImageUrl = "Kitchen";
            cateringProduct1.Price = 72;
            cateringProduct1.ServingSize = "16 Pieces";
            cateringProduct1.Category = "Breakfast";
            cateringProduct1.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct1);

            var cateringProduct2 = new CateringProduct();
            cateringProduct2.Name = "Mini Pastry Assortment";
            cateringProduct2.Description = "Assortment of Croissant, Pain Au Chocolate, and Pain Au Raisin.";
            cateringProduct2.ImageUrl = "Kitchen";
            cateringProduct2.Price = 38;
            cateringProduct2.ServingSize = "15 Pieces";
            cateringProduct2.Category = "Breakfast";
            cateringProduct2.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct2);

            var cateringProduct3 = new CateringProduct();
            cateringProduct3.Name = "Tuna and Vegetable Salad";
            cateringProduct3.Description = "Homemade Tuna Salad with Mixed Greens, Tomato, Cucumber, Red Onion, Hard Boiled Egg & Kalamata Olives.";
            cateringProduct3.ImageUrl = "https://www.instagram.com/p/BStoJbylkx8/?hl=en";
            cateringProduct3.Price = 39;
            cateringProduct3.ServingSize = "64 oz";
            cateringProduct3.Category = "Lunch";
            cateringProduct3.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct3);

            var cateringProduct4 = new CateringProduct();
            cateringProduct4.Name = "Crudite Platter";
            cateringProduct4.Description = "Variety of Fresh, Seasonal Vegetables from The Union Square Greenmarket, Including Cherry Tomato, Cucumber, Carrot, Red Pepper, Baby Radish Served with A Sour Cream & Chive Dip. ";
            cateringProduct4.ImageUrl = "https://www.instagram.com/p/BSeceYSlem5/?taken-by=breadsbakery&hl=en";
            cateringProduct4.Price = 44;
            cateringProduct4.ServingSize = "2.2 lbs";
            cateringProduct4.Category = "Lunch";
            cateringProduct4.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct4);

            var cateringProduct5 = new CateringProduct();
            cateringProduct5.Name = "Cheese Straw Bites";
            cateringProduct5.Description = "A Bite Size Version of Our Famous Cheese Straws.";
            cateringProduct5.ImageUrl = "https://www.instagram.com/p/BSJrRMmgJqD/?taken-by=breadsbakery&hl=en";
            cateringProduct5.Price = 38;
            cateringProduct5.ServingSize = "65 pieces";
            cateringProduct5.Category = "Appetizers";
            cateringProduct5.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct5);

            var cateringProduct6 = new CateringProduct();
            cateringProduct6.Name = "Rugelach Platter";
            cateringProduct6.Description = "Delicious Chocolate Rugelach. ";
            cateringProduct6.ImageUrl = "https://www.instagram.com/p/BSeceYSlem5/?taken-by=breadsbakery&hl=en";
            cateringProduct6.Price = 41;
            cateringProduct6.ServingSize = "24 pieces";
            cateringProduct6.Category = "Desserts";
            cateringProduct6.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct6);

            var cateringProduct7 = new CateringProduct();
            cateringProduct7.Name = "Danish Tartlet Platter";
            cateringProduct7.Description = "Marzipan, Crème Patisserie Filling and Fresh Seasonal Fruit.";
            cateringProduct7.ImageUrl = "https://www.instagram.com/p/BSJrRMmgJqD/?taken-by=breadsbakery&hl=en";
            cateringProduct7.Price = 71;
            cateringProduct7.ServingSize = "16 pieces";
            cateringProduct7.Category = "Desserts";
            cateringProduct7.DepartmentId = department2.DepartmentId;
            context.CateringProducts.Add(cateringProduct7);



            var user1 = new User( );
            user1.FirstName = "Keely";
            user1.LastName = "Glenn";
            user1.CompanyName = "Epicodus";
            context.Users.Add(user1);

            context.SaveChanges();
        }
    }
}