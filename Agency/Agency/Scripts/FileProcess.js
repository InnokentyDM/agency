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
            for (var i = 0; i < input.files.length; i++)
            {
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
        for (var i = 0; i < files; i++)
        {

        }
    });
});