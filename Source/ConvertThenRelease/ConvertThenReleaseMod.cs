using Mlie;
using UnityEngine;
using Verse;

namespace ConvertThenRelease;

[StaticConstructorOnStartup]
internal class ConvertThenReleaseMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static ConvertThenReleaseMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private ConvertThenReleaseSettings settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public ConvertThenReleaseMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.ConvertThenRelease"));
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    public ConvertThenReleaseSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<ConvertThenReleaseSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Convert Then Release";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("CTRe.reduceresistance.label".Translate(),
            ref Settings.ReduceResistance, "CTRe.reduceresistance.description".Translate());
        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listing_Standard.Label("CTRe.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        Settings.Write();
    }
}