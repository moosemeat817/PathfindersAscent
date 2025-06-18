using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindersAscent.Cargo
{
    [HarmonyPatch(typeof(GameManager), "Awake")]
    public class MapPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            string activeScene = GameManager.m_ActiveScene;

            if (activeScene != "CrashMountainRegion")
            {
                //MelonLogger.Msg($"[MapPatch] Not in CrashMountainRegion (Current Scene: {activeScene}). Skipping.");
                return;
            }

            //MelonLogger.Msg("[MapPatch] Running in CrashMountainRegion. Checking for CargoCrates...");

            GameObject[] cargoCrates = UnityEngine.Object.FindObjectsOfType<GameObject>()
                .Where(obj => obj.name.Contains("CONTAINER_CargoCrate"))
                .ToArray();

            if (cargoCrates.Length == 0)
            {
                //MelonLogger.Msg("[MapPatch] No CargoCrates found.");
                return;
            }

            foreach (GameObject cargoCrate in cargoCrates)
            {
                //MelonLogger.Msg($"[MapPatch] Disabling MapDetail on {cargoCrate.name}");
                Main.DisableMapDetail(cargoCrate);
            }

            //MelonLogger.Msg($"[MapPatch] Disabled MapDetail on {cargoCrates.Length} CargoCrates.");
        }
    }
}

