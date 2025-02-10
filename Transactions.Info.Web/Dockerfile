FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Transactions.Info.Web/Transactions.Info.Web.csproj", "Transactions.Info.Web/"]
RUN dotnet restore "Transactions.Info.Web/Transactions.Info.Web.csproj"
COPY . .
WORKDIR "/src/Transactions.Info.Web"
RUN dotnet build "Transactions.Info.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Transactions.Info.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transactions.Info.Web.dll"]