var subscriber = require("eventstore-stream-subscriber");
var request = require("request");

// helper methods
function postCommand(command, url) {
    request.post({
        url: url,
        body: command,
        json: true
    }, function (err, response, body) {
        if (!err && response.statusCode == 200) {
            console.log(body);
        }
        else {
            if (response)
                console.log("Status: " + response.statusCode);
            if (err)
                console.log("Error: " + err.toString());
        }
    });
}

function eventToJson(evt) {
    console.log("Event received");
    let e = evt.originalEvent.data.toString();
    console.log(e);
    return JSON.parse(e);
}

function logCommand(command) {
    console.log("Command created: " + command.toString());
}

function validateEvent(eventType, jsonEvent) {
    var schemaPath = "./schemas/Car/events/" + eventType + ".json";
    console.log("event schemapath: " + schemaPath.toString());
    var schema = require(schemaPath);
    var validateSchema = require('jsonschema').validate;
    var result = validateSchema(jsonEvent, schema);
    if (!result.valid) {
        console.log(eventType + " event was not valid with schema " + schemaPath);
        console.log(result.toString());
        return false;
    }
    return true;
}

// register eventhandlers for eventtypes of a stream
subscriber.registerHandler("CarAquired", (subscription, evt) => {
    let json = eventToJson(evt);
    validateEvent("CarAquired", json);
    let command = {
        "Registration": json.Registration,
        "CarRentalCode": json.CarRentalCode,
        "Model": json.Model,
        "Milage": json.Milage,
        "RegistrationDate" : json.RegistrationDate
    };
    logCommand(command);
    postCommand(command, "http://eventstoredemo.api.car:23450/api/cars")

    
});

// configure the subscriber
subscriber.configure({
    resolveLinkTos: false,
    logHeartbeats: false
});

// connect and start consuming events
subscriber.createConnection({}).then(() =>
    subscriber.catchupAndSubscribeToStream("demo1.carrental")
        .catch((reason) => console.log(reason))
)
    .catch((reason) => console.log(reason));