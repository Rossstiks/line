# line
## SalonApp
This repository contains a simple C# application for managing a beauty salon. It uses SQLite via Entity Framework Core to store monthly financial records.

### Build
```bash
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# build all projects
dotnet build Salon.sln
```

### Run
The original console interface can still be launched with:
```bash
dotnet run --project SalonApp
```
A basic Avalonia-based GUI is available:
```bash
dotnet run --project SalonGui
```
The first run will create `salon.db` in the same directory.
