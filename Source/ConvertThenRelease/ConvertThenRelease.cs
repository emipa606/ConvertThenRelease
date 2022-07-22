using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ConvertThenRelease;

[StaticConstructorOnStartup]
public static class ConvertThenRelease
{
    public static readonly PrisonerInteractionModeDef ConvertThenReleaseMode;

    static ConvertThenRelease()
    {
        var harmony = new Harmony("Mlie.ConvertThenRelease");

        harmony.PatchAll(Assembly.GetExecutingAssembly());
        ConvertThenReleaseMode = DefDatabase<PrisonerInteractionModeDef>.GetNamedSilentFail("ConvertThenRelease");
    }
}