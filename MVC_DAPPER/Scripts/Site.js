$(document).ready(function () {
    $('.datepicker').datepicker({
        dateFormat: 'dd/mm/yy',
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true
    }).on("change", function (e) {
        $(this).valid();
    });

    $('.datepicker').attr("autocomplete", "off");

    $('.datatable').DataTable({
        "order": [],
        "columnDefs": [
            { className: 'dt-body-center', orderable: false, targets: -1 },
            { width: "2%", orderable: false, targets: 0 }
        ]
    });
});