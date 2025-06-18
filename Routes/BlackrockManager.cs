using Il2CppTLD.Gameplay;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using PathfindersAscent.SaveData;
using PathfindersAscent.Placements;

namespace PathfindersAscent.Routes
{
    public class BlackrockManager
    {
        public static void ProcessBlackrockRoutes(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                MelonLogger.Warning("ProcessBlackrockRoutes called with null or empty scene name");
                return;
            }

            switch (sceneName)
            {
                case "BlackrockPrisonSurvivalZone":
                    MelonLogger.Msg("Modifying Blackrock Prison");
                    ModifyBlackrockPrison();
                    break;
                case "BlackrockRegion":
                    MelonLogger.Msg("Modifying Blackrock Region");
                    ModifyBlackrockRegion();
                    break;
                case "BlackrockRegion_SANDBOX":
                    MelonLogger.Msg("Modifying Blackrock Sandbox");
                    ModifyBlackrockSandbox();
                    break;
                default:
                    MelonLogger.Msg($"No Blackrock route modifications for scene: {sceneName}");
                    break;
            }
        }


        private static void ModifyBlackrockPrison()
        {
            MelonLogger.Msg("Starting Blackrock Prison modifications");

            try
            {

                MelonLogger.Msg("******************************Place Snow Pile BRP");
                // Define a helper method to instantiate objects
                void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                {
                    GameObject prefab = GameObject.Find(prefabName);
                    SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                }
                if (SaveDataManager.fenceShift == 0)
                {
                    InstantiatePrefab("TRN_RockCliff_08_Med_A_Top_Prefab", new Vector3(-74.4238f, 208.8076f, 61.4438f), new Vector3(14.012f, 170.7239f, 354.0549f), new Vector3(0.8549f, 2.2f, 0.8549f));
                    MelonLogger.Msg($"****************************** Fence LARGE Snow Pile set");
                }
                else
                {
                    InstantiatePrefab("TRN_RockCliff_08_Med_A_Top_Prefab", new Vector3(-76.4238f, 207.7075f, 62.3438f), new Vector3(14.012f, 181.7239f, 354.0549f), new Vector3(0.8549f, 2.2f, 0.8549f));
                    MelonLogger.Msg($"****************************** Fence SMALL Snow Pile set");
                }



                // Enable Blackrock art object
                EnableBlackrockArtObject();

                // Disable specified objects
                DisablePrisonObjects();

                // Reposition objects
                RepositionPrisonObjects();

                MelonLogger.Msg("Completed Blackrock Prison modifications");
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying Blackrock Prison: {ex.Message}");
            }
        }

        private static void EnableBlackrockArtObject()
        {
            var parent = GameObject.Find("RegionScene_Art");
            if (parent?.transform == null)
            {
                MelonLogger.Warning("RegionScene_Art parent not found");
                return;
            }

            var child = parent.transform.Find("Blackrock_ArtObject_ForHexSector");
            if (child?.gameObject != null)
            {
                child.gameObject.SetActive(true);
                MelonLogger.Msg("Blackrock_ArtObject_ForHexSector enabled");
            }
            else
            {
                MelonLogger.Warning("Blackrock_ArtObject_ForHexSector not found");
            }
        }

