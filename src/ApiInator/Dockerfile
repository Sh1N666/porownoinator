FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER root
RUN apt-get update && \
    apt-get install -y python3 python3-pip && \
    rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY Infrastructure/requirements.txt .
RUN pip3 install --no-cache-dir --break-system-packages -r requirements.txt
USER $APP_UID
EXPOSE 13001

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiInator/ApiInator.csproj", "src/ApiInator/"]
RUN dotnet restore "src/ApiInator/ApiInator.csproj"
COPY . .
WORKDIR "/src/src/ApiInator"
RUN dotnet build "./ApiInator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiInator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiInator.dll"]