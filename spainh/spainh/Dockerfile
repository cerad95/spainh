FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /spainh

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /spainh
COPY --from=build-env /spainh/out .
ENTRYPOINT ["dotnet", "spainh.dll"]