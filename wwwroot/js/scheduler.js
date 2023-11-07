$(document).ready(function () {
    var selectedDates = [];

    // Initialize flatpickr
    flatpickr("#selectedDates", {
        mode: "multiple",
        dateFormat: "Y-m-d",
        onClose: function (selectedDatesArray) {
            selectedDates = selectedDatesArray.map(function (dateStr) {
                return new Date(dateStr);
            });
           
        }
    });
      


    // Event handler for the resetcalibdate button
    $("#resetcalibdate").click(function () {
        var selectType = $("#selectType").val();

        // Determine which table to reset based on selectType
        var tableToReset;

        if (selectType === "Equipment") {
            tableToReset = $("#searchResultsTable tbody");
        } else if (selectType === "Jig") {
            tableToReset = $("#searchResultsTable2 tbody");
        } else {
            // Handle an unknown selectType value if needed
            return;
        }

        // Shuffle the dates in the first column of the table
        shuffleDates(tableToReset);

        // Update the result tables with the shuffled dates
        updateResultTables(selectedDates);
    });

    // Function to shuffle the dates in the first column of a table
    function shuffleDates(tableBody) {
        var rows = tableBody.find("tr");

        // Extract the dates from the first column into an array
        var dates = rows.map(function () {
            return new Date($(this).find("td:eq(0)").text());
        }).get();

        // Sort the dates from oldest to newest
        dates.sort(function (a, b) {
            return a - b;
        });

        // Update the first column of the table with the shuffled dates
        rows.each(function (index) {
            $(this).find("td:eq(0)").text(formatDate(dates[index]));
        });
    }

        
    

    // Function to update the result tables with data
    function updateResultTables(selectedDates) {
        var selectType = $("#selectType").val();
        var table1 = $("#searchResultsTable tbody");
        var table2 = $("#searchResultsTable2 tbody");

        // Determine which table to update based on selectType
        var tableToUpdate = selectType === "Equipment" ? table1 : table2;

        // Calculate the number of rows in the selected table
        var numRows = tableToUpdate.find("tr").length;

        // Calculate the quantity for distributing the dates evenly
        var quantity = Math.ceil(numRows / selectedDates.length);

        // Initialize the date index to 0
        var dateIndex = 0;

       
        tableToUpdate.find("tr").each(function (rowIndex) {
            var cell = $(this).find("td:eq(0)");

            // Create an input element for editing
            var dateInput = $("<input type='date'>");

            // Initially, display the selected date as plain text
            cell.text(formatDate(selectedDates[dateIndex]));

            // Handle cell click to replace text with the input element
            cell.on("click", function () {
                // Replace the text with the input element
                cell.empty().append(dateInput);

                // Set the date value based on the selectedDates array
                dateInput.val(formatDate(selectedDates[dateIndex]));

                // Focus on the input element
                dateInput.focus();

                // Handle input change to update selectedDates
                dateInput.on("change", function () {
                    // Update the selectedDates array with the edited date
                    var editedDate = new Date(dateInput.val());
                    if (!isNaN(editedDate.getTime())) {
                        selectedDates[dateIndex] = editedDate;

                        // Update the displayed date as plain text
                        cell.text(formatDate(editedDate));
                    }
                });
            });

            // Increment the date index after distributing the date to 'quantity' rows
            if ((rowIndex + 1) % quantity === 0) {
                dateIndex++;
            }
                
       
        });

       
    }

    // Function to format the date
    function formatDate(dateString) {
        if (dateString) {
            var date = new Date(dateString);
            return date.toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
        }
        /*return 'N/A';*/
    }

    // Function to toggle table visibility based on selected item
    function toggleTables(selectedItem) {
        if (selectedItem === "Equipment") {
            $("#searchResultsTable").show();
            $("#searchResultsTable2").hide();
            $("#searchResultsTable3").show();
            $("#searchResultsTable4").hide();

            $("#cardTb3").show();
            $("#cardTb4").hide();
        } else if (selectedItem === "Jig") {
            $("#searchResultsTable").hide();
            $("#searchResultsTable2").show();
            $("#searchResultsTable3").hide();
            $("#searchResultsTable4").show();

            $("#cardTb3").hide();
            $("#cardTb4").show();
        } else {
            // Hide both tables if no valid selection
            $("#searchResultsTable").hide();
            $("#searchResultsTable2").hide();
            $("#searchResultsTable3").hide();
            $("#searchResultsTable4").hide();

            $("#cardTb3").hide();
            $("#cardTb4").hide();
            
        }
    }

    // Initial toggle based on the default selected item
    toggleTables($("#selectType").val());

    // Event handler for select change
    $("#selectType").change(function () {
        var selectedItem = $(this).val();
        toggleTables(selectedItem);
    });

    // AJAX success callback
    function handleSuccess(data, selectedItem) {
        // Clear the previous search results based on selected item
        if (selectedItem === "Equipment") {
            $("#searchResultsTable tbody").empty();
            // Populate the search results table with data received from the server
            data.forEach(function (item, index) {
                var formattedDate = formatDate(item.fld_nextCalibDate);

                // Create a new row
                var row = $("<tr></tr>");

                // Add the calibrationDate to the row
                var calibrationDate = selectedDates[index]; // Use the index provided by forEach
                var formattedDate2 = formatDate(calibrationDate);
                row.append("<td>" + formattedDate2 + "</td>");

                // Add other columns as needed
                row.append("<td>" + formattedDate + "</td>");
                row.append("<td>" + item.fld_codeNo + "</td>");
                row.append("<td>" + item.fld_ctrlNo + "</td>");
                row.append("<td>" + item.fld_eqpName + "</td>");
                row.append("<td>" + item.fld_eqpModelNo + "</td>");
                row.append("<td>" + item.fld_serial + "</td>");
                row.append("<td>" + item.fld_brand + "</td>");
                row.append("<td>" + item.fld_term + "</td>");
                row.append("<td>" + item.fld_reqFunction + "</td>");
                row.append("<td>" + item.fld_comment + "</td>");

                $("#searchResultsTable tbody").append(row);
                updateResultTables(selectedDates);
            });
        } else if (selectedItem === "Jig") {
            $("#searchResultsTable2 tbody").empty();
            // Populate the search results table with data received from the server
            data.forEach(function (item, index) {
                var formattedDate = formatDate(item.fld_nextCalibDate);

                // Create a new row
                var row = $("<tr></tr>");

                // Add the calibrationDate to the row
                var calibrationDate = selectedDates[index]; // Use the index provided by forEach
                var formattedDate2 = formatDate(calibrationDate);
                row.append("<td>" + formattedDate2 + "</td>");

                // Add other columns as needed
                row.append("<td>" + formattedDate + "</td>");
                row.append("<td>" + item.fld_ctrlNo + "</td>");
                row.append("<td>" + item.fld_jigName + "</td>");
                row.append("<td>" + item.fld_drawingNo + "</td>");
                row.append("<td>" + item.fld_term + "</td>");
                row.append("<td>" + item.fld_reqFunction + "</td>");
                row.append("<td>" + item.fld_remarks + "</td>");

                $("#searchResultsTable2 tbody").append(row);
                updateResultTables(selectedDates);
            });
        }
    }

    // Event handler for the search button
    $("#searchButton").click(function () {
        var selectType = $("#selectType").val();
        var myDateInput1 = $("#myDateInput1").val();
        var myDateInput2 = $("#myDateInput2").val();

        // Perform the search using AJAX
        $.ajax({
            url: '/CalibSchedule/SearchData',
            type: 'POST',
            data: {
                selectType: selectType,
                myDateInput1: myDateInput1,
                myDateInput2: myDateInput2
            },
            success: function (data) {
                handleSuccess(data, selectType);
               
            },
            error: function (error) {
                console.error("Error fetching data: " + JSON.stringify(error));
            }
        });
    });








});





