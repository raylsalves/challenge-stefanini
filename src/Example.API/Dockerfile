#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Example.API/Stefanini.Challenge.API.csproj", "src/Example.API/"]
COPY ["src/Example.Application/Stefanini.Challenge.Application.csproj", "src/Example.Application/"]
COPY ["src/Example.Infra.Data/Stefanini.Challenge.Infra.Data.csproj", "src/Example.Infra.Data/"]
COPY ["src/Example.Domain/Stefanini.Challenge.Domain.csproj", "src/Example.Domain/"]
RUN dotnet restore "src/Example.API/Stefanini.Challenge.API.csproj"
COPY . .
WORKDIR "/src/src/Example.API"
RUN dotnet build "Stefanini.Challenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stefanini.Challenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stefanini.Challenge.API.dll"]
