#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ENV APP_HOME /src
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY ["CompanyService/*.csproj", "$APP_HOME/CompanyService/"]
COPY ["CompanyService.Api/*.csproj", "$APP_HOME/CompanyService.Api/"]
RUN cd $APP_HOME/CompanyService && dotnet restore

COPY ["CompanyService", "$APP_HOME/CompanyService/"]
COPY ["CompanyService.Api", "$APP_HOME/CompanyService.Api/"]
RUN cd $APP_HOME/CompanyService && dotnet build

FROM build AS publish
WORKDIR $APP_HOME/CompanyService
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5030
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyService.dll"]