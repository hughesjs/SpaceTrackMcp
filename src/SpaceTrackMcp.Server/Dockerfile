FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SpaceTrackMcp.Server/SpaceTrackMcp.Server.csproj", "SpaceTrackMcp.Server/"]
RUN dotnet restore "SpaceTrackMcp.Server/SpaceTrackMcp.Server.csproj"
COPY . .
WORKDIR "/src/SpaceTrackMcp.Server"
RUN dotnet build "./SpaceTrackMcp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SpaceTrackMcp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceTrackMcp.Server.dll"]
