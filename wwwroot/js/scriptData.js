﻿//automatic set of nextcalibration date month and year based in terms and expiration period



function updateCalibrationDate() {

    //console.log('Function called'); // Add this line to check if the function is called.

    var termSelect = document.getElementById('fld_term');
    var expirationSelect = document.getElementById('expirationSelect');
    var calibrationDateInput = document.getElementById('calibrationDateInput');
    var nextCalibrationDateInput = document.getElementById('nextCalibrationDateInput');
    var nextCalibrationMonthInput = document.getElementById('nextCalibrationMonthInput');
    var nextCalibrationYearInput = document.getElementById('nextCalibrationYearInput');
    var calibrationYearInput = document.getElementById('calibrationYearInput');

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

// Add event listeners to the input elements
document.getElementById('fld_term').addEventListener('change', updateCalibrationDate);
document.getElementById('expirationSelect').addEventListener('change', updateCalibrationDate);
document.getElementById('calibrationDateInput').addEventListener('change', updateCalibrationDate);

// Call the function initially to set the initial values
updateCalibrationDate();



//date format
//// Get the date input element
//var dateInput = document.getElementById('myDateInput');

//// Add an event listener for the 'input' event
//dateInput.addEventListener('input', function () {
//    // Get the entered date value
//    var enteredDate = dateInput.value;

//    // Convert the entered date to the desired format (yyyy-MM-dd)
//    var formattedDate = formatDate(enteredDate);

//    // Set the formatted date back to the input element
//    dateInput.value = formattedDate;
//});

//// Function to format the date as yyyy-MM-dd
//function formatDate(dateString) {
//    var date = new Date(dateString);
//    var month = (date.getMonth() + 1).toString().padStart(2, '0');
//    var day = date.getDate().toString().padStart(2, '0');
//    var year = date.getFullYear();

//    return year + '-' + month + '-' + day;
//}

document.addEventListener('DOMContentLoaded', function () {
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
});






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




//export to excel
function exportToExcel() {
    // Get the DataTable instance
    var dataTable = $('#equipment-registration').DataTable();

    // Get all data from the DataTable
    var data = dataTable.data().toArray();

    // Create a new workbook
    var workbook = XLSX.utils.book_new();

    // Create a new worksheet
    var worksheet = XLSX.utils.aoa_to_sheet([]);

    // Add headers to the worksheet
    var headers = [
        "Code",
        "Control Number",
        "Division",
        "Category",
        "Code",
        "Equipment Name",
        "Model",
        "Serial",
        "Maker",
        "Term",
        "Employment Place",
        "Pass/Fail",
        "Registration Date",
        "IMTE",
        "Calibration Date",
        "Calibration Month",
        "Calibration Year",
        "Next Calibration Date",
        "Next Calibration Month",
        "Next Calibration Year",
        "Internal/External",
        "External Supplier",
        "Comment",
        "Standard Equipment",
        
        "Status",
        "Calibration Result",
        "IMG Result"
    ];

    var filteredData = data.map(function (row) {
        return row.filter(function (_, index) {
            // Exclude column 0 (Action) and columns 25 to 34
            return index !== 0 && (index < 25 || index > 34);
        });
    });

    var dataWithHeaders = [headers].concat(filteredData);

    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

    // Add the worksheet to the workbook
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Equipment Registration');

    // Generate the Excel file
    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

    // Save the file
    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'equipment_registration.xlsx');
}


//export to excel Jig
function exportToExcel2() {
    // Get the DataTable instance
    var dataTable = $('#jig-registration').DataTable();

    // Get all data from the DataTable
    var data = dataTable.data().toArray();

    // Create a new workbook
    var workbook = XLSX.utils.book_new();

    // Create a new worksheet
    var worksheet = XLSX.utils.aoa_to_sheet([]);

    // Add headers to the worksheet
    var headers = [
        "Code",
        "Control Number",
        "Division",
        
        "Jig Name",
        "Drawing No.",
        "Serial",
        
        "Term",
        "Employment Place",
        "Pass/Fail",
        "Registration Date",
        "IMTE",
        "Calibration Date",
        "Calibration Month",
        "Calibration Year",
        "Next Calibration Date",
        "Next Calibration Month",
        "Next Calibration Year",
        "Internal/External",

        "Comment",

        "Path IMG",
        "Path DOC",
        "Status",
        "Description"

    ];

    var filteredData = data.map(function (row) {
        return row.filter(function (_, index) {
            // Exclude column 0 (Action) and columns 25 to 34
            return index !== 0 && (index < 24 || index > 34);
        });
    });

    var dataWithHeaders = [headers].concat(filteredData);

    XLSX.utils.sheet_add_aoa(worksheet, dataWithHeaders);

    // Add the worksheet to the workbook
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Jig Registration');

    // Generate the Excel file
    var excelFile = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

    // Save the file
    saveAs(new Blob([excelFile], { type: 'application/octet-stream' }), 'jig_registration.xlsx');
}


function updateLabelCounts() {
    // Get the table element
    var table = document.getElementById('table-registration');

    // Check if the table exists
    if (table) {
        // Initialize the count variables
        var completedCount = 0;
        var pendingCount = 0;
        var ongoingCount = 0;

        // Loop through each row in the table
        for (var i = 0; i < table.rows.length; i++) {
            // Get the cell value of the 14th column (assuming it contains the status)
            var statusCell = table.rows[i].cells[13];
            if (statusCell) {
                var status = statusCell.innerText.trim(); // Trim any leading/trailing whitespace

                // Update the count based on the status value
                switch (status) {
                    case 'COMPLETED':
                        completedCount++;
                        break;
                    case 'PENDING':
                        pendingCount++;
                        break;
                    case 'ONGOING':
                        ongoingCount++;
                        break;
                    default:
                        break;
                }
            }
        }

        // Update the label values
        document.getElementById('complete').innerText = 'Completed Count: ' + completedCount;
        document.getElementById('pending').innerText = 'Pending Count: ' + pendingCount;
        document.getElementById('ongoing').innerText = 'Ongoing Count: ' + ongoingCount;
    }
}

// Call the function after the page has finished loading
document.addEventListener('DOMContentLoaded', updateLabelCounts);



function updateLabelCountsJig() {
    // Get the table element
    var table = document.getElementById('table-registration-jig');

    // Check if the table exists
    if (table) {
        // Initialize the count variables
        var completedCount = 0;
        var pendingCount = 0;
        var ongoingCount = 0;

        // Loop through each row in the table
        for (var i = 0; i < table.rows.length; i++) {
            // Get the cell value of the 14th column (assuming it contains the status)
            var statusCell = table.rows[i].cells[15];
            if (statusCell) {
                var status = statusCell.innerText.trim(); // Trim any leading/trailing whitespace

                // Update the count based on the status value
                switch (status) {
                    case 'COMPLETED':
                        completedCount++;
                        break;
                    case 'PENDING':
                        pendingCount++;
                        break;
                    case 'ONGOING':
                        ongoingCount++;
                        break;
                    default:
                        break;
                }
            }
        }

        // Update the label values
        document.getElementById('completeJig').innerText = 'Completed Count: ' + completedCount;
        document.getElementById('pendingJig').innerText = 'Pending Count: ' + pendingCount;
        document.getElementById('ongoingJig').innerText = 'Ongoing Count: ' + ongoingCount;
    }
}

// Call the function after the page has finished loading
document.addEventListener('DOMContentLoaded', updateLabelCountsJig);


