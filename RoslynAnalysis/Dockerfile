FROM mcr.microsoft.com/dotnet/runtime:6.0-bookworm-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/runtime:6.0-bookworm-slim AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RoslynAnalysis/RoslynAnalysis.csproj", "RoslynAnalysis/"]
RUN dotnet restore "./RoslynAnalysis/RoslynAnalysis.csproj"
COPY . .
WORKDIR "/src/RoslynAnalysis"
RUN dotnet build "./RoslynAnalysis.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoslynAnalysis.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoslynAnalysis.dll"]
