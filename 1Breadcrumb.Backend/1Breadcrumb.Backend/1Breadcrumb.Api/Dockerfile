FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["1Breadcrumb.Api/1Breadcrumb.Api.csproj", "1Breadcrumb.Api/"]
RUN dotnet restore "1Breadcrumb.Api/1Breadcrumb.Api.csproj"
COPY . .
WORKDIR "/src/1Breadcrumb.Api"
RUN dotnet build "./1Breadcrumb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./1Breadcrumb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "1Breadcrumb.Api.dll"]
