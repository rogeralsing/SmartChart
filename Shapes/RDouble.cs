namespace SmartChart;

public record RDouble(FDouble Fun)
{
    public static implicit operator FDouble(RDouble v) => v.Fun;
    public static implicit operator RDouble(FDouble v) => new(v);
    public static implicit operator RDouble(double v) => new(() => v);

    public static RDouble operator -(RDouble v1, RDouble v2) => new(() => v1.Fun() - v2.Fun());
    public static RDouble operator +(RDouble v1, RDouble v2) => new(() => v1.Fun() + v2.Fun());
    public static RDouble operator /(RDouble v1, RDouble v2) => new(() => v1.Fun() / v2.Fun());
    public static RDouble operator *(RDouble v1, RDouble v2) => new(() => v1.Fun() * v2.Fun());
}