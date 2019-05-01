FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetcoreChat.Api/NetcoreChat.Api.csproj", "NetcoreChat.Api/"]
COPY ["NetcoreChat.Infrastructure.Data/NetcoreChat.Infrastructure.Data.csproj", "NetcoreChat.Infrastructure.Data/"]
COPY ["NetcoreChat.Domain.Entities/NetcoreChat.Domain.Entities.csproj", "NetcoreChat.Domain.Entities/"]
RUN dotnet restore "NetcoreChat.Api/NetcoreChat.Api.csproj"
COPY . .
WORKDIR "/src/NetcoreChat.Api"
RUN dotnet build "NetcoreChat.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetcoreChat.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetcoreChat.Api.dll"]
