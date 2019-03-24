$('document').ready(() => {

$('#thema-nav').on('click', (e) => {
    if (!e.target.classList.contains('geselecteerdThema')) {

        $.ajax({
            type: "POST",
            url: "/Lesmateriaal/LesmateriaalViewHead",
            data: {
                GraadId: $('.geselecteerdeKyu').get(0).id,
                ThemaNaam: e.target.innerHTML
            },
            success: (r) => {
                $('#lesmateriaalHead').html(r);
            }
        });

        $('.geselecteerdThema').removeClass('geselecteerdThema');
        e.target.classList.add('geselecteerdThema');
    }
});
            });



$('.kyu-nav > ul > li').click((e) => {
    $.get("/Lesmateriaal/ThemaView", { GraadId: e.target.id }, function (response) {
        $("#thema-nav").html(response);
    });
    $('.geselecteerdeKyu').removeClass('geselecteerdeKyu');
    e.target.classList.add('geselecteerdeKyu');
});

