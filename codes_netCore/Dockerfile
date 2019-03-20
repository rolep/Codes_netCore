FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["codes_netCore/codes_netCore.csproj", "codes_netCore/"]
RUN dotnet restore "codes_netCore/codes_netCore.csproj"
COPY . .
WORKDIR "/src/codes_netCore"
RUN dotnet build "codes_netCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "codes_netCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "codes_netCore.dll"]