# Build

$tag = "gainzville-database:1"

docker build . --tag $tag


# Run base SQL Server docker container
docker run -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=GainzPassword123!" -d mcr.microsoft.com/mssql/server

# Run
docker run -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=GainzPassword123!" -d $tag