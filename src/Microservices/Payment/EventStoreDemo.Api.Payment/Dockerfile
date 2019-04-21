FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 23453

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Microservices/Payment/EventStoreDemo.Api.Payment/EventStoreDemo.Api.Payment.csproj", "Microservices/Payment/EventStoreDemo.Api.Payment/"]
COPY ["Microservices/Payment/EventStoreDemo.Domain.Payment/EventStoreDemo.Domain.Payment.csproj", "Microservices/Payment/EventStoreDemo.Domain.Payment/"]
COPY ["EventStoreDemo.Domain/EventStoreDemo.Domain.csproj", "EventStoreDemo.Domain/"]
RUN dotnet restore "Microservices/Payment/EventStoreDemo.Api.Payment/EventStoreDemo.Api.Payment.csproj"
COPY . .
WORKDIR "/src/Microservices/Payment/EventStoreDemo.Api.Payment"
RUN dotnet build "EventStoreDemo.Api.Payment.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStoreDemo.Api.Payment.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStoreDemo.Api.Payment.dll"]