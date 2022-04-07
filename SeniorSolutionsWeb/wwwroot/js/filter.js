/*$(function(){
    $('#PopulateLocals').select2();
});*/

$(document).ready(function () {
    $('#PopulateLocals').select2({
        selectOnClose: true
    });

    window.onload = function () {
        /*slideOne();
        console.log("Fired S1 | IN\n");
        slideTwo();
        console.log("Fired S2 | IN\n");*/
        slider(sliderOne, _displayValOne, sliderTwo, 1);
        slider(sliderTwo, _displayValTwo, sliderOne, 2);
        slider(sliderThree, _displayValThree, sliderFour, 3);
        slider(sliderFour, _displayValFour, sliderThree, 4);
        $('#slider-1').on('input', function () {
            console.log("Fired S1\n");
            slider(sliderOne, _displayValOne, sliderTwo, 1);
        });
        $('#slider-2').on('input', function () {
            console.log("Fired S2\n");
            slider(sliderTwo, _displayValTwo, sliderOne, 2);
        });
        $('#slider-3').on('input', function () {
            console.log("Fired S3\n");
            slider(sliderThree, _displayValThree, sliderFour, 3);
        });
        $('#slider-4').on('input', function () {
            console.log("Fired S4\n");
            slider(sliderFour, _displayValFour, sliderThree,4);
        });
    }

    //slideOne();
    //slideTwo();

    let sliderOne = document.getElementById("slider-1");
    let sliderTwo = document.getElementById("slider-2");
    let sliderThree = document.getElementById("slider-3");
    let sliderFour = document.getElementById("slider-4");

    let _displayValOne = document.getElementById("start_top");
    let _displayValTwo = document.getElementById("start_bottom");
    let _displayValThree = document.getElementById("end_top");
    let _displayValFour = document.getElementById("end_bottom");

    let minGap = 4;
    let sliderTrackA = document.querySelector("#track-A");
    let sliderTrackB = document.querySelector("#track-B");
    let sliderMaxValue = document.getElementById("slider-1").max;

    function slider(control, control_assist, depend, core) {
        //Core Should be set to 1 when refering (currently control) to the range on the left side
        if (parseInt(core) % 2 !== 0) {
            console.error("Left | Fired & core:", (core))
            if (parseInt(depend.value) - parseInt(control.value) <= minGap) {
                control.value = parseInt(depend.value) - minGap;
            }
        }
        else {
            if (parseInt(control.value) - parseInt(depend.value) <= minGap) {
                control.value = parseInt(depend.value) + minGap;
            }
        }
        for (i = 0; i < 4; i++) {
            var intro = AdditionByFour_15Min(i + 1, control.value, i + 93, 0, i * 15)
            if (intro !== "0") {
                time = intro;
                control_assist.value = time;
                break;
            }
        }
        if (parseInt(core) < 3) {
            if (parseInt(core) % 2 === 0) {
                _fillColor(depend, control, sliderTrackA);
            }
            else {
                _fillColor(control, depend, sliderTrackA);
            }
        }
        else {
            if (parseInt(core) % 2 === 0) {
                _fillColor(depend, control, sliderTrackB);
            }
            else {
                _fillColor(control, depend, sliderTrackB);
            }
        }
    }

    function _fillColor(left,right, slide) {
        percent1 = (left.value / sliderMaxValue) * 100;
        percent2 = (right.value / sliderMaxValue) * 100;
        console.error("Left:", left.value, " | ","Right:",right.value)
        console.error("Left [p]:", percent1, " | ", "Right [p]:", percent2)
        slide.style.background = `linear-gradient(to right, #dadae5 ${percent1}% , #3264fe ${percent1}% , #3264fe ${percent2}%, #dadae5 ${percent2}%)`;
    }


    function slideOne() {
        if (parseInt(sliderTwo.value) - parseInt(sliderOne.value) <= minGap) {
            sliderOne.value = parseInt(sliderTwo.value) - minGap;
        }
        //displayValOne.textContent = sliderOne.value;
        for (i = 0; i < 4; i++) {
            var intro = AdditionByFour_15Min(i + 1, sliderOne.value, i + 93, 0, i * 15)
            if (intro !== "0") {
                time = intro;
                //displayValOne.textContent = time;
                _displayValOne.value = time;
                break;
            }
        }
        fillColor();
    }
    function slideTwo() {
        if (parseInt(sliderTwo.value) - parseInt(sliderOne.value) <= minGap) {
            sliderTwo.value = parseInt(sliderOne.value) + minGap;
        }
        //displayValTwo.textContent = sliderTwo.value;
        var time = "";
        for (i = 0; i < 4; i++) {
            var intro = AdditionByFour_15Min(i + 1, sliderTwo.value, i + 93, 0, i * 15)
            if (intro !== "0") {
                time = intro;
                //displayValTwo.textContent = time;
                _displayValTwo.value = time;
                break;
            }
        }
        fillColor();
    }
    function fillColor() {
        percent1 = (sliderOne.value / sliderMaxValue) * 100;
        percent2 = (sliderTwo.value / sliderMaxValue) * 100;
        sliderTrack.style.background = `linear-gradient(to right, #dadae5 ${percent1}% , #3264fe ${percent1}% , #3264fe ${percent2}%, #dadae5 ${percent2}%)`;
    }

    function AdditionByFour_15Min(Initial, Current, Max, Iteration, Min) {
        if (Current == Initial) {
            console.log("Initial:" + Initial)
            console.log("Current:" + Current)
            console.log("Max:" + Max)
            console.log("Iteration:" + Iteration)
            console.log("Min:" + Min)
            var AMPM = "AM"
            if (Current > 48) {
                AMPM = "PM"
            }
            var hour = Iteration;
            if (Iteration > 13) {
                hour = hour - 12;
            }
            switch (Iteration) {
                case 0:
                    hour = 12;
                    break;
                default:
                    break;
            }
            if (Min == 0) {
                Min = "00"
            }
            return hour + ":" + Min + " " + AMPM
        }
        else if (Initial + 4 <= Max) {
            var result = AdditionByFour_15Min(Initial + 4, Current, Max, Iteration + 1, Min)
            if (result != "0") {
                return result;
            }
        }
        return "0"
    }
});