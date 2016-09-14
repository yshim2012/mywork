var Login = function () {
    
    return {
        //main function to initiate the module
        init: function () {
        	
           $('.login-form').validate({
	            errorElement: 'label', //default input error message container
	            errorClass: 'help-inline', // default input error message class
	            focusInvalid: false, // do not focus the last invalid input
	            rules: {
	                username: {
	                    required: true
	                },
	                password: {
	                    required: true
	                },
	                remember: {
	                    required: false
	                }
	            },

	            messages: {
	                username: {
	                    required: "用户名不能为空"
	                },
	                password: {
	                    required: "密码不能为空"
	                }
	            },

	            invalidHandler: function (event, validator) { //display error alert on form submit   
	                $('.alert-error', $('.login-form')).show();
	            },

	            highlight: function (element) { // hightlight error inputs
	                $(element)
	                    .closest('.control-group').addClass('error'); // set error class to the control group
	            },

	            success: function (label) {
	                label.closest('.control-group').removeClass('error');
	                label.remove();
	            },

	            errorPlacement: function (error, element) {
	                error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
	            },

	            submitHandler: function (form) {
	                login();
	            }
	        });

	        $('.login-form input').keypress(function (e) {
	            if (e.which == 13) {
	                if ($('.login-form').validate().form()) {

	                    login();
	                }
	                return false;
	            }
	        }); 
        } 
    };



    function login()
    {
        var d = {};
        //判断文件框内容
        if ($("#username").val() != "") {
            d["Username"] = $("#username").val();
        }

        if ($("#password").val() != "") {
            d["Password"] = $("#password").val();
        }

        if ((JSON.stringify(d) == "{}")) {
            d = null;
        }
        $.ajax({
            url: "../api/LoginApi/login",
            type: "post",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(d),
            success: function (data) {

                if (data == "") {
                    alert('用户名或密码错误!');
                }
                else {
                    window.location.href = "http://localhost:3947/Home/Index";
                }
            }
        }).fail(
        function (err) {
            alert('登录失败!');
        });

    }
}();