$(document).ready(function () {

    function formatDate2(dateString) {
        if (dateString) {
            var date = new Date(dateString);
            return date.toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
        }
        //return 'N/A';
    }


    // Event handler for the search button
    $("#searchButtonDb").click(function () {
        var selectType = $("#selectType").val();
        var monthInput = $("#monthInput").val();
        var yearInput = $("#yearInput").val();

        
        // Make an AJAX request to fetch data from the database based on the selected options
        $.ajax({
            url: '/CalibSchedule/SearchDb', // Replace with your API endpoint
            type: 'POST', // Adjust the HTTP method as needed
            data: {
                selectType: selectType,
                monthInput: monthInput,
                yearInput: yearInput
            },
            success: function (data) {               
                if (selectType === 'Equipment') {
                    populateEquipmentTable(data);
                    
                } else if (selectType === 'Jig') {
                    populateJigTable(data);
                }
            },
            error: function (error) {
                console.error("Error fetching data: " + JSON.stringify(error));
            }
        });
    });

    // Function to populate the Equipment table
    function populateEquipmentTable(data) {
        var table = $("#searchResultsTable3 tbody");
        table.empty();

        // Iterate through the data and create rows for the Equipment table
        data.forEach(function (item) {
            var row = $("<tr></tr>");
            var formattedDate3 = formatDate2(item.fld_nextCalibDate);
            row.append("<td><button class='transferButton'>Transfer</button></td>");
            row.append("<td>" + formattedDate3 + "</td>");
            row.append("<td>" + item.fld_codeNo + "</td>");
            row.append("<td>" + item.fld_ctrlNo + "</td>");
            row.append("<td>" + item.fld_eqpName + "</td>");
            row.append("<td>" + item.fld_eqpModelNo + "</td>");
            row.append("<td>" + item.fld_serial + "</td>");
            row.append("<td>" + item.fld_brand + "</td>");
            row.append("<td>" + item.fld_term + "</td>");
            row.append("<td>" + item.fld_reqFunction + "</td>");
            row.append("<td>" + item.fld_comment + "</td>");

            table.append(row);
            
        });
    }

    // Function to populate the Jig table
    function populateJigTable(data) {
        var table = $("#searchResultsTable4 tbody");
        table.empty();

        // Iterate through the data and create rows for the Jig table
        data.forEach(function (item) {
            var row = $("<tr></tr>");
            var formattedDate4 = formatDate2(item.fld_nextCalibDate);
            row.append("<td><button class='transferButton'>Transfer</button></td>");
            row.append("<td>" + formattedDate4 + "</td>");
            row.append("<td>" + item.fld_ctrlNo + "</td>");
            row.append("<td>" + item.fld_jigName + "</td>");
            row.append("<td>" + item.fld_drawingNo + "</td>");
            row.append("<td>" + item.fld_term + "</td>");
            row.append("<td>" + item.fld_reqFunction + "</td>");
            row.append("<td>" + item.fld_remarks + "</td>");

            table.append(row);
        });
    }
});

