using Microsoft.EntityFrameworkCore;
using Menu.Models;
namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new 
            { 
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish {  Id=1, Name="Hawaiian", Price = 7.50, ImageUrl= "https://sallysbakingaddiction.com/wp-content/uploads/2014/08/It-doesnt-get-much-better-than-Homemade-Hawaiian-Pizza.-Tropical-paradise-for-dinner-2.jpg" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id=1, Name="Tomato Sauce"},
                new Ingredient { Id=2, Name="Mozzarella Cheese"},
                new Ingredient { Id=3, Name="Pineapple"},
                new Ingredient { Id=4, Name="Ham"}
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId=1, IngredientId=1},
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 3 },
                new DishIngredient { DishId = 1, IngredientId = 4 }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<DishIngredient> dishIngredients { get; set; }  
    }
}
