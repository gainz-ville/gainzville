# Get base SDK image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy csproj to restore
COPY . .
RUN dotnet clean
RUN dotnet restore #./Gainzville.Server/Gainzville.Server.csproj

FROM build AS publish
RUN dotnet publish ./Gainzville.Server/Gainzville.Server.csproj -c Release -o /app/publish --no-restore

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/Gainzville.Client/dist .
COPY nginx.conf /etc/nginx/nginx.conf

#
## Get base SDK image
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /src
#
## Copy csproj to restore
#COPY Gainzville.Server/*.csproj ./
#RUN dotnet restore
#
## Copy files and build
#COPY Gainzville.Server ./
#FROM build AS publish
#RUN dotnet publish -c Release -o /app/publish --no-restore
#
#FROM nginx:alpine AS final
#WORKDIR /usr/share/nginx/html
#COPY --from=publish /app/publish/Gainzville.Server/dist .
#COPY nginx.conf /etc/nginx/nginx.conf