using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

// In-memory inventory list
var inventory = new List<Item>();

var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI/Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Default root endpoint
app.MapGet("/", () => "Inventory API is running. Use /items endpoints to manage inventory.");

// Get all items
app.MapGet("/items", () => inventory);

// Get a specific item by ID
app.MapGet("/items/{id}", (string id) =>
{
    var item = inventory.Find(i => i.ID == id);
    return item is not null ? Results.Ok(item) : Results.NotFound($"Item with ID {id} not found.");
});

// Add a new item
app.MapPost("/items", (Item newItem) =>
{
    // Validate ID (3-digit numeric)
    if (!int.TryParse(newItem.ID, out _) || newItem.ID.Length != 3)
        return Results.BadRequest("ID must be a 3-digit numeric string.");

    // Validate price
    if (newItem.Price < 0)
        return Results.BadRequest("Price must be a positive number.");

    inventory.Add(newItem);
    return Results.Created($"/items/{newItem.ID}", newItem);
});

// Run the app
app.Run();

// Item record
record Item(string ID, string FirstName, string LastName, double Price);
