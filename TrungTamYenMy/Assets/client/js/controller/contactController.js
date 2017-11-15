var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val(); 
            var email = $('#txtEmail').val();
            var mobile = $('#txtSDT').val();
            var address = $('#txtDiaChi').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: '/Home/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    sdt: mobile,
                    diachi: address,
                    content: content
                },
                success: function (res) {
                    if (res.TrangThai == true) {
                        window.alert('Gửi thành công');
                        //contact.resetForm();
                        contact.redirec();
                    }
                }
            });
            alert('Gửi thành công!');
        });
    },
    //resetForm: function () {
    //    $('#txtName').val('');
    //    $('#txtEmail').val('');
    //    $('#txtSDT').val('');
    //    $('#txtDiaChi').val('');
    //    $('#txtContent').val('');
    //},
    redirec:function(){
        window.location="/Home/LienHe";
    }
}
contact.init();