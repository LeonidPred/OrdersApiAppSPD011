#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrdersApiAppSPD011/OrdersApiAppSPD011.csproj", "OrdersApiAppSPD011/"]
RUN dotnet restore "OrdersApiAppSPD011/OrdersApiAppSPD011.csproj"
COPY . .
WORKDIR "/src/OrdersApiAppSPD011"
RUN dotnet build "OrdersApiAppSPD011.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrdersApiAppSPD011.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersApiAppSPD011.dll"]