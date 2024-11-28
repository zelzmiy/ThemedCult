using System.IO;

namespace ThemedCult.Theming;

public class GoatTheme : Theme
{
    public override string AssetPath => Path.Combine(Plugin.PluginPath, "Assets", "Goat");

    public override Sprite ShrineBody =>
        TextureHelper.CreateSpriteFromPath(Path.Combine(AssetPath, "Shrine", "Shrine_Base_Goat.png"));

    public override Sprite ShrineHead => 
        TextureHelper.CreateSpriteFromPath(Path.Combine(AssetPath, "Shrine", "Shrine_Head_Goat.png"));
    public override void ChangeToTheme()
    {
        foreach (var structure in StructureManager.GetAllStructuresOfType<Structures_Shrine>())
        {
            ChangeShrine(structure.GetShrine().gameObject);
        }
    }

    public override void ChangeShrine(GameObject statue)
    {
        var shrine = statue.FindChild("Shrine_Normal");
        var head = shrine.FindChild("Shrine_Head");
        var flag = shrine.FindChild("Shrine_Flag");
        var shrineSprite = shrine.GetComponent<SpriteRenderer>();

        shrineSprite.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        shrineSprite.sprite = ShrineBody;
        shrineSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -10.71f, -1.15f), shrine.transform.rotation);

        var headSprite = head.GetComponent<SpriteRenderer>();
        headSprite.sprite = ShrineHead;
        headSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -9.8f, -2.92f), shrine.transform.rotation);

        flag.SetActive(false);
    }
}