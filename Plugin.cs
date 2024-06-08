using System.IO;
using COTL_API.CustomInventory;
using COTL_API.CustomFollowerCommand;
using System.Collections.Generic;

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
            Harmony.PatchAll();
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            LogInfo($"Unloaded {PluginName}!");
        }

    }
}