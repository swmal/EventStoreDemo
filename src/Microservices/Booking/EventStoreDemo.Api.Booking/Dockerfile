FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23451

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Microservices/Booking/EventStoreDemo.Api.Booking/EventStoreDemo.Api.Booking.csproj", "Microservices/Booking/EventStoreDemo.Api.Booking/"]
COPY ["Microservices/Booking/EventStoreDemo.Domain.Booking/EventStoreDemo.Domain.Booking.csproj", "Microservices/Booking/EventStoreDemo.Domain.Booking/"]
COPY ["EventStoreDemo.Domain/EventStoreDemo.Domain.csproj", "EventStoreDemo.Domain/"]
RUN dotnet restore "Microservices/Booking/EventStoreDemo.Api.Booking/EventStoreDemo.Api.Booking.csproj"
COPY . .
WORKDIR "/src/Microservices/Booking/EventStoreDemo.Api.Booking"
RUN dotnet build "EventStoreDemo.Api.Booking.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStoreDemo.Api.Booking.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStoreDemo.Api.Booking.dll"]