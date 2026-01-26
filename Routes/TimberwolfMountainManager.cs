using Il2CppTLD.Gameplay;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;
using PathfindersAscent.Cargo;
using Unity.Burst.Intrinsics;

namespace PathfindersAscent.Routes
{
    public class TimberwolfMountainManager
    {
        // Process routes for Timberwolf Mountain (Crash Mountain) region
        public static void ProcessTimberwolfMountainRoutes(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                //Melonlogger.Warning("****************************** Scene name is null or empty");
                return;
            }

            if (sceneName == "CrashMountainRegion")
            {
                //Melonlogger.Msg("****************************** Modifying Crash Mountain (Timberwolf Mountain)");
                ModifyCrashMountain();

                //Melonlogger.Msg("****************************** Checking for cargo container configuration");
                CargoContainerManager.ConfigureCargoContainers(sceneName, true);
            }
            else if (sceneName == "CrashMountainRegion_SANDBOX")
            {
                //Melonlogger.Msg("****************************** Modifying Crash Mountain SANDBOX (Timberwolf Mountain)");
                ModifyCrashMountainSandbox();
            }
            else
            {
                //Melonlogger.Msg($"****************************** No Timberwolf Mountain route modifications for scene: {sceneName}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // CRASH MOUNTAIN (TIMBERWOLF MOUNTAIN)
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyCrashMountain()
        {
            //Melonlogger.Msg("****************************** Starting Timberwolf Mountain (Crash Mountain) modifications");

            // Disable climbing equipment
            //Melonlogger.Msg("****************************** Disabling climbing equipment");
            DisableClimbingEquipment("Art/Climbing/Climb100_chasm");
            DisableClimbingEquipment("Art/Climbing/Climb100m_mountain");

            // Disable specific objects by index
            //Melonlogger.Msg("****************************** Disabling specific game objects by index");
            RouteUtilities.DisableChildrenByIndex("Art/GameObject", new int[] { 74, 173, 177 });
            RouteUtilities.DisableChildrenByIndex("Design/NaturalResources/Plants/lichen", new int[] { 36, 37 });
            RouteUtilities.DisableChildrenByIndex("STR_StoneCabinA_Prefab(Clone)", new int[] { 0, 12, 15 });

            // Disable objects
            //Melonlogger.Msg("****************************** Disabling objects");
            RouteUtilities.DisableGameObjects(new string[] {
                "Art/Terrain/TreeBridge/OBJ_TreeCedarFelledC_Prefab (11)",
                "Design/Loot/CaveCamp_hatchet/cave2",
                "Art/Objects/PlaneBits/OBJ_PlaneFrontLandingGear_Prefab",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisF_Prefab (2)",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisF_Prefab (3)",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisC_Prefab (1)",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisC_Prefab (2)",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisF_Prefab (4)",
                "Art/Objects/PlaneBits/OBJ_PlaneDebrisC_Prefab"
            });

            // Disable optional objects that might not exist
            //Melonlogger.Msg("****************************** Disabling optional buffer memory cave objects");

            RouteUtilities.SafeDisable("Design/BufferMemoryCaveCorpse/OBJ_ComputerLaptopB_Prefab");
            RouteUtilities.SafeDisable("Design/BufferMemoryCaveCorpse/CORPSE_Human_3");
            //RouteUtilities.SafeDisable("Design/Loot/CaveCamp_hatchet/cave2");


            // Disable rock anchors and ropes
            //Melonlogger.Msg("****************************** Disabling rock anchors and ropes");
            DisableRockAnchorsAndRopes();

            // Reposition all objects using unified method
            //Melonlogger.Msg("****************************** Repositioning objects");
            RepositionAllObjects();

            //Melonlogger.Msg("****************************** Completed Timberwolf Mountain modifications");
        }

        // ------------------------------------------------------------------------------------------------------------------
        // CRASH MOUNTAIN SANDBOX (TIMBERWOLF MOUNTAIN)
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyCrashMountainSandbox()
        {
            // Reposition bunker using unified method
            //Melonlogger.Msg("****************************** Repositioning bunker");
            var bunkerData = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                {
                    "Design/BunkerHatch/INTERACTIVE_HatchRandomSelect_Prefab",
                    (new Vector3(908.0961f, 323.4271f, 1766.38f), new Vector3(0f, 180f, 0f))
                }
            };



            RouteUtilities.RepositionObjects(bunkerData, "bunker objects");
        }

