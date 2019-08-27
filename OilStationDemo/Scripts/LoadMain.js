//加载主框架
function LoadMain(url) {
    var newUrl = "";
    switch (url) {
        case "BasicDataMaintenance/JobManager.aspx":
            newUrl = "/JobManger/Index";
            break;
        case "BasicDataMaintenance/OrganizationStructureManger.aspx":
            newUrl = "/OrganizationManger/Index";
            break;
        default:
            break;
    }
    alert(url);
    $("#mainContent").attr("src", newUrl);
}
