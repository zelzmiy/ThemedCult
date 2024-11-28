using System;
using System.IO;
using ThemedCult.Theming;
using UnityEngine.SceneManagement;

namespace ThemedCult;

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
        LogInfo(scene.name);
        if (scene.name != "Base Biome 1")
            return;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ThemeChanger.ChangeTheme(CultTheme.GoatTheme);
        }
    }
}