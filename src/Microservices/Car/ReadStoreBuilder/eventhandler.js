function resumeEvent(event) {
    return [
        event.originalEvent.eventType,
        [event.originalEventNumber.toNumber(), event.originalStreamId].join('@'),
        event.originalPosition
    ].join(" ")
}

function handleEvent(subscription, event) {
    console.log("Event received", resumeEvent(event))
    console.log("data: ", event.originalEvent.data.toString());
}

module.exports.handleEvent = handleEvent