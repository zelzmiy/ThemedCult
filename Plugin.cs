using System.IO;
using COTL_API.CustomInventory;
using COTL_API.CustomFollowerCommand;
using System.Collections.Generic;
using Rewired.UI.ControlMapper;
using System;
using UnityEngine.SceneManagement;
using ThemedCult.Theming;

namespace ThemedCult
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "xyz.zelzmiy.ThemedCult";
        public const string PluginName = "ThemedCult";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        private void Awake()
        {
            Log = Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);
        }

        private void OnEnable()
        {
            Harmony.PatchAll(typeof(Plugin));
            SceneManager.sceneLoaded += OnCultLoaded;
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            SceneManager.sceneLoaded -= OnCultLoaded;
            LogInfo($"Unloaded {PluginName}!");
        }

        public void OnCultLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Base Biome 1")
                return;
            
            // why -100? i don't know, ask the COTL devs
            ThemeChanger.ChangeTheme((CultTheme)DataManager.instance.TempleBorder - 100);
        }

        [HarmonyPatch(typeof(Interaction_TempleAltar), nameof(Interaction_TempleAltar.SetAltarStyle))]
        [HarmonyPostfix]
        public static void ChangeThemes(int style)
        {
            ThemeChanger.ChangeTheme((CultTheme)style);
        }
    }
}