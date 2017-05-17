using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BreadsBakery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


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
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<BreadsBakeryDbContext>()
             .AddDefaultTokenProviders();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            var context = app.ApplicationServices.GetService<BreadsBakeryDbContext>();
            AddTestData(context);

            app.UseIdentity();
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
            storeProduct1.ImageUrl = "https://static.wixstatic.com/media/a4b210_16b0e50349434afc959eb3d8596e10c0~mv2.jpg";
            storeProduct1.Price = 1;
            storeProduct1.Category = "SavoryPastry";
            storeProduct1.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct1);

            var storeProduct2 = new StoreProduct();
            storeProduct2.Name = "Chocolate Babka";
            storeProduct2.Description = "Chocolate Babka is a sweet, swirly, brioche-meets-cake loaf rooted in Eastern European Jewish traditions.";
            storeProduct2.ImageUrl = "https://static.wixstatic.com/media/a4b210_44fea4167e5ed867bd1fbf93b82cd839.jpg";
            storeProduct2.Price = 12;
            storeProduct2.Category = "SweetPastry";
            storeProduct2.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct2);

            var storeProduct3 = new StoreProduct();
            storeProduct3.Name = "Almond Croissant";
            storeProduct3.Description = "An almond croissant that is filled with marzipan imported from germany";
            storeProduct3.ImageUrl = "https://static.wixstatic.com/media/a4b210_5a3eb6d56d358fe1677beea613608df2.jpg";
            storeProduct3.Price = 4;
            storeProduct3.Category = "SweetPastry";
            storeProduct3.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct3);

            var storeProduct4 = new StoreProduct();
            storeProduct4.Name = "Rugelach";
            storeProduct4.Description = "Chocolate nutella rolled in croissant dough";
            storeProduct4.ImageUrl = "https://static.wixstatic.com/media/a4b210_b38fd8802fac090debde5cc713db6d05.jpg";
            storeProduct4.Price = 4;
            storeProduct4.Category = "SweetPastry";
            storeProduct4.DepartmentId = department3.DepartmentId;
            context.StoreProducts.Add(storeProduct4);

            var storeProduct6 = new StoreProduct();
            storeProduct6.Name = "Passion Fruit Concord Cake ";
            storeProduct6.Description = "Passion Fruit Concord Cake";
            storeProduct6.ImageUrl = "https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/17818516_1666215223683066_6781984498344001536_n.jpg";
            storeProduct6.Price = 20;
            storeProduct6.Category = "Cake";
            storeProduct6.DepartmentId = department2.DepartmentId;
            context.StoreProducts.Add(storeProduct6);

            var storeProduct7 = new StoreProduct();
            storeProduct7.Name = "Matzo Soup";
            storeProduct7.Description = "Matzah balls are an Ashkenazi Jewish soup dumpling made from a mixture of matzah meal, eggs, water, and a fat, such as oil, margarine, or chicken fat. Matzah balls are traditionally served in chicken soup.";
            storeProduct7.ImageUrl = "https://i0.wp.com/farm3.static.flickr.com/2420/2240152649_9a35850105_z.jpg";
            storeProduct7.Price = 4;
            storeProduct7.Category = "Soup";
            storeProduct7.DepartmentId = department1.DepartmentId;
            context.StoreProducts.Add(storeProduct7);

            var storeProduct5 = new StoreProduct();
            storeProduct5.Name = "Foccacia";
            storeProduct5.Description = "Focaccia is a flat oven-baked Italian bread product similar in style and texture to pizza doughs. It may be topped with herbs or other ingredients";
            storeProduct5.ImageUrl = "https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/c0.93.1080.1080/17586842_727955184031581_6854760202323886080_n.jpg";
            storeProduct5.Price = 4;
            storeProduct5.Category = "Bread";
            storeProduct5.DepartmentId = department4.DepartmentId;
            context.StoreProducts.Add(storeProduct5);


            //Add CateringProducts to database
   
        var cateringProduct1 = new CateringProduct();
            cateringProduct1.Name = "Mini Sandwiches";
            cateringProduct1.Description = "Tuna Salad & Hard-Boiled Egg; Gouda & Vegetable; Freshly Made Egg Salad & Tomato; Smoked Salmon & Cream Cheese.";
            cateringProduct1.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/MiniSandwiches_12769.jpg";
            cateringProduct1.Price = 72;
            cateringProduct1.ServingSize = "16 Pieces";
            cateringProduct1.Category = "Breakfast";
            cateringProduct1.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct1);

            var cateringProduct2 = new CateringProduct();
            cateringProduct2.Name = "Mini Pastry Assortment";
            cateringProduct2.Description = "Assortment of Croissant, Pain Au Chocolate, and Pain Au Raisin.";
            cateringProduct2.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/MiniPastryAssortment_12769.jpg";
            cateringProduct2.Price = 38;
            cateringProduct2.ServingSize = "15 Pieces";
            cateringProduct2.Category = "Breakfast";
            cateringProduct2.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct2);

            var cateringProduct3 = new CateringProduct();
            cateringProduct3.Name = "Tuna and Vegetable Salad";
            cateringProduct3.Description = "Homemade Tuna Salad with Mixed Greens, Tomato, Cucumber, Red Onion, Hard Boiled Egg & Kalamata Olives.";
            cateringProduct3.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/TunaVegetableSalad_12770.jpg";
            cateringProduct3.Price = 39;
            cateringProduct3.ServingSize = "64 oz";
            cateringProduct3.Category = "Lunch";
            cateringProduct3.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct3);

            var cateringProduct4 = new CateringProduct();
            cateringProduct4.Name = "Crudite Platter";
            cateringProduct4.Description = "Variety of Fresh, Seasonal Vegetables from The Union Square Greenmarket, Including Cherry Tomato, Cucumber, Carrot, Red Pepper, Baby Radish Served with A Sour Cream & Chive Dip. ";
            cateringProduct4.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/CruditePlatter_12770.jpg";
            cateringProduct4.Price = 44;
            cateringProduct4.ServingSize = "2.2 lbs";
            cateringProduct4.Category = "Lunch";
            cateringProduct4.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct4);

            var cateringProduct5 = new CateringProduct();
            cateringProduct5.Name = "Cheese Straw Bites";
            cateringProduct5.Description = "A Bite Size Version of Our Famous Cheese Straws.";
            cateringProduct5.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/CheeseStrawBites_12766.jpg";
            cateringProduct5.Price = 38;
            cateringProduct5.ServingSize = "65 pieces";
            cateringProduct5.Category = "Appetizers";
            cateringProduct5.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct5);

            var cateringProduct6 = new CateringProduct();
            cateringProduct6.Name = "Rugelach Platter";
            cateringProduct6.Description = "Delicious Chocolate Rugelach. ";
            cateringProduct6.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/RugelachPlatter_12768.jpg";
            cateringProduct6.Price = 41;
            cateringProduct6.ServingSize = "24 pieces";
            cateringProduct6.Category = "Desserts";
            cateringProduct6.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct6);

            var cateringProduct7 = new CateringProduct();
            cateringProduct7.Name = "Danish Tartlet Platter";
            cateringProduct7.Description = "Marzipan, Crème Patisserie Filling and Fresh Seasonal Fruit.";
            cateringProduct7.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/DanishTartletPlatter_12768.jpg";
            cateringProduct7.Price = 71;
            cateringProduct7.ServingSize = "16 pieces";
            cateringProduct7.Category = "Desserts";
            cateringProduct7.DepartmentId = department2.DepartmentId;
            context.CateringProducts.Add(cateringProduct7);




      
            var cateringProduct8 = new CateringProduct();
            cateringProduct8.Name = "Croissant Sandwiches";
            cateringProduct8.Description = "Atlantic Smoked Salmon; Gouda & Vegetable; Brie & Olive";
            cateringProduct8.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/CroissantSandwiches_12769.jpg";
            cateringProduct8.Price = 65;
            cateringProduct8.ServingSize = "12 Pieces";
            cateringProduct8.Category = "Breakfast";
            cateringProduct8.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct8);

            var cateringProduct9 = new CateringProduct();
            cateringProduct9.Name = "Mini Burekas";
            cateringProduct9.Description = "Cheese - Feta, Cream Cheese & Sour Cream, Spinach & Cheese - Feta, Spinach, Cream Cheese & Onion, Potato - Potato, Parsley, Salt & Pepper.";
            cateringProduct9.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/MiniBurekas_12769.jpg";
            cateringProduct9.Price = 30;
            cateringProduct9.ServingSize = "30 Pieces";
            cateringProduct9.Category = "Breakfast";
            cateringProduct9.DepartmentId = department3.DepartmentId;
            context.CateringProducts.Add(cateringProduct9);

            var cateringProduct10 = new CateringProduct();
            cateringProduct10.Name = "Mini Quiche Assortment";
            cateringProduct10.Description = "Mediterranean - Eggplant, Roasted Pepper, Goat Cheese - Goat Cheese, Onion, Gouda, Onion & Leek - Caramelized Onion & Lee, Mushroom - Mushroom, Onion & Gouda. ";
            cateringProduct10.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/MiniQuicheAssortment_12769.jpg";
            cateringProduct10.Price = 60;
            cateringProduct10.ServingSize = "20 Pieces";
            cateringProduct10.Category = "Breakfast";
            cateringProduct10.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct10);

            var cateringProduct11 = new CateringProduct();
            cateringProduct11.Name = "Beet & Lentil Salad";
            cateringProduct11.Description = "Lentil and Roasted Beet Salad with Feta Cheese and A Dijon Vinaigrette";
            cateringProduct11.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/BeetLentilSalad_12770.jpg";
            cateringProduct11.Price = 39;
            cateringProduct11.ServingSize = "64 oz.";
            cateringProduct11.Category = "Lunch";
            cateringProduct11.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct11);

            var cateringProduct12 = new CateringProduct();
            cateringProduct12.Name = "Avocado Salad Cups";
            cateringProduct12.Description = " Layers of Avocado, Tomato, Goat Cheese and Cream Cheese";
            cateringProduct12.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/AvocadoSaladCups_12766.jpg";
            cateringProduct12.Price = 40;
            cateringProduct12.ServingSize = "12 Pieces";
            cateringProduct12.Category = "Appetizers";
            cateringProduct12.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct12);

            var cateringProduct13 = new CateringProduct();
            cateringProduct13.Name = "Salmon Crostini";
            cateringProduct13.Description = "Toasted Baguette Topped with Cream Cheese and Atlantic Smoked Salmon, Topped with A Caper and Chive Garnish";
            cateringProduct13.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/SalmonCrostini_12766.jpg";
            cateringProduct13.Price = 49;
            cateringProduct13.ServingSize = "14 Pieces";
            cateringProduct13.Category = "Appetizers";
            cateringProduct13.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct13);

            var cateringProduct14 = new CateringProduct();
            cateringProduct14.Name = "Cheese Platter";
            cateringProduct14.Description = " Gouda, Feta, Brie and Blue Cheese Garnished with Fresh Seasonal Fruit (Recommended to Accompany Our Bread Basket).";
            cateringProduct14.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/CheesePlatter_12767.jpg";
            cateringProduct14.Price = 66;
            cateringProduct14.ServingSize = "2.2 lbs.";
            cateringProduct14.Category = "Appetizers";
            cateringProduct14.DepartmentId = department1.DepartmentId;
            context.CateringProducts.Add(cateringProduct14);


            var cateringProduct15 = new CateringProduct();
            cateringProduct15.Name = "Chocolate Truffles";
            cateringProduct15.Description = "Premium Belgian Chocolate Rolled in Pure Cocoa Powder";
            cateringProduct15.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/CheesePlatter_12767.jpg";
            cateringProduct15.Price = 49;
            cateringProduct15.ServingSize = "1.1 lbs.";
            cateringProduct15.Category = "Desserts";
            cateringProduct15.DepartmentId = department2.DepartmentId;
            context.CateringProducts.Add(cateringProduct15);

            var cateringProduct17 = new CateringProduct();
            cateringProduct17.Name = "Mini Feuille";
            cateringProduct17.Description = "Caramelized Puff Pastry Squares with A Delicate Crème Patisserie Filling";
            cateringProduct17.ImageUrl = "https://orders.9fold.me/RestaurantsData/Menus/Items/MiniFeuille_12768.jpg";
            cateringProduct17.Price = 52;
            cateringProduct17.ServingSize = "25 Pieces";
            cateringProduct17.Category = "Desserts";
            cateringProduct17.DepartmentId = department2.DepartmentId;
            context.CateringProducts.Add(cateringProduct17);



            var user1 = new User( );
            user1.FirstName = "Keely";
            user1.LastName = "Glenn";
            user1.CompanyName = "Epicodus";
            context.Users.Add(user1);

            context.SaveChanges();
        }
    }
}