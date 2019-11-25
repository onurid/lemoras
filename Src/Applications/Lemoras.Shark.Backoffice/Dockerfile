FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Applications/Lemoras.Shark.Backoffice/Lemoras.Shark.Backoffice.csproj Applications/Lemoras.Shark.Backoffice/
RUN dotnet restore Applications/Lemoras.Shark.Backoffice/Lemoras.Shark.Backoffice.csproj
COPY . .
WORKDIR /src/Applications/Lemoras.Shark.Backoffice
RUN dotnet build Lemoras.Shark.Backoffice.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Lemoras.Shark.Backoffice.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lemoras.Shark.Backoffice.dll"]
