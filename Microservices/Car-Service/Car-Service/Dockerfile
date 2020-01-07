FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Car-Service/Car-Service.csproj", "Car-Service/"]
RUN dotnet restore "Car-Service/Car-Service.csproj"
COPY . .
WORKDIR "/src/Car-Service"
RUN dotnet build "Car-Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Car-Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Car-Service.dll"]