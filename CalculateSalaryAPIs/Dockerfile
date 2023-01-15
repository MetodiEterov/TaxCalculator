#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CalculateSalaryAPIs/CalculateSalaryAPIs.csproj", "CalculateSalaryAPIs/"]
COPY ["DomainLayer/DomainLayer.csproj", "DomainLayer/"]
COPY ["ServiceLayer/ServiceLayer.csproj", "ServiceLayer/"]
RUN dotnet restore "CalculateSalaryAPIs/CalculateSalaryAPIs.csproj"
COPY . .
WORKDIR "/src/CalculateSalaryAPIs"
RUN dotnet build "CalculateSalaryAPIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculateSalaryAPIs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculateSalaryAPIs.dll"]