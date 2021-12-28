FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["C04_ASPNET.Core/C04_ASPNET.Core.csproj", "C04_ASPNET.Core/"]
RUN dotnet restore "C04_ASPNET.Core/C04_ASPNET.Core.csproj"
COPY . .
WORKDIR "/src/C04_ASPNET.Core"
RUN dotnet build "C04_ASPNET.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C04_ASPNET.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C04_ASPNET.Core.dll"]
