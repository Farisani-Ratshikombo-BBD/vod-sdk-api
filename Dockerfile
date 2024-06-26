FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080
# Copy everything
COPY . ./
# Restore as distinct layers

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/VodacomCSharpAPI/bin/Release/net8.0 .
ENTRYPOINT ["dotnet", "VodacomCSharpAPI.dll"]