// Function to handle the transfer button click
$(document).on("click", ".transferButton", function () {
    // Get the closest row to the clicked button
    var row = $(this).closest("tr");

    // Determine which table to transfer to based on the selectType
    var selectType = $("#selectType").val();
    var targetTableId;

    if (selectType === "Equipment") {
        targetTableId = "#searchResultsTable tbody";
    } else if (selectType === "Jig") {
        targetTableId = "#searchResultsTable2 tbody";
    } else {
        // Handle an unknown selectType value if needed
        return;
    }

    // Clone the row, remove the button column, and append it to the target table
    var clonedRow = row.clone();
    clonedRow.find("td:first-child").empty(); // Remove the first cell (containing the button)
    $(targetTableId).append(clonedRow);

    // Remove the row from the source table
    row.remove();
});





// Function to export data to an Excel file
// Function to call the ExportToExcel action
function exportToExcel(selectType, selectMonth) {
    // Get the table data from the HTML table
    var tableId = selectType === 'Equipment' ? 'searchResultsTable' : 'searchResultsTable2';
    var table = document.getElementById(tableId);
    var tableData = [];

    // Iterate through the table rows and cells to extract data
    for (var i = 0; i < table.rows.length; i++) {
        var rowData = [];
        var cells = table.rows[i].cells;
        for (var j = 0; j < cells.length; j++) {
            rowData.push(cells[j].textContent.trim());
        }
        tableData.push(rowData);
    }

    // Create a URL to call the ExportToExcel action with the selected parameters
    var url = `/CalibSchedule/ExportToExcel?selectType=${selectType}&selectMonth=${selectMonth}`;

    // Send a POST request with the data
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tableData)
    })
        .then(response => response.blob())
        .then(blob => {
            // Create a URL for the blob data and trigger a download
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            a.href = url;
            a.download = `${selectMonth}_Calibration_${selectType}_Notice.xlsx`;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(error => console.error('Error:', error));
}


// Handle export
// Add an event listener to your export button
//document.getElementById("exportButton").addEventListener("click", function () {
//    var selectType = document.getElementById("selectType").value;
//    var selectMonth = document.getElementById("selectMonth").value;
//    exportToExcel(selectType, selectMonth);
//});

document.addEventListener("DOMContentLoaded", function () {
    var exportButton = document.getElementById("exportButton");
    if (exportButton) {
        exportButton.addEventListener("click", function () {
            var selectType = document.getElementById("selectType").value;
            var selectMonth = document.getElementById("selectMonth").value;
            exportToExcel(selectType, selectMonth);
        });
    }
});
