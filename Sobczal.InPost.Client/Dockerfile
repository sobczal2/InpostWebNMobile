FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sobczal.InPost.Client/Sobczal.InPost.Client.csproj", "Sobczal.InPost.Client/"]
COPY ["Sobczal.InPost.Dtos/Sobczal.InPost.Dtos.csproj", "Sobczal.InPost.Dtos/"]
RUN dotnet restore "Sobczal.InPost.Client/Sobczal.InPost.Client.csproj"
COPY . .
WORKDIR "/src/Sobczal.InPost.Client"
RUN dotnet build "Sobczal.InPost.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sobczal.InPost.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Sobczal.InPost.Client/nginx.conf /etc/nginx/nginx.conf
