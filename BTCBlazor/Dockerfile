#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Server/BTCBlazor.Server.csproj", "Server/"]
COPY ["Client/BTCBlazor.Client.csproj", "Client/"]
COPY ["Shared/BTCBlazor.Shared.csproj", "Shared/"]
COPY ["BTCBlazor.ClientTests/BTCBlazor.ClientTests.csproj", "BTCBlazor.ClientTests/"]

RUN dotnet restore "Server/BTCBlazor.Server.csproj"
RUN dotnet restore "BTCBlazor.ClientTests/BTCBlazor.ClientTests.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "BTCBlazor.Server.csproj" -c Release -o /app/build

WORKDIR "/src/BTCBlazor.ClientTests"
RUN dotnet build "BTCBlazor.ClientTests/BTCBlazor.ClientTests.csproj" -c Release -o /app/build
RUN dotnet test BTCBlazor.ClientTests/BTCBlazor.ClientTests.csproj -c Release --logger "trx;LogFileName=testresults.trx"

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTCBlazorApp.dll"]
