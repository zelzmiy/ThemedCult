using System.IO;

namespace ThemedCult.Theming;

class BoneTheme : Theme
{

    public override string AssetPath => Path.Combine(Plugin.PluginPath, "Assets", "Bone");

    public override Sprite ShrineBody => TextureHelper.CreateSpriteFromPath(Path.Combine(AssetPath, "Shrine", "Shrine_Base_Bone.png"));
    public override Sprite ShrineHead => TextureHelper.CreateSpriteFromPath(Path.Combine(AssetPath, "Shrine", "Shrine_Head_Bone.png"));

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

        shrineSprite.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        shrineSprite.sprite = ShrineBody;
        shrineSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -10.36f, -1.75f), shrine.transform.rotation);

        var headSprite = head.GetComponent<SpriteRenderer>();
        headSprite.sprite = ShrineHead;
        headSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -10f, -2.8f), shrine.transform.rotation);

        flag.transform.SetPositionAndRotation(new Vector3(0.18f, -10.25f, -2.35f), flag.transform.rotation);
    }
}