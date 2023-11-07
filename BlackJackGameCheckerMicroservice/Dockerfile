#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlackJackGameCheckerMicroservice/BlackJackGameCheckerMicroservice.csproj", "BlackJackGameCheckerMicroservice/"]
RUN dotnet restore "BlackJackGameCheckerMicroservice/BlackJackGameCheckerMicroservice.csproj"
COPY . .
WORKDIR "/src/BlackJackGameCheckerMicroservice"
RUN dotnet build "BlackJackGameCheckerMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlackJackGameCheckerMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlackJackGameCheckerMicroservice.dll"]