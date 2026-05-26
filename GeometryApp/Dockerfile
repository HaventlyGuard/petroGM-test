FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY GeometryLib/GeometryLib.csproj GeometryLib/
COPY GeometryApp/GeometryApp.csproj GeometryApp/

RUN dotnet restore GeometryApp/GeometryApp.csproj

COPY GeometryLib/ GeometryLib/
COPY GeometryApp/ GeometryApp/

RUN dotnet publish GeometryApp/GeometryApp.csproj -c Release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/runtime:9.0 AS runtime
WORKDIR /app

RUN apt-get update && \
    apt-get install -y --no-install-recommends locales && \
    locale-gen en_US.UTF-8 && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

ENV LANG=en_US.UTF-8
ENV LC_ALL=en_US.UTF-8
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /app .

COPY GeometryApp/input.txt /app/input.txt

ENTRYPOINT ["dotnet", "GeometryApp.dll"]
CMD ["/app/input.txt"]