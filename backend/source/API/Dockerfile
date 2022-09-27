#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["source/API/OriolOr.Maneko.API.csproj", "source/API/"]
COPY ["source/Services/OriolOr.Maneko.Services.csproj", "source/Services/"]
COPY ["source/Domain/OriolOr.Maneko.Domain.csproj", "source/Domain/"]
COPY ["source/Infrastructure/OriolOr.Maneko.Infrastructure.csproj", "source/Infrastructure/"]
COPY ["source/ExternalCom/OriolOr.Maneko.ExternalCom.csproj", "source/ExternalCom/"]
RUN dotnet restore "source/API/OriolOr.Maneko.API.csproj"
COPY . .
WORKDIR "/src/source/API"
RUN dotnet build "OriolOr.Maneko.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OriolOr.Maneko.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OriolOr.Maneko.API.dll"]