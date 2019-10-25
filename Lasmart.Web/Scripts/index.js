import $ from 'jquery';
window.jQuery = $; window.$ = $;



import "@progress/kendo-ui";
import "@progress/kendo-ui/js/kendo.aspnetmvc";
import "@progress/kendo-theme-default/dist/all.css";
import 'konva';

debugger;


window.gridDataBound = function (e) {
    createScene();
}

var createScene = function () {
    var width = window.innerWidth;
    var height = window.innerHeight/2;

    var stage = new Konva.Stage({
        container: 'container',
        width: width,
        height: height
    });

    var layer = new Konva.Layer();

    var rect1 = new Konva.Rect({
        x: 20,
        y: 20,
        width: 100,
        height: 50,
        fill: 'green',
        stroke: 'black',
        strokeWidth: 4
    });
    // add the shape to the layer
    layer.add(rect1);

    var rect2 = new Konva.Rect({
        x: 150,
        y: 40,
        width: 100,
        height: 50,
        fill: 'red',
        shadowBlur: 10,
        cornerRadius: 10
    });
    layer.add(rect2);

    var rect3 = new Konva.Rect({
        x: 50,
        y: 120,
        width: 100,
        height: 100,
        fill: 'blue',
        cornerRadius: [0, 10, 20, 30]
    });
    layer.add(rect3);


    stage.add(layer);

    var itemURL = '';
    var images = document.getElementsByClassName('drag-image');
    for (var i = 0, len = images.length; i < len; i++) {
        var image = images[i];
        image
            .addEventListener('dragstart', function (e) {
                itemURL = e.target.src;
            });
    
}
    

    var con = stage.container();
    con.addEventListener('dragover', function (e) {
        e.preventDefault(); 
    });

    con.addEventListener('drop', function (e) {
        e.preventDefault();
        stage.setPointersPositions(e);

        Konva.Image.fromURL(itemURL, function (image) {
            image.width(100);
            image.height(100);
            layer.add(image);
            image.position(stage.getPointerPosition());
            image.draggable(true);

            layer.draw();
        });
    });
}