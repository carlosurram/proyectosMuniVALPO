function noforwardbutton() {

    window.location.hash = "no-forward-button";


    window.location.hash = "Again-No-forward-button" //chrome

    window.onhashchange = function () { window.location.hash = "no-forward-button"; }

}