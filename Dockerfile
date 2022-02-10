FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

COPY bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "aspnetapp.dll"]