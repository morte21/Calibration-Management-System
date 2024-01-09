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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/Registration/EQPLoadData',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                &nbsp;&nbsp;<a style="font-size:x-small;" href="/Registration/Edit_Data/${row.id}">Edit</a>&nbsp;&nbsp; |
                &nbsp;&nbsp;<a style="font-size:x-small;" href="/EquipmentMaster/EditGet?fld_codeNo=${encodeURIComponent(row.fld_codeNo)}&fld_eqpName=${encodeURIComponent(row.fld_eqpName)}&fld_eqpModelNo=${encodeURIComponent(row.fld_eqpModelNo)}&fld_serial=${encodeURIComponent(row.fld_serial)}&fld_brand=${encodeURIComponent(row.fld_brand)}&fld_reqFunction=${encodeURIComponent(row.fld_reqFunction)}&fld_ctrlNo=${encodeURIComponent(row.fld_ctrlNo)}">Register Calibration</a>
                </td>`;
                }
            },

            { data: 'fld_dateReg' },
            { data: 'fld_reqFunction' },
            { data: 'fld_incharge', visible: false },
            { data: 'fld_approvedBy', visible: false },
            { data: 'fld_codeNo', visible: false },
            { data: 'fld_ctrlNo', visible: false },
            { data: 'fld_eqpName' },
            { data: 'fld_eqpModelNo' },
            { data: 'fld_serial', visible: false },
            { data: 'fld_brand', visible: false },
            { data: 'fld_submissionDate', visible: false },
            { data: 'fld_receivedBy', visible: false },
            { data: 'fld_status' },
            { data: 'fld_emailOne', visible: false },
            { data: 'fld_emailTwo', visible: false },
            { data: 'fld_emailThree', visible: false },
            { data: 'fld_jigName', visible: false },
            { data: 'fld_drawingNo', visible: false },
            { data: 'fld_reRegJigCtrlNo', visible: false },
            { data: 'fld_jigCategory', visible: false },
            
            { data: 'fld_remarks', visible: false }
        ],


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },



        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/Registration/ExportAllDataEQP';
                } 
            },
        ],

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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],

        processing: true,
        serverSide: true,
        ajax: {
            url: '/Registration/JIGLoadData',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    <a style="font-size:x-small;" href="/Registration/Edit_DataJig/${row.id}">Edit</a> |
                    <a style="font-size:x-small;" href="/JigMaster/EditGet?fld_codeNo=${row.fld_codeNo}&fld_jigName=${row.fld_jigName}&fld_drawingNo=${row.fld_drawingNo}&fld_serial=${row.fld_serial}&fld_reqFunction=${row.fld_reqFunction}&fld_ctrlNo=${row.fld_ctrlNo}">Register Calibration</a>
                </td>`;
                }
            },

            { data: 'id', visible: false },
            { data: 'fld_dateReg' },
            { data: 'fld_reqFunction' },
            { data: 'fld_incharge', visible: false },
            { data: 'fld_approvedBy', visible: false },
            { data: 'fld_codeNo', visible: false },
            { data: 'fld_ctrlNo', visible: false },
            { data: 'fld_jigName' },
            { data: 'fld_drawingNo' },
            { data: 'fld_eqpName', visible: false },
            { data: 'fld_eqpModelNo', visible: false },
            { data: 'fld_serial', visible: false },
            { data: 'fld_brand', visible: false },
            { data: 'fld_submissionDate', visible: false },
            { data: 'fld_receivedBy', visible: false },
            { data: 'fld_status' },
            { data: 'fld_emailOne', visible: false },
            { data: 'fld_emailTwo', visible: false },
            { data: 'fld_emailThree', visible: false },

            { data: 'fld_reRegJigCtrlNo', visible: false },
            { data: 'fld_jigCategory', visible: false },

            { data: 'fld_remarks', visible: false }
        ],

        


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/Registration/ExportAllDataJIG';
                } 
            },
        ],

    });
});

