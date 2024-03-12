FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Prohelika.API/Prohelika.API.csproj", "src/Prohelika.API/"]
COPY ["src/Prohelika.Infrastructure/Prohelika.Infrastructure.csproj", "src/Prohelika.Infrastructure/"]
COPY ["src/Prohelika.Domain/Prohelika.Domain.csproj", "src/Prohelika.Domain/"]
COPY ["src/Prohelika.Application/Prohelika.Application.csproj", "src/Prohelika.Application/"]
RUN dotnet restore "src/Prohelika.API/Prohelika.API.csproj"
COPY . .
WORKDIR "/src/src/Prohelika.API"
RUN dotnet build "Prohelika.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Prohelika.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prohelika.API.dll"]
