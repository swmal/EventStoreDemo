//const client = require('../src/client');
const client = require("node-eventstore-client");
const eventhandler = require("./eventhandler.js");

const resolveLinkTos = true;

const eventAppeared = (subscription, event) => eventhandler.handleEvent(subscription, event);

const subscriptionDropped = (subscription, reason, error) => console.log("Subscription dropped", reason, error);

const libeProcessingStarted = () => console.log("Live processing started.");

const credentials = new client.UserCredentials("admin", "changeit");

var endpoint = "tcp://localhost:1113";
if (process.env.DEMO1_EVENTSTORE_URL)
    endpoint = process.env.DEMO1_EVENTSTORE_URL;
console.log("endpoint ", endpoint);
const settings = {};
const connection = client.createConnection(settings, endpoint);

connection.connect().catch(err => console.log("Connection failed", err));

connection.on('heartbeatInfo', heartbeatInfo =>
    console.log('Heartbeat latency', heartbeatInfo.responseReceivedAt - heartbeatInfo.requestSentAt, 'ms')
);

connection.once("connected", tcpEndPoint => {
    console.log(`Connected to eventstore at ${tcpEndPoint.host}:${tcpEndPoint.port}`);

    connection.subscribeToStream(
        "demo1.car",
        resolveLinkTos,
        eventAppeared,
        subscriptionDropped,
        credentials
    );
});

connection.on("error", error =>
    console.log(`Error occurred on connection: ${error}`)
)

connection.on("closed", reason =>
    console.log(`Connection closed, reason: ${reason}`)
)