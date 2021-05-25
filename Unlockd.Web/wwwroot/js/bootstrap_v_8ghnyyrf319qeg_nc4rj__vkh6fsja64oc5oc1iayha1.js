
function checkIMEI(n) {
    var i, r, u, t;
    $.isNumeric(n) ? (u = $.makeArray(n), isIMEI(n) ? (i = "Valid IMEI", r = "valid", t = $("#request"), t.removeData("validator").removeData("unobtrusiveValidation"), $.validator.unobtrusive.parse(t), t.valid() ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")) : (i = "Invalid IMEI", r = "invalid", $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")), $(".message").animate({
        opacity: 1,
        top: "-15px"
    }), $(".message").removeClass("valid").removeClass("invalid").addClass(r).empty().append(i)) : $(this).val("")
}

function isIMEI(n) {
    if (!/^[0-9]{15}$/.test(n)) return !1;
    for (sum = 0, mul = 2, l = 14, i = 0; i < l; i++) digit = n.substring(l - i - 1, l - i), tp = parseInt(digit, 10) * mul, sum += tp >= 10 ? tp % 10 + 1 : tp, mul == 1 ? mul++ : mul--;
    return (chk = (10 - sum % 10) % 10, chk != parseInt(n.substring(14, 15), 10)) ? !1 : !0
}

function update() {
    var n = new Date,
        t = n.getHours() == 0 ? 12 : n.getHours() > 12 ? n.getHours() - 12 : n.getHours(),
        i = n.getMinutes() < 10 ? "0" + n.getMinutes() : n.getMinutes();
    $("#hours").text(t);
    $("#minutes").text(i)
}

function requestForm(n, t, i, r, u, f, e) {
    $.ajax({
        url: "/",
        type: "GET",
        data: {
            type: n,
            country: t
        }
    }).done(function(t) {
        $("#requestform").replaceWith(t);
        $("#devices").length > 0 && $("#devices").css({
            top: "44px"
        });
        // $("body").css({
        //     filter: "blur(5px)",
        //     opacity: "0.7"
        // });
        $('.dropdown-toggle[data-value="Model"] ~ .dropdown-menu .slimscroll').each(function() {
            $(this).slimScroll({
                height: "376px",
                railVisible: !0,
                alwaysVisible: !0
            })
        });
        $('.dropdown-toggle[data-value="Network"] ~ .dropdown-menu .slimscroll').each(function() {
            $(this).slimScroll({
                height: "326px",
                railVisible: !0,
                alwaysVisible: !0
            })
        });
        typeof i != "undefined" && ($('select[data-target="#ModelId"]').css("display") != "block" ? $('button[data-value="Model"] ~ .dropdown-menu ul li a').each(function() {
            $.trim($(this).text()) == $.trim(r) && $('button[data-value="Model"] span').empty().append($(this).text())
        }) : ($('select[data-target="#ModelId"] option[value="' + i + '"]').prop("selected", !0), i != 0 && $('select[data-target="#ModelId"]').css({
            "background-image": "url(/images/select-check.png)"
        })), $("#ModelId").val(i));
        typeof u != "undefined" && ($('select[data-target="#NetworkId"]').css("display") != "block" ? $('button[data-value="Network"] ~ .dropdown-menu ul li a').each(function() {
            $.trim($(this).text()) == $.trim(f) && $('button[data-value="Network"] span').empty().append($(this).text())
        }) : ($('select[data-target="#NetworkId"] option[value="' + u + '"]').prop("selected", !0), $('select[data-target="#NetworkId"]').css({
            "background-image": "url(/images/select-check.png)"
        })), $("#NetworkId").val(u));
        (e != null || e != undefined) && $("input#IMEI").val(e);
        $(".navbar-toggle").css("display") == "block" ? ($("body").css({
            position: "relative",
            "overflow-x": "hidden",
            height: $(".phone-ui").outerHeight() + "px"
        }), $("#requestform .phone-ui").animate({
            top: 44
        }, 600)) : $("#requestform .phone-ui").animate({
            bottom: "50%"
        }, 600);
        Track(n + " Clicked")
    })
}

