

$(document).ready(function () {
    $("#content div:nth-child(1)").show();
    //$(".ClassAba1").click(function () {
    //    $("#FrameGrade").show();
    //    $(".ClassAba1").addClass("selecionado");
    //    $(".ClassAba2").removeClass("selecionado");
    //});

    //$(".ClassAba2").click(function () {
    //    $("#FrameGrade").hide();
    //    $(".ClassAba2").addClass("selecionado");
    //    $(".ClassAba1").removeClass("selecionado");
    //});
    $("#<%=GridPrincipal.UniqueID%> tr").click(function () {
        $(this).css("background-color", "yellow");
    });
    
    $(".ClassAba1").hover(
        function(){$(this).addClass("ativa1")},
        function(){$(this).removeClass("ativa1")}
    );
    $(".ClassAba2").hover(
        function () { $(this).addClass("ativa2") },
        function () { $(this).removeClass("ativa2") }


);
});