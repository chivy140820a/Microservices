#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Order.API/Order.API.csproj", "Order.API/"]
COPY ["Order.Infrastructures/Order.Infrastructures.csproj", "Order.Infrastructures/"]
COPY ["Product.API/Product.API.csproj", "Product.API/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Infrastructures/Infrastructures.csproj", "Infrastructures/"]
COPY ["Order.Domain/Order.Domain.csproj", "Order.Domain/"]
COPY ["Order.Application/Order.Application.csproj", "Order.Application/"]
RUN dotnet restore "Order.API/Order.API.csproj"
COPY . .
WORKDIR "/src/Order.API"
RUN dotnet build "Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.API.dll"]