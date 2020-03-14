# Get base SDK image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# Copy csproj to restore
COPY . .
RUN dotnet clean
RUN dotnet restore

FROM build AS publish
RUN dotnet publish ./Gainzville.Client/Gainzville.Client.csproj -c Release -o /app/publish --no-restore

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/Gainzville.Client/dist .
COPY nginx.conf /etc/nginx/nginx.conf