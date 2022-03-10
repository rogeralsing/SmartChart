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

var l = new Line()
{
    X1 = a.AnchorCenterX,
    Y1 = a.AnchorCenterY,

    X2 = d.AnchorCenterX,
    Y2 = d.AnchorCenterY,
};

WriteLine(d.AnchorCenterX.Fun());
WriteLine(d.AnchorCenterY.Fun());


WriteLine(l.X2.Fun());
WriteLine(l.Y2.Fun());

shapes.AddRange(new Element[] { a, b, c, d ,l });

var sb = new StringBuilder();
sb.AppendLine(@"
<style>
  .shape {
    fill: #ff0000;
    stroke: #00ff00;
    stroke-width: 2px;
  }
  .text {
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
  }
  .rect {
  }
  .circle {
  }
  .triangle {
    clip-path: polygon(50% 0%, 100% 100%, 0% 100%);
  }
  .line {
    stroke: #ff00ff;
    stroke-width: 2px;
  }
</style>

<svg xmlns='http://www.w3.org/2000/svg' width='1000' height='800'>
");
foreach (var shape in shapes)
{
    shape.Render(sb);
}
WriteLine(sb.ToString());