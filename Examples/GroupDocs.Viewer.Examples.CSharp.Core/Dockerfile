# Navigate to 'Examples' folder
# Build container image with `docker build -f "GroupDocs.Viewer.Examples.CSharp.Core\Dockerfile" -t groupdocs-viewer:examples .`
# Run container `docker run -it --rm -v ${pwd}/Output:/app/Output groupdocs-viewer:examples`
# Or run 'Docker' profile in Visual Studio

FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app

# begin install libgdiplus and dependencies
RUN apt-get update \
    && apt-get install -y \
        apt-transport-https \
        dirmngr \
        gnupg \
        ca-certificates

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic main" >> /etc/apt/sources.list.d/mono-official-stable.list

RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev

# begin ttf-mscorefonts-installer
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
	&& apt-get update \
    && apt-get install -y \
        libfontconfig1 \
        xfonts-utils \
		ttf-mscorefonts-installer
# end ttf-mscorefonts-installer

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["GroupDocs.Viewer.Examples.CSharp.Core/GroupDocs.Viewer.Examples.CSharp.Core.csproj", "GroupDocs.Viewer.Examples.CSharp.Core/"]
RUN dotnet restore "GroupDocs.Viewer.Examples.CSharp.Core/GroupDocs.Viewer.Examples.CSharp.Core.csproj"
COPY . .
WORKDIR "/src/GroupDocs.Viewer.Examples.CSharp.Core"
RUN dotnet build "GroupDocs.Viewer.Examples.CSharp.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupDocs.Viewer.Examples.CSharp.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupDocs.Viewer.Examples.CSharp.Core.dll"]