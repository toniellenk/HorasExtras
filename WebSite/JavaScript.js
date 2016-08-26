$(document).ready(function () {
    $("#content div:nth-child(1)").show();
    //$(".abas li:first div").addClass("selected");

    $(".aba1").click(function(){
        $("#FrameGrade").hide();
        $(".aba1").addClass("selecionado");
        $(".aba2").removeClass("selecionado");
    });

    $(".aba2").click(function () {
        $("#FrameGrade").show();
        $(".aba2").addClass("selecionado");
        $(".aba1").removeClass("selecionado");
    });

    $(".aba1").hover(
        function(){$(this).addClass("ativa1")},
        function(){$(this).removeClass("ativa1")}
    );
    $(".aba2").hover(
        function () { $(this).addClass("ativa2") },
        function () { $(this).removeClass("ativa2") }


);
});