$('document').ready(() => {

        $.ajax({
            type: "POST",
            url: "/Lesmateriaal/ThemaView",
            data: {
                GraadId: $('#GraadIdGebruiker').get(0).textContent
            },
        success: (r) => {
            $('#thema-nav').html(r);
        },
        complete: () => {
            $.ajax({
                type: "POST",
                url: "/Lesmateriaal/LesmateriaalViewHead",
                data: {
                    GraadId: $('.geselecteerdeKyu').get(0).id,
                    ThemaNaam: $('.geselecteerdThema').get(0).innerHTML
                },
                success: (r) => {
                    $('#lesmateriaalHead').html(r);
                },
                complete: () => {
                    $.ajax({
                        type: "POST",
                        url: "Lesmateriaal/LesmateriaalView",
                        data: {
                            Username: $('#HuidigeGebruiker').get(0).textContent,
                            ThemaNaam: $('.geselecteerdThema').get(0).textContent,
                            GraadId: $('.geselecteerdeKyu').get(0).id,
                            LesmateriaalId: $('.dropdown-item').get(0).id
                        },
                        success: (response) => {
                            $('#lesmateriaal').html(response);
                        }
                    });
                }
            });
        }                
                });

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

function laadLesmateriaal(e) {

    $.ajax({
        type: "POST",
        url: "Lesmateriaal/LesmateriaalView",
        data: {
            Username: $('#HuidigeGebruiker').get(0).textContent,
            ThemaNaam: $('.geselecteerdThema').get(0).textContent,
            GraadId: $('.geselecteerdeKyu').get(0).id,
            LesmateriaalId: e.id
        },
        success: (response) => {
            $('#lesmateriaal').html(response);
        }
    });

}


$('.kyu-nav > ul > li').click((e) => {
    $.get("/Lesmateriaal/ThemaView", { GraadId: e.target.id }, function (response) {
        $("#thema-nav").html(response);
    });
    $('.geselecteerdeKyu').removeClass('geselecteerdeKyu');
    e.target.classList.add('geselecteerdeKyu');
});

function modalLaden(e) {
    $('#afbeeldingModal .modal-body > img').get(0).src = e.src;
    console.log(e.src);
}