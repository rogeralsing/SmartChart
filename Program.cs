// See https://aka.ms/new-console-template for more information

using SmartChart;
using static System.Console;

var shapes = new List<Shape>();
var a = new Shape
{
    Type   = "rect",
    Label  = "A",
    Left   = 10,
    Top    = 10,
    Width  = 5,
    Height = 5
};
var b = new Shape
{
    Type   = "triangle",
    Label  = "B",
    Right  = a.AnchorLeft - 2,
    Top    = a.AnchorTop,
    Width  = 6,
    Height = 6
};
var c = new Shape
{
    Type    = "rect",
    Label   = "C",
    CenterX = b.AnchorCenterX,
    Bottom  = b.AnchorTop,
    Width   = 4,
    Height  = 4,
};
var d = new Shape
{
    Type    = "circle",
    Label   = "D",
    CenterX = c.AnchorCenterX,
    CenterY = c.AnchorCenterY,
    Width   = 2,
    Height  = 2,
};
shapes.AddRange(new[] { a, b, c, d });

foreach (var shape in shapes)
{
    var bounds = shape.GetBounds();
    var left = bounds.Left * 50 + 3;
    var width = bounds.Width * 50 + 3;
    var top = bounds.Top * 50 - 6;
    var height = bounds.Height * 50 - 6;
    var el = $"<div class='{shape.Type} shape' style='left:{left}px; width:{width}px; top:{top}px; height:{height}px;'>{shape.Label}</div>";
    WriteLine(el);
}