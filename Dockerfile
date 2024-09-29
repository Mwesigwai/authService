FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildEnv
WORKDIR /app
EXPOSE 80
EXPOSE 433  

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS finalEnv
COPY --from=buildEnv /app/out .
ENTRYPOINT [ "dotnet", "authService.dll" ]
