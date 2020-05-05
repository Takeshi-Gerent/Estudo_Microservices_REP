#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ENV APP_HOME /src
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY ["EmployeeService/*.csproj", "$APP_HOME/EmployeeService/"]
COPY ["EmployeeService.Api/*.csproj", "$APP_HOME/EmployeeService.Api/"]
RUN cd $APP_HOME/EmployeeService && dotnet restore

COPY ["EmployeeService", "$APP_HOME/EmployeeService/"]
COPY ["EmployeeService.Api", "$APP_HOME/EmployeeService.Api/"]
RUN cd $APP_HOME/EmployeeService && dotnet build

FROM build AS publish
WORKDIR $APP_HOME/EmployeeService
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5040
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.dll"]