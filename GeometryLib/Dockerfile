FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY GeometryLib/GeometryLib.csproj GeometryLib/

RUN dotnet restore GeometryLib/GeometryLib.csproj

COPY GeometryLib/ GeometryLib/

RUN dotnet build GeometryLib/GeometryLib.csproj -c Release --no-restore

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final
WORKDIR /lib
COPY --from=build /src/GeometryLib/bin/Release/net9.0/ /lib/
CMD ["echo", "GeometryLib built successfully"]