#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NjordBooks.API.csproj", ""]
RUN dotnet restore "./NjordBooks.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NjordBooks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NjordBooks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NjordBooks.API.dll