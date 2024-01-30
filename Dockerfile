FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/GameHub.JanusWrapper.Api/GameHub.JanusWrapper.Api.csproj", "GameHub.JanusWrapper.Api/"]
RUN dotnet restore "GameHub.JanusWrapper.Api/GameHub.JanusWrapper.Api.csproj"
COPY . .
WORKDIR "/src/GameHub.JanusWrapper.Api"
RUN dotnet build "GameHub.JanusWrapper.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GameHub.JanusWrapper.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameHub.JanusWrapper.Api.dll"]
