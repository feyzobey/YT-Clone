FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VideoClone.WebAPI/VideoClone.WebAPI.csproj", "VideoClone.WebAPI/"]
RUN dotnet restore "VideoClone.WebAPI/VideoClone.WebAPI.csproj"
COPY . .
WORKDIR "/src/VideoClone.WebAPI"
RUN dotnet build "VideoClone.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoClone.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoClone.WebAPI.dll"]
