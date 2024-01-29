//automatic set of nextcalibration date month and year based in terms and expiration period



function updateCalibrationDate() {

    

    var termSelect = document.getElementById('fld_term');
    var expirationSelect = document.getElementById('expirationSelect');
    var calibrationDateInput = document.getElementById('calibrationDateInput');
    var nextCalibrationDateInput = document.getElementById('nextCalibrationDateInput');
    var nextCalibrationMonthInput = document.getElementById('nextCalibrationMonthInput');
    var nextCalibrationYearInput = document.getElementById('nextCalibrationYearInput');
    var calibrationYearInput = document.getElementById('calibrationYearInput');

    // Check if the element exists before trying to access its value
    if (termSelect) {
        var term = parseInt(termSelect.value);
        var expiration = expirationSelect.options[expirationSelect.selectedIndex].value;
        var calibrationDate = new Date(calibrationDateInput.value);

        if (isNaN(calibrationDate.getTime())) {
            // Return early if the calibration date is invalid
            nextCalibrationDateInput.value = '';
            nextCalibrationMonthInput.value = '';
            nextCalibrationYearInput.value = '';
            calibrationYearInput.value = '';
            return;
        }

        var calibYear = new Date(calibrationDate);
        var year = calibYear.getFullYear();

        calibrationYearInput.value = year;

        // Calculate the next calibration date based on the selected term and expiration period
        var nextCalibrationDate = new Date(calibrationDate);
        var year = nextCalibrationDate.getFullYear();
        var month = nextCalibrationDate.getMonth();

        if (expiration === 'Same Date Expiration') {
            nextCalibrationDate.setMonth(month + term);
        } else if (expiration === 'End of Month Expiration') {
            nextCalibrationDate.setMonth(month + term + 1, 0);
        } else if (expiration === 'November 30 Expiration') {
            nextCalibrationDate.setFullYear(year + Math.floor(term / 12));
            nextCalibrationDate.setMonth(10, 30);
        }

        // Format the next calibration date as "yyyy-MM-dd"
        var formattedDate = nextCalibrationDate.toISOString().split('T')[0];

        // Update the next calibration date input
        nextCalibrationDateInput.value = formattedDate;
        nextCalibrationMonthInput.value = (nextCalibrationDate.getMonth() + 1).toString().padStart(2, '0');
        nextCalibrationYearInput.value = nextCalibrationDate.getFullYear().toString();
    }


    //calib month

    const dateInput = document.getElementById('calibrationDateInput');
    const selectedDate = new Date(dateInput.value);

    console.log(selectedDate);

    if (!isNaN(selectedDate.getTime())) {
        const monthIndex = selectedDate.getMonth(); // Month index is zero-based
        const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

        const calibMonth = document.getElementById('calibMonth');
        calibMonth.innerHTML = ''; // Clear existing options

        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.textContent = 'Select Month';
        calibMonth.appendChild(defaultOption);

        monthNames.forEach((month, index) => {
            const option = document.createElement('option');
            option.value = index + 1; // Add 1 to match option indexes
            option.textContent = month;
            calibMonth.appendChild(option);
        });

        calibMonth.selectedIndex = monthIndex + 1; // Add 1 to match option indexes
    }

}



document.addEventListener('DOMContentLoaded', function () {
    // Add event listeners to the input elements
    //document.getElementById('fld_term').addEventListener('change', updateCalibrationDate);
    //document.getElementById('expirationSelect').addEventListener('change', updateCalibrationDate);
    //document.getElementById('calibrationDateInput').addEventListener('change', updateCalibrationDate);

    const fldTerm = document.getElementById('fld_term');
    if (fldTerm) {
        fldTerm.addEventListener('change', updateCalibrationDate);
    }

    const expirationSelect = document.getElementById('expirationSelect');
    if (expirationSelect) {
        expirationSelect.addEventListener('change', updateCalibrationDate);
    }

    const calibrationDateInput = document.getElementById('calibrationDateInput');
    if (calibrationDateInput) {
        calibrationDateInput.addEventListener('change', updateCalibrationDate);
    }

});
// Call the function initially to set the initial values
updateCalibrationDate();



    var dateInput = document.getElementById('myDateInput');

    if (dateInput) {
        dateInput.addEventListener('input', function () {
            var enteredDate = dateInput.value;
            var formattedDate = formatDate(enteredDate);
            dateInput.value = formattedDate;
        });
    } else {
        //console.error('The dateInput element is not found.');
    }

    function formatDate(dateString) {
        var date = new Date(dateString);
        var month = (date.getMonth() + 1).toString().padStart(2, '0');
        var day = date.getDate().toString().padStart(2, '0');
        var year = date.getFullYear();

        return year + '-' + month + '-' + day;
    }







//combine fld_category and fld_code2 value to create output for fld_ctrlNo
$(document).ready(function () {
    // Function to update fld_ctrlNo based on fld_code2 and fld_category
    function updateCtrlNo() {
        var code2 = $('#fld_code2').val();
        var category = $('#fld_category').val();
        var ctrlNo = $('#fld_ctrlNo').val(); // Get the current value of fld_ctrlNo

        // Check if fld_ctrlNo is not null or empty, if so, don't remove the value
        if (ctrlNo) {
            // Update the value of fld_ctrlNo with the existing value
            $('#fld_ctrlNo').val(ctrlNo);
            return; // Exit the function early since we don't need to fetch a new value
        }

        // Check if both fld_category and fld_code2 have values
        if (category && code2) {
            // AJAX request to get the recent value from the database
            $.ajax({
                url: '/EquipmentMaster/GetRecentValue',
                type: 'GET',
                data: { code2: code2, category: category },
                success: function (response) {
                    //console.log('Success response:', response); // Log the response

                    // Increment the value retrieved from the database or set it to 1 if it's null
                    var newValue = response ? parseInt(response) + 1 : 1;

                    // Format the new value with leading zeros if it has less than 3 digits
                    var formattedValue = newValue.toString().padStart(3, '0');

                    // Combine fld_code2 and fld_category with the new value
                    var combinedValue = category + code2 + formattedValue;

                    // Update fld_ctrlNo input field
                    $('#fld_ctrlNo').val(combinedValue);
                },
                error: function () {
                    // Handle error case
                    //console.log('Error occurred while getting the recent value.');
                }
            });
        } else {
            // Clear the value of fld_ctrlNo if either fld_category or fld_code2 is empty
            $('#fld_ctrlNo').val('');
        }
    }

    // Bind event handlers to fld_code2 and fld_category input and change events
    $('#fld_code2, #fld_category').on('input change', function () {
        updateCtrlNo();
    });


    // Initial call to updateCtrlNo on page load
    updateCtrlNo();
    
});



function getCodeByDepartment() {
    var selectedValue = $('#requestingFunctionSelect').val();

    if (!selectedValue) {
        $('#codeInput').val('');
        return;
    }

    $.ajax({
        url: '/Registration/GetCodeByDepartment',  // Replace with the actual route
        type: 'GET',
        data: { department: selectedValue },
        success: function (response) {
            if (response) {
                $('#codeInput').val(response);
            } else {
                $('#codeInput').val('');
            }
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
}

    //$('#requestingFunctionSelect').on('change', getCodeByDepartment);
    //getCodeByDepartment();  // Initial load





