namespace SmartChart;

public class Shape
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
}