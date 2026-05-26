FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test
WORKDIR /src

COPY GeometryLib/GeometryLib.csproj GeometryLib/
COPY GeometryTest/GeometryTest.csproj GeometryTest/

RUN dotnet restore GeometryTest/GeometryTest.csproj

COPY GeometryLib/ GeometryLib/
COPY GeometryTest/ GeometryTest/

ENTRYPOINT ["dotnet", "test", "GeometryTest/GeometryTest.csproj", "--no-restore", "--verbosity", "normal"]