FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TeaShoppe.Web/TeaShoppe.Web.csproj", "TeaShoppe.Web/"]
RUN dotnet restore "TeaShoppe.Web/TeaShoppe.Web.csproj"
COPY . .
WORKDIR "/src/TeaShoppe.Web"
RUN dotnet build "./TeaShoppe.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TeaShoppe.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeaShoppe.Web.dll"]