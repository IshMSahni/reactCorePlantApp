using aspnetserver.NewFolder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder
        .AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions=>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Ship Vista Plant Waterer", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "Ship Vista Plant Waterer";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API about a plant watering system");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-plants", async () => await PlantsRepository.GetPlantsAsync());

app.MapGet("/get-plant-by-id/{plantId}", async(int plantId) =>
{
    Plant plantToReturn = await PlantsRepository.GetPlantsByIdAsync(plantId);
    if(plantToReturn != null)
    {
        return Results.Ok(plantToReturn);
    } 
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Plant Endpoints");


app.MapPost("/create-plant", async (Plant plantToCreate) =>
{
    bool createSuccessful = await PlantsRepository.CreatePlantAsync(plantToCreate);
   
    if (createSuccessful)
    {
        return Results.Ok("Successful Creation");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Plant Endpoints");



app.MapPut("/update-plant", async (Plant plantToUpdate) =>
{
    bool updateSuccessful = await PlantsRepository.UpdatePlantAsync(plantToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Successful Update");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Plants Endpoints");

app.MapGet("/isWaterable/{plantId}/{dt}", async (int plantId, DateTime dt) =>
{
    bool getSuccessful = await PlantsRepository.isWaterable(plantId, dt);

    if (getSuccessful)
    {
        return Results.Ok("Successful Creation");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Plants Endpoints");

app.MapDelete("/delete-plant", async (int plantId) =>
{
    bool deleteSuccessful = await PlantsRepository.DeletePlantAsync(plantId);

    if (deleteSuccessful)
    {
        return Results.Ok("Successful Delete");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Plants Endpoints");

app.Run();