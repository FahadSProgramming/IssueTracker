using IT.Domain;
using Microsoft.EntityFrameworkCore;

namespace IT.Persistence.Data {
    public static class CountrySeeds {
        public static async Task Seed(DataContext context, CancellationToken cancellationToken) {
            if(await context.Countries.AnyAsync()) {
                return;
            }

            var countries = new List<Country> {
                new Country {
                    Name = "Canada",
                    ISOCode = "CA",
                    ISOCode3 = "CAN",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "001"
                },
                new Country {
                    Name = "Turkey",
                    ISOCode = "TR",
                    ISOCode3 = "TUR",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "090"
                },
                new Country {
                    Name = "Palestine",
                    ISOCode = "PS",
                    ISOCode3 = "PSE",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "970"
                },
                new Country {
                    Name = "United Arab Emirates",
                    ISOCode = "AE",
                    ISOCode3 = "ARE",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "971"
                },
                new Country {
                    Name = "Japan",
                    ISOCode = "JP",
                    ISOCode3 = "JPN",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "081"
                },
                new Country {
                    Name = "South Korea",
                    ISOCode = "KR",
                    ISOCode3 = "KOR",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "082"
                },
                new Country {
                    Name = "Kingdom of Saudi Arabia",
                    ISOCode = "SA",
                    ISOCode3 = "SAU",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "966"
                },
                new Country {
                    Name = "Pakistan",
                    ISOCode = "PK",
                    ISOCode3 = "PAK",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "092"
                },
                new Country {
                    Name = "Qatar",
                    ISOCode = "QA",
                    ISOCode3 = "QAT",
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PhoneCode = "974"
                }
            };
            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}