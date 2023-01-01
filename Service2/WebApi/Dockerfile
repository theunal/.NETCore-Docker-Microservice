FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7002

ENV ASPNETCORE_URLS=https://+:7002
ENV ASPNETCORE_ENVIRONMENT=Development

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Service2/WebApi/WebApi.csproj", "Service2/WebApi/"]
RUN dotnet restore "Service2/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Service2/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
