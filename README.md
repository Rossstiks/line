# line
## SalonApp
This repository contains a simple C# console application for managing a beauty salon. It uses SQLite via Entity Framework Core to store monthly financial records. Run the following commands to build the application:

```bash
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0
export PATH="$PATH:/root/.dotnet/tools" # if dotnet-ef is installed

dotnet build SalonApp/SalonApp.csproj
```

Use `dotnet run --project SalonApp` to start the interactive menu. The first run will create `salon.db` in the same directory.
