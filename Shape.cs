namespace SmartChart;

public class Group
{
    public List<Shape> Shapes { get; set; }
}

public class Shape
{
    public string Type { get; init; }
    public string Label { get; set; }
    public Group Group { private get; set; }
    public RInt32? Left { private get; init; }
    public RInt32? Top { private get; init; }
    public RInt32? Bottom { private get; init; }
    public RInt32? Right { private get; init; }
    public RInt32? CenterX { private get; init; }
    public RInt32? CenterY { private get; init; }

    public int? Width { get; set; } = 1;
    public int? Height { get; set; } = 1;

    public RInt32 AnchorLeft =>
        this switch
        {
            { Left: not null }    => Left,
            { Right: not null }   => Right - AnchorWidth,
            { CenterX: not null } => CenterX - AnchorWidth / 2,
            _                     => 0
        };

    public RInt32 AnchorTop =>
        new(this switch
        {
            { Top: not null }     => Top,
            { Bottom: not null }  => Bottom - AnchorHeight,
            { CenterY: not null } => CenterY - AnchorHeight / 2,
            _                     => 0
        });

    public RInt32 AnchorWidth =>
        new(this switch
        {
            { Width: not null } => () => Width.Value,
            _                   => () => 0
        });

    public RInt32 AnchorHeight =>
        new(this switch
        {
            { Height: not null } => () => Height.Value,
            _                    => () => 0
        });

    public RInt32 AnchorCenterX => AnchorLeft + AnchorWidth / 2;
    
    public RInt32 AnchorCenterY => AnchorTop + AnchorHeight / 2;

    public RInt32 GetRight() => AnchorLeft + AnchorWidth;

    public RInt32 GetBottom() => AnchorTop + AnchorHeight;

    public Bounds GetBounds() => new(AnchorLeft.FInt32(), AnchorTop.FInt32(), AnchorWidth.FInt32(), AnchorHeight.FInt32());
}

public delegate int FInt32();

public record RInt32(FInt32 FInt32)
{
    public static implicit operator FInt32(RInt32 v) => v.FInt32;
    public static implicit operator RInt32(FInt32 v) => new(v);
    public static implicit operator RInt32(int v) => new(() => v);

    public static RInt32 operator -(RInt32 v1, RInt32 v2) => new(() => v1.FInt32() - v2.FInt32());
    public static RInt32 operator +(RInt32 v1, RInt32 v2) => new(() => v1.FInt32() + v2.FInt32());
    public static RInt32 operator /(RInt32 v1, RInt32 v2) => new(() => v1.FInt32() / v2.FInt32());
    public static RInt32 operator *(RInt32 v1, RInt32 v2) => new(() => v1.FInt32() * v2.FInt32());
}

public record Bounds(int Left, int Top, int Width, int Height);