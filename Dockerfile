FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY codes_netCore ./
RUN cp appsettings.Docker.json appsettings.json
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "codes_netCore.dll"]
