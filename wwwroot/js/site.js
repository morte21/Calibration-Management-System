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


$(function () {
    // Setup - add a text input to each footer cell
    $('#table-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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

            //var r = $('#table-registration tfoot tr');
            //r.find('th').each(function () {
            //    $(this).css('padding', 8);
            //});
            //$('#table-registration thead').append(r);
            //$('#search_0').css('text-align', 'center');


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



$(function () {
    // Setup - add a text input to each footer cell
    $('#table-registration-jig tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#equipment-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#jig-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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







$(function () {
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#table-suspendRegistration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    $('#table-suspendRegistration').DataTable({
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#table-disposedRegistration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    $('#table-disposedRegistration').DataTable({
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#table-suspendMaster tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    $('#table-suspendMaster').DataTable({
        order: [[0, 'desc']],
        //"scrollY": '50vh',
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



$(function () {
    // Setup - add a text input to each footer cell
    $('#table-disposedMaster tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    $('#table-disposedMaster').DataTable({
        order: [[0, 'desc']],
        //"scrollY": '50vh',
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#failurereport-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    $('#failurereport-registration').DataTable({
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

$(function () {
    // Setup - add a text input to each footer cell
    $('#uncontrolled-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    $('#uncontrolled-registration').DataTable({
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

$(function () {
    // Setup - add a text input to each footer cell
    $('#ncr-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    $('#ncr-registration').DataTable({
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



$(function () {
    // Setup - add a text input to each footer cell
    $('#generalform-registration tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    $('#generalform-registration').DataTable({
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


$(function () {
    // Setup - add a text input to each footer cell
    $('#calib-notice tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    $('#calib-notice').DataTable({
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

//dfgdfg
document.getElementById("composeButton").addEventListener("click", function () {
    var subject = "Your Subject";
    var body = "Your Message";
    var to = "email@example.com";
    var mailtoUrl = "mailto:" + to + "?subject=" + encodeURIComponent(subject) + "&body=" + encodeURIComponent(body);
    window.location.href = mailtoUrl;
});

//dropdown
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
});


//datepicker
// Get today's date as a string in "YYYY-MM-DD" format
var today = new Date().toISOString().split('T')[0];

// Set the input field value to today's date
document.getElementById("myDateInputs").value = today;



