#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BTCBlazor.Server.csproj", "Server/"]
COPY ["BTCBlazor/Client/BTCBlazor.Client.csproj", "Client/"]
COPY ["BTCBlazor/Shared/BTCBlazor.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/BTCBlazor.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "BTCBlazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BTCBlazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTCBlazor.Server.dll"]