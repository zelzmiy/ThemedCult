using System;
using System.Collections.Generic;
using System.Text;
using static ThemedCult.Theming.CultTheme;
namespace ThemedCult.Theming
{
    public partial class ThemeChanger
    {
        public static void ChangeTheme(CultTheme theme)
        {
            switch (theme)
            { 
                case BasicTheme:
                    break;
                case ForestTheme:
                    break;
                case BoneTheme:
                    ChangeToBoneTheme();
                    break;
                case GoldTheme:
                    break;
            }
        }
    }

    public enum CultTheme
    {
        BasicTheme = 0,
        ForestTheme = 1,
        BoneTheme = 2,
        GoldTheme = 3
    }
}
