FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 6789


FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Location Service/Location Service.csproj", "Location Service/"]
RUN dotnet restore "Location Service/Location Service.csproj"
COPY . .
WORKDIR "/src/Location Service"
RUN dotnet build "Location Service.csproj" -c Release -o /published

FROM build AS publish
RUN dotnet publish "Location Service.csproj" -c Release -o /published

FROM base AS final
WORKDIR /app
COPY --from=publish /published .
ENTRYPOINT ["dotnet", "Location Service.dll"]