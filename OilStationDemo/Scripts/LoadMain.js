//加载主框架
function LoadMain(url) {
    var index = layer.load(3);
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
    layer.close(index);//请求完毕 关闭
}
