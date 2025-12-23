# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore EShop.Api/EShop.Api.csproj
RUN dotnet publish EShop.Api/EShop.Api.csproj -c Release -o /out

# Etapa final: runtime limpio
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "EShop.Api.dll"]