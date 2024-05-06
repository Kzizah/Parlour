// JavaScript source code
$(document).ready(function () {
    $("#btnLoadReport").click(function ())
    ReportManager.LoadReport();

});
var ReportManager = {
    LoadReport: function () {
        var jsonParam = "";
        var serviceUrl = "../Customer/GenerateCustomerReport";
        ReportManager.GetReport(serviceUrl, jsonParam, onFailed);

        function onFailed(error) {
            alert("Found Error");
        }



    },
    GetReport: function (serviceUrl, jsonParam, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            contenttype: "appliation/json; charset=utf-8",
            success: function () {
                window.open('../Report/ReportViewer.aspx', '_newtab');
            },
            error: errorCallback
        })
    }

}