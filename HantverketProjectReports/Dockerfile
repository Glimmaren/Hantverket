#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HantverketProjectReports/HantverketProjectReports.csproj", "HantverketProjectReports/"]
RUN dotnet restore "HantverketProjectReports/HantverketProjectReports.csproj"
COPY . .
WORKDIR "/src/HantverketProjectReports"
RUN dotnet build "HantverketProjectReports.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HantverketProjectReports.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HantverketProjectReports.dll"]
