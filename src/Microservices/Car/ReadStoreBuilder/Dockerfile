FROM node:8

# Create app directory
WORKDIR /src/app

ENV DEMO1_EVENTSTORE_URL=tcp://admin:changeit@eventstore:1113

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY ["Microservices/Car/ReadStoreBuilder/package*.json", "/src/app/"]

RUN npm install
# If you are building your code for production
# RUN npm ci --only=production

# Bundle app source
COPY ["Microservices/Car/ReadStoreBuilder/", "/src/app/"]

CMD [ "npm", "start" ]