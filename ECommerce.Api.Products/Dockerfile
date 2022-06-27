FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5267


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
WORKDIR /src
COPY ["ECommerce.Api.Products/ECommerce.Api.Products.csproj", "ECommerce.Api.Products/"]
RUN dotnet restore "ECommerce.Api.Products/ECommerce.Api.Products.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api.Products"
RUN dotnet build "ECommerce.Api.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.Products.dll"]