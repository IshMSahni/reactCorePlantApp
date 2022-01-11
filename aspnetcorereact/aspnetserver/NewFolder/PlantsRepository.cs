using Microsoft.EntityFrameworkCore;

namespace aspnetserver.NewFolder
{
    internal static class PlantsRepository
    {
        internal async static Task<List<Plant>> GetPlantsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Plants.ToListAsync();
            }
        }
        internal async static Task<Plant> GetPlantsByIdAsync(int plantId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Plants.FirstOrDefaultAsync(plant => plant.plantId == plantId);
            }
        }

        internal async static Task<bool>CreatePlantAsync(Plant plantToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Plants.AddAsync(plantToCreate);
                    return await db.SaveChangesAsync() >= 1;
                } catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePlantAsync(Plant plantToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Plants.AddAsync(plantToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> isWaterable(int plantId, DateTime dt)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Plant plantToWater = await GetPlantsByIdAsync(plantId);
                    if (plantToWater != null)
                    {

                        TimeSpan span = dt.Subtract(plantToWater.lastWatered);
                        plantToWater.lastWatered = dt;
                        if (span.TotalSeconds >= 30)
                        {
                            plantToWater.WateringStatus = true;
                            try
                            {
                                await db.Plants.AddAsync(plantToWater);
                                await db.SaveChangesAsync();
                                return true;
                            }
                            catch (Exception e)
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePlantAsync(int plantId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Plant plantToDelete = await GetPlantsByIdAsync(plantId);
                    db.Remove(plantToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