        private static void DisablePrisonObjects()
        {
            string[] objectsToDisable = {
                "BlackRock_Art/Walls/STR_PrisonWall_DebrisB_Prefab (5)",
                "RegionScene_Art/Blackrock_RocksSmall/TRN_RockCliff_08_Small_F_Top_Prefab (2)",
                "BlackRock_Art/Fences/OBJ_Fence_SecurityMetal_HighC_Prefab (2)",
                "BlackRock_Art/BlackRock_Prison_ Buildings/STR_CentralPrison_Damaged_Prefab/OBJ_PrisonWalkway_Junction_Damaged_Prefab",
                "BlackRock_Art/BlackRock_Prison_ Buildings/STR_CentralPrison_Damaged_Prefab/OBJ_PrisonWalkway_Wing_Damaged_Prefab",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GateFrameB_Prefab (2)/Hinge/OBJ_Fence_SecurityMetal_GateA_Prefab",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GatePostA_Prefab (2)/Hinge/OBJ_Fence_SecurityMetal_GateA_Prefab",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GatePostA_Prefab (4)/Hinge/OBJ_Fence_SecurityMetal_GateA_Prefab",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GateFrameB_Prefab (1)/Hinge/OBJ_Fence_SecurityMetal_GateA_Prefab",
                "BlackRock_Art/BlackRock_Prison_ Buildings/STR_CentralPrison_Damaged_Prefab/STR_Shed_A_Damaged_Prefab",
                "BlackRock_Art/BlackRock_Prison_ Buildings/STR_CentralPrison_Damaged_Prefab/OBJ_BraceSupport_Prefab",
                //"BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GatePostA_Prefab (3)",
                "BlackRock_Art/BlackRock_Prison_ Buildings/Signs/OBJ_PrisonDoNotEnterSignA_Prefab",
                "RegionScene_Art/Blackrock_ArtObject_ForHexSector/Blackrock_RocksBig",
                "BlackRock_Art/Fences/BeforeEscape/INTERACTIVE_Fence_SecurityMetal_GatePostA_Prefab (1)",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GateFrameA_Prefab (6)",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GateFrameA_Prefab (1)",
                "BlackRock_Art/BlackRock_Prison_ Buildings/Signs/OBJ_PrisonKeepLockedSignA_Prefab",
                "BlackRock_Art/Fences/INTERACTIVE_Fence_SecurityMetal_GateFrameB_Prefab/Hinge/OBJ_Fence_SecurityMetal_GateA_Prefab"
            };

            RouteUtilities.DisableGameObjects(objectsToDisable);
        }

        private static void RepositionPrisonObjects()
        {
            var repositionData = new Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)>
            {
                {
                    "BlackRock_Art/BlackRock_Prison_ Buildings/STR_CentralPrison_Damaged_Prefab/STR_StairsCement_D_Prefab (1)",
                    (new Vector3(-236.6165f, 224.3602f, 150.689f), new Vector3(0.0f, 64.2358f, 0.0f), null)
                },
                {
                    "RegionScene_Art/Blackrock_ArtObjects_PrisonRocks/TRN_RockCliff_08_Med_A_Bot_Prefab",
                    (new Vector3(-263.5103f, 226.7234f, 48.56f), new Vector3(359.7492f, 155.8122f, 12.4531f), null)
                },
                {
                    "RegionScene_Art/Blackrock_ArtObject_ForHexSector/Blackrock_RocksMed/TRN_RockCliff_08_Med_A_Top_Prefab",
                    (new Vector3(-209.1656f, 218.3796f, 142.1079f), new Vector3(18.012f, 170.7239f, 354.0549f), new Vector3(0.9549f, 1.2f, 0.9549f))
                },
                {
                    "RegionScene_Art/Blackrock_ArtObject_ForHexSector/Blackrock_RocksMed/TRN_RockCliff_08_Med_B_Top_Prefab",
                    (new Vector3(-236.5304f, 219.4428f, 123.6694f), new Vector3(349.6669f, 242.5649f, 352.3899f), new Vector3(1f, 1f, 0.5f))
                }
            };