$(function () {
    new DataTable('#equipment-registration', {
        order: [[2, 'desc']],
        /*"scrollY": '50vh',*/
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],



        processing: true,
        serverSide: true,
        ajax: {
            url: '/EquipmentMaster/masterRegLoadData',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/EquipmentMaster/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/EquipmentMaster/Details/${row.id}">Details</a> |
                    &nbsp;&nbsp;<a href="/EquipmentMaster/Delete/${row.id}">Delete</a>
                </td>`;
                }
            },

            { data: 'fld_codeNo' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_division' },
            { data: 'fld_category' },
            { data: 'fld_code2' },
            { data: 'fld_eqpName' },
            { data: 'fld_eqpModelNo' },
            { data: 'fld_serial' },
            { data: 'fld_brand' },
            { data: 'fld_term' },
            { data: 'fld_reqFunction' },
            { data: 'fld_passFail' },
            { data: 'fld_registrationDate' },
            { data: 'fld_imte' },
            { data: 'fld_calibDate' },
            { data: 'fld_calibMonth' },
            { data: 'fld_calibYear' },
            { data: 'fld_nextCalibDate' },
            { data: 'fld_nextCalibMonth' },
            { data: 'fld_nextCalibYear' },
            { data: 'fld_internalExternal' },
            { data: 'fld_supplierExternal' },
            { data: 'fld_comment' },
            { data: 'fld_appStandardEqp' },
            { data: 'fld_pathIMG' },
            { data: 'fld_pathDoc' },
            { data: 'fld_stat' },
            { data: 'fld_calibResult' }
        ],


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/EquipmentMaster/ExportAllDataEQP';
                }
            },
        ],

       

        // Event listener for footer input change
    
    });
});


$(document).ready(function () {
    $('#equipment-registration').DataTable();

    $('#example_filter').hide(); // Hide default search datatables where example is the ID of table

    $('#txtSearch').on('keyup', function () {
        $('#example')
            .DataTable()
            .search($('#txtSearch').val(), false, true)
            .draw();
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],

        //server side data
        processing: true,
        serverSide: true,
        ajax: {
            url: '/JigMaster/JigLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/JigMaster/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/JigMaster/Details/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_codeNo' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_division' },
            { data: 'fld_jigName' },
            { data: 'fld_drawingNo' },
            { data: 'fld_serialNo' },
            { data: 'fld_term' },
            { data: 'fld_reqFunction' },
            { data: 'fld_passfail' },
            { data: 'fld_registrationDate' },
            { data: 'fld_imte' },
            { data: 'fld_calibDate' },
            { data: 'fld_calibMonth' },
            { data: 'fld_calibYear' },
            { data: 'fld_nextCalibDate' },
            { data: 'fld_nextCalibMonth' },
            { data: 'fld_nextCalibYear' },
            { data: 'fld_internalExternal' },
            { data: 'fld_remarks' },
            { data: 'fld_pathDoc' },
            { data: 'fld_pathIMG' },
            { data: 'fld_stat' },
           
            { data: 'fld_description' }
        ],

        //search function
        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },


        //export data to excel
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/JigMaster/ExportAllDataJIG';
                }
            },
        ],
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
//            [15, 25, 50, 100],
//            [15, 25, 50, 100, 100],
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],

        processing: true,
        serverSide: true,
        ajax: {
            url: '/SuspendDispose/SuspendLoadData1',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/SuspendDispose/Edit_Suspend2/${row.id}">Update</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/SuspendDispose/ActivateSuspend/${row.id}">Activate Suspend</a>
                </td>`;
                }
            },

            { data: 'id', visible: false }, // Hidden column
            { data: 'fld_dateReg' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_itemName' },
            { data: 'fld_calibType', visible: false },
            { data: 'fld_modelNo' },
            { data: 'fld_serial', visible: false },
            { data: 'fld_brand', visible: false },
            { data: 'fld_reqFunction', visible: false },
            { data: 'fld_fixedAsset', visible: false },
            { data: 'fld_requestBy', visible: false },
            { data: 'fld_approvedBy', visible: false },
            { data: 'fld_reason', visible: false },
            { data: 'fld_drawingNo', visible: false },
            { data: 'fld_suspendedDate', visible: false },
            { data: 'fld_disposalDate', visible: false },
            { data: 'fld_submitdate', visible: false },
            { data: 'fld_receivedBy', visible: false },
            { data: 'fld_reqStatus' },
            { data: 'fld_inchargeQA', visible: false },
            { data: 'fld_followUpDate', visible: false },
            { data: 'fld_nextFollowUp', visible: false },
            { data: 'fld_inchargeRequestor', visible: false }
        ],




        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/SuspendDispose/DisposeLoadData1',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/SuspendDispose/Edit_Suspend2/${row.id}">Update</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/SuspendDispose/ActivateSuspend/${row.id}">Dispose Item</a>
                </td>`;
                }
            },


            { data: 'fld_dateReg' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_itemName' },
            { data: 'fld_calibType' },
            { data: 'fld_modelNo' },
            { data: 'fld_serial', visible: false },
            { data: 'fld_brand', visible: false },
            { data: 'fld_reqFunction', visible: false },
            { data: 'fld_fixedAsset', visible: false },
            { data: 'fld_requestBy', visible: false },
            { data: 'fld_approvedBy', visible: false },
            { data: 'fld_reason', visible: false },
            { data: 'fld_drawingNo', visible: false },
            { data: 'fld_suspendedDate', visible: false },
            { data: 'fld_disposalDate', visible: false },
            { data: 'fld_submitdate', visible: false },
            { data: 'fld_receivedBy', visible: false },
            { data: 'fld_reqStatus', visible: false },
            { data: 'fld_inchargeQA', visible: false },
            { data: 'fld_followUpDate', visible: false },
            { data: 'fld_nextFollowUp', visible: false },
            { data: 'fld_inchargeRequestor', visible: false }
        ],

        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },


        
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],

        processing: true,
        serverSide: true,
        ajax: {
            url: '/SuspendDispose/SuspendLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/SuspendDispose/Edit_Suspend2/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/SuspendDispose/DetailsSuspend/${row.id}">Details</a>
                </td>`;
                }
            },

            //{ data: 'id', visible: false }, // Hidden column
            { data: 'fld_dateReg' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_itemName' },
            { data: 'fld_calibType' },
            { data: 'fld_modelNo' },
            { data: 'fld_serial' },
            { data: 'fld_brand' },
            { data: 'fld_reqFunction' },
            { data: 'fld_fixedAsset' },
            { data: 'fld_requestBy' },
            { data: 'fld_approvedBy' },
            { data: 'fld_reason' },
            { data: 'fld_drawingNo' },
            { data: 'fld_suspendedDate' },
            { data: 'fld_disposalDate' },
            { data: 'fld_submitdate' },
            { data: 'fld_receivedBy' },
            { data: 'fld_reqStatus' },
            { data: 'fld_inchargeQA' },
            { data: 'fld_followUpDate' },
            { data: 'fld_nextFollowUp' },
            { data: 'fld_inchargeRequestor' }
        ],
        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        //export data to excel
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/SuspendDispose/ExportAllDataSUS';
                }
            },
        ],

        
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/SuspendDispose/DisposeLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/SuspendDispose/Edit_Suspend2/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/SuspendDispose/DetailsSuspend/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_dateReg' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_itemName' },
            { data: 'fld_calibType' },
            { data: 'fld_modelNo' },
            { data: 'fld_serial' },
            { data: 'fld_brand' },
            { data: 'fld_reqFunction' },
            { data: 'fld_fixedAsset' },
            { data: 'fld_requestBy' },
            { data: 'fld_approvedBy' },
            { data: 'fld_reason' },
            { data: 'fld_drawingNo' },
            { data: 'fld_suspendedDate' },
            { data: 'fld_disposalDate' },
            { data: 'fld_submitdate' },
            { data: 'fld_receivedBy' },
            { data: 'fld_reqStatus' },
            { data: 'fld_inchargeQA' },
            { data: 'fld_followUpDate' },
            { data: 'fld_nextFollowUp' },
            { data: 'fld_inchargeRequestor' }
        ],


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        //export data to excel
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/SuspendDispose/ExportAllDataDIS';
                }
            },
        ],
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/FailureReport/FRLoadData1',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/FailureReport/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/FailureReport/Details/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_reportNo' },
            { data: 'fld_dateIssue' },
            { data: 'fld_deptsec' },
            { data: 'fld_incharge' },
            { data: 'fld_mainincharge' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_EquipName' },
            { data: 'fld_qty' },
            { data: 'fld_contents' },

            { data: 'fld_pathDoc', visible: false },
            { data: 'fld_pathIMG', visible: false }
        ],

        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        //export data to excel
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/FailureReport/ExportAllData';
                }
            },
        ],
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/Uncontrolled/UNLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/Uncontrolled/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/Uncontrolled/Details/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_nameEquip' },
            { data: 'fld_modelType' },
            { data: 'fld_serial' },
            { data: 'fld_maker' },
            { data: 'fld_reasonUncontrolled' },
            { data: 'fld_qty' },
            { data: 'fld_reqDate' },
            { data: 'fld_reqBy' },
            { data: 'fld_department' },

          
            { data: 'fld_commento' }
        ],


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/Uncontrolled/ExportAllData';
                }
            },
        ],

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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/NCR/NCRLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/NCR/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/NCR/Details/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_nonConReportNo' },
            { data: 'fld_dateIssue' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_IssueTo' },
            { data: 'fld_mainIncharge' },
            { data: 'fld_modelNo' },
            { data: 'fld_qty' },
            { data: 'fld_withDisposalForm' },
            { data: 'fld_contents' },
            { data: 'fld_dateCompleted' },
            { data: 'fld_status' },
            { data: 'fld_calibReportNo' },
            { data: 'fld_giveDisposeSuspendedForm' },
            { data: 'fld_givenTo' },
            { data: 'fld_rcvDisposeSuspendedForm' },
            { data: 'fld_pathDoc', visible: false },
            { data: 'fld_pathIMG', visible: false }
        ],

        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/NCR/ExportAllData';
                }
            },
        ],

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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/GeneralForm/GFLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/GeneralForm/Edit/${row.id}">Edit</a>&nbsp;&nbsp; |
                    &nbsp;&nbsp;<a href="/GeneralForm/Details/${row.id}">Details</a>
                </td>`;
                }
            },

            { data: 'fld_no' },
            { data: 'fld_dateEst' },
            { data: 'fld_appEquipment' },
            { data: 'fld_docNo' },
           
            { data: 'fld_rev' }
        ],


        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
            });
        },

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: 'Export to Excel',
                action: function (e, dt, button, config) {
                    // Trigger the export action here
                    window.location.href = '/GeneralForm/ExportAllData';
                }
            },
        ],
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
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
        order: [[5, 'desc']],
        "scrollY": '50vh',
        "scrollX": '50vh',
        "scrollCollapse": true,
        "paging": true,
        "select": true,

        lengthMenu: [
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],

        processing: true,
        serverSide: true,
        ajax: {
            url: '/ResultEQP/ResultEQPLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a href="/ResultEQP/Edit/${row.id}">Edit</a>&nbsp;&nbsp;
                </td>`;
                }
            },

            { data: 'fld_stat' },
            { data: 'fld_codeNo' },
            { data: 'fld_ctrlNo' },
            { data: 'calibrationdate' },
            { data: 'fld_eqpName' },
            { data: 'fld_eqpModelNo' },
            { data: 'fld_serial' },
            { data: 'fld_brand' },
            { data: 'fld_term' },
            { data: 'fld_reqFunction' },
            { data: 'fld_passFail' },
            { data: 'fld_imte' },
            { data: 'fld_calibDate' },
            { data: 'fld_calibMonth' },
            { data: 'fld_calibYear' },
            { data: 'fld_nextCalibDate' },
            { data: 'fld_nextCalibMonth' },
            { data: 'fld_nextCalibYear' },
            { data: 'fld_internalExternal' },
            { data: 'fld_supplierExternal' },
            { data: 'fld_comment' },
            { data: 'fld_appStandardEqp' },
            { data: 'fld_pathIMG', visible: false },
            { data: 'fld_pathDoc', visible: false },
            { data: 'fld_dateReturned' },
            { data: 'fld_withNC' },
            { data: 'fld_CalibFR' },
            { data: 'fld_calibDisSusForm' },
            { data: 'fld_withCalibResult' },
            { data: 'fld_incharge' },
            { data: 'fld_remarks' },
            { data: 'fld_changeSticker' },
            { data: 'fld_actualCalibDueDate' },
            { data: 'fld_dateRecv' },
            { data: 'fld_month', visible: false },
            { data: 'fld_year', visible: false }
        ],

        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
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
            [15, 25, 50, 100],
            [15, 25, 50, 100],
        ],


        processing: true,
        serverSide: true,
        ajax: {
            url: '/ResultJIG/ResultJIGLoadData2',
            type: 'POST',
            data: function (d) {
                // Get tfoot search values
                $('tfoot input').each(function (index) {
                    d[`searchColumn${index}`] = $(this).val();
                });
                // other data parameters if needed
            }
        },

        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    return `
                <td>
                    &nbsp;&nbsp;<a  href="/ResultJIG/Edit/${row.id}">Edit</a>&nbsp;&nbsp;
                </td>`;
                }
            },

            { data: 'fld_stat' },
            { data: 'fld_ctrlNo' },
            { data: 'fld_jigName' },
            { data: 'calibrationdate' },
            { data: 'fld_codeNo', visible: false },
            { data: 'fld_drawingNo' },
            { data: 'fld_term' },
            { data: 'fld_reqFunction' },
            { data: 'fld_remarks' },
            { data: 'fld_passfail' },
            { data: 'fld_imte' },
            { data: 'fld_dateRecv' },
            { data: 'fld_calibDate' },
            { data: 'fld_calibMonth' },
            { data: 'fld_calibYear' },
            { data: 'fld_nextCalibDate' },
            { data: 'fld_nextCalibMonth' },
            { data: 'fld_nextCalibYear' },
            { data: 'fld_dateReturned' },
            { data: 'fld_internalExternal' },
            { data: 'fld_withNC' },
            { data: 'fld_CalibFR' },
            { data: 'fld_calibDisSusForm' },
            { data: 'fld_withCalibResult' },
            { data: 'fld_pathDoc', visible: false },
            { data: 'fld_pathIMG', visible: false },
            { data: 'fld_incharge' },
            { data: 'fld_changeSticker' },
            { data: 'fld_actualCalibDueDate' },
            { data: 'fld_month', visible: false },
            { data: 'fld_year', visible: false }
        ],

        initComplete: function () {
            var table = this;
            $('tfoot input').on('keyup change', function () {
                var index = $(this).parent().index();
                table.column(index).search(this.value).draw();
            });

            this.api().columns().every(function () {
                var column = this;
                var columnIndex = column.index();
                var title = $(column.header()).text();

                // Create the input element for each column
                var input = $('<input type="text" placeholder="Search ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
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




