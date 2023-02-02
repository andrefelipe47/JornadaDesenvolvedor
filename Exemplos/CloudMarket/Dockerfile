#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CloudMarket/CloudMarket.csproj", "CloudMarket/"]
RUN dotnet restore "CloudMarket/CloudMarket.csproj"
COPY . .
WORKDIR "/src/CloudMarket"
RUN dotnet build "CloudMarket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudMarket.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudMarket.dll"]