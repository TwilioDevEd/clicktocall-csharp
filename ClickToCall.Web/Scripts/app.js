// Execute JavaScript on page load
$(function () {
    $("#userNumber, #salesNumber").intlTelInput({
        responsiveDropdown: true,
        autoFormat: true
    });
    var $form = $("#contactform"),
        $submit = $("#contactform input[type=submit]");

    // Intercept form submission
    $form.on("submit", function (e) {
        // Prevent form submission and repeat clicks
        e.preventDefault();
        $submit.attr("disabled", "disabled");

        // Submit the form via AJAX
        $.ajax({
            url: "/CallCenter/Call",
            method: "POST",
            data: {
                userNumber: $("#userNumber").val(),
                salesNumber: $("#salesNumber").val()
            }
        }).done(function (data) {
            alert(data.message);
            if (data.success) {
                $form.reset();
            }
        }).fail(function () {
            alert("There was a problem calling you - please try again later.");
        }).always(function () {
            $submit.removeAttr("disabled");
        });
    });
});