FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-preview AS base
WORKDIR /App
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview AS build
WORKDIR /src

COPY LAB.Clothing.Collection.sln /src
COPY . /src
RUN dotnet restore
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o out --no-restore

FROM base AS final
WORKDIR /App
COPY --from=publish /src/out /App
ENTRYPOINT ["dotnet", "/App/LABCC.Application.dll"]
