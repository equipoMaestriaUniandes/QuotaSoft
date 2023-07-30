FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["4.WebApi/Quota.WebApi/Quota.WebApi.csproj", "4.WebApi/Quota.WebApi/"]
COPY ["1.Domain/Quota.Domain.Entities/Quota.Domain.Entities.csproj", "1.Domain/Quota.Domain.Entities/"]
COPY ["2.Infraestructure/Quota.Infra.IoC/Quota.Infra.IoC.csproj", "2.Infraestructure/Quota.Infra.IoC/"]
COPY ["3.Application/Quota.Application.Services/Quota.Application.Services.csproj", "3.Application/Quota.Application.Services/"]
COPY ["3.Application/Quota.Application.Contracts/Quota.Application.Contracts.csproj", "3.Application/Quota.Application.Contracts/"]
COPY ["3.Application/Quota.Application.Interfaces/Quota.Application.Interfaces.csproj", "3.Application/Quota.Application.Interfaces/"]
COPY ["1.Domain/Quota.Domain.Services/Quota.Domain.Services.csproj", "1.Domain/Quota.Domain.Services/"]
COPY ["1.Domain/Quota.Domain.Interfaces/Quota.Domain.Interfaces.csproj", "1.Domain/Quota.Domain.Interfaces/"]
COPY ["2.Infraestructure/Quota.Infra.Data/Quota.Infra.Data.csproj", "2.Infraestructure/Quota.Infra.Data/"]
RUN dotnet restore "4.WebApi/Quota.WebApi/Quota.WebApi.csproj"
COPY . .
WORKDIR "/src/4.WebApi/Quota.WebApi"
RUN dotnet build "Quota.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quota.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "Quota.WebApi.dll"]