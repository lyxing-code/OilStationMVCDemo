//关闭弹出层
function CloseLayerWindown()
{
    //关闭弹出层
    //parent.window.location.reload();
    var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
    parent.layer.close(index);
}