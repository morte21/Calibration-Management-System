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
    new DataTable('#table-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});
$(function () {
    new DataTable('#table-registration-jig', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});

$(function () {
    new DataTable('#equipment-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});

$(function () {
    new DataTable('#jig-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});

//$(function () {
//    new DataTable('#requestingFunctionSelect', {
//        order: [[0, 'desc']],
//        /*"scrollY": '50vh',*/
//        "scrollX": '50vh',
//        "scrollCollapse": true,
//        "paging": true,
//        "select": true,

//        lengthMenu: [
//            [5, 10, 15, 25, -1],
//            [5, 10, 15, 25, 'All'],
//        ],
//        initComplete: function () {
//            this.api()
//                .columns()
//                .every(function () {
//                    let column = this;
//                    let title = column.footer().textContent;

//                    // Create input element
//                    let input = document.createElement('input');
//                    input.placeholder = title;
//                    column.footer().replaceChildren(input);

//                    // Event listener for user input
//                    input.addEventListener('keyup', () => {
//                        if (column.search() !== this.value) {
//                            column.search(input.value).draw();
//                        }
//                    });
//                });
//        }
//    });
//});


$(function () {
    new DataTable('#table-suspendRegistration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#table-disposedRegistration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#table-suspendMaster', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#table-disposedMaster', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});




$(function () {
    new DataTable('#failurereport-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#uncontrolled-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#ncr-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#generalform-registration', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});



$(function () {
    new DataTable('#calib-notice', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});


$(function () {
    new DataTable('#email-list', {
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
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});



$(function () {
    new DataTable('#dailyCalibEQP', {
        order: [[3, 'desc']],
        "scrollY": '50vh',
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [8, 10, 15, 25, -1],
            [8, 10, 15, 25, 'All'],
        ],
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});




$(function () {
    new DataTable('#dailyCalibJig', {
        order: [[3, 'desc']],
        "scrollY": '50vh',
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [8, 10, 15, 25, -1],
            [8, 10, 15, 25, 'All'],
        ],
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    let column = this;
                    let title = column.footer().textContent;

                    // Create input element
                    let input = document.createElement('input');
                    input.placeholder = title;
                    column.footer().replaceChildren(input);

                    // Event listener for user input
                    input.addEventListener('keyup', () => {
                        if (column.search() !== this.value) {
                            column.search(input.value).draw();
                        }
                    });
                });
        }
    });
});



//dfgdfg
//document.getElementById("composeButton").addEventListener("click", function () {
//    var subject = "Your Subject";
//    var body = "Your Message";
//    var to = "email@example.com";
//    var mailtoUrl = "mailto:" + to + "?subject=" + encodeURIComponent(subject) + "&body=" + encodeURIComponent(body);
//    window.location.href = mailtoUrl;
//});



//dropdown
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
});


//datepicker
// Get today's date as a string in "YYYY-MM-DD" format
var today = new Date().toISOString().split('T')[0];

// Set the input field value to today's date
//document.getElementById("myDateInputs").value = today;

//document.getElementById("yearUpload").value = today;


    //// Your JavaScript code here
    //var today = new Date(); // Get the current date

    //// Set the value of the element with ID "myDateInputs" to today's date
    //var myDateInputs = document.getElementById("myDateInputs");
    //if (myDateInputs) {
    //    myDateInputs.value = today;
    //}

    // Set the value of the element with ID "yearUpload" to today's date
    //var yearUpload = document.getElementById("yearUpload");
    //if (yearUpload) {
    //    yearUpload.value = today;
    //}




