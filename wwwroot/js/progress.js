
$(document).ready(function () {



    function toggleUploadButtonState() {
        var monthValue = $('#monthUpload').val();
        var yearValue = $('#yearUpload').val();
        var uploadButton = $('#uploadDatabase');

        if (monthValue !== "Select month" && yearValue !== "") {
            uploadButton.removeAttr("disabled");
        } else {
            uploadButton.attr("disabled", "disabled");
        }
    }

    // When you open the modal, disable the button initially
    $('#modalYearMonth').on('show.bs.modal', function (e) {
        $('#uploadDatabase').attr("disabled", "disabled");
    });

    // Check and enable/disable the button when the month or year changes
    $('#yearUpload, #monthUpload').change(function () {
        toggleUploadButtonState();
    });








    $('#uploadDatabase').click(function () {
       
        // Get the file names from the input elements
        var eqpFileName = $('#eqpFileName').val();
        var jigFileName = $('#jigFileName').val();
        var editId = $('#num').val();
        // Get the values of the "monthUpload" and "yearUpload" fields
        var monthValue = $('#monthUpload').val();
        var yearValue = $('#yearUpload').val();

        

        // Send file names to the controller for processing
        $.ajax({
            url: '/CalibrationNotice/UploadExcelToDatabase',
            type: 'POST',
            data: { eqpFileName: eqpFileName, jigFileName: jigFileName, editId: editId, monthValue: monthValue, yearValue: yearValue },
            success: function (response) {

                // Handle the response from the server, e.g., show a success message
                if (response.success) {
                    alert("Upload successful: " + response.message);
                    window.location.href = '/CalibrationNotice/Index';
                } else {

                    alert("Upload failed: " + response.message);
                }
            },
            error: function (error) {
                // Handle errors, e.g., display an error message
                alert("An error occurred: " + error.statusText);
            }
        });
    });







    // Function to check the value of fld_stat
    function checkApprovalStat() {
        var fld_stat = $("#approvalStat").val();
        if (fld_stat === "APPROVED") {
            // If it's "APPROVED," enable and show the buttons
            $("#sendEmailBtn, #uploadDatabase").prop("disabled", false).show();
        } else {
            // If it's not "APPROVED," disable and hide the buttons
            $("#sendEmailBtn, #uploadDatabase").prop("disabled", true).hide();
        }
    }

    // Initial check when the page loads
    checkApprovalStat();

    // Check again whenever fld_stat changes
    $("#approvalStat").change(checkApprovalStat);



    // Function to update the selected count
    function updateSelectedCount(selectElement, countElementId) {
        var selectedCount = $(selectElement).find("option:selected").length;
        $(countElementId).text(selectedCount + " selected");
    }

    // For getEmailTo
    $("#getEmailTo").change(function () {
        updateSelectedCount(this, "#selectedEmailToCount");
    });

    // For getEmailCc
    $("#getEmailCc").change(function () {
        updateSelectedCount(this, "#selectedEmailCcCount");
    });

});







// Function to handle the Send Notification button
function handleSendButton() {
    const getEmailTo = document.getElementById("getEmailTo");
    const getEmailCc = document.getElementById("getEmailCc");
    const sendEmailBtn = document.getElementById("sendEmailBtn");

    // Check if at least one option is selected in both select elements
    if (getEmailTo.options.length > 1 && getEmailCc.options.length > 1) {
        sendEmailBtn.removeAttribute("disabled");
    } else {
        sendEmailBtn.setAttribute("disabled", "disabled");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    // Your JavaScript code here
    const getEmailTo = document.getElementById("getEmailTo");
    const getEmailCc = document.getElementById("getEmailCc");

    if (getEmailTo) {
        for (let i = 0; i < getEmailTo.options.length; i++) {
            // Access and work with the options of getEmailTo
        }
    }

    if (getEmailCc) {
        for (let i = 0; i < getEmailCc.options.length; i++) {
            // Access and work with the options of getEmailCc
        }
    }
});

// Attach the event listener when the modal is shown
$('#staticBackdrop').on('shown.bs.modal', function () {
    handleSendButton();
});







document.addEventListener('DOMContentLoaded', function () {
    // Get the close button element
    const closeButton = document.querySelector('.modal .btn-close');

    // Add a click event listener to the close button
    if (closeButton) {
        closeButton.addEventListener('click', function () {
            // Refresh the page when the close button is clicked
            window.location.reload();
        });
    }
});