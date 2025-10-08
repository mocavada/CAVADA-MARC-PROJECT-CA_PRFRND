# Project 1 - Programming Fundamentals Project  
**Inventory Management System**

---

## Introduction
Today is your first day on the job as a junior programmer. Your immediate supervisor has tasked you with developing an application prototype that simulates the capturing of basic inventory information.  

You are expected to deliver a functioning prototype in six days. This is your opportunity to showcase your **analysis, design, coding, and testing abilities** in **C# using Visual Studio IDE**.

---

## Objectives
The main objectives of this project are to:  
- Interpret specifications and perform analysis.  
- Design a solution based on requirements and specifications.  
- Design the logic required for a functional solution.  
- Translate design documents and algorithms into source code.  
- Use debugging tools and error-handling techniques.  
- Validate the solution with test data.  
- Integrate the knowledge acquired thus far.  
- Use the features of Visual Studio IDE.  
- Demonstrate the use of the C# programming language.  
- Apply various program flow constructs.  

---

## Time Required
You will require **30 hours** to complete this project.  
This includes 5 in-class sessions plus homework time.  

---

## Required Material
- Microsoft Visual Studio .NET (specifically C# .NET)  
- Microsoft Visual Studio .NET documentation  
- Course textbook or other reference material suggested/provided by your instructor  

---

## Requirements

### Part 1 – The Logic
- Analyze the functionality of the project.  
- Produce **program design documents** (flowcharts, pseudocode, class diagrams, etc.).  
- Submit your design for **validation and approval** before coding.  

⚠️ *Failure to complete Part 1 and get instructor approval will result in losing marks for this part.*  

---

### Part 2 – Interpret the Program Logic to Write Source Code
- Translate your approved logic into C# code.  
- Ensure that your code flow matches your design.  
- Example: if you designed a `while` loop in your logic, implement the same in code.  

**Error Management & Testing**
- Test as you build.  
- Add input validation and error-handling at every step.  
- Ensure captured data is valid and matches expected types.  

---

## Schedule

### Session 11 – Analysis and Design
- Analyze project specs and requirements.  
- Create design documentation (at least 2 types, e.g., flowchart + pseudocode/class diagram).  
- Validate logic with your instructor.  

### Session 12 – Detailing Processes
- Finalize each process with sufficient detail.  
- Adjust based on instructor feedback.  
- Create project structure in Visual Studio.  
- Begin coding according to logic documentation.  

### Sessions 13 to 15 – Coding and Refinement
- Apply problem-solving skills.  
- Code the various processes according to specs.  
- Add input validation and error-handling.  
- Revise logic iteratively as needed (update design docs accordingly).  
- Document any changes to your logic/design and explain your reasoning.  
- Validate the solution using test cases.  
- Add any missing error-handling or validation.  
- Update the documentation.  
- Submit the project.  

---

## Test Data

Use the following **test data** to verify the basic functionality of your application.  
Test both valid and invalid entries to check error-handling.

| ID   | Firstname | Lastname | Purchase      | Comment |
|------|-----------|----------|---------------|---------|
| 101  | Pulses    | Pulses   | pack 381.65   | ✅ Should work without issues |
| 200  | Lemon     | Lemon    | Box 587.17    | ❌ Reject – ID not valid (must be 3 characters long) |
| 234  | Mango     | Mango    | Box 587.17    | ✅ Should work correctly |
| 984  | Apple     | Apple    | Box "Two hundred" | ❌ Reject – Price must be numeric |
| Abc  | Test      | Test     | description 45| ❌ Reject – ID not numerical |
| 1Ac  | Test      | Test     | description 20| ❌ Reject – ID not numerical |

👉 You must also create **additional test data** to fully validate your application.  
👉 Submit your test data along with your program so your instructor can test it.  

**Important:** Ensure all validation errors are properly handled and user-friendly.  

---

## Bonus Features (Optional – Extra Marks)
If time allows, you can extend the project with additional features:  

1. **Auto-generate Sequential IDs**  
   - Instead of entering a 3-digit ID, the system assigns the next sequential ID automatically.  

2. **Display Item Selection List**  
   - When displaying a specific item, show a list of available item IDs to choose from.  

3. **Show Item with Highest Price**  
   - Add a menu option that finds and displays the most expensive item.  

4. **Sorting Feature**  
   - Sort items before displaying them in the "Display All" option.  

---

## Deliverables
- Design documentation (flowcharts, pseudocode, diagrams).  
- C# Source code implementation.  
- Test data file (with expected outcomes).  
- Final project submission with updated documentation.  

---

## Notes
- Follow your initial plan but adjust iteratively when needed.  
- Clearly document any changes and the reasons.  
- Ensure the application is tested, validated, and functional before submission.  

---
