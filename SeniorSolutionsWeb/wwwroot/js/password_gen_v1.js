$(document).ready(function () {
    let inputed_clubs = [];

    window.onload = function ()
    {
        //$("div").append("<p>Test</p>");
        $("#gen_key").on('click', function () {
            $("#key").val(getkey("Resident"));
        });
    }
    class Tuple {
        constructor(key, perm) {
            this.key = key;
            this.perm = perm;
        }
        getEval(num) {
            var i = 0;
            for (; i < key.length; i++) {
                if (num == key[i]) {
                    console.log("Tuple:", eval[i], "\n");
                    return eval[i];
                }
            }
        }
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
        $('#_advance_club').hide()
        $.ajax({
            url: '/Manager/CheckClub',
            success: function (partialView) {
                $('.club-input').append(partialView);
            },
            error: function () {
                $('#_advance_club').show()
            }
        });
    });

    $(document).on('click', '#man_remove_club', function (e) {
        $(this).parent().remove();
        $('#_advance_club').show()
    });

    $(document).on('click', '#man_remove_club_entry', function (e) {
        var find = $(this).prop("rel")
        console.log(find)
        var filtered = inputed_clubs.filter(ID => ID != find)
        inputed_clubs = filtered
        $(this).parent().parent().remove();
    });

    $(document).on('click', '#club_role_remove', function (e) {
        var topLevel = $(this).parent().parent().parent()
        console.log(topLevel);
        inputed_clubs.pop();
        topLevel.children('#_role_selection').children('#Pain')
        $(this).parent().parent().parent().remove();
        $('#_advance_club').show()
    });

    $(document).on('click', '#club_role_submit', function (e) {
        var topLevel = $(this).parent().parent().parent()
        console.log(topLevel);
        var last_ele = inputed_clubs.pop()
        topLevel.children('.col-6').html("<a class='btn btn-primary mt-2' id='man_remove_club_entry' rel='" + last_ele + "'>Remove Role</a>")
        inputed_clubs.push(last_ele)
        $(this).parent().parent().remove()
        $('#_advance_club').show()
    });
    
    $(document).on('click', '#man_search_club', function (e) {
        var ClubID = parseInt($(this).parent().children('#input_club_number').val())
        console.log(inputed_clubs)
        console.log(ClubID)
        console.log(inputed_clubs.find(element => element == ClubID))
        var current = $(this).parent();
        //console.log(ClubID);
        if (inputed_clubs.find(element => element == ClubID) === undefined)
        {
            $.ajax({
                url: '/Manager/PopulateRoles?ClubID=' + ClubID,
                success: function (partialView) {
                    inputed_clubs.push($("#input_club_number").val())
                    current.remove();
                    $('.club-input').append(partialView);
                }
            });
        }
    });

});