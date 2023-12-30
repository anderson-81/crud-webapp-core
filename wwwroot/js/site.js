$(function () {

    // Alert and Validations Summaries: 

    $("#divalert").fadeOut(7000);
    $(".validation-summary-errors").fadeOut(7000);

    // Datatable

    if (window.location.pathname == "/Customers") {
        $('#tbCustomers').DataTable({
            "pageLength": 6
        });

        $("#tbCustomers_length").remove();

        $("input[type=search]").addClass("form-control border-2");
    }

    //maskMoney:

    /*
    if (window.location.href.includes("Create") || window.location.href.includes("Edit")) {
        $('#Customer_Salary').maskMoney({
            thousands: '',
            decimal: '.',
            precision: 2,
            allowZero: true,
            allowNegative: false,
            allowEmpty: false
        });
    }
    */

    //datetimepicker:

    /*
    if (window.location.href.includes("Create") || window.location.href.includes("Edit")) {
        var date = new Date();

        date.setFullYear(date.getFullYear() - 18);

        if (($('#Customer_Birthday').val() == "") || ($('#Customer_Birthday').val() == date.toString())) {
            $('#Customer_Birthday').val(date);
        }

        $('#Customer_Birthday').datetimepicker({
            format: "MM/DD/YYYY"
        });

        $('#Customer_Birthday').data("DateTimePicker").maxDate(date);
    }
    */

    //modal operations:

    if (window.location.href.includes("Edit")) {
        $("#btnEdit").click(function () {
            $(".delete").css("display", "none");
            $(".edit").css("display", "block");
        });

        $("#btnDelete").click(function () {
            $(".edit").css("display", "none");
            $(".delete").css("display", "block");
        });
    }

    //
    /*
    if (window.location.href.includes("Create")) {
        $("#Customer_Salary").on("change paste keyup", function () {
            $(this).val("3000.00");
        });
    }

    if (window.location.href.includes("Edit")) {
        $("#Customer_Salary").on("change paste keyup", function () {
            $(this).val("3300.00");
        });
    }
    */
    $("form").submit(function () {
        $("#btnSubmit").attr("disabled", true);
        $("button").attr("disabled", true);
    });
});