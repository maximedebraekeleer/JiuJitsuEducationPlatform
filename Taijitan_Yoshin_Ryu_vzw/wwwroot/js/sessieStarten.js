$(document).ready(() => {
    let leden = document.getElementsByClassName("ledenlijstLid");

    for (let i = 0; i < leden.length; i++) {
        leden[i].addEventListener('click', (e) => {
            if (e.target.classList.contains('aanwezig')) {
                e.target.classList.remove('aanwezig');
            } else
                e.target.classList.add('aanwezig');
        });
    }

});
