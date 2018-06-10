function cargarFotos() {
    var idAlbum = $("#cmbAlbum").val();
    if (!idAlbum) {
        alert("Seleccione un ALbum");
        return;
    }
     
    $.get("/Home/ObtenerFotos/", { idAlbum: idAlbum }, function (resultado) {
        var html = ""
        for (var indice = 0; indice < resultado.length; indice++) {
            html += "<tr>"
            html += "<td>"
            html += indice + 1;
            html += "</td>"
            html += "<td>"
            html += resultado[indice].title
            html += "</td>"
            html += "<td>"
            html += "<img heigth='20px' width='20px' src='" + resultado[indice].thumbnailUrl + "'/>";
            html += "</td>"
            html += "<td style='cursor:point' onclick='cargarComentario(" + resultado[indice].id + ")'>"
            html += "Ver comentario"
            html += "</td>"
            html += "<td>"
            html += "</td>"
            html += "</tr>"
        }
        $("#ContenidoAlbum").html(html);
    });

}

function cargarComentario(idFoto) {
    $.get("/Home/ObtenerComentario/", { idFoto: idFoto }, function (resultado) {
        var html = ""
        for (var indice = 0; indice < resultado.length; indice++) {
            html += "<tr>"
            html += "<td>"
            html += indice + 1;
            html += "</td>"
            html += "<td>"
            html += resultado[indice].name
            html += "</td>"
            html += "<td>"
            html += resultado[indice].email
            html += "</td>"
            html += "<td>"
            html += resultado[indice].body
            html += "</td>"

            html += "</tr>"
        }
        $("#ContenidoComentario").html(html);
    });
}
function limpiar()
{
    $("#ContenidoComentario").html("");
    $("#ContenidoAlbum").html("");
}