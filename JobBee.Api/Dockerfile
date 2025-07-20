FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

ENV NUGET_PACKAGES=/src/.nuget/packages
ENV DOTNET_CLI_HOME=/src/.dotnet

COPY ["JobBee.Api/JobBee.Api.csproj", "JobBee.Api/"]
COPY ["JobBee.Application/JobBee.Application.csproj", "JobBee.Application/"]
COPY ["JobBee.Domain/JobBee.Domain.csproj", "JobBee.Domain/"]
COPY ["JobBee.Shared/JobBee.Shared.csproj", "JobBee.Shared/"]
COPY ["JobBee.Infrastructure/JobBee.Infrastructure.csproj", "JobBee.Infrastructure/"]
COPY ["JobBee.Persistence/JobBee.Persistence.csproj", "JobBee.Persistence/"]

RUN dotnet restore "./JobBee.Api/JobBee.Api.csproj"

COPY . .

WORKDIR "/src/JobBee.Api"
RUN dotnet build "./JobBee.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JobBee.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY --from=publish /app/publish .
COPY --from=build /src /app/src

ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "JobBee.Api.dll"]