namespace ThemedCult.Theming;
public static class ThemeChanger
{
    public static void ChangeTheme(CultTheme theme)
    {
        switch (theme)
        { 
            case CultTheme.BasicTheme:
                break;
            case CultTheme.ForestTheme:
                break;
            case CultTheme.BoneTheme:
                new BoneTheme().ChangeToTheme();
                break;
            case CultTheme.GoldTheme:
                break;
            case CultTheme.GoatTheme:
                new GoatTheme().ChangeToTheme();
                break;
        }
    }
        
    #region Patches
        
    //runs on cult loaded for the first time
    [HarmonyPatch(typeof(BaseLocationManager), "ShowCultName")]
    [HarmonyPostfix]
    private static void ChangeThemes() 
    {
        // why - 100? because CultUpgradeData.TYPE has themes offset by 100 and temple upgrades as 0,1,2,3...
        ThemeChanger.ChangeTheme((CultTheme)DataManager.instance.TempleBorder - 100);
    }

    [HarmonyPatch(typeof(Interaction_TempleAltar), nameof(Interaction_TempleAltar.SetAltarStyle))]
    [HarmonyPostfix]
    private static void ChangeThemes(int style)
    {
        ThemeChanger.ChangeTheme((CultTheme)style);
    }
    
    #endregion
}

public enum CultTheme
{
    BasicTheme = 0,
    ForestTheme = 1,
    BoneTheme = 2,
    GoldTheme = 3,
    GoatTheme = 4,
}