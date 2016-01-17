function sketchProc(processing) {
    processing.size(250, 250);
    processing.background(0, 0, 0, 0);
    processing.noLoop();
    processing.draw = function() {
        //in here is where you can drop your code. setup() runs once, draw() will run
        //continuously
        /**
            GitHub-Style Avatar Generator
            by Colin Reeder
        
            Enter your name in the NAME string, maybe modify the size a bit, and view the image generated for you!
        */
        var SIZE = 3;
        var NAME = $("#AvatarCanvas").data("user");


        var genHash = function(s) {
            var hash = 0;
            if (s.length === 0) {
                return hash;
            }
            for (var i = 0; i < s.length; i++) {
                var char = s.charCodeAt(i);
                hash = ((hash << 5) - hash) + char;
                hash = hash & hash;
            }
            return hash;
        };
        var addZeroes = function(ns, nd) {
            //Shortest useful for loop ever.
            for (; 0 < nd - ns.length; ns = "0" + ns) {
            }
            return ns;
        };
        var op = addZeroes(processing.abs(genHash(NAME)).toString(16), 8);
        Processing.debug("hash of " + NAME + " is " + op);
        var clr = processing.color(parseInt(op.substring(0, 2), 16), parseInt(op.substring(2, 4), 16), parseInt(op.substring(4, 6), 16));
        Processing.debug(NAME + "'s color is rgb(" + processing.red(clr) + ", " + processing.green(clr) + ", " + processing.blue(clr) + ")");
        processing.fill(clr);
        processing.noStroke();
        processing.randomSeed(parseInt(op.substring(6, 8), 16));
        var mult = 200 / ((SIZE * 2) - 1);
        for (var x = 0; x < SIZE; x++) {
            for (var y = 0; y < SIZE * 2; y++) {
                if (processing.random() < 0.5) {
                    processing.rect(x * mult, y * mult, mult, mult);
                    processing.rect(200 - (x + 1) * mult, y * mult, mult, mult);
                }
            }
        }
    };

}

var canvas = document.getElementById("AvatarCanvas");
// attaching the sketchProc function to the canvas
var p = new Processing(canvas, sketchProc);
// p.exit(); to detach it