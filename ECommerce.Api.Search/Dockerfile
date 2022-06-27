FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5267

ENV ASPNETCORE_URLS=http://+:5267

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECommerce.Api.Search/ECommerce.Api.Search.csproj", "ECommerce.Api.Search/"]
RUN dotnet restore "ECommerce.Api.Search\ECommerce.Api.Search.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api.Search"
RUN dotnet build "ECommerce.Api.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.Search.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.Search.dll"]
