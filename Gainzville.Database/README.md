### To re-create the database from design first, run the following command:

> (You can run this from the package manager console for the powershell, make sure the database project is current)

> Get the connection string from the appsettings.json

.NET CLI
```cmd
dotnet ef dbcontext scaffold '{CONNECTION_STRING}' Microsoft.EntityFrameworkCore.SqlServer --context GainzDbContext --use-database-names --startup-project '..\Gainzville.Server' --force -v
```

Powershell
```powershell
Scaffold-DbContext "{CONNECTION_STRING}" Microsoft.EntityFrameworkCore.SqlServer -Context "GainzDbContext" -DataAnnotations -UseDatabaseNames -Force
```



### To create database migration cs files


.NET CLI
```cmd
dotnet ef migrations add {migrationName} --startup-project ..\Gainzville.Server\Gainzville.Server.csproj
```

Powershell
```powershell
Add-Migration InitialCreate
```

### To create database migrations as SQL script
.NET CLI
```cmd
dotnet ef migrations script {FROM} {TO} --startup-project ..\Gainzville.Server\Gainzville.Server.csproj --output script.sql
```


### To apply the migrations
.NET CLI
```cmd
dotnet ef database update --startup-project ..\Gainzville.Server\Gainzville.Server.csproj
```
