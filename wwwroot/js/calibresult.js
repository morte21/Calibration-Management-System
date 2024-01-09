$(document).ready(function () {
    $('#viewSchedule').click(function () {
        var searchMonth = $('#searchMonth').val();
        var searchYear = $('#searchYear').val();
        var tableBody = $('#dailyCalibEQP tbody');

        //console.log("run");
        // Clear the table before populating with search results
        tableBody.empty();

        // Send an AJAX request to fetch data based on search criteria
        $.ajax({
            url: '/ResultEQP/SearchSchedule',
            method: 'POST',
            data: { searchMonth: searchMonth, searchYear: searchYear },
            success: function (data) {
                //console.log(data);
                // Populate the table with search results
                if (data.length > 0) {
                    data.forEach(function (item) {

                         //<option value="PASSED">PASSED</option>
                         //   <option value="FAILED">FAILED</option>
                         //   <option value="SUSPENDED">SUSPENDED</option>
                         //   <option value="DISPOSED">DISPOSED</option>


                        // Create the set of links
                        // Construct HTML links manually
                        var editLink = '<a href="/ResultEQP/Edit/' + item.id + '">Edit</a>';


                        // Determine the row color class based on fld_stat
                        var rowColorClass = '';
                        if (item.fld_stat === 'OK') {
                            rowColorClass = 'green';
                        } else if (item.fld_stat === 'NG') {
                            rowColorClass = 'red';
                        } else if (item.fld_stat === 'SUSPENDED') {
                            rowColorClass = 'yellow';
                        } else if (item.fld_stat === 'DISPOSED') {
                            rowColorClass = 'orange';
                        }

                        //console.log(item.fld_stat);
                        //console.log(rowColorClass);
                        //console.log('<tr class="' + rowColorClass + '">');

                        // Create a cell with the links
                        var linksCell = editLink;

                        tableBody.append(
                            '<tr>' +
                            '<td >' + linksCell + '</td>' +
                            '<td class="' + rowColorClass + '">' + item.fld_stat + '</td>' +
                            '<td>' + item.fld_codeNo + '</td>' +
                            '<td>' + item.fld_ctrlNo + '</td>' +
                            '<td>' + item.calibrationdate + '</td>' +
                            '<td>' + item.fld_eqpName + '</td>' +
                            '<td>' + item.fld_eqpModelNo + '</td>' +
                            '<td>' + item.fld_serial + '</td>' +
                            '<td>' + item.fld_brand + '</td>' +
                            '<td>' + item.fld_term + '</td>' +
                            '<td>' + item.fld_reqFunction + '</td>' +
                            '<td>' + item.fld_passFail + '</td>' +
                            '<td>' + item.fld_imte + '</td>' +
                            '<td>' + item.fld_calibDate + '</td>' +
                            '<td>' + item.fld_calibMonth + '</td>' +
                            '<td>' + item.fld_calibYear + '</td>' +
                            '<td>' + item.fld_nextCalibDate + '</td>' +
                            '<td>' + item.fld_nextCalibMonth + '</td>' +
                            '<td>' + item.fld_nextCalibYear + '</td>' +
                            '<td>' + item.fld_internalExternal + '</td>' +
                            '<td>' + item.fld_supplierExternal + '</td>' +
                            '<td >' + item.fld_comment + '</td>' +
                            '<td >' + item.fld_appStandardEqp + '</td>' +
                            '<td hidden>' + item.fld_pathIMG + '</td>' +
                            '<td hidden>' + item.fld_pathDoc + '</td>' +
                            
                            '<td >' + item.fld_dateReturned + '</td>' +
                            '<td >' + item.fld_withNC + '</td>' +
                            '<td >' + item.fld_CalibFR + '</td>' +
                            '<td >' + item.fld_calibDisSusForm + '</td>' +
                            '<td >' + item.fld_withCalibResult + '</td>' +
                            '<td >' + item.fld_incharge + '</td>' +
                            '<td >' + item.fld_remarks + '</td>' +
                            '<td >' + item.fld_changeSticker + '</td>' +
                            '<td >' + item.fld_actualCalibDueDate + '</td>' +
                            '<td >' + item.fld_dateRecv + '</td>' +
                            '<td hidden>' + item.fld_month + '</td>' +
                            '<td hidden>' + item.fld_year + '</td>' +

                            '</tr>'
                        );
                    });
                    
                    // Calculate the completion rate
                    var totalCalibrated = data.filter(function (item) {
                        return item.fld_stat !== "";
                    }).length;
                    var totalRecords = data.length;
                    

                    var completionRate = totalCalibrated / totalRecords;

                    // Display the completion rate
                    $('#completionRate').text('Completion Rate: ' + (completionRate * 100).toFixed(1) + '%' + ' | ') ;
                    $('#totalRate').text('Total Calibration: ' + (totalRecords) + ' | ');
                    $('#totalCalibrated').text('Total Calibrated: ' + (totalCalibrated));




                } else {
                    // No results found
                    tableBody.append('<tr><td colspan="3">No results found</td></tr>');
                }
            },
            error: function (error) {
                console.error(error);
            }
        })
    });
});




