FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app

COPY *.sln .
COPY SimpleApplication/*.csproj ./SimpleApplication/
COPY SimpleApplication/*.config ./SimpleApplication/
RUN nuget restore

COPY SimpleApplication/. ./SimpleApplication/
WORKDIR /app/SimpleApplication
RUN msbuild -r:False


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/SimpleApplication/. ./
