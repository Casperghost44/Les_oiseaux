FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Les_oiseaux.Web/Les_oiseaux.Web.csproj", "Les_oiseaux.Web/"]
COPY ["Les_oiseaux.Inf/Les_oiseaux.Inf.csproj", "Les_oiseaux.Inf/"]
COPY ["Les_oiseaux.App/Les_oiseaux.App.csproj", "Les_oiseaux.App/"]

RUN dotnet restore "Les_oiseaux.Web/Les_oiseaux.Web.csproj"

COPY . .
WORKDIR "/src/Les_oiseaux.Web"

RUN dotnet build "Les_oiseaux.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Les_oiseaux.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "Les_oiseaux.Web.dll"]