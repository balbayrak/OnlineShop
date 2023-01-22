#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Customer/WebApi/OnlineShop.Customer.WebApi/OnlineShop.Customer.WebApi.csproj", "src/Services/Customer/WebApi/OnlineShop.Customer.WebApi/"]
RUN dotnet restore "src/Services/Customer/WebApi/OnlineShop.Customer.WebApi/OnlineShop.Customer.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Customer/WebApi/OnlineShop.Customer.WebApi"
RUN dotnet build "OnlineShop.Customer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShop.Customer.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShop.Customer.WebApi.dll"]