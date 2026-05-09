# Guest House Management System

This is a C#-based Desktop Application for managing guest house operations, including customer registrations, room bookings, and occupancy tracking. It features a modern GUI built with Windows Forms and a SQL Server database.

## Project Overview

The **Guest House Management System** is designed to simplify the daily operations of a guest house. It provides a centralized dashboard for administrators to monitor room availability, manage customer records, and handle booking transactions efficiently.

## Features

* **Dashboard:** Real-time statistics on booked rooms, customer counts, and occupancy percentages.
* **Customer Management:** Full CRUD (Create, Read, Update, Delete) operations for guest profiles including contact info and DOB.
* **Booking System:** Streamlined process for assigning rooms to customers with filtering options by room type.
* **User Management:** Secure login system to ensure only authorized personnel can access the management tools.
* **Modern UI:** Uses Guna UI2 and Bunifu frameworks for a high-quality user experience.

## Prerequisites

* **.NET Framework** - Version 4.7.2 or higher.
* **Visual Studio** - 2019 or newer recommended.
* **SQL Server Express** - LocalDB instance for database hosting.
* **Guna.UI2 / Bunifu Framework** - UI libraries (should be restored via NuGet).

## How to Set Up the Project

### 1. **Set up the Database:**

* The application uses a LocalDB file named `guesthouse.mdf`.
* Ensure the database file is placed in your Documents folder: `C:\Users\YourUsername\Documents\guesthouse.mdf` (or update the connection string in the `.cs` files).
* The system requires the following tables: `UserTbl`, `CustomerTbl`, `BookingTbl`, and `RoomTbl`.

### 2. **Opening the Project:**

* Launch Visual Studio.
* Open the `guesthouse4.sln` or `guesthouse4.csproj` file.
* Wait for Visual Studio to restore the necessary NuGet packages (Guna.UI2, etc.).

### 3. **Run the Application:**

* Set the solution configuration to **Debug**.
* Click the **Start** button or press `F5` to compile and launch the application.
* The application will start at the **Login** screen.

## Login Credentials

* **Default Administrator:**
* **Username:** `admin` (or any user present in `UserTbl`)
* **Password:** `admin123`


* **Staff Users:**
* Additional users can be managed via the **Users** section within the application.



---
