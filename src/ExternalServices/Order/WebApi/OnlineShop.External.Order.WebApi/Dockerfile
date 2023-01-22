#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ExternalServices/Order/WebApi/OnlineShop.External.Order.WebApi/OnlineShop.External.Order.WebApi.csproj", "src/ExternalServices/Order/WebApi/OnlineShop.External.Order.WebApi/"]
RUN dotnet restore "src/ExternalServices/Order/WebApi/OnlineShop.External.Order.WebApi/OnlineShop.External.Order.WebApi.csproj"
COPY . .
WORKDIR "/src/src/ExternalServices/Order/WebApi/OnlineShop.External.Order.WebApi"
RUN dotnet build "OnlineShop.External.Order.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShop.External.Order.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShop.External.Order.WebApi.dll"]