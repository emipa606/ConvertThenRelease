using Verse;

namespace ConvertThenRelease;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ConvertThenReleaseSettings : ModSettings
{
    public bool ReduceResistance;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ReduceResistance, "ReduceResistance");
    }
}