using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThemedCult.Theming
{
    partial class ThemeChanger
    {

        private static readonly string _bonePath = Path.Combine(Plugin.PluginPath, "Assets", "Bone");

        private static Sprite BoneShrine_Body_3 => TextureHelper.CreateSpriteFromPath(Path.Combine(_bonePath, "Shrine", "TempleCenter_Base_3_Bone.png"));
        private static Sprite BoneShrine_Head_3 => TextureHelper.CreateSpriteFromPath(Path.Combine(_bonePath, "Shrine", "TempleCenter_Head_3_Bone.png"));
        private static void ChangeToBoneTheme()
        {
            foreach (Structures_Shrine structure in StructureManager.GetAllStructuresOfType<Structures_Shrine>())
            {
                ChangeShrineToBone(structure.GetShrine().gameObject);
            }
        }

        private static void ChangeShrineToBone(GameObject statue)
        {
            // im about to vomit... THRICE?!??
            GameObject shrine = statue.FindChild("Shrine_Normal");
            GameObject head = shrine.FindChild("Shrine_Head");
            GameObject flag = shrine.FindChild("Shrine_Flag");
            var shrineSprite = shrine.GetComponent<SpriteRenderer>();

            shrineSprite.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            shrineSprite.sprite = BoneShrine_Body_3;
            shrineSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -10.36f, -1.75f), shrine.transform.rotation);

            var headSprite = head.GetComponent<SpriteRenderer>();
            headSprite.sprite = BoneShrine_Head_3;
            headSprite.transform.SetPositionAndRotation(new Vector3(0.18f, -10f, -2.8f), shrine.transform.rotation);

            flag.transform.SetPositionAndRotation(new Vector3(0.18f, -10.25f, -2.35f), flag.transform.rotation);
        }
    }
}
