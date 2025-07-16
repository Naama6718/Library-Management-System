## 📚 Digital Library Management System – C# Console App

### 📝 Overview

This is a console-based digital library management system built in **C#** using **Visual Studio 2022**.
The project demonstrates the practical use of multiple **Design Patterns**, and simulates real-world library operations such as book loans, categorized storage, access control, and more.

---

### 🧠 Key Features & Design Patterns

| Feature                              | Design Pattern Used | Description                                                                         |
| ------------------------------------ | ------------------- | ----------------------------------------------------------------------------------- |
| Displaying books in different styles | `Adapter`           | Converts standard book objects into stylized views (e.g., by category color).       |
| Flexible color schemes               | `Bridge`            | Separates abstraction (display style) from implementation (color logic).            |
| Hierarchical categories              | `Composite`         | Allows nesting categories and books under unified structures.                       |
| Custom book tags                     | `Decorator`         | Adds dynamic properties (e.g., “rare”, “library-only”) without altering book class. |
| Simple user access                   | `Facade`            | Provides a clean interface (`LibraryFacade`) to handle complex book operations.     |
| Memory optimization                  | `Flyweight`         | Avoids duplicate memory usage for identical books.                                  |
| Access control                       | `Proxy`             | Restricts access to sensitive books based on user permissions.                      |

---

### 🔧 Technologies Used

* **Language:** C#
* **IDE:** Visual Studio 2022
* **Type:** Console Application
* **Architecture:** Modular OOP with layered design

---

### 🛠 System Capabilities

* 📚 Add, display, and search books by category
* 👥 Role-based access control (e.g., premium vs regular users)
* 🏷 Tag books with custom properties (e.g., "Recommended", "Rare")
* 🔄 Borrow and return books
* 🎨 Display books with custom styling (console colors)
* 💾 Shared memory usage for duplicate books

---

### 🚀 Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Naama6718/Library-Management-System.git
   ```

2. Open the `.sln` file in Visual Studio 2022

3. Run the `Program.cs` (inside `src/main`) to see the system in action.

---

### 📸 Console Output Example

```
Welcome to the Digital Library!
--------------------------------
Are you a premium user? (y/n): y

Choose an option:
1. Search for a book
2. Borrow a book
3. Return a book
4. Design all books
5. Design one book
6. Exit
5
Enter ID: 1
choose how to display: 1 for background and 2 for text 2
Book: Mevukash by Yona Sapir
Name :Mevukash
Author :Yona Sapir
Category :Adult
Id :1
num of copies:2
IsItBorrowed :False
BorrowingDate :01/01/0001 00:00:00
```

---

### 📂 Project Structure (Simplified)

<img width="420" height="492" alt="image" src="https://github.com/user-attachments/assets/b22563e5-c372-4da9-9956-e27d66969d43" />

---

### 💬 Future Enhancements

* 🖥 Convert to GUI-based system using WPF or Blazor
* 💾 Add database support (e.g., SQLite or EF Core)
* 🌐 Build a REST API wrapper for external access

---

### 📌 Credits

Developed by **Naama Saadon** as part of software engineering studies.
Includes patterns inspired by GoF (Gang of Four) design principles.

---
