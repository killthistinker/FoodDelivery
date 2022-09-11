
$(document).ready(function () {
    $("#password-view").on("click", function () {
        var type = $("#password").attr('type') === "text" ? "password" : "text";
        $("#password").prop('type', type);
    });

    $("#confirm-view").on("click", function () {
        var type = $("#confirm").attr('type') == "text" ? "password" : "text";
        $("#confirm").prop('type', type);
    });

    $("#password-view-login").on("click", function () {
        var type = $("#login-password").attr('type') == "text" ? "password" : "text";
        $("#login-password").prop('type', type);
    });
    
    // $('#dish-add-form').submit(function (e){
    //     e.preventDefault();
    //     var name = $('#point-name').val();
    //     var file = $('#point-file').val();
    //     var formdata = new FormData();
    //     formdata.append('file', $('#point-file')[0].files[0]);
    //     var description = $('#point-description').val();
    //     var pointViewModel = {
    //         name: name,
    //         file: formdata,
    //         description: description
    //     };
    //     console.log(pointViewModel)
    // })
    //
    // $('#payment-form').submit(function (e) {
    //     e.preventDefault();
    //     var providerId = $('#provider').val();
    //     var props = $('#props').val();
    //     var paymentSum = $('#payment-sum').val();
    //     var paymentInformer = $('#payment-button');
    //     var addPaymentViewModel = {
    //         providerId: providerId,
    //         sum: paymentSum,
    //         propsId: props
    //     }
    //     console.log(addPaymentViewModel);
    //     $.ajax({
    //         method: "POST",
    //         url: 'https://localhost:5001/payments/newpayment',
    //         data: JSON.stringify(addPaymentViewModel),
    //         contentType: 'application/json',
    //         success: function (res) {
    //             switch (res) {
    //                 case 200:
    //                     paymentInformer.attr('data-content', `Платеж  совершен на сумму: ${paymentSum}`);
    //                     paymentInformer.popover('show');
    //                     break;
    //                 case 406:
    //                     paymentInformer.attr('data-content', `Недостаточно средств`);
    //                     paymentInformer.popover('show')
    //                     break;
    //                 case 404:
    //                     paymentInformer.attr('data-content', `пользователь не найден`);
    //                     paymentInformer.popover('show');
    //                     break;
    //                 case 407:
    //                     paymentInformer.attr('data-content', `нельзя пополнить баланс самому себе`);
    //                     paymentInformer.popover('show');
    //                     break;
    //                 case 409:
    //                     paymentInformer.attr('data-content', `введена отрицательная сумма`);
    //                     paymentInformer.popover('show');
    //                     break;
    //                 default:
    //                     paymentInformer.attr('data-content', `Введены некорректные данные`);
    //                     paymentInformer.popover('show');
    //                     break;
    //             }
    //             updateUserBalance();
    //         }
    //     });
    //
    // });
    // $('#filtration-form').submit(function (e) {
    //     e.preventDefault();
    //   
    //     var dateTo = $('#date-to').val();
    //     var dateFrom = $('#date-from').val();
    //   
    //     var filtrationViewModel = {
    //         dateTo: dateTo,
    //         dateFrom: dateFrom,
    //     }
    //     console.log(filtrationViewModel);
    //     $.ajax({
    //         method: "GET",
    //         url: 'https://localhost:5001/transactions/filtration',
    //         data: {dateFrom: dateFrom, dateTo: dateTo},
    //         contentType: 'application/json',
    //         success: function (res) {
    //             console.log(res);
    //            $('#table-body').empty().append(res);
    //             }
})