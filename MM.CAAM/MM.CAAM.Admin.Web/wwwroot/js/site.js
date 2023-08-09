// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var spinnerVisible = false;

function showProgress() { 
    if (!spinnerVisible) {
        $("#transparencia").fadeIn("fast");
        $("#panel_loading").fadeIn("fast");
        spinnerVisible = true;
    }
};

function hideProgress() { 
    if (spinnerVisible) {
        $("#transparencia").fadeOut("fast");
        var spinner = $("#panel_loading");
        spinner.stop();
        spinner.fadeOut("fast");
        spinnerVisible = false;
    }
};