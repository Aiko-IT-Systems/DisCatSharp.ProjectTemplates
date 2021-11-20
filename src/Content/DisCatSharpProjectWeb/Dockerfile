#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#if (UseNet6)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#else
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#endif

WORKDIR /app
EXPOSE 80
EXPOSE 443

#if (UseNet6)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#else
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#endif
WORKDIR /src
COPY ["DisCatSharpWebHost/DisCatSharpWebHost.csproj", "DisCatSharpWebHost/"]
RUN dotnet restore "DisCatSharpWebHost/DisCatSharpWebHost.csproj"
COPY . .
WORKDIR "/src/DisCatSharpWebHost"
RUN dotnet build "DisCatSharpWebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DisCatSharpWebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DisCatSharpWebHost.dll"]