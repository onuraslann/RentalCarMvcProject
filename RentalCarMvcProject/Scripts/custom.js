
$(function () {
    $("#tblBrand").DataTable()
    $("#tblBrand").on("click", ".btnBrandDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Brand/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {
    $("#tblCar").DataTable()
    $("#tblCar").on("click", ".btnCarDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Car/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {
    $("#tblCarImage").DataTable()
    $("#tblCarImage").on("click", ".btnCarImageDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/CarImage/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {
    $("#tblColor").DataTable()
    $("#tblColor").on("click", ".btnColorDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Color/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {
    $("#tblCustomer").DataTable()
    $("#tblCustomer").on("click", ".btnCustomerDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Customer/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});