var validate = require('jsonschema').validate;


function validateEvent(eventType, jsonEvent) {
    var schemaPath = "./schemas/Car/events/" + eventType + ".json";
    console.log("event schemapath: " + schemaPath.toString());
    var schema = require(schemaPath);
    console.log(schema);
    console.log(validate(jsonEvent, schema));
}

validateEvent("CarAquired", {"test" : 123});