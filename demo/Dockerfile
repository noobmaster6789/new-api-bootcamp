# Use the official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["new-api-bootcamp.csproj", "./"]
RUN dotnet restore "new-api-bootcamp.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Copy the build output to the final container
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "new-api-bootcamp.dll"]
