$('document').ready(function () {
    $('#files').click(function () {
        var div = document.getElementById("filePreview");
        $('#files').val('');
        while (div.hasChildNodes())
            div.removeChild(div.lastChild);
    });
    $('#files').change(function () {
        var div = document.getElementById("filePreview");
        var input = document.getElementById('files');
        if (input.files && input.files[0]) {
            for (var i = 0; i < input.files.length; i++) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var max_width = 150;
                    var g = document.createElement('img');
                    g.setAttribute('src', e.target.result);
                    var width = g.width;
                    var height = g.height;
                    var factor = width / max_width;
                    var tmp_height = height / factor;
                    g.width = max_width;
                    g.height = tmp_height;
                    div.appendChild(g);
                }
                reader.readAsDataURL(input.files[i]);
            }
        }
    });
    $('#subm').click(function () {
        var input = document.getElementById('files');
        var files = input.files;
        for (var i = 0; i < files; i++) {

        }
    });
    ymaps.ready(init);
    var myMap,
        myPlacemark;


    function init() {
        myMap = new ymaps.Map("map", {
            center: [55.76, 37.64],
            zoom: 7
        });
        // Создание элемента управления «Поиск по карте».
        var searchControl = new ymaps.control.SearchControl({
            options: {
                // Будет производиться поиск и по топонимам и по организациям.
                provider: 'yandex#search'
            }
        });
        myMap.events.add('click', function (e) {
            $('#hiddenGeoLat').val("");
            $('#hiddenGeoLong').val("");
            $('#hiddenAddress').val("");
            myMap.geoObjects.removeAll();
            // Получение координат щелчка
            var coords = e.get('coords');
            var placemark = new ymaps.Placemark(coords);
            var myGeocoder = ymaps.geocode(coords, { kind: 'house' });
            myGeocoder.then(
                function (res) {
                    var street = res.geoObjects.get(0);
                    var name = street.properties.get('name');
                    // Будет выведено «улица Большая Молчановка»,
                    // несмотря на то, что обратно геокодируются
                    // координаты дома 10 на ул. Новый Арбат.
                    $('#hiddenAddress').val(name);
                    console.log($('#hiddenAddress').val());
                    alert(name);
                }
            );
            myMap.geoObjects.add(placemark);
            $('#hiddenGeoLat').val(coords[0]);
            $('#hiddenGeoLong').val(coords[1]);        
            console.log($('#hiddenGeoLat').val());
            console.log($('#hiddenGeoLong').val());

        });

        // Добавляем элемент управления на карту.
        myMap.controls.add(searchControl);
    }
});
