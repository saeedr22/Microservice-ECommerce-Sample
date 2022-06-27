FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5267


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECommerce.Api.Customers/ECommerce.Api.Customers.csproj", "ECommerce.Api.Customers/"]
RUN dotnet restore "ECommerce.Api.Customers/ECommerce.Api.Customers.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api.Customers"
RUN dotnet build "ECommerce.Api.Customers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.Customers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.Customers.dll"]