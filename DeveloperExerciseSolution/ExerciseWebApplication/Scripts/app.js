
function calculateDistance(event) {
    event.stopPropagation();

    var elementDistance = $("#distance");
    elementDistance.text("");

    var airportA = $("#AirportA option:selected").val();
    var airportB = $("#AirportB option:selected").val();

    if (airportA != "" && airportB != "" && airportA != airportB) {
        var url = '/Distance/Calculate?codeA=' + airportA + '&codeB=' + airportB;
        $.getJSON(url, function (data) {
            //console.log(data);

            if (data != "error") {
                elementDistance.text("Distance: " + data + " KM");
            }
            else {
                elementDistance.text("Could not determine the distance!");
            }
        });
    }
    else {
        elementDistance.text("Not enough data to start calculation");
    }
}

