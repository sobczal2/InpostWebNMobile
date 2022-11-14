FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sobczal.InPost.Client/Sobczal.InPost.Client.csproj", "Sobczal.InPost.Client/"]
RUN dotnet restore "Sobczal.InPost.Client/Sobczal.InPost.Client.csproj"
COPY . .
WORKDIR "/src/Sobczal.InPost.Client"
RUN dotnet build "Sobczal.InPost.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sobczal.InPost.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sobczal.InPost.Client.dll"]
