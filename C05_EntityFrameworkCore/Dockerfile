FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["C05_EntityFrameworkCore/C05_EntityFrameworkCore.csproj", "C05_EntityFrameworkCore/"]
RUN dotnet restore "C05_EntityFrameworkCore/C05_EntityFrameworkCore.csproj"
COPY . .
WORKDIR "/src/C05_EntityFrameworkCore"
RUN dotnet build "C05_EntityFrameworkCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C05_EntityFrameworkCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C05_EntityFrameworkCore.dll"]
