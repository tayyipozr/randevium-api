# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . . 

ENV ASPNETCORE_ENVIRONMENT=Development

RUN dotnet restore ".\src\randevu\WebAPI\WebAPI.csproj" --disable-parallel
RUN dotnet publish ".\src\randevu\WebAPI\WebAPI.csproj" -c release -o /app --no-restore


# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "WebAPI.dll"]