using GameNetcodeStuff;
using HarmonyLib;

namespace HubertsToolkit;

[HarmonyPatch(typeof(PlayerControllerB), "LateUpdate")]
internal static class InfiniteSprintPatch
{
    [HarmonyPostfix]
    private static void Postfix(PlayerControllerB __instance)
    {
        if (!Plugin.InfiniteSprint.Value || __instance == null || !__instance.IsOwner)
        {
            return;
        }

        __instance.sprintMeter = 1f;
        __instance.isExhausted = false;
    }
}
