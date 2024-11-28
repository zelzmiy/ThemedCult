
namespace ThemedCult.Theming;

public abstract class Theme
{
    public abstract string AssetPath { get; }

    public abstract Sprite ShrineBody { get; }
    public abstract Sprite ShrineHead { get; }


    public abstract void ChangeToTheme();
    public abstract void ChangeShrine(GameObject statue);
}