$(document).ready(function () {
    $('#viewScheduleJig').click(function () {
        var searchMonth = $('#searchMonthJig').val();
        var searchYear = $('#searchYearJig').val();
        var tableBody = $('#dailyCalibJig tbody');

        // Clear the table before populating with search results
        tableBody.empty();

        // Send an AJAX request to fetch data based on search criteria
        $.ajax({
            url: '/ResultJIG/SearchSchedule',
            method: 'POST',
            data: { searchMonth: searchMonth, searchYear: searchYear },
            success: function (data) {
                // Populate the table with search results
                if (data.length > 0) {
                    data.forEach(function (item) {

                        //<option value="PASSED">PASSED</option>
                        //   <option value="FAILED">FAILED</option>
                        //   <option value="SUSPENDED">SUSPENDED</option>
                        //   <option value="DISPOSED">DISPOSED</option>


                        // Create the set of links
                        // Construct HTML links manually
                        var editLink = '<a href="/ResultJIG/Edit/' + item.id + '">Edit</a>';


                        // Determine the row color class based on fld_stat
                        var rowColorClass = '';
                        if (item.fld_stat === 'OK') {
                            rowColorClass = 'green';
                        } else if (item.fld_stat === 'NG') {
                            rowColorClass = 'red';
                        } else if (item.fld_stat === 'SUSPENDED') {
                            rowColorClass = 'yellow';
                        } else if (item.fld_stat === 'DISPOSED') {
                            rowColorClass = 'orange';
                        }

                        
                        //console.log(item.fld_stat);
                        //console.log(rowColorClass);
                        //console.log('<tr class="' + rowColorClass + '">');

                        // Create a cell with the links
                        var linksCell = editLink;

                        tableBody.append(
                            '<tr>' +
                            '<td>' + linksCell + '</td>' +
                            '<td class="' + rowColorClass + '">' + item.fld_stat + '</td>' +
                            '<td>' + item.fld_ctrlNo + '</td>' +
                            '<td>' + item.fld_jigName + '</td>' +
                            '<td>' + item.calibrationdate + '</td>' +
                            '<td>' + item.fld_codeNo + '</td>' +
                            '<td>' + item.fld_drawingNo + '</td>' +
                            '<td>' + item.fld_term + '</td>' +
                            '<td>' + item.fld_reqFunction + '</td>' +
                            '<td>' + item.fld_remarks + '</td>' +
                            '<td>' + item.fld_passfail + '</td>' +
                            '<td>' + item.fld_imte + '</td>' +
                            '<td>' + item.fld_dateRecv + '</td>' +
                            '<td>' + item.fld_calibDate + '</td>' +
                            '<td>' + item.fld_calibMonth + '</td>' +
                            '<td>' + item.fld_calibYear + '</td>' +
                            '<td>' + item.fld_nextCalibDate + '</td>' +
                            '<td>' + item.fld_nextCalibMonth + '</td>' +
                            '<td>' + item.fld_nextCalibYear + '</td>' +
                            '<td>' + item.fld_dateReturned + '</td>' +
                            '<td>' + item.fld_internalExternal + '</td>' +
                            '<td>' + item.fld_withNC + '</td>' +
                            '<td>' + item.fld_CalibFR + '</td>' +
                            '<td>' + item.fld_calibDisSusForm + '</td>' +
                            '<td>' + item.fld_withCalibResult + '</td>' +
                            '<td hidden>' + item.fld_pathIMG + '</td>' +
                            '<td hidden>' + item.fld_pathDoc + '</td>' +
                            '<td>' + item.fld_incharge + '</td>' +
                            '<td>' + item.fld_changeSticker + '</td>' +
                            '<td>' + item.fld_actualCalibDueDate + '</td>' +
                            '<td hidden>' + item.fld_month + '</td>' +
                            '<td hidden>' + item.fld_year + '</td>' +

                            '</tr>'
                        );
                    });

                    // Calculate the completion rate
                    var totalCalibrated = data.filter(function (item) {
                        return item.fld_stat !== "";
                    }).length;
                    var totalRecords = data.length;

                    var completionRate = totalCalibrated / totalRecords;

                    // Display the completion rate
                    $('#completionRateJig').text('Completion Rate: ' + (completionRate * 100).toFixed(1) + '%' + ' | ');
                    $('#totalRateJig').text('Total Calibration: ' + (totalRecords) + ' | ');
                    $('#totalCalibratedJig').text('Total Calibrated: ' + (totalCalibrated));




                } else {
                    // No results found
                    tableBody.append('<tr><td colspan="3">No results found</td></tr>');
                }
            },
            error: function (error) {
                console.error(error);
            }
        })
    });
});