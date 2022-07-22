using HarmonyLib;
using RimWorld;
using Verse;

namespace ConvertThenRelease;

[HarmonyPatch(typeof(Pawn_IdeoTracker), "IdeoConversionAttempt")]
public static class Pawn_IdeoTracker_IdeoConversionAttempt
{
    public static void Postfix(bool __result, Pawn ___pawn)
    {
        if (!__result)
        {
            return;
        }

        if (!___pawn.IsPrisonerOfColony)
        {
            return;
        }

        if (___pawn.guest.interactionMode != ConvertThenRelease.ConvertThenReleaseMode)
        {
            return;
        }

        if (___pawn.Ideo != Faction.OfPlayer.ideos.PrimaryIdeo)
        {
            return;
        }

        ___pawn.guest.interactionMode = PrisonerInteractionModeDefOf.Release;
        var text = "CTRe.pawnconverted".Translate(___pawn.NameFullColored);
        var messageType = MessageTypeDefOf.PositiveEvent;
        var message = new Message(text, messageType, new LookTargets(___pawn));
        Messages.Message(message);
    }
}