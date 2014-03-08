function selectView(view) {
    try {
        $(".display").not("#" + view + "Display").hide();
        $("#" + view + "Display").show();
    }

    catch (error) {
        if (window.console) {
            console.log(error.message);
        }
    }
}

function getData() {
    $.ajax({
        type: "GET",
        url: "/api/Reservation",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                + 'value="' + data[i].ReservationId + '" /></td>'
                + '<td>' + data[i].ClientName + '</td>'
                + '<td>' + data[i].Location + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });
}
$("button").click(function (e) {
    var selectedRadio = $("input:radio:checked");
    var reservationId = selectedRadio.attr("value");
    switch (e.target.id) {
        case "edit":
            $.ajax({
                type: "GET",
                url: "/api/Reservation/" + reservationId,
                success: function (data) {
                    $("#editReservationId").val(data.ReservationId);
                    $("#editClientName").val(data.ClientName);
                    $("#editLocation").val(data.Location);
                    selectView("edit");
                }
            });
            break;

        case "delete":
            $.ajax({
                type: "DELETE",
                url: "/api/Reservation/" + reservationId,
                success: function (data) {
                    selectedRadio.closest('tr').remove();
                }
            });

            break;
    }
});