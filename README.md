I’ve reviewed your Markdown. There are a few issues that will prevent it from rendering properly on GitHub:
	1.	Code blocks are mixed: You’ve combined C# code, HTTP requests, and text (🔧 Development Highlights, folder structure) into a single triple-backtick block. GitHub will treat everything in the block as code and won’t render headings, lists, or Mermaid diagrams properly.
	2.	Mermaid block is outside the proper context: It’s correctly fenced with ```mermaid, but it should not be inside a larger code block.
	3.	Folder structure is indented improperly: Markdown lists or tree structures should be in their own fenced code block.

Here’s a corrected version you can copy into README.md. All sections are separated properly, and the Mermaid diagram is standalone so GitHub can render it with a supported preview tool:

---
title: "Inventory Management System"
description: "C# Programming Fundamentals Project by Marc Cavada"
author: "Marc Cavada"
---

# 🧩 Inventory Management System  
**Project 1 – Programming Fundamentals (CA-PRFND)**  

## 📘 Introduction  
This project is a **prototype Inventory Management System** developed in **C# using .NET 9 and Visual Studio Code**.  
It captures and manages inventory items using **EF Core and SQLite**, exposing a **RESTful API** with Swagger/OpenAPI support.

---

## 📂 InventoryAPI – Code Files

### 1. Program.cs
```csharp
// Program.cs contents...

2. InventoryDbContext.cs

// InventoryDbContext.cs contents...

3. Item.cs

// Item.cs contents...

4. InventoryAPI.csproj

<!-- InventoryAPI.csproj contents -->

5. InventoryAPI.http

GET https://localhost:7255/items
GET https://localhost:7255/items/1
POST https://localhost:7255/items
Content-Type: application/json

{
  "id": 101,
  "firstName": "Apple",
  "lastName": "Box",
  "price": 499.99
}


⸻

🔧 Development Highlights
	•	Minimal API with ASP.NET Core
	•	EF Core SQLite integration
	•	Input validation for IDs and prices
	•	Async/await for database operations
	•	Swagger/OpenAPI for endpoint testing

⸻

🧩 Folder Structure

InventoryAPI/
├── Program.cs
├── Item.cs
├── InventoryDbContext.cs
├── appsettings.json
├── appsettings.Development.json
├── Properties/
├── bin/
├── obj/
└── InventoryAPI.csproj


⸻

📊 Program Flow (Mermaid Diagram)

flowchart TD
    Start[Start API] --> Root[Swagger / Root Endpoint]
    Root --> Select{Select Endpoint}

    Select --> |GET /items| FetchAll[Fetch all items from DB]
    FetchAll --> ReturnList[Return JSON list]

    Select --> |GET /items/:id| FetchOne[Fetch item by ID]
    FetchOne --> Exists{Item Exists?}
    Exists --> |Yes| ReturnItem[Return Item JSON]
    Exists --> |No| Return404[Return 404 Not Found]

    Select --> |POST /items| PostItem[Receive Item JSON]
    PostItem --> Validate{Validate Input}
    Validate --> |Valid| Insert[Insert into DB]
    Validate --> |Invalid| BadRequest[Return 400 Bad Request]
    Insert --> Created[Return Created Response]

Note: GitHub renders Mermaid diagrams in Markdown only in supported previews (like GitHub Pages or Mermaid Live Editor).

⸻

👨‍💻 Author

Marc Cavada
Programming Fundamentals – CDI College
Project: CA_PRFND – Inventory Management System

✅ This version will:  
- Render each section properly on GitHub.  
- Keep code, HTTP requests, and folder structures separated.  
- Allow the Mermaid diagram to render if the environment supports it.  

If you want, I can **also inline the full C#, DbContext, and Item.cs code** so the README is fully ready for GitHub. Do you want me to do that next?