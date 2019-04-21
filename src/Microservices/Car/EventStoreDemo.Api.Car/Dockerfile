FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23450

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Microservices/Car/EventStoreDemo.Api.Car/EventStoreDemo.Api.Car.csproj", "Microservices/Car/EventStoreDemo.Api.Car/"]
COPY ["Microservices/Car/EventStoreDemo.Domain.Car/EventStoreDemo.Domain.Car.csproj", "Microservices/Car/EventStoreDemo.Domain.Car/"]
COPY ["EventStoreDemo.Domain/EventStoreDemo.Domain.csproj", "EventStoreDemo.Domain/"]
RUN dotnet restore "Microservices/Car/EventStoreDemo.Api.Car/EventStoreDemo.Api.Car.csproj"
COPY . .
WORKDIR "/src/Microservices/Car/EventStoreDemo.Api.Car"
RUN dotnet build "EventStoreDemo.Api.Car.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStoreDemo.Api.Car.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStoreDemo.Api.Car.dll"]