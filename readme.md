# ProjectTimeApi

A simple .NET 8 Web API for managing projects and user time logs using SQLite.

---

## Project Purpose

This API allows users to create projects and log work times per user on each project. It’s designed as a learning project to practice .NET Web API development, Entity Framework Core, and SQLite integration.

---

## Installation

1. Clone the repository:

```bash
git clone https://your-repo-url.git
cd ProjectTimeApi
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Apply migrations and create the database:

```bash
dotnet ef database update
```

4. Run the API:

```bash
dotnet run
```

---
