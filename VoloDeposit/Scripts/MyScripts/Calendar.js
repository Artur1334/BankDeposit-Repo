$(function () {
    var min = $('.startdatetimepicker').attr("min");
    $('.startFromdatetimepicker').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('.startTodatetimepicker').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('.startdatetimepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        minDate: moment()
    });
    $('.dateTimepicker').datetimepicker({
        format: 'DD/MM/YYYY'
    });

});
