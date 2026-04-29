using HarmonyLib;

namespace AboubiBeGone
{
    [HarmonyPatch(typeof(PlayerHealth))]
    [HarmonyPatch(typeof(PlayerHealth), "RpcLogic___ExplodeForAll_576886416")]
    class PlayerDeathHook
    {
        static void Prefix(PlayerHealth __instance) => Plugin.DisableLocalRagdollSpawn(__instance);
    }
}
   