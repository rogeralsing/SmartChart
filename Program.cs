// See https://aka.ms/new-console-template for more information

using System.Text;
using SmartChart;
using static System.Console;

var shapes = new List<Element>();
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
    Width  = 5,
    Height = 5
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

var sb = new StringBuilder();
foreach (var shape in shapes)
{
    shape.Render(sb);
}
WriteLine(sb.ToString());