            RouteUtilities.RepositionObjects(repositionData);
        }

        private static void ModifyBlackrockRegion()
        {
            MelonLogger.Msg("Starting Blackrock Region modifications");

            try
            {
                // Log the current gate door value for debugging
                MelonLogger.Msg($"****************************** Current gateDoor value: {SaveDataManager.gateDoor}");

                if (SaveDataManager.gateDoor == 0)
                {

                    GameObject.Find("Design/Scripting/Transitions/PrisonGate/SURVIVAL_Only/InteriorLoadTrigger (1)").gameObject.SetActive(false);
                    MelonLogger.Msg($"****************************** Gate Door set Inactive");

                }
                else
                {
                    GameObject.Find("Design/Scripting/Transitions/PrisonGate/SURVIVAL_Only/InteriorLoadTrigger (1)").gameObject.SetActive(true);
                    MelonLogger.Msg($"****************************** Gate Door set ACTIVE");
                }

                MelonLogger.Msg("******************************PlaceTerrain BRM");
                // Define a helper method to instantiate objects
                void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                {
                    GameObject prefab = GameObject.Find(prefabName);
                    SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                }
                if (SaveDataManager.gateDoor == 0)
                {
                    InstantiatePrefab("TRN_Mine_SnowPile_B_Prefab (4)", new Vector3(-185.8748f, 224.9003f, 5.2238f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1.4f, 1.2f));
                    MelonLogger.Msg($"****************************** Gate Door LARGE Snow Pile set");
                }
                else
                {
                    InstantiatePrefab("TRN_Mine_SnowPile_B_Prefab (4)", new Vector3(-185.8748f, 223.9002f, 5.9238f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1.4f, 1.2f));
                    MelonLogger.Msg($"****************************** Gate Door SMALL Snow Pile set");
                }

                // Disable specified objects
                DisableRegionObjects();

                // Disable and enable specific children
                RouteUtilities.DisableChildrenByIndex("Collsion_Scene", new int[] { 9, 10 });
                RouteUtilities.DisableChildrenByIndex("Scene_Art/RiverBlockage (1)", new int[] { 13 });
                RouteUtilities.DisableChildrenByIndex("Scene_Art/Blackrock_TreeBridges/", new int[] { 8 });
                RouteUtilities.EnableChildrenByIndex("STR_StoneCabinA_Prefab(Clone)", new int[] { 1 });  // Door
                RouteUtilities.DisableChildrenByIndex("STR_StoneCabinA_Prefab(Clone)", new int[] { 0, 12, 15 });

                // Enable cabin hinge
                var cabinHinge = GameObject.Find("Scene_Art/Blackrock_structures/AbandonedCabin/STR_StoneCabinA_Prefab/Hinge");
                if (cabinHinge != null)
                {
                    cabinHinge.SetActive(true);
                }

                // Reposition objects
                RepositionRegionObjects();

                // Reposition woods
                RepositionMiscObjects();

                MelonLogger.Msg("Completed Blackrock Region modifications");
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying Blackrock Region: {ex.Message}");
            }
        }


        private static void DisableRegionObjects()
        {
            string[] objectsToDisable = {
                "Scene_Art/Blackrock_Climbs/Clambers/Cliff_Climbable_5m_mid (3)",
                "Root/Art/Climbs/INTERACTIVE_ClimbLedge_08_A",
                "Scene_Art/Blackrock_Climbs/wRope/INTERACTIVE_ClimbLedge_08_A",
                "Scene_Art/Blackrock_waterfalls/TRN_waterfall_TopWide_B_Nested_FX/Collision",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (8)",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (7)",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (6)",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (10)",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (9)",
                "Scene_Art/RiverBlockage (1)/TRN_RockCliff_08_Small_B_NS_Prefab",
                "Scene_Art/RiverBlockage (1)/TRN_RockCliff_09_Med_B_Top_Prefab",
                "Scene_Art/RiverBlockage (1)/TRN_RockCliff_09_Med_C_NS_Prefab",
                "Scene_Art/RiverBlockage (1)/TRN_RockCliff_09_Med_D_NS_Prefab",
                "Root/Art/Rocks_Big/TRN_RockCliff_08_Big_F_Prefab",
                "Scene_Art/Blackrock_RocksNotInstanced/TRN_RockCliff_09_Big_G_Prefab",
                "Scene_Art/RiverBlockage (1)/OBJ_LogFallenSingleA_Prefab (4)",
                "Scene_Art/Blackrock_structures/SemiBridgeBroken/STR_BridgeD_Damaged_Prefab",
                "Scene_Art/Blackrock_structures/AbandonedCabin/STR_StoneCabinADoor_Prefab"
            };

            RouteUtilities.DisableGameObjects(objectsToDisable);
        }

        private static void RepositionRegionObjects()
        {
            var repositionData = new Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)>
        {
            {
                "Scene_Art/Blackrock_Climbs/Clambers/Cliff_Climbable_5m_mid (5)",
                (new Vector3(-426.6406f, 235.3105f, -143.3853f), new Vector3(356f, 257.6217f, 0f), null)
            },
            {
                "Scene_Art/Blackrock_structures/STRSPAWN_HuntersBlind_Prefab",
                (new Vector3(850.997f, 307.8823f, 351.8448f), new Vector3(0.5536f, 29.6129f, 1.1198f), new Vector3(1.5f, 1f, 1f))
            }
        };

            RouteUtilities.RepositionObjects(repositionData, "region objects");
        }

        private static void ModifyBlackrockSandbox()
        {
            MelonLogger.Msg("Starting Blackrock Sandbox modifications");

            try
            {
                // Disable log using DisableChildrenByIndex
                RouteUtilities.DisableChildrenByIndex("Root/Art/Logs", new int[] { 9 });

                // Reposition objects
                var repositionData = new Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)>
            {
                {
                    "Root/Design/BunkerHatch/INTERACTIVE_HatchRandomSelect_Prefab",
                    (new Vector3(-811.4968f, 93.5338f, -351.4724f), new Vector3(0f, 0f, 0f), null)
                },
                {
                    "Root/Art/Climbs/INTERACTIVE_RopeCliff_08_50m (3)",
                    (new Vector3(-491.6755f, 157.4954f, -70.8283f), new Vector3(0f, 63.4434f, 0f), null)
                }
            };

                RouteUtilities.RepositionObjects(repositionData, "sandbox objects");

                // Disable optional objects
                RouteUtilities.SafeDisable("Root/Design/Loot/Knife/KnifeGroup2/GEAR_Knife");
                RouteUtilities.SafeDisable("Root/Design/Loot/Knife/KnifeGroup2/CORPSE_Human_Frozen1");

                MelonLogger.Msg("Completed Blackrock Sandbox modifications");
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying Blackrock Sandbox: {ex.Message}");
            }
        }

        public static void RepositionPlayerSpawnPoints()
        {
            // Convert to the format that RouteUtilities.RepositionObjects expects
            var spawnPoints = new Dictionary<string, (Vector3 position, Vector3 rotation)>
        {
            {"Design/Scripting/PlayerSpawnPoints/Start", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/Cave", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/SubstationForest", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/BarnForest", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/RopeBase", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/RiverSide", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/InterloperRavine", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))},
            {"Design/Scripting/PlayerSpawnPoints/InterloperLandslide", (new Vector3(-747.23f, 80.59f, -733.08f), new Vector3(0.0f, 270f, 0.0f))}
        };

            RouteUtilities.RepositionObjects(spawnPoints, "player spawn points");
        }

        public static void RepositionMiscObjects()
        {
            var miscObjects = new Dictionary<string, (Vector3 position, Vector3 rotation)>
        {
            {"Root/Design/NaturalResourses/sticks/central/RadialSpawn_sticks (6)", (new Vector3(-355.82f, 275.67f, 30.51f), new Vector3(0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/RadialSpawn_sticks (9)", (new Vector3(-347.02f, 283.52f, -3.84f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/RadialSpawn_sticks (12)", (new Vector3(-366.84f, 238.69f, -183.77f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/RadialSpawn_sticks (15)", (new Vector3(-273.08f, 245.55f, -242.36f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/RadialSpawn_sticks (18)", (new Vector3(-289.76f, 241.92f, -255.57f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/RadialSpawn_sticks (6)", (new Vector3(-444.69f, 190.02f, -198.71f), new Vector3(0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/RadialSpawn_sticks (9)", (new Vector3(-483.66f, 202.35f, -208.22f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/RadialSpawn_sticks (12)", (new Vector3(-473.32f, 194.72f, -132.14f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/RadialSpawn_sticks (15)", (new Vector3(-483.94f, 178.63f, -271.33f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/RadialSpawn_sticks (18)", (new Vector3(-434.29f, 221.97f, -76.76f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/Limbs/RadialSpawn_branches_soft (6)", (new Vector3(-363.41f, 238.69f, -190.65f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/limbs/RadialSpawn_branches_soft (3)", (new Vector3(-276.50f, 243.63f, -261.79f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/limbs/RadialSpawn_branches_soft (4)", (new Vector3(-293.94f, 239.06f, -242.62f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/limbs/RadialSpawn_branches_soft", (new Vector3(-476.01f, 198.87f, -149.95f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/toMine/limbs/RadialSpawn_branches_hard", (new Vector3(-484.35f, 179.37f, -276.87f), new Vector3(0.0f, 0f, 0f))},
            {"Root/Design/NaturalResourses/sticks/central/Limbs/RadialSpawn_branches_hard (1)", (new Vector3(-357.13f, 277.88f, 14.07f), new Vector3(0.0f, 0f, 0f))}
        };

            RouteUtilities.RepositionObjects(miscObjects, "misc objects");
        }
    }
}