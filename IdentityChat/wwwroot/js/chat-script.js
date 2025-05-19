$(function () {
    // Mesaj kutusunu sayfa y�klendi�inde en alta kayd�r
    var container = $(".chatContainerScroll");
    if (container.length) {
        container.scrollTop(container[0].scrollHeight);
    }

    // Kullan�c� arama filtresi (garantili s�r�m)
    $(document).on("input", "#searchText", function () {
        var keyword = $(this).val().toLowerCase().trim();
        $(".user-item").each(function () {
            var username = $(this).find(".name-meta").text().toLowerCase();
            $(this).toggle(username.includes(keyword));
        });
    });

    // (Opsiyonel) panel a�/kapat �rnekleri
    $(".heading-compose").click(function () {
        $(".side-two").css("left", "0");
    });

    $(".newmessage-back").click(function () {
        $(".side-two").css("left", "-100%");
    });
});
