//$(document).ready(function () {
//    $("#click-create").click(function () {
//        $.ajax({
//            type: 'GET',
//            datatype: 'html',
//            url: '/Cupcake/Create',
//            success: function (result) {
//                $('.return-create').html(result);
//            }
//        });
//    });

//    $('.new-cupcake').submit(function (event) {
//        event.preventDefault();
//        $.ajax({
//            url: 'Cupcake/Create',
//            type: 'POST',
//            dataType: 'json',
//            data: $(this).serialize(),
//            success: function (result) {
//                var resultReturn = result.name;
//                $('#cupcake-list').append('<p>' + resultReturn + '</p>');
//            }
//        });
//    });
//});