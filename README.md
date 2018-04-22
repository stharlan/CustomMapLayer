# CustomMapLayer
Custom map layer with ESRI Mapping API 4.x, MVC and SkiaSharp.

This is a basic demo to show how a custom dynamic map layer can be created
using MVC as the application framework, SkiaSharp as the mechanism in the
controller action to produce the dynamic map image, and, the ESRI Mapping
API 4.x JavaScript framework to produce the dynamic map in the web page
that will consume the dynamic map image.

To start, there is a basic ESRI Map set up on the home/index page.
This is taken directly from ESRI's documentation at:

http://developer.esri.com

The map setup js code creates a subclass of the BaseDynamicLayer. It overloads
the getImageUrl method which is what the API calls when it needs a new image.
This usually occurs when the user pans or zooms the map. The method code constructs
a URL to a controller method "Home/Layer1" which will return a map image, the size
of which is specified by the width and height, which are supplied by the mapping
API based on the map size in the page. The mapping API is doing all the heavy lifting.

The controller method simply needs to produce an image, the size of that which was
requested, and, return it to the page where the mapping API will display it. The
method in the example uses SkiaSharp to produce that image. The example simply produces
a red circle in the middle of the map, however, the drawing code can produce any
type of map overlay that is needed, from, drawing point locations queried from a
database, to, producing a heat map overlay, both of which I have done in production
applications.

The image is streamed back using a class called "FileGeneratingResult" that I
obtained from this stackoverflow post.

https://stackoverflow.com/questions/943122/writing-to-output-stream-from-action

TODO

- Add code to plot markers at specific GPS coordinates.
- Add code to produce a "heat map".

SH
