using Microsoft.EntityFrameworkCore;

namespace aspnetserver.NewFolder
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./NewFolder/AppDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Plant[] plantsToSeed = new Plant[5];
            plantsToSeed[0] = new Plant
            {
                plantId = 1,
                Name = "Rose",
                Content = $"This is plant 1 and it has some very interesting traits.",
                WateringStatus = false,
                lastWatered = new DateTime()
    };
            plantsToSeed[1] = new Plant
            {
                plantId = 2,
                Name = "Habiscus",
                Content = $"This is plant 2 and it has some very interesting traits.",
                WateringStatus = false,
                lastWatered = new DateTime()
            };
            plantsToSeed[2] = new Plant
            {
                plantId = 3,
                Name = "Jasmine",
                Content = $"This is plant 3 and it has some very interesting traits.",
                WateringStatus = false,
                lastWatered = new DateTime()
            };
            plantsToSeed[3] = new Plant
            {
                plantId = 4,
                Name = "Sunflower",
                Content = $"This is plant 4 and it has some very interesting traits.",
                WateringStatus = false,
                lastWatered = new DateTime()
            };
            plantsToSeed[4] = new Plant
            {
                plantId = 5,
                Name = "Yellow Tulip",
                Content = $"This is plant 5 and it has some very interesting traits.",
                WateringStatus = false,
                lastWatered = new DateTime()
            };

            modelBuilder.Entity<Plant>().HasData(plantsToSeed);
        }
    }
}
