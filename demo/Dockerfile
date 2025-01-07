# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory inside the container to /app
WORKDIR /app

# Copy the demo.csproj into the container's /app directory
COPY demo.csproj ./demo.csproj

# Restore the dependencies (nuget)
RUN dotnet restore demo.csproj

# Copy all files from the demo directory (including the source code)
COPY . .

# Build and publish the app
RUN dotnet publish demo.csproj -c Release -o /app/out

# Use a smaller runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the build output from the previous image
COPY --from=build-env /app/out .

# Expose the necessary port (default is 80)
EXPOSE 80

# Set the entry point to start the application
ENTRYPOINT ["dotnet", "demo.dll"]
