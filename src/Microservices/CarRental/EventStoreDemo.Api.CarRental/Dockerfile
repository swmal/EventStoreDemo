FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23452

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Microservices/CarRental/EventStoreDemo.Api.CarRental/EventStoreDemo.Api.CarRental.csproj", "Microservices/CarRental/EventStoreDemo.Api.CarRental/"]
COPY ["Microservices/CarRental/EventStoreDemo.Domain.CarRental/EventStoreDemo.Domain.CarRental.csproj", "Microservices/CarRental/EventStoreDemo.Domain.CarRental/"]
COPY ["EventStoreDemo.Domain/EventStoreDemo.Domain.csproj", "EventStoreDemo.Domain/"]
RUN dotnet restore "Microservices/CarRental/EventStoreDemo.Api.CarRental/EventStoreDemo.Api.CarRental.csproj"
COPY . .
WORKDIR "/src/Microservices/CarRental/EventStoreDemo.Api.CarRental"
RUN dotnet build "EventStoreDemo.Api.CarRental.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStoreDemo.Api.CarRental.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStoreDemo.Api.CarRental.dll"]