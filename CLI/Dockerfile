FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CLI/CLI.fsproj", "CLI/"]
RUN dotnet restore "CLI/CLI.fsproj"
COPY . .
WORKDIR "/src/CLI"
RUN dotnet build "CLI.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CLI.fsproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CLI.dll"]
