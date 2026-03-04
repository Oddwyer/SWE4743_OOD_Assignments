# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY TeaShoppe/TeaShoppe.csproj TeaShoppe/
RUN dotnet restore TeaShoppe/TeaShoppe.csproj

# Copy the rest of the source
COPY . .

# Build and publish
WORKDIR /src/TeaShoppe
RUN dotnet publish TeaShoppe.csproj -c Release -o /app/publish

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TeaShoppe.dll"]