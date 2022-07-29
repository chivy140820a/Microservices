#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderContent.API/OrderContent.API.csproj", "OrderContent.API/"]
COPY ["Order.Infrastructures/Order.Infrastructures.csproj", "Order.Infrastructures/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Infrastructures/Infrastructures.csproj", "Infrastructures/"]
COPY ["Order.Domain/Order.Domain.csproj", "Order.Domain/"]
COPY ["Order.Application/Order.Application.csproj", "Order.Application/"]
RUN dotnet restore "OrderContent.API/OrderContent.API.csproj"
COPY . .
WORKDIR "/src/OrderContent.API"
RUN dotnet build "OrderContent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderContent.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderContent.API.dll"]