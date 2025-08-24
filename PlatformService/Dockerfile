FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Expose port 80 for the application
EXPOSE 80

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the default listening URLs for the container
ENV ASPNETCORE_URLS=http://0.0.0.0:80

ENTRYPOINT [ "dotnet", "PlatformService.dll" ]