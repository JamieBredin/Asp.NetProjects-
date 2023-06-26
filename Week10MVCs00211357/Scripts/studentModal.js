$(function () {
    $("a[data-modal]").on("click", function () {
        $("#studentCreateModalContent").load(this.href, function () {
            $("#studentCreateModal").modal({
                keyboard: true
            }, "show");

        });
        return false; // As we do not want the event to fire on the form that calls it. Just one of the JS things!!
    });

});