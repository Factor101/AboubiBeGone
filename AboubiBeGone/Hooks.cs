using System;
using System.Collections.Generic;
using BepInEx;
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

    [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate),
        new[] { typeof(UnityEngine.Object), typeof(Vector3), typeof(Quaternion) })]
    public static class RemoveAllBloodPatch
    {
        private static readonly HashSet<string> BloodPrefabs = new HashSet<string>(StringComparer.Ordinal)
        { // result of recursive grep for "blood" in the game's assets 
        "VFX_Blood_Burst_Directional_L",
        "VFX_Blood_RondRouge_00_L",
        "VFX_Blood_RondRouge_00_M",
        "VFX_Blood_RondRouge_00_XXL",
        "PF_BloodSplatter_00_L",
        "PF_BloodSplatter_00_M",
        "PF_BloodSplatter_00_S",
        "VFX_Blood_Burst_Directional_M",
        "VFX_BloodImpactShower_01",
        "VFX_StyleBlood_Slice_Omni_L",
        "VFX_StyleGore_Explosion_Omni_XXL",
        "VFX_Blood_Spray_Directional_L",
        "PF_Blood",
        "VFX_BloodFountain_00",
        "VFX_BloodFountain_01",
        "VFX_BloodFountain_02",
        "VFX_BloodImpactShower_00",
        "VFX_BloodImpact_00",
        "VFX_Blood_Flow_Splash_L",
        "VFX_Blood_Flow_Splash_XL",
        "VFX_Blood_Slice_Omni_M",
        "VFX_StyleBlood_Spray_Directional_M",
        
        };
        static bool Prefix(UnityEngine.Object original)
        {
            
            var isBloodGameObject = BloodPrefabs.Contains(original.name);
            return !isBloodGameObject;
        }
    }
}
