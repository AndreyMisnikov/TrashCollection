function changeCollectorStatus(status) {
    console.log(status);
    $.ajax('ChangeCollectorStatus', {
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: "application/json; charset=utf-8",
        success: function () {
            BootstrapDialog.alert({
                title: 'Успешно',
                message: 'Изменения были схранены!',
                type: BootstrapDialog.TYPE_SUCCESS
            });
        },
        error: function (errMesage) {
            BootstrapDialog.alert({
                title: 'Внимание',
                message: 'Не удалось сохранить!' + errMesage,
                type: BootstrapDialog.TYPE_DANGER
            });
        }
    });
}

function changeCustomerStatus(status) {
    console.log(status);
    return;
}