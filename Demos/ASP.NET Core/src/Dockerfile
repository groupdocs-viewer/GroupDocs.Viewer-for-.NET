# syntax=docker/dockerfile:1

# How to build and run this demo in Docker container
# 1. To build execute `docker build -t groupdocs-viewer:aspnetcore-demo .`
# 2. To run execute `docker run --rm -d -p 8080:80 --name viewer-aspnetcore-demo groupdocs-viewer:aspnetcore-demo`
# 3. Navigete to <http://localhost:8080/viewer> in your browser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build-env /app/out .

# begin install libgdiplus and dependencies
RUN apt-get update \
    && apt-get install -y \
        apt-transport-https \
        dirmngr \
        gnupg \
        ca-certificates

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" >> /etc/apt/sources.list.d/mono-official-stable.list

RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev
# end install libgdiplus and dependencies

# begin ttf-mscorefonts-installer
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
	&& apt-get update \
    && apt-get install -y \
        libfontconfig1 \
        xfonts-utils \
		ttf-mscorefonts-installer
# end ttf-mscorefonts-installer

ENTRYPOINT ["dotnet", "GroupDocs.Viewer.AspNetCore.dll"]