To re-create the database from design first, run the following command:

> (You can run this from the package manager console, make sure the database project is current)

```powershell
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GainzData" Microsoft.EntityFrameworkCore.SqlServer -Context "GainzDbContext" -DataAnnotations -UseDatabaseNames -Force

```

```cmd
dotnet ef dbcontext scaffold 'Server=(localdb)\mssqllocaldb;Database=GainzData;Trusted_Connection=True;' Microsoft.EntityFrameworkCore.SqlServer --context GainzDbContext --use-database-names --startup-project '..\Gainzville.Server' --force -v
```