FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Madiff.CardsPermissionsCalculator.API/Madiff.CardsPermissionsCalculator.API.csproj", "Madiff.CardsPermissionsCalculator.API/"]
RUN dotnet restore "Madiff.CardsPermissionsCalculator.API/Madiff.CardsPermissionsCalculator.API.csproj"
COPY . .
WORKDIR "/src/Madiff.CardsPermissionsCalculator.API"
RUN dotnet build "Madiff.CardsPermissionsCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Madiff.CardsPermissionsCalculator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Madiff.CardsPermissionsCalculator.API.dll"]
