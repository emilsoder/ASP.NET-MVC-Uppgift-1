﻿$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function TextCounter(val) {
    var charCount = val.value.length;
    var textLeft = 50 - charCount;
    $('#headerCharCountLabel').text("Tecken kvar: " + textLeft);
}

function TextCounter2(val) {
    var charCount2 = val.value.length;
    var textLeft2 = 2000 - charCount2;
    $('#bodyCharCountLabel').text("Tecken kvar: " + textLeft2);
}

//$(window).resize(function () {
//    if ($(window).width() < 975) {
//        $('.onn').css({
//            'width': '175'
//        });
//        if ($(window).width() < 466) {
//            $('.onn').css({
//                'width': '172'
//            });
//        }
//        if ($(window).width() < 426) {
//            $('.onn').css({
//                'width': '150'
//            });
//        }
//        if ($(window).width() < 375) {
//            $('.onn').css({
//                'width': '140'
//            });
//        }
//        if ($(window).width() < 346) {
//            $('.onn').css({
//                'width': '100%'
//            });
//            $('#SearchString').css({
//                'width': '120px'
//            });
//        } if ($(window).width() > 346) {
//            $('#SearchString').css({
//                'width': 'auto'
//            });
//        }
//    }
//    else if ($(window).width() > 466) {
//        $('.onn').css({
//            'width': 'auto'
//        });
//    }
//});

//$(document).ready(function () {
//if ($(window).width() < 466) {
//    $('.onn').css({
//        'width': '172'
//    });
//    if ($(window).width() < 412) {
//        $('.onn').css({
//            'width': '150'
//        });
//    }
//    if ($(window).width() < 367) {
//        $('.onn').css({
//            'width': '140'
//        });
//    }
//    if ($(window).width() < 346) {
//        $('.onn').css({
//            'width': '100%'
//        });
//        $('#SearchString').css({
//            'width': '120px'
//        });
//    }
//    if ($(window).width() > 346) {
//        $('#SearchString').css({
//            'width': 'auto'
//        });
//    }
//}
//    if ($(window).width() < 975) {
//        $('.onn').css({
//            'width': '175'
//        });
//        if ($(window).width() < 466) {
//            $('.onn').css({
//                'width': '172'
//            });
//        }
//        if ($(window).width() < 426) {
//            $('.onn').css({
//                'width': '150'
//            });
//        }
//        if ($(window).width() < 375) {
//            $('.onn').css({
//                'width': '140'
//            });
//        }
//        if ($(window).width() < 346) {
//            $('.onn').css({
//                'width': '100%'
//            });
//            $('#SearchString').css({
//                'width': '120px'
//            });
//        } if ($(window).width() > 346) {
//            $('#SearchString').css({
//                'width': 'auto'
//            });
//        }
//    }
//    else if ($(window).width() > 466) {
//        $('.onn').css({
//            'width': 'auto'
//        });
//    }
//});

// New function. Made for iPhone sizes.
// MODEL --------- WIDTH 
// iPhone 6 Plus:   414
// iPhone 6:        375
// iPhone 4/5:      320

$(document).ready(function () {
    if ($(window).width() <= 512) {
        $('.onn').css({
            'width': '48.5%'
        });
        if ($(window).width() <= 325) {
            $('.onn').css({
                'width': '100%'
            });
        }
        if ($(window).width() < 346) {
            $('#SearchString').css({
                'width': '120px'
            });
        }
        else if ($(window).width() > 346) {
            $('#SearchString').css({
                'width': 'auto'
            });
        }
    }
    else if ($(window).width() > 415) {
        $('.onn').css({
            'width': 'auto'
        });
    }
});

$(window).resize(function () {
    if ($(window).width() <= 512) {
        $('.onn').css({
            'width': '48.5%'
        });
        if ($(window).width() <= 325) {
            $('.onn').css({
                'width': '100%'
            });
        }
        if ($(window).width() < 346) {
            $('#SearchString').css({
                'width': '120px'
            });
        }
        else if ($(window).width() > 346) {
            $('#SearchString').css({
                'width': 'auto'
            });
        }
    }
    else if ($(window).width() > 415) {
        $('.onn').css({
            'width': 'auto'
        });
    }
});

$(document).ready(function () {
    if ($(window).width() < 495) {
        $('.sortListLabel').hide();
    }
    else if ($(window).width() > 495) {
        $('.sortListLabel').show();
    }
});
$(window).resize(function () {
    if ($(window).width() < 495) {
        $('.sortListLabel').hide();
    }
    else if ($(window).width() > 495) {
        $('.sortListLabel').show();
    }
});

$(document).ready(function () {
    if ($(window).width() > 325) {
        $('#mobileCategoriesMenuButton').hide();
        $('#mobileCategoriesMenu').removeClass('collapse');
        $('#mobileCategoriesMenu').removeClass('in');
        $('#mobileCategoriesMenu').css({
            'border': '0px solid #009688',
            'padding': '0px 0px 0px 0px',
            'background-color': '#fff',
            'margin': '0'
        });
        $('.w3-btn').css({
            'margin': '2px 2px 2px 2px;'
        });
    }
    else if ($(window).width() < 325) {
        $('#mobileCategoriesMenuButton').show();
        $('#mobileCategoriesMenu').addClass('collapse');
        $('#mobileCategoriesMenu').css({
            'border': '1px solid #009688',
            'padding': '5px 9px 5px 4px',
            'background-color': '#f2f2f2',
            'margin': '0'
        });
        $('.w3-btn').css({
            'margin': '2px 0px 2px 0px;'
        });
    }
});
$(window).resize(function () {
    if ($(window).width() > 325) {
        $('#mobileCategoriesMenuButton').hide();
        $('#mobileCategoriesMenu').removeClass('collapse');
        $('#mobileCategoriesMenu').removeClass('in');
        $('#mobileCategoriesMenu').css({
            'border': '0px solid #009688',
            'padding': '0px 0px 0px 0px',
            'background-color': '#fff',
            'margin': '0'
        });
        $('.w3-btn').css({
            'margin': '2px 2px 2px 2px;'
        });
    }
    else if ($(window).width() < 325) {
        $('#mobileCategoriesMenuButton').show();
        $('#mobileCategoriesMenu').addClass('collapse');
        $('#mobileCategoriesMenu').css({
            'border': '1px solid #009688',
            'padding': '5px 9px 5px 4px',
            'background-color': '#f2f2f2',
            'margin': '0'
        });
        $('.w3-btn').css({
            'margin': '2px 0px 2px 0px;'
        });
    }
});