function Track(n) {
    $.ajax({
        url: "/Home/TrackData",
        type: "GET",
        data: {
            recorded: n
        }
    })
}

// function salesPromo() {
//     var n = $("#SalesPromo").attr("data-network"),
//         t = $("#SalesPromo").attr("data-model");
//     $.ajax({
//         url: "/Home/SalesPromo",
//         type: "GET",
//         data: {
//             networkid: n,
//             modelid: t
//         }
//     }).done(function(n) {
//         $(".sales").empty().append(n)
//     })
// }

function getCookie(n) {
    var i = document.cookie,
        u = n + "=",
        t = i.indexOf("; " + u),
        r;
    if (t == -1) {
        if (t = i.indexOf(u), t != 0) return null
    } else t += 2, r = document.cookie.indexOf(";", t), r == -1 && (r = i.length);
    return decodeURI(i.substring(t + u.length, r))
}
if ("undefined" == typeof jQuery) throw new Error("Bootstrap's JavaScript requires jQuery"); + function(n) {
    "use strict";
    var t = n.fn.jquery.split(" ")[0].split(".");
    if (t[0] < 2 && t[1] < 9 || 1 == t[0] && 9 == t[1] && t[2] < 1 || t[0] > 3) throw new Error("Bootstrap's JavaScript requires jQuery version 1.9.1 or higher, but lower than version 4");
}(jQuery); + function(n) {
    "use strict";

    function t() {
        var i = document.createElement("bootstrap"),
            t = {
                WebkitTransition: "webkitTransitionEnd",
                MozTransition: "transitionend",
                OTransition: "oTransitionEnd otransitionend",
                transition: "transitionend"
            },
            n;
        for (n in t)
            if (void 0 !== i.style[n]) return {
                end: t[n]
            };
        return !1
    }
    n.fn.emulateTransitionEnd = function(t) {
        var i = !1,
            u = this,
            r;
        n(this).one("bsTransitionEnd", function() {
            i = !0
        });
        return r = function() {
            i || n(u).trigger(n.support.transition.end)
        }, setTimeout(r, t), this
    };
    n(function() {
        n.support.transition = t();
        n.support.transition && (n.event.special.bsTransitionEnd = {
            bindType: n.support.transition.end,
            delegateType: n.support.transition.end,
            handle: function(t) {
                if (n(t.target).is(this)) return t.handleObj.handler.apply(this, arguments)
            }
        })
    })
}(jQuery); + function(n) {
    "use strict";

    function u(i) {
        return this.each(function() {
            var r = n(this),
                u = r.data("bs.alert");
            u || r.data("bs.alert", u = new t(this));
            "string" == typeof i && u[i].call(r)
        })
    }
    var i = '[data-dismiss="alert"]',
        t = function(t) {
            n(t).on("click", i, this.close)
        },
        r;
    t.VERSION = "3.3.7";
    t.TRANSITION_DURATION = 150;
    t.prototype.close = function(i) {
        function e() {
            r.detach().trigger("closed.bs.alert").remove()
        }
        var f = n(this),
            u = f.attr("data-target"),
            r;
        u || (u = f.attr("href"), u = u && u.replace(/.*(?=#[^\s]*$)/, ""));
        r = n("#" === u ? [] : u);
        i && i.preventDefault();
        r.length || (r = f.closest(".alert"));
        r.trigger(i = n.Event("close.bs.alert"));
        i.isDefaultPrevented() || (r.removeClass("in"), n.support.transition && r.hasClass("fade") ? r.one("bsTransitionEnd", e).emulateTransitionEnd(t.TRANSITION_DURATION) : e())
    };
    r = n.fn.alert;
    n.fn.alert = u;
    n.fn.alert.Constructor = t;
    n.fn.alert.noConflict = function() {
        return n.fn.alert = r, this
    };
    n(document).on("click.bs.alert.data-api", i, t.prototype.close)
}
$(document).ready(function() {
        var n, t, i, r, e, o;
        $(this).on("click", 'button[data-value="CountryPopup"]', function() {
            var n = $("#ControllerField").val(),
                t = $("#PageField").val();
            $.ajax({
                type: "GET",
                url: "/Country/GetCountries",
                data: {
                    controllerName: n,
                    page: t
                },
                success: function(n) {
                    $('div[data-target="CountryPopup"] ul').empty();
                    $.each(n, function(n, t) {
                        $('div[data-target="CountryPopup"] ul').append('<li><span class="countryLink"><img src="/Images/flags/' + t.Item2 + '.png" alt=""> ' + t.Item1 + "<\/span><\/li>")
                    })
                }
            })
        });
        n = !1;
        $(this).on("click", "#SelectCountryPopup .invisible-selector", function() {
            if (!n) {
                var t = $("#ControllerField").val(),
                    i = $("#PageField").val(),
                    r = $('select[data-target="#CountryPopupId"] option:first').text();
                $.ajax({
                    type: "GET",
                    url: "/Country/GetCountries",
                    data: {
                        controllerName: t,
                        page: i
                    },
                    success: function(n) {
                        $('select[data-target="#CountryPopupId"]').empty();
                        $.each(n, function(n, t) {
                            var i = "";
                            t.Item1 == r && (i = "selected");
                            $('select[data-target="#CountryPopupId"]').append('<option data-value="' + t.Item1 + '" data-target="" ' + i + ">" + t.Item1 + "<\/option>")
                        })
                    }
                });
                n = !0
            }
        });
        $(this).on("click", "#CountrySelect .dropdown-toggle", function() {
            var n = $("#ControllerField").val(),
                t = $("#PageField").val();
            $.ajax({
                type: "GET",
                url: "/Country/GetCountries",
                data: {
                    controllerName: n,
                    page: t
                },
                success: function(n) {
                    $('div[data-target="GlobalCountry"] ul').empty();
                    $.each(n, function(n, t) {
                        $('div[data-target="GlobalCountry"] ul').append('<li><span class="countryLink" data-value="' + t.Item1 + '" data-target="' + t.Item3 + '"><img src="/Images/loading.gif" height="11" alt="" data-value="/Images/flags/' + t.Item2 + '.png" />' + t.Item1 + "<\/span><\/li>")
                    });
                    $("#CountrySelect ul li img").each(function() {
                        var n = $(this).attr("data-value");
                        $(this).attr("src", n)
                    })
                }
            })
        });
        t = !1;
        $(this).on("click", "#CountrySelect .invisible-selector", function() {
            if (!t) {
                var n = $("#ControllerField").val(),
                    i = $("#PageField").val(),
                    r = $("#CountrySelect select option:first").attr("data-value");
                $.ajax({
                    type: "GET",
                    url: "/Country/GetCountries",
                    data: {
                        controllerName: n,
                        page: i
                    },
                    success: function(n) {
                        $("#CountrySelect select").empty();
                        $.each(n, function(n, t) {
                            var i = "";
                            t.Item1 + " (" + t.Item4 + ")" == r && (i = "selected");
                            $("#CountrySelect select").append('<option data-target="' + t.Item3 + '" data-value="' + t.Item1 + '" ' + i + ">" + t.Item1 + " (" + t.Item4 + ")<\/option>")
                        })
                    }
                });
                t = !0
            }
        });
        if ($('[data-toggle="popover"]').popover(), $("#SalesPromo").length > 0 && (i = $("#SalesPromo").attr("data-refresh"), salesPromo(), setInterval(salesPromo, i)), $(window).scroll(function() {
                var n = $(this).scrollTop();
                $("#background-img.hero-background").css({
                    "background-position": "center top -" + n + "px"
                });
                n > 20 ? $(".navbar-toggle").css("display") != "block" && $("#hero.beta .arrow").fadeOut("slow") : $(".navbar-toggle").css("display") != "block" && $("#hero.beta .arrow").fadeIn("slow")
            }), r = getCookie("CountryCookie"), $("#CheckLocationField").val() == "true") {
            var u = $("#ControllerField").val(),
                f = $("#PageField").val(),
                s = $("#ISOField").val();
            r == null ? $.ajax({
                url: "/Country/CountrySelectPopup",
                type: "GET",
                
                data: {
                    controllerName: u,
                    page: f,
                    iso: s
                }
            }).done(function(n) {
                $.trim(n) && ($(".navbar.navbar-inverse").before(n), $("#CountryPopup").modal("show"))
            }) : $.ajax({
                url: "/Country/CountryRedirect",
                type: "GET",
                data: {
                    controllerName: u,
                    page: f
                },
                success: function(n) {
                    n != "" && (window.location.href = n)
                }
            })
        }
        $(this).on("click", "#CountrySelect .countryLink, #SubmitCountry, #CountryPopup .fa-close", function() {
            var t = $(this).attr("data-value"),
                n = $(this).attr("href");
            return n == null && (n = $(this).attr("data-target")), $.ajax({
                url: "/Home/CountrySelect",
                type: "POST",
                data: {
                    countryname: t
                },
                success: function() {
                    n == undefined && (window.location = window.location);
                    window.location = n.includes("?") ? window.location + n.toLocaleLowerCase() : n
                }
            }), !1
        });
        $(this).on("click", "#CountryPopup ul li .countryLink", function() {
            var n = $(this).text();
            $('button[data-value="CountryPopup"] span').html($(this).html());
            $("#SubmitCountry").attr("data-value", n.trim())
        });
        $(this).on("change", '[data-target="#CountryPopupId"]', function() {
            var n = $(this).find(":selected").attr("data-value");
            $("#SubmitCountry").attr("href", n.trim())
        });
        $(this).on("change", "#CountrySelect select", function() {
            var t = $(this).find(":selected").attr("data-value"),
                n = $(this).find(":selected").attr("data-target");
            return $.ajax({
                url: "/Home/CountrySelect",
                type: "POST",
                data: {
                    countryname: t
                },
                success: function() {
                    window.location = n.includes("?") ? window.location + n : n
                }
            }), !1
        });
        // $(this).on("hide.bs.modal", function() {
        //     $("body").css({
        //         filter: "blur(0)",
        //         opacity: "1",
        //         height: "auto"
        //     })
        // });
        $(this).on("click", "#hero .arrow, #hero .arrow a", function() {
            return $("html, body").animate({
                scrollTop: $("#steps").offset().top
            }, 600), !1
        });
        $("#devices").affix({
            offset: {
                top: 44
            }
        });
        e = window.location.href.replace("http://", "");
        o = e.split("/");
        $(".navbar-nav > li").each(function() {
            $(this).find("a").attr("title").toLocaleLowerCase() == o[1].toLocaleLowerCase() && $(this).addClass("active")
        });
        $(".page-nav").length > 0 && $(".page-nav").affix({
            offset: {
                top: 1
            }
        });
        $("#footer").waypoint(function() {
            $("#footer img").each(function() {
                var n = $(this).attr("data-target");
                $(this).attr("src", n)
            })
        }, {
            offset: "45%"
        });
        $("#networksCarousel").waypoint(function() {
            $("#networksCarousel img").each(function() {
                var n = $(this).attr("data-target");
                $(this).attr("src", n)
            })
        }, {
            offset: "45%"
        });
        $("#deviceIndex").waypoint(function() {
            $("#deviceIndex img").each(function() {
                var n = $(this).attr("data-target");
                $(this).attr("src", n)
            })
        }, {
            offset: "45%"
        });
        $("#Tracking, #Times").waypoint(function(n) {
            n == "down" ? $("#" + this.element.id).addClass("in-view") : $("#" + this.element.id).removeClass("in-view")
        }, {
            offset: "45%"
        });
        $(this).on("click", ".navbar-toggle", function() {
            $(this).find(".fa").hasClass("fa-bars") ? ($(this).find(".fa").removeClass("fa-bars").addClass("fa-times"), $(".navbar-inverse").css({
                "background-color": "rgba(0,0,0,1)"
            }), $(".navbar-inverse .navbar-collapse").stop().animate({
                height: "100vh",
                opacity: 1
            }), $(".navbar-inverse .navbar-nav > li").each(function(n) {
                var t = 100 * parseInt(n);
                $(this).delay(t).animate({
                    marginLeft: 0,
                    opacity: 1
                })
            })) : ($(this).find(".fa").removeClass("fa-times").addClass("fa-bars"), $(".navbar-inverse .navbar-nav > li").each(function(n) {
                var t = 100 * parseInt(n);
                $(this).delay(t).animate({
                    marginLeft: "-10%",
                    opacity: 0
                })
            }), $(".navbar-inverse .navbar-collapse").stop().animate({
                height: 0,
                opacity: 0
            }), $(".navbar-inverse").css({
                "background-color": "rgba(0,0,0,0.8)"
            }))
        });
        $(this).on("mouseover", "#devices ul li", function() {
            $("#devices ul li").removeClass("active");
            $(this).addClass("active")
        });
        $(this).on("mouseover", ".navbar, #hero", function() {
            $("#devices ul li").removeClass("active")
        });
        $(this).on("click", "footer .col-md-8 li.list-title", function() {
            var n = $(this);
            $(".navbar-toggle").css("display") == "block" && ($("footer .col-md-8 ul.list-unstyled").stop().animate({
                height: "40px"
            }, 300, function() {
                $("footer .col-md-8 li.list-title").removeClass("active")
            }), n.hasClass("active") ? n.parent().stop().animate({
                height: "40px"
            }, 300, function() {
                n.removeClass("active")
            }) : n.parent().stop().animate({
                height: "130px"
            }, 300, function() {
                n.addClass("active")
            }))
        });
        $(this).on("mouseover", '[data-helper="true"]', function() {
            if (!$(this).attr("type")) {
                var n = $('.help-tip[data-value="' + $(this).attr("data-value") + '_Helper"]'),
                    t = $(n).height() / 2 - 10;
                $(n).css({
                    "margin-top": "-" + t + "px"
                });
                $(n).stop().animate({
                    opacity: 1,
                    left: "-310px"
                })
            }
        });
        $(this).on("mouseout", '[data-helper="true"]', function() {
            $(this).attr("type") || $(".help-tip").stop().animate({
                opacity: 0,
                left: "-300px"
            })
        });
        $(this).on("focus", '[data-helper="true"]', function() {
            var n = $('.help-tip[data-value="' + $(this).attr("data-value") + '_Helper"]'),
                t = $(n).height() / 2 - 10;
            $(n).css({
                "margin-top": "-" + t + "px"
            });
            $(".help-tip").stop().animate({
                opacity: 0,
                left: "-300px"
            });
            $(n).stop().animate({
                opacity: 1,
                left: "-310px"
            })
        });
        $(".tracking-update").length > 0 && $(".tracking-update").each(function() {
            var n = $(this).attr("id"),
                t = $(this).attr("data-country");
            ($("#order-" + n).find(".btn-default").length > 0 || $("#order-" + n).find("strong").text().indexOf("Network -")) && $.ajax({
                url: "/Tracking/TrackedStatus",
                type: "GET",
                data: {
                    id: n,
                    CountryName: t
                }
            }).done(function(t) {
                $("#" + n + " .tracking-progress").empty().append(t)
            })
        });
        $(this).on("change", "#LockedMobStatus", function() {
            $(this).is(":checked") ? ($("#LockedMobNum").attr("disabled", "disabled"), $(".lockedInfoText").show()) : ($("#LockedMobNum").removeAttr("disabled"), $(".lockedInfoText").hide())
        });
        $(".dropdown-menu .slimscroll").each(function() {
            $(this).find("li").length > 7 && $(this).slimScroll({
                height: "200px",
                railVisible: !0,
                alwaysVisible: !0
            })
        });
        $(this).on("click", ".phone-ui .dropdown-toggle", function() {
            $(this).parent().append('<a href="#" title="Close" class="close-dropdown"><i class="fa fa-times"><\/i><\/a>');
            $(document).on("hide.bs.dropdown", function() {
                return !1
            })
        });
        $(this).on("click", ".phone-ui .close-dropdown", function() {
            $(".dropdown-backdrop").remove();
            $(".dropdown-toggle ~ .close-dropdown").parent().removeClass("open");
            $(this).remove()
        });
        $(this).on("click", ".ui-select ul li a", function() {
            var t = $(this).attr("data-value"),
                n, i = $(this).html(),
                r = $(this).attr("data-img");
            return n = $(this).closest("ul").parent().hasClass("slimScrollDiv") ? $(this).closest("ul").parent().parent().attr("data-target") : $(this).closest("ul").parent().attr("data-target"), $("#" + n + "Id").length > 0 && ($("#" + n + "Id").val(t), $("#" + n + "Id").valid(), $("#" + n + "Id").trigger("change")), $("#" + n + "ID").length > 0 && ($("#" + n + "ID").val(t), $("#" + n + "ID").valid(), $("#" + n + "ID").trigger("change")), $("#" + n + "Name").length > 0 && ($("#" + n + "Name").val(i), $("#" + n + "Name").valid(), $("#" + n + "Name").trigger("change")), $('button[data-value="' + n + '"] span').empty().append(i), $('button[data-value="' + n + '"] .fa-chevron-right').length > 0 && $('button[data-value="' + n + '"]').find(".fa").removeClass("fa-chevron-right").addClass("fa-check"), $('button[data-value="' + n + '"] img').length > 0 && $('button[data-value="' + n + '"] img').attr("src", r), $(".dropdown-backdrop").remove(), $('button[data-value="' + n + '"]').parent().removeClass("open"), $(".close-dropdown").remove(), !1
        });
        $(this).on("click", 'a[data-target="requestform"]', function() {
            var i = $(this).attr("data-model"),
                r = $(this).attr("data-model-name"),
                u = $(this).attr("data-network"),
                f = $(this).attr("data-network-name"),
                e = $(this).attr("data-imei"),
                n = $(this).attr("data-type"),
                t = $(this).attr("data-country");
            return $.ajax({
                url: "#",
                data: {
                    type: n,
                    country: t
                },
                context: document.body
            }).done(function(o) {
                $("#requestform").length > 0 && $("#requestform").remove();
                $("#google_translate_element").append(o);
                requestForm(n, t, i, r, u, f, e)
            }), !1
        });
        $(this).on("click", "#request .ui-select ul li a", function() {
            var n = $("#request"),
                t = $("#request input#IMEI").val();
            n.valid() && isIMEI(t) ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")
        });
        $(this).on("change", "#request .ui-select select", function() {
            var r = $(this).find(":selected").attr("value"),
                u = $(this).attr("data-target"),
                n, t, i;
            $(u).val(r);
            $(this).find(":selected").hasClass("toggleTab") ? (n = $(this).find(":selected").attr("data-target"), $(".tab-pane").removeClass("active"), $(n).addClass("active"), $("#IMEI").addClass("ignore"), $("#IMEI").val(""), $("#Serial").removeClass("ignore")) : ($(".tab-pane").removeClass("active"), $("#imei.tab-pane").addClass("active"));
            t = $("#request");
            i = $("#request input#IMEI").val();
            t.valid() && isIMEI(i) ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid");
            $(this).css({
                "background-image": "url(/images/select-check.png)"
            })
        });
        $(this).on("click", 'a[href="#serial"]', function() {
            $("#IMEI").addClass("ignore");
            $("#IMEI").val("");
            $("#Serial").removeClass("ignore")
        });
        $(this).on("click", 'a[href="#imei"]', function() {
            $("#IMEI").removeClass("ignore");
            $("#Serial").addClass("ignore");
            $("#Serial").val("")
        });
        $(this).on("click", "#SubmitForm", function(n) {
            n.preventDefault();
            var t = $("#request"),
                i = $("#IMEI").val(),
                r = $("#Serial").val();
            t.removeData("validator").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse(t);
            t.valid() ? i.length == 15 ? isIMEI(i) ? (Track("Valid IMEI - " + i), $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid"), t[0].submit()) : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid") : r != undefined ? (Track("Serial entered - " + r), $(".step").animate({
                opacity: 0
            }, function() {
                $(".preloader").fadeIn()
            }), $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid"), t[0].submit()) : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")
        });
        $(this).on("change", "#request input#IMEI", function() {
            var n = $("#request"),
                t = $(this).val();
            n.valid() && isIMEI(t) ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")
        });
        $(this).on("change", "#request input#Serial", function() {
            var n = $(this).val();
            n.length > 0 ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")
        });
        $(this).on("click", '.button-controls a[data-value="Cancel"]', function() {
            var n = $(this).attr("data-target");
            return $("#devices").length > 0 && $("#devices").css({
                top: "44px;"
            }), $("#devices").css({
                top: "44px;"
            }), 
            // $("body").css({
            //     filter: "blur(0)",
            //     opacity: "1",
            //     height: "100%"
            // }), 
            $(".navbar-toggle").css("display") == "block" ? $(".phone-ui").animate({
                top: "-1000px"
            }, 800) : $(".phone-ui").animate({
                bottom: "-15em"
            }, 800), $('button[data-value="Model"] span').empty().append("Select Model"), $("#ModelId").val(""), $("#NetworkId").val(""), !1
        });
        $(this).on("click", ".numpad li a", function() {
            var t = $(this).attr("data-value"),
                n = $("#IMEI").val();
            switch (t) {
                case "del":
                    $("#IMEI").val(n.slice(0, -1));
                    checkIMEI(n.slice(0, -1));
                    break;
                case "clr":
                    $("#IMEI").val("");
                    checkIMEI(0);
                    break;
                default:
                    $("#IMEI").val().length < 15 ? $("#IMEI").val(n + t) : alert("Your IMEI Number can only be 15 digits long.");
                    checkIMEI(n + t)
            }
            return !1
        });
        $(this).on("change paste keyup mouseup", "#IMEI", function() {
            var n = $(this).val();
            n.length <= 15 ? checkIMEI(n) : ($("#IMEI").val(n.slice(0, -1)), alert("Your IMEI Number can only be 15 digits long."))
        });
        $(this).on("click", ".keypad li a", function() {
            var t = $(this).attr("data-value"),
                n = $("#Serial").val();
            switch (t) {
                case "del":
                    $("#Serial").val(n.slice(0, -1));
                    break;
                case "clr":
                    $("#Serial").val("");
                    $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid");
                    break;
                case "num":
                    $(".keypad").parent().stop().animate({
                        opacity: 0
                    });
                    $(".numpad").parent().stop().animate({
                        opacity: 1
                    });
                    break;
                default:
                    $("#Serial").val(n + t)
            }
            n.length > 1 ? $(".phone-ui .btn-primary").removeClass("btn-invalid").addClass("btn-valid") : $(".phone-ui .btn-primary").removeClass("btn-valid").addClass("btn-invalid")
        });
        $(this).on("click", "body", function() {
            $('a[data-value="Cancel"]').trigger("click")
        });
        $(this).on("click", '.dropdown-menu[data-target="Country"] a', function() {
            var n = $(this).attr("data-content"),
                t = $('.dropdown-toggle[data-value="Model"] span').text();
            return $.ajax({
                url: "/Home/RequestFormV2",
                type: "POST",
                data: {
                    type: "Phone Unlock",
                    country: n,
                    model: $.trim(t.replace(/[\t\n]+/g, " "))
                }
            }).done(function(n) {
                $("#PhoneUnlockForm").empty().append(n);
                $("#PhoneUnlockForm .dropdown-toggle ~ .dropdown-menu .slimscroll").each(function() {
                    $(this).find("li").length > 7 && $(this).slimScroll({
                        height: "200px",
                        railVisible: !0,
                        alwaysVisible: !0
                    })
                })
            }), !1
        })
    })
 


