#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitTestProject/UnitTestProject.csproj", "UnitTestProject/"]
COPY ["DomainLayer/DomainLayer.csproj", "DomainLayer/"]
COPY ["CalculateSalaryAPIs/CalculateSalaryAPIs.csproj", "CalculateSalaryAPIs/"]
COPY ["ServiceLayer/ServiceLayer.csproj", "ServiceLayer/"]
RUN dotnet restore "UnitTestProject/UnitTestProject.csproj"
COPY . .
WORKDIR "/src/UnitTestProject"
RUN dotnet build "UnitTestProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTestProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTestProject.dll"]