        private static void DisableClimbingEquipment(string basePathName)
        {
            if (string.IsNullOrEmpty(basePathName))
            {
                //Melonlogger.Warning("****************************** Base path name is null or empty");
                return;
            }

            //Melonlogger.Msg($"****************************** Processing climbing equipment at path: {basePathName}");
            GameObject basePath = GameObject.Find(basePathName);
            if (basePath != null)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (i < basePath.transform.childCount)
                    {
                        GameObject child = basePath.transform.GetChild(i)?.gameObject;
                        if (child != null)
                        {
                            child.SetActive(false);
                            //Melonlogger.Msg($"****************************** Disabled child {i} of {basePathName}");
                        }
                        else
                        {
                            //Melonlogger.Warning($"****************************** Child {i} gameObject is null in {basePathName}");
                        }
                    }
                    else
                    {
                        //Melonlogger.Warning($"****************************** Child {i} not found in {basePathName}");
                    }
                }
            }
            else
            {
                //Melonlogger.Warning($"****************************** Base path not found: {basePathName}");
            }
        }

        private static void DisableRockAnchorsAndRopes()
        {
            //Melonlogger.Msg("****************************** Disabling rock anchors and ropes");

            for (int attempt = 0; attempt < 3; attempt++)
            {
                if (attempt > 0)
                {
                    //Melonlogger.Msg($"****************************** Retry attempt {attempt + 1}");
                    System.Threading.Thread.Sleep(200); // Wait 1/10 second
                }
                string[] rockAnchorsAndRopes = {
                //"/Art/Climbing/Climb50m_lake/INTERACTIVE_RopeCliff_50m/TRN_RockAnchor01",
                //"/Art/Climbing/Climb50m_creek/INTERACTIVE_RopeCliff_50m/TRN_RockAnchor01",
                //"/Art/Climbing/Climb50m_Mountain/INTERACTIVE_RopeCliff_50m/TRN_RockAnchor01",
                //"/Art/Climbing/Climb50m_lake/INTERACTIVE_RopeCliff_50m/Rope_50m",
                //"/Art/Climbing/Climb50m_creek/INTERACTIVE_RopeCliff_50m/Rope_50m",
                //"/Art/Climbing/Climb50m_Mountain/INTERACTIVE_RopeCliff_50m/Rope_50m",
                "/Art/Climbing/Climb50m_lake/INTERACTIVE_RopeCliff_50m",
                "/Art/Climbing/Climb50m_creek/INTERACTIVE_RopeCliff_50m",
                "/Art/Climbing/Climb50m_Mountain/INTERACTIVE_RopeCliff_50m"
                };

                RouteUtilities.DisableGameObjects(rockAnchorsAndRopes);
            }
        }



        public static void RepositionPlayerSpawnPoints()
        {
            // Convert to the format that RouteUtilities.RepositionObjects expects
            var spawnPoints = new Dictionary<string, (Vector3 position, Vector3 rotation)>
    {
        {"Design/Scripting/PlayerSpawnPoints/CrashClearing", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashRavine", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashEntrance", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashCreek", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashForest", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashCave", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashCabin", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/CrashCreek2", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/InterloperCrashLedge", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))},
        {"Design/Scripting/PlayerSpawnPoints/InterloperCrashPeak", (new Vector3(1177.91f, 55.96f, 874.70f), new Vector3(0.0f, 180f, 0.0f))}
    };
            RouteUtilities.RepositionObjects(spawnPoints, "player spawn points");
        }





        private static void RepositionAllObjects()
        {
            // Reposition transition points
            var transitions = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                // Ridge Below Summit Cave
                {"Design/Scripting/Transitions/MountainCaveAUpper/TransitionZone",
                    (new Vector3(618.6489f, 424.35f, 1498.121f), new Vector3(0.0f, 170.9978f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveAUpper/TransitionContact",
                    (new Vector3(617.2971f, 424.35f, 1487.915f), new Vector3(0.0f, 170.9978f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveAUpper/MountainCaveAExitPoint2",
                    (new Vector3(619.35f, 418.73f, 1500.24f), new Vector3(0f, 0f, 0f))},
                // Upper Creek Cave
                {"Design/Scripting/Transitions/MountainCaveBUpper/TransitionZone",
                    (new Vector3(594.3f, 303.22f, 1223.75f), new Vector3(0.0f, 154.7459f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveBUpper/TransitionContact",
                    (new Vector3(594.3f, 303.22f, 1223.75f), new Vector3(0.0f, 154.7459f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveBUpper/MountainCaveBExitPoint2",
                    (new Vector3(586.28f, 301.25f, 1218.08f), new Vector3(0f, 241.9945f, 0f))},
                // Chasm Cave
                {"Design/Scripting/Transitions/MountainCaveBLower/TransitionZone",
                    (new Vector3(1329.04f, 53.4601f, 885.6812f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveBLower/TransitionContact",
                    (new Vector3(1328.46f, 51.47f, 884.02f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/Transitions/MountainCaveBLower/MountainCaveBExitPoint1",
                    (new Vector3(1321.86f, 50.31f, 895.07f), new Vector3(0f, 0f, 0f))}
            };

            RouteUtilities.RepositionObjects(transitions, "transition points");



            // Reposition misc objects
            var miscObjects = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                {"Art/Terrain/TRN_MountainDistant_Group/Trees/TRN_PineTree_SingleJ_Prefab (7)",
                    (new Vector3(1032.381f, 146.0051f, 464.9521f), new Vector3(5.8723f, 305.9673f, 358.5946f))},
                {"Art/Climbing/DisabledRopes/Climb50m_engine/INTERACTIVE_RopeCliff_50m",
                    (new Vector3(310.16f, 216.2f, 1064.18f), new Vector3(0.0f, 20.2899f, 0.0f))},
                {"Art/Climbing/Climb50m_Deer/INTERACTIVE_RopeCliff_50m",
                    (new Vector3(1479.09F, 144.61F, 1339.72f), new Vector3(-0, 17.3353F, 0f))},
                {"Art/Climbing/DisabledRopes/Climb50m_bigcave/INTERACTIVE_RopeCliff_50m",
                    (new Vector3(1716.2F, 153F, 1426.9f), new Vector3(-0F, 28.6631F, 0f))}
            };

            RouteUtilities.RepositionObjects(miscObjects, "misc objects");
        }
    }
}