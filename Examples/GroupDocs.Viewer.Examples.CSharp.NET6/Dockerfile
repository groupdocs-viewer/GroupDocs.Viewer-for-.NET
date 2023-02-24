# Navigate to 'Examples' folder
# Build container image with `docker build -f "GroupDocs.Viewer.Examples.CSharp.NET6\Dockerfile" -t groupdocs-viewer:examples .`
# Run container `docker run -it --rm -v ${pwd}/Output:/app/Output groupdocs-viewer:examples`
# Or run 'Docker' profile in Visual Studio

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# begin install libgdiplus
RUN apt update; apt install apt-transport-https dirmngr gnupg ca-certificates -y
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN "deb https://download.mono-project.com/repo/debian stable-buster main" | tee /etc/apt/sources.list.d/mono-official-stable.list
RUN apt update; apt install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev
# end install libgdiplus
		
# begin ttf-mscorefonts-installer
RUN sed -i'.bak' 's/$/ contrib/' /etc/apt/sources.list
RUN apt update; apt install -y ttf-mscorefonts-installer fontconfig
# end ttf-mscorefonts-installer

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GroupDocs.Viewer.Examples.CSharp.NET6/GroupDocs.Viewer.Examples.CSharp.NET6.csproj", "GroupDocs.Viewer.Examples.CSharp.NET6/"]
RUN dotnet restore "GroupDocs.Viewer.Examples.CSharp.NET6/GroupDocs.Viewer.Examples.CSharp.NET6.csproj"
COPY . .
WORKDIR "/src/GroupDocs.Viewer.Examples.CSharp.NET6"
RUN dotnet build "GroupDocs.Viewer.Examples.CSharp.NET6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupDocs.Viewer.Examples.CSharp.NET6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupDocs.Viewer.Examples.CSharp.NET6.dll"]