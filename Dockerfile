FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TaskHub.API/TaskHub.API.csproj", "src/TaskHub.API/"]
COPY ["src/TaskHub.Application/TaskHub.Application.csproj", "src/TaskHub.Application/"]
COPY ["src/TaskHub.Domain/TaskHub.Domain.csproj", "src/TaskHub.Domain/"]
COPY ["src/TaskHub.Infrastructure/TaskHub.Infrastructure.csproj", "src/TaskHub.Infrastructure/"]
RUN dotnet restore "./src/TaskHub.API/TaskHub.API.csproj"
COPY . .
WORKDIR "/src/src/TaskHub.API"
RUN dotnet build "./TaskHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaskHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskHub.API.dll"]
