#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8084
EXPOSE 8085

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MsContatos.Api/MsContatos.Api.csproj", "MsContatos.Api/"]
COPY ["MsContatos.Core/MsContatos.Core.csproj", "MsContatos.Core/"]
COPY ["MsContatos.Shared/MsContatos.Shared.csproj", "MsContatos.Shared/"]
COPY ["MsContatos.Infra/MsContatos.Infra.csproj", "MsContatos.Infra/"]
RUN dotnet restore "./MsContatos.Api/MsContatos.Api.csproj"
COPY . .
WORKDIR "/src/MsContatos.Api"
RUN dotnet build "./MsContatos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MsContatos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MsContatos.Api.dll"]