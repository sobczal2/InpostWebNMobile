FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sobczal.InPost.Api/Sobczal.InPost.Api.csproj", "Sobczal.InPost.Api/"]
COPY ["Sobczal.InPost.Application/Sobczal.InPost.Application.csproj", "Sobczal.InPost.Application/"]
COPY ["Sobczal.InPost.Dtos/Sobczal.InPost.Dtos.csproj", "Sobczal.InPost.Dtos/"]
COPY ["Sobczal.InPost.Infrastructure/Sobczal.InPost.Infrastructure.csproj", "Sobczal.InPost.Infrastructure/"]
COPY ["Sobczal.InPost.Models/Sobczal.InPost.Models.csproj", "Sobczal.InPost.Models/"]
RUN dotnet restore "Sobczal.InPost.Api/Sobczal.InPost.Api.csproj"
COPY . .
WORKDIR "/src/Sobczal.InPost.Api"
RUN dotnet build "Sobczal.InPost.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sobczal.InPost.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sobczal.InPost.Api.dll"]
