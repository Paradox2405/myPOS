# myPOS: Sun Fair POS (2019, C# WinForms)

A Windows desktop point-of-sale and inventory app written in C# for the **Sun Fair** clothing store. It covers counter billing, products, brands and categories, with data in a local SQL Server database.

> An early project for the same store. The current system is [Sunfair-POS](https://github.com/Paradox2405/Sunfair-POS) (2026), an offline-capable web POS built with React, Fastify and PostgreSQL.

## Features

- **Counter billing**: item code, item name and quantity
- **Manage products** and keep records
- **Manage brands**: brand list, add and modify
- **Manage categories**: category list, add and modify
- User and system settings, plus login and logout

## Tech stack

- **C#**, .NET Framework, **Windows Forms**
- **SQL Server LocalDB** (`sunfairdb.mdf`)
- Visual Studio solution (`Sunfairpos.csproj`)

## Project structure

```
Sunfairpos/
  Program.cs              entry point
  Form1.cs                main window / counter billing
  branddata.cs, managebrands.cs
  category.cs, categorylists.cs
  dbconnection.cs         SQL Server connection
  dbo.Table.sql           table schema
```

## Running

1. Open `Sunfairpos/Sunfairpos.csproj` in **Visual Studio**.
2. Create the database from `dbo.Table.sql` in SQL Server LocalDB.
3. Update the connection string in `dbconnection.cs`, which currently points at an absolute `AttachDbFilename` path.
4. Build and run (F5).
