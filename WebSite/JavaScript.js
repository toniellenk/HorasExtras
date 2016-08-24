$(document).ready(function () {
    $("#content div:nth-child(1)").show();
    $(".abas li:first div").addClass("selected");

    $(".aba").click(function(){
        $("#FrameGrade").hide();
    });

    $(".aba").hover(
        function(){$(this).addClass("ativa")},
        function(){$(this).removeClass("ativa")}
    );
});