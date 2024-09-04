#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

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
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GroupDocs.Viewer.AspNetCore.CrossPlatform.csproj", "."]
RUN dotnet restore "./GroupDocs.Viewer.AspNetCore.CrossPlatform.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./GroupDocs.Viewer.AspNetCore.CrossPlatform.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GroupDocs.Viewer.AspNetCore.CrossPlatform.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupDocs.Viewer.AspNetCore.CrossPlatform.dll"]