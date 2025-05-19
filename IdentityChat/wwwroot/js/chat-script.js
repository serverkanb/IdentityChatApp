$(function () {
    // Mesaj kutusunu sayfa yüklendiðinde en alta kaydýr
    var container = $(".chatContainerScroll");
    if (container.length) {
        container.scrollTop(container[0].scrollHeight);
    }

    // Kullanýcý arama filtresi (garantili sürüm)
    $(document).on("input", "#searchText", function () {
        var keyword = $(this).val().toLowerCase().trim();
        $(".user-item").each(function () {
            var username = $(this).find(".name-meta").text().toLowerCase();
            $(this).toggle(username.includes(keyword));
        });
    });

    // (Opsiyonel) panel aç/kapat örnekleri
    $(".heading-compose").click(function () {
        $(".side-two").css("left", "0");
    });

    $(".newmessage-back").click(function () {
        $(".side-two").css("left", "-100%");
    });
});
