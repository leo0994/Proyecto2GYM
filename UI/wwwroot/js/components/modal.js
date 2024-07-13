function createModal(HTML_dynamic) {
    let modalHtml = `
            <div data-modal-gym class="modal">
                <div class="modal-content">
                    <span class="close">&times;</span>
                    <div class="content-modal">${HTML_dynamic}</div>
                </div>
            </div>
        `;
    $('body').append(modalHtml);

    $(".close").click(function () {
        $("[data-modal-gym]").fadeOut(function () {
            $(this).remove();
        });
    });

    $(window).click(function (event) {
        if ($(event.target).is("[data-modal-gym]")) {
            $("[data-modal-gym]").fadeOut(function () {
                $(this).remove();
            });
        }
    });
    $("[data-modal-gym]").fadeIn();
}

export default createModal;