using System.Text;

namespace SmartChart;

public abstract class Element
{
    public abstract void Render(StringBuilder sb);
}

public class Shape : Element
{
    public Group Group { private get; set; }
    public string Type { get; init; }
    public string Label { get; set; }
    public RDouble? Left { private get; init; }
    public RDouble? Top { private get; init; }
    public RDouble? Bottom { private get; init; }
    public RDouble? Right { private get; init; }
    public RDouble? CenterX { private get; init; }
    public RDouble? CenterY { private get; init; }

    public double? Width { get; set; } = 1d;
    public double? Height { get; set; } = 1d;

    public RDouble AnchorLeft =>
        this switch
        {
            { Left: not null }    => Left,
            { Right: not null }   => Right - AnchorWidth,
            { CenterX: not null } => CenterX - AnchorWidth / 2d,
            _                     => 0d
        };

    public RDouble AnchorTop =>
        new(this switch
        {
            { Top: not null }     => Top,
            { Bottom: not null }  => Bottom - AnchorHeight,
            { CenterY: not null } => CenterY - AnchorHeight / 2d,
            _                     => 0d
        });

    public RDouble AnchorWidth =>
        new(this switch
        {
            { Width: not null } => () => Width.Value,
            _                   => () => 0d
        });

    public RDouble AnchorHeight =>
        new(this switch
        {
            { Height: not null } => () => Height.Value,
            _                    => () => 0d
        });

    public RDouble AnchorCenterX => AnchorLeft + AnchorWidth / 2d;
    
    public RDouble AnchorCenterY => AnchorTop + AnchorHeight / 2d;

    public RDouble GetRight() => AnchorLeft + AnchorWidth;

    public RDouble GetBottom() => AnchorTop + AnchorHeight;

    public Bounds GetBounds() => new(AnchorLeft.Fun(), AnchorTop.Fun(), AnchorWidth.Fun(), AnchorHeight.Fun());

    public override void Render(StringBuilder sb)
    {
        var bounds = GetBounds();
        var left = (int)(bounds.Left * 50 + 3);
        var width = (int)(bounds.Width * 50 + 3);
        var top = (int)(bounds.Top * 50 - 6);
        var height = (int)(bounds.Height * 50 - 6);
        sb.AppendLine("<g>");
        var el = Type switch
        {
            "circle"   => $"\t<rect class='shape {Type}' x='{left}' y='{top}' width='{width}' height='{height}' rx='50%' />",
            "rect"     => $"\t<rect class='shape {Type}' x='{left}' y='{top}' width='{width}' height='{height}' />",
            "triangle" => $"\t<polygon class='shape {Type}' points='{left},{top+height} {left+width/2},{top} {left+width},{top+height}' />",
            _          => ""
        };
        sb.AppendLine(el);
        var lb = $"\t<foreignObject class='text' x='{left}' y='{top}' width='{width}' height='{height}'>{Label}</foreignObject>";
        sb.AppendLine(lb);
        sb.AppendLine("</g>");
    }
}