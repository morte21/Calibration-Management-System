// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setInitId() {
    var initId = $('#initId').val();
    $('#characRegister_InitId').val(initId);
}

$(function () {
    // Get the selected value of the AssyLine dropdown
    var selectedAssyLine = $('#AssyLine').val();

    // Set the value of the hidden input in the form of Controller2
    $('#Controller2AssyLine').val(selectedAssyLine);
});


$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#table-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search" />');
    });

    // DataTable
$('#table-registration').DataTable({
        order: [[0, 'desc']],
    //"scrollY": '50vh',
    //"scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [5, 10, 15, 25, -1],
            [5, 10, 15, 25, 'All'],
        ],

        initComplete: function () {

            var r = $('#table-registration tfoot tr');
            r.find('th').each(function () {
                $(this).css('padding', 8);
            });
            $('#table-registration thead').append(r);
            $('#search_0').css('text-align', 'center');


            // Apply the search
            this.api()
                .columns()
                .every(function () {
                    var that = this;

                    $('input', this.footer()).on('keyup change clear', function () {
                        if (that.search() !== this.value) {
                            that.search(this.value).draw();
                        }
                    });
                });

            },

    });
});



$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#table-registration-jig tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search" />');
    });

    // DataTable
    $('#table-registration-jig').DataTable({
        order: [[0, 'desc']],
        //"scrollY": '50vh',
        //"scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [5, 10, 15, 25, -1],
            [5, 10, 15, 25, 'All'],
        ],

        initComplete: function () {

            var r = $('#table-registration-jig tfoot tr');
            r.find('th').each(function () {
                $(this).css('padding', 8);
            });
            $('#table-registration-jig thead').append(r);
            $('#search_0').css('text-align', 'center');


            // Apply the search
            this.api()
                .columns()
                .every(function () {
                    var that = this;

                    $('input', this.footer()).on('keyup change clear', function () {
                        if (that.search() !== this.value) {
                            that.search(this.value).draw();
                        }
                    });
                });

        },

    });
});


$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#equipment-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search" />');
    });

$('#equipment-registration').DataTable({
    order: [[0, 'desc']],
    /*"scrollY": '50vh',*/
    "scrollX": '50vh',
    "scrollCollapse": true,
    "paging": true,
    "select": true,

    lengthMenu: [
        [5, 10, 15, 25, -1],
        [5, 10, 15, 25, 'All'],
    ],

    initComplete: function () {
        
        // Apply the search
        this.api()
            .columns()
            .every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change clear', function () {
                    if (that.search() !== this.value) {
                        that.search(this.value).draw();
                    }
                });
            });
   
        
    },
});

});


$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#jig-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search" />');
    });

    $('#jig-registration').DataTable({
        order: [[0, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [5, 10, 15, 25, -1],
            [5, 10, 15, 25, 'All'],
        ],

        initComplete: function () {

            // Apply the search
            this.api()
                .columns()
                .every(function () {
                    var that = this;

                    $('input', this.footer()).on('keyup change clear', function () {
                        if (that.search() !== this.value) {
                            that.search(this.value).draw();
                        }
                    });
                });


        },
    });

});







$(document).ready(function () {
    // Listen for changes in the select element
    $('#requestingFunctionSelect').on('change', function () {
        // Get the selected option value
        var selectedValue = $(this).val();

        // Add a console log to check the selected value (optional, for debugging purposes)
        console.log("Selected Value:", selectedValue);

        // Make an AJAX request to retrieve the code based on the selected department
        $.ajax({
            url: '/EquipmentMaster/GetCodeByDepartment',
            type: 'GET',
            data: { department: selectedValue },
            success: function (response) {
                // Update the value of the input field
                $('#codeInput').val(response);

                // Add a console log to check the response (optional, for debugging purposes)
                console.log("Response:", response);
            },
            error: function (error) {
                // Add a console log to check errors (optional, for debugging purposes)
                console.log("Error:", error);
            }


        });
    });
});


//dropdown
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
});






