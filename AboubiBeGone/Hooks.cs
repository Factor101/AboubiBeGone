using HarmonyLib;
using UnityEngine;

namespace AboubiBeGone
{
    [HarmonyPatch(typeof(PlayerHealth))]
    [HarmonyPatch(typeof(PlayerHealth), "RpcLogic___ExplodeForAll_576886416")]
    class PlayerDeathHook
    {
        static void Prefix(PlayerHealth __instance) => Plugin.DisableLocalRagdollSpawn(__instance);
    };



    [HarmonyPatch(typeof(PredictedProjectile), "HandleCollision")]
    class Patch_PredictedProjectile_NoBlood
    {
        static void Prefix(PredictedProjectile __instance,
            out GameObject __state_bloodVfx,
            out GameObject __state_headBloodVfx,
            out GameObject __state_bloodSplatter)
         => Plugin.Prefix_PredictedProjectile_NoBlood(
                __instance, out __state_bloodVfx, out __state_headBloodVfx, out __state_bloodSplatter);

        static void Postfix(PredictedProjectile __instance,
            GameObject __state_bloodVfx,
            GameObject __state_headBloodVfx,
            GameObject __state_bloodSplatter)
         => Plugin.Postfix_PredictedProjectile_NoBlood(
                __instance, __state_bloodVfx, __state_headBloodVfx, __state_bloodSplatter);
    };
}
