$(document).ready(function () {

    $("#id_comum").hide();
    $("#id_commum_list").hide();
    $("#id_commum_list_loop").hide();

});



function chamarjs() {
    var itemSelecionado = $("#id_tipo_pessoa option:selected");
    var itemAtribuido = itemSelecionado.val();

    //id = a 4 é pf
    if (itemAtribuido == 4) {

        $("#id_comum").show("slow");
        $("#id_pj").hide("slow");
        $("#id_pf").show("slow");
        //alert("pessoa fisica");


    } else if (itemAtribuido == 5) {
        //id = a 5 é pj

        //alert("pessoa juridica");
        $("#id_comum").show("slow");
        $("#id_pj").show("slow");
        $("#id_pf").hide("slow");
    }
    else {
        $("#id_comum").hide("slow");
        $("#id_pj").hide("slow");
        $("#id_pf").hide("slow");
        alert("selecione um tipo de pessoa");
    }
}

function chamarBancos(){
    var itemSelecionado = $("#id_bancos option:selected");
    var itemAtribuido = itemSelecionado.val();

    if (itemAtribuido == 1)
    {
        alert("Escolha um Banco");
    } else if (itemAtribuido == 2)
    {
        alert("Banco Itaú S.A.");
    } else if (itemAtribuido == 3) {
        alert("Banco Santander (Brasil) S.A.");
    } else if (itemAtribuido == 4) {
        alert("Banco Real S.A. (antigo)");
    } else if (itemAtribuido == 5) {
        alert("Itaú Unibanco Holding S.A.");
    } else if (itemAtribuido == 6) {
        alert("Banco Bradesco S.A.");
    } else if (itemAtribuido == 7) {
        alert("Banco Citibank S.A.");
    } else if (itemAtribuido == 8) {
        alert("HSBC Bank Brasil S.A. – Banco Múltiplo");
    } else if (itemAtribuido == 9) {
        alert("Caixa Econômica Federal");
    } else if (itemAtribuido == 10) {
        alert("Banco Mercantil do Brasil S.A.");
    } else if (itemAtribuido == 11) {
        alert("Banco Rural S.A.");
    } else if (itemAtribuido == 12) {
        alert("Banco Safra S.A.");
    } else if (itemAtribuido == 13) {
        alert("Banco Rendimento S.A.");
    } else if (itemAtribuido == 14) {
        alert("Banco do Brasil S.A.");
    }else {
        alert("Escolha um Banco.");
    }
      


}

function aparecerLogo() {

    $("#imgLogo").show();
    window.print();
    $("#imgLogo").hide();
    $("#btnImpimir").show();

}

function esconder() {
    
    $("#imgLogo").hide();

}