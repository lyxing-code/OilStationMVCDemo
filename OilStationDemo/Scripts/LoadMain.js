//加载主框架
function LoadMain(url) {
    var newUrl = "";
    switch (url) {
        case "BasicDataMaintenance/JobManager.aspx":
            newUrl = "/JobManger/Index";
            break;
        default:
            break;
    }
    $("#mainContent").attr("src", newUrl);
}
