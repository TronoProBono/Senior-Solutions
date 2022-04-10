$(document).ready(function () {
    window.onload = function ()
    {
        //$("div").append("<p>Test</p>");
        $("#gen_key").on('click', function () {
            $("#key").val(getkey("Resident"));
        });
    }
    function getkey(role)
    {
        var F_name = $("#f_name").val();
        var L_name = $("#l_name").val();
        console.log("First Name:", F_name);
        console.log("Last Name:", L_name);
        var now = new Date();
        var first = "";
        var last = "";
        var date_year = (String)(now.getFullYear());
        var int_date_day = (now.getMonth()+1);
        var date_day = ""
        if(int_date_day < 10)
        {
            date_day += "0";
        }
        date_day += int_date_day

        var gened = "";
        var remain_1 = 3;
        var remain_2 = 3;
        for(var i = 0; i < 3 && i < F_name.length; i++)
        {
            first += F_name[i]
            remain_1--;
        }
        remain_2 += remain_1;
        for(var i = 0; i < 3 + remain_1 && i < L_name.length; i++)
        {
            last += L_name[i]
            remain_2--;
        }

        for(var i = 0; i < 6 + remain_2; i++)
        {
            var it = Math.floor(Math.random() * 26) + 65;
            gened += String.fromCharCode(it);
        }
        $("#key").append("<p>Test</p>");
        var result = role[0].toUpperCase() + role[1].toUpperCase() + date_day + first.toUpperCase() + date_year + last.toUpperCase() + gened;
        //var password_input = document.getElementById("key");
        //password_input.value = result;
        return result;
    };

    $(document).on('click', '#man_add_club', function (e) {
        $.ajax({
            url: '/Manager/CheckClub',
            success: function (partialView) {
                $('.club-input').append(partialView);
            }
        });
    });

    $(document).on('click', '#man_remove_club', function (e) {
        $(this).parent().remove();
    });

    
    $(document).on('click', '#man_search_club', function (e) {
        var ClubID = parseInt($(this).parent().children('#input_club_number').val())
        var current = $(this).parent();
        //console.log(ClubID);
        $.ajax({
            url: '/Manager/PopulateRoles?ClubID=' + ClubID,
            success: function (partialView) {
                current.remove();
                $('.club-input').append(partialView);
            }
        });
    });

});