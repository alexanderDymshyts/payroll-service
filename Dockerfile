# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./PayrollService/PayrollService.csproj" --disable-parallel
COPY . .
RUN dotnet publish "./PayrollService/PayrollService.csproj" -c release -o /app 

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal 
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "PayrollService.dll"]

