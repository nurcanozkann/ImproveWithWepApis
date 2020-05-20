


function Veriler() {
    var url = '/Pharmacy/Index',
        $('table').html();
    var thead = '<thead><tr><td>Name</td><td>Phone</td><td>Dist</td><td>Address</td></tr></thead>';
    $('table').append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].Name + '</td><td>' + data.Result[item].Phone + '</td><td>' + data.Result[item].Dist + '</td><td>' + data.Result[item].Address + '</td></tbody>'
            $('table').append(deger);
        }
    });
}