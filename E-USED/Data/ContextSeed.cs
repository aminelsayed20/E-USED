using E_USED.Models.Entity;
using E_USED.Models.Entity.Product;

namespace E_USED.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                var cities = new List<City>
            {
                new City {Name = "Cairo"},
                new City {Name = "Giza"},
                new City {Name = "Manshyet Nasser"},
                new City {Name = "Port Said"},
                new City {Name = "Suez"},
                new City {Name = "Luxor"},
                new City {Name = "Aswan"},
                new City {Name = "Mansoura"},
                new City {Name = "Tanta"},
                new City { Name = "Qena"},
                new City { Name = "Sohag"},
                new City { Name = "Assiut"},
                new City { Name = "Ismailia"},
                new City { Name = "Fayyum"},
                new City { Name = "Minya"},
                new City { Name = "Beni Suef"},
                new City { Name = "Damietta"},
                new City { Name = "Zagazig"},
                new City { Name = "Hurghada"}
            };
                context.Cities.AddRange(cities);
            }

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
            {
                new Category {Name = "Vehicles"},
                new Category {Name = "Properties"},
                new Category {Name = "Mobiles and Accessories"},
                new Category {Name = "Electronics and Home Appliances"},
                new Category {Name = "Home and Garden"},
                new Category {Name = "Fashion and Beauty"},
                new Category {Name = "Pets"},
                new Category {Name = "Kids and Babies"},
                new Category {Name = "Sporting Goods and Bikes"},
                new Category {Name = "Hobbies, Music, Art and Books"},
                new Category {Name = "Jobs and Services"},
                new Category {Name = "Business and Industrial"}
            };
                context.Categories.AddRange(categories);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
/*
 * Cities
        Cairo,
        Giza,
        Alexandria,
        Manshyet_Nasser,
        Port_Said,
        Suez,
        Luxor,
        Aswan,
        Mansoura,
        Tanta,
        Qena,
        Sohag,
        Assiut,
        Ismailia,
        Fayyum,
        Minya,
        Beni_Suef,
        Damietta,
        Zagazig,
        Hurghada 
*/
/*
 * Categories
        Vehicles,
        Properties ,
        MobilesAndAccessories,
        ElectronicsAndHomeAppliances,
        HomeAndGarden,
        FashionAndBeauty,
        Pets,
        KidsAndBabies,
        SportingGoodsAndBikes,
        HobbiesMusicArtAndBooks,
        JobsAndServices,
        BusinessAndIndustrial
*/