FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper.Api/VideoGameHub.JanusWrapper.Api.csproj", "src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper.Api/"]
COPY ["src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper/VideoGameHub.JanusWrapper.csproj", "src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper/"]
COPY ["src/VideoGameHub.BuildingBlock/VideoGameHub.BuildingBlock.csproj", "src/VideoGameHub.BuildingBlock/"]
RUN dotnet restore "src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper.Api/VideoGameHub.JanusWrapper.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/JanusWrapper/src/VideoGameHub.JanusWrapper.Api"
RUN dotnet build "VideoGameHub.JanusWrapper.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VideoGameHub.JanusWrapper.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoGameHub.JanusWrapper.Api.dll"]
