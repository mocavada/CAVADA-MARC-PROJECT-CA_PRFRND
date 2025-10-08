---
title: "Inventory Management System"
description: "C# Programming Fundamentals Project by Marc Cavada"
author: "Marc Cavada"
---

# 🧩 Inventory Management System  
**Project 1 – Programming Fundamentals (CA-PRFND)**  

## 📘 Introduction  
This project is a **prototype Inventory Management System** developed in **C# using Visual Studio .NET**.  
It simulates capturing and managing basic inventory information, allowing users to input, validate, and display product records while handling errors gracefully.  

You have been tasked, as a **junior programmer**, to design, code, test, and document the solution. The prototype must be completed within **six days**, demonstrating your understanding of programming fundamentals, analysis, and iterative development.  

### 📊 Program Flow (Mermaid Diagram)

```mermaid
flowchart TD
    A[Start Application] --> B[Display Main Menu]
    B --> C{Select Option}
    C -->|1. Insert Item| D[Prompt User for ID, Name, Description, Price]
    D --> E{Validate Input}
    E -->|Valid| F[Store Item in List]
    E -->|Invalid| G[Display Error Message]
    F --> H{Add Another Item?}
    H -->|Yes| D
    H -->|No| B

    C -->|2. Display Item| I[Prompt User for ID]
    I --> J{ID Exists?}
    J -->|Yes| K[Display Item Details]
    J -->|No| L[Display Item Not Found]
    K --> B
    L --> B

    C -->|3. Display All Items| M[Iterate through List]
    M --> N[Display Each Item with Headers]
    N --> B

    C -->|4. Exit| O[Terminate Program]
    G --> D

## 🎯 Objectives  
The main objectives of this project are to:  

- Interpret specifications and perform requirement analysis.  
- Design a functional solution based on requirements.  
- Apply program logic, structures, and error-handling.  
- Translate design into working source code in **C#**.  
- Debug, test, and validate input/output.  
- Use **Visual Studio IDE** features effectively.  
- Demonstrate knowledge of procedural flow and control structures.  

---

## ⏱️ Time Required  
You will need approximately **30 hours** to complete this project.  
This includes **5 in-class sessions** plus homework and testing.  

---

## 🧰 Required Materials  
- **Microsoft Visual Studio .NET** (C#)  
- **Visual Studio documentation** and course materials  
- **Project specifications and test cases** provided by your instructor  

---

## 🧠 Development Phases  

### Sessions 13 to 15: Apply Analysis and Design to Coding  
- Apply problem-solving and algorithmic thinking.  
- Implement processes based on design specifications.  
- Add **input validation** and **error handling** for all user inputs.  
- Use **iterative development** — revise logic as needed and update documentation.  
- Record any **changes** made to design or logic and justify why.  
- **Validate the solution** using the provided test cases.  
- Update the documentation to reflect final changes.  
- Submit the final version of the project.  

---

## 🧪 Test Data  

| ID  | Firstname | Lastname | Purchase     | Comment                                                                 |
|-----|------------|-----------|--------------|--------------------------------------------------------------------------|
| 101 | Pulses     | Pulses pack | 381.65      | ✅ Works without issues                                                 |
| 200 | Lemon      | Lemon Box  | 587.17      | ❌ Reject (ID should be 3 characters long)                              |
| 234 | Mango      | Mango Box  | 587.17      | ✅ Works correctly                                                      |
| 984 | Apple      | Apple Box  | Two hundred | ❌ Reject (price must be numeric)                                       |
| Abc | Test       | Test description | 45       | ❌ Reject (ID must be numeric)                                          |
| 1Ac | Test       | Test description | 20       | ❌ Reject (ID must be numeric)                                          |

> 💡 You should create additional test data to validate edge cases and exceptions.  
Ensure that all generated errors are properly handled by the application.  

---

## 🧱 Folder Structure  

```bash
CAVADA-MARC-PROJECT-CAPRFND/
│
├── Program.cs                     # Main entry point
├── appsettings.json               # App configuration
├── appsettings.Development.json   # Development config
├── Properties/                    # Project metadata
├── bin/                           # Compiled binaries
├── obj/                           # Build files
├── Assignments/                   # Design & documentation
└── CAVADA-MARC-PROJECT-CAPRFND.csproj # Project file


⸻

⚙️ How to Run the Application

🖥️ Option 1 – Run from Visual Studio
	1.	Open Visual Studio.
	2.	Go to File → Open → Project/Solution.
	3.	Locate and open:

CAVADA-MARC-PROJECT-CAPRFND.csproj

	4.	Build the project using Ctrl + Shift + B or Build → Build Solution.
	5.	Run the program using F5 or Debug → Start Debugging.
	6.	Follow the on-screen prompts to test input, view validation, and observe error messages.

⸻

💻 Option 2 – Run from Command Line (Mac or Windows)

cd path/to/CAVADA-MARC-PROJECT-CAPRFND
dotnet run

Enter sample data as prompted (refer to the Test Data section).
Observe input validation, exception handling, and correct output responses.

⸻

🏆 Bonus Features (Optional Enhancements)

If time allows, you may extend your application with these optional features:
	1.	Auto-increment ID
	•	Generate sequential item IDs automatically instead of requiring user input.
	2.	Selectable Item List
	•	Display a list of all item IDs for selection when viewing details.
	3.	Highest Priced Item
	•	Add an option to display the item with the highest purchase price.
	4.	Sorting Functionality
	•	Enable sorting before displaying all inventory items.

⸻

🧩 Key Concepts Demonstrated
	•	Input Validation and Exception Handling
	•	Conditional Statements and Loops
	•	Arrays or Lists for Data Storage
	•	Procedural Design and Modularization
	•	Iterative Development
	•	Testing and Debugging in Visual Studio

⸻

✅ Submission Checklist

Before submitting, ensure the following are complete:
	•	✅ Functional C# application
	•	✅ Updated design and logic documentation
	•	✅ Complete test data and validation logs
	•	✅ This README.mdx included in the repository

⸻

👨‍💻 Author

Marc Cavada
Programming Fundamentals – CDI College
Project: CA_PRFND – Inventory Management System

⸻



Would you like me to now include a **Mermaid flowchart component** inside this MDX file (for example: data input → validation → display → error handling)?  
It would render automatically if your docs site supports MDX.
