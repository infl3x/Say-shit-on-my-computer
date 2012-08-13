$(document).ready(function () {

    $('#txtSay').focus();

    $('#frmSpeak').submit(function () {
        $('#btnSubmit').fadeOut('fast', function () {
            $('#status').html('Uploading...').fadeIn('fast', function () {
                var data = {
                    text: $('#txtSay').val(),
                    voiceTypeIdx: $('#slctVoice :selected').val()
                };

                $.ajax({
                    type: 'POST',
                    url: '/Home/Speak',
                    data: data,
                    success: function (response) {
                        if (response.success) {
                            $('#status').html('Speaking...');

                            window.setTimeout(function () {
                                checkStatus(response.hashCode);
                            }, 100);
                        }
                    },
                    error: function () {
                        $('#status').html('Error!');
                    }
                });
            });
        });

        return false;
    });

    function checkStatus(hashCode) {
        var data = {
            hashCode: hashCode,
        };

        $.ajax({
            type: 'POST',
            url: '/Home/Status',
            data: data,
            success: function (response) {
                if (response.success) {
                    $('#status').html(response.status);

                    if (response.status == 'Done!') {
                        // Done!
                        $('#txtSay').focus().select();
                        window.setTimeout(function() {
                            $('#status').fadeOut('fast', function () {
                                $('#btnSubmit').fadeIn('fast');
                            });
                        }, 1000);
                    } else {
                        // Not Done!
                        window.setTimeout(function () {
                            checkStatus(hashCode);
                        }, 100);
                    }
                }
            },
            error: function () {
                $('#status').html('Error!');
            }
        });
    }
});