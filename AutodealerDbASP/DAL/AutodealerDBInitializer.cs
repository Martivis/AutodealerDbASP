using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutodealerDbASP.Models.AutodealerDb.Entities;

namespace AutodealerDbWF
{
    internal class AutodealerDbInitializer : CreateDatabaseIfNotExists<AutodealerDbContext>
    {
        protected override void Seed(AutodealerDbContext context)
        {
            IList<CarBrand> defaultBrands = new List<CarBrand>()
            {
                new CarBrand() { Name = "Audi" },
                new CarBrand() { Name = "BMW" },
                new CarBrand() { Name = "Mercedes-Benz" },
                new CarBrand() { Name = "Skoda" },
                new CarBrand() { Name = "Volkswagen" },
            };
            context.CarBrands.AddRange(defaultBrands);

            IList<CarColor> defaultColors = new List<CarColor>()
            {
                new CarColor() { Name = "Black" },
                new CarColor() { Name = "Grey" },
                new CarColor() { Name = "Red" },
                new CarColor() { Name = "Silver" },
                new CarColor() { Name = "White" },
            };
            context.CarColors.AddRange(defaultColors);

            IList<Model> defaultModels = new List<Model>()
            {
                new Model()
                {
                    Name =  "A5",
                    CarBrand = defaultBrands.First(x => x.Name == "Audi"),
                    CarColor = defaultColors.First(x => x.Name == "Black"),
                    Power = 230
                },
                new Model()
                {
                    Name = "X3",
                    CarBrand = defaultBrands.First(x => x.Name == "BMW"),
                    CarColor = defaultColors.First(x => x.Name == "Silver"),
                    Power = 184
                },
            };
            context.Models.AddRange(defaultModels);

            IList<Provider> defaultProviders = new List<Provider>()
            {
                new Provider()
                {
                    Name = "Rus Auto",
                    PhoneNumber = "89524861575",
                    Email = "rusauto@mail.ru",
                    WebsiteUrl = "rusauto.ru"
                }
            };
            context.Providers.AddRange(defaultProviders);

            base.Seed(context);
        }
    }
}
