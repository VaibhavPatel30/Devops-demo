# Step 1: Use official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy rest of the files and build
COPY . ./
RUN dotnet publish -c Release -o out

# Step 2: Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/out ./

# Expose port (same as backend)
EXPOSE 1414


# Run the app
ENTRYPOINT ["dotnet", "docker-backend.dll"]