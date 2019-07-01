FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CompanySoftwareStore/CompanySoftwareStore.csproj", "CompanySoftwareStore/"]
RUN dotnet restore "CompanySoftwareStore/CompanySoftwareStore.csproj"
WORKDIR "/src/CompanySoftwareStore"
COPY . .
RUN dotnet build "CompanySoftwareStore.csproj" -c Release -o /app

FROM build AS publish
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install -y nodejs
RUN dotnet publish "CompanySoftwareStore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CompanySoftwareStore.dll"]