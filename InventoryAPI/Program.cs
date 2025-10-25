using Microsoft.EntityFrameworkCore;
using InventoryAPI;  // <-- this is required to access InventoryDbContext & Item



var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<InventoryAPI.InventoryDbContext>(options =>
    options.UseSqlite("Data Source=inventory.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
app.MapGet("/", () => "Inventory API is running.");

app.MapGet("/items", async (InventoryAPI.InventoryDbContext db) => await db.Items.ToListAsync());

app.MapGet("/items/{id}", async (int id, InventoryDbContext db) =>
{
    var item = await db.Items.FindAsync(id);
    return item != null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/items", async (Item newItem, InventoryDbContext db) =>
{
    db.Items.Add(newItem);
    await db.SaveChangesAsync();
    return Results.Created($"/items/{newItem.Id}", newItem);
});

app.Run();