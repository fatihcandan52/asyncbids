var searchVisible = 0;
var transparent = true;
var mobile_device = false;

$(document).ready(function () {

    $.material.init();

    // Code for the Validator
    var $validatorStepOne = $('.wizard-card form').validate({
        rules: {
            IdentificationNumber: {
                required: true,
                minlength: 11,
                maxlength: 11
            },
            LicensePlate: {
                required: true,
                minlength: 5,
                maxlength: 20
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    var $validatorStepTwo = $('.wizard-card form').validate({
        rules: {
            LicenseSerialCode: {
                required: true,
                maxlength: 2,
                minlength: 2
            },
            LicenseSerialNo: {
                required: true,
                minlength: 6,
                minlength: 6
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    // Wizard Initialization
    $('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {
            if (index == 1) {
                var $validOne = $('.wizard-card form').valid();
                if (!$validOne) {
                    $validatorStepOne.focusInvalid();
                    return false;
                } else {
                    var jsonData = {
                        identification: $("#IdentificationNumber").val(),
                        plate: $("#LicensePlate").val()
                    };

                    $.post("/Home/GetInfoByIdentificationAndPlate", jsonData, function (response) {
                        if (response.isSucceed) {
                            var data = response.object;
                            $("#LicenseSerialCode").val(data.licenseSerialCode);
                            $("#LicenseSerialNo").val(data.licenseSerialNo);
                        }
                    });
                }
            } else if (index == 2) {
                var $validTwo = $('.wizard-card form').valid();
                if (!$validTwo) {
                    $validatorStepTwo.focusInvalid();
                    return false;
                } else {
                    $("#description").html("");

                    connection.invoke("SendAsync", {
                        licensePlate: $("#LicensePlate").val(),
                        identificationNumber: $("#IdentificationNumber").val(),
                        licenseSerialCode: $("#LicenseSerialCode").val(),
                        licenseSerialNo: $("#LicenseSerialNo").val()
                    });
                }
            }
        },

        onPrevious: function (tab, navigation, index) {
            
        },
        onInit: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $wizard = navigation.closest('.wizard-card');

            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.wizard-card .wizard-navigation').append($moving_div);

            refreshAnimation($wizard, index);

            $('.moving-tab').css('transition', 'transform 0s');
        },

        onTabClick: function (tab, navigation, index) {
            return false;
        },

        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.wizard-card');

            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');

            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });
});

function refreshAnimation($wizard, index) {
    $total = $wizard.find('.nav li').length;
    $li_width = 100 / $total;

    total_steps = $wizard.find('.nav li').length;
    move_distance = $wizard.width() / total_steps;
    index_temp = index;
    vertical_level = 0;

    mobile_device = $(document).width() < 600 && $total > 3;

    if (mobile_device) {
        move_distance = $wizard.width() / 2;
        index_temp = index % 2;
        $li_width = 50;
    }

    $wizard.find('.nav li').css('width', $li_width + '%');

    step_width = move_distance;
    move_distance = move_distance * index_temp;

    $current = index + 1;

    if ($current == 1 || (mobile_device == true && (index % 2 == 0))) {
        move_distance -= 8;
    } else if ($current == total_steps || (mobile_device == true && (index % 2 == 1))) {
        move_distance += 8;
    }

    if (mobile_device) {
        vertical_level = parseInt(index / 2);
        vertical_level = vertical_level * 38;
    }

    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform': 'translate3d(' + move_distance + 'px, ' + vertical_level + 'px, 0)',
        'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

    });
}