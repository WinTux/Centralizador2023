FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Centralizador2023.csproj", ""]
RUN dotnet restore "./Centralizador2023.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Centralizador2023.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Centralizador2023.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Centralizador2023.dll"]