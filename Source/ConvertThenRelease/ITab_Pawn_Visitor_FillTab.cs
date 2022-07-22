using System.Collections.Generic;
using HarmonyLib;
using RimWorld;

namespace ConvertThenRelease;

[HarmonyPatch(typeof(ITab_Pawn_Visitor), "FillTab")]
[HarmonyAfter("Harmony_PrisonLabor")]
public class ITab_Pawn_Visitor_FillTab
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instr)
    {
        var lastCode = string.Empty;
        foreach (var codeInstruction in instr)
        {
            if (codeInstruction.operand is float operand and > 120f && lastCode == "ldloc.2 NULL")
            {
                codeInstruction.operand = operand += 30;
            }

            lastCode = codeInstruction.ToString();
            yield return codeInstruction;
        }
    }
}