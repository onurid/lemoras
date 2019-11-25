FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Services/Admin/Lemoras.Remora.Admin.Api/Lemoras.Remora.Admin.Api.csproj Services/Admin/Lemoras.Remora.Admin.Api/
COPY Common/Lemoras.Remora.Api/Lemoras.Remora.Api.csproj Common/Lemoras.Remora.Api/
COPY Common/Lemoras.Remora.Infrastrcutre/Lemoras.Remora.Infrastrcutre.csproj Common/Lemoras.Remora.Infrastrcutre/
COPY Common/Lemoras.Remora.Core/Lemoras.Remora.Core.csproj Common/Lemoras.Remora.Core/
COPY Services/Admin/Lemoras.Remora.Admin.Business/Lemoras.Remora.Admin.Business.csproj Services/Admin/Lemoras.Remora.Admin.Business/
COPY Services/Admin/Lemoras.Remora.Admin.Domain/Lemoras.Remora.Admin.Domain.csproj Services/Admin/Lemoras.Remora.Admin.Domain/
COPY Services/Admin/Lemoras.Remora.Admin.Infrastructure/Lemoras.Remora.Admin.Infrastructure.csproj Services/Admin/Lemoras.Remora.Admin.Infrastructure/
RUN dotnet restore Services/Admin/Lemoras.Remora.Admin.Api/Lemoras.Remora.Admin.Api.csproj
COPY . .
WORKDIR /src/Services/Admin/Lemoras.Remora.Admin.Api
RUN dotnet build Lemoras.Remora.Admin.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Lemoras.Remora.Admin.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lemoras.Remora.Admin.Api.dll"]
