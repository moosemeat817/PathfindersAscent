using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;
using PathfindersAscent.SaveData;
using PathfindersAscent.Placements;

namespace PathfindersAscent.Routes
{
    public class AshCanyonManager
    {
        // Process routes for all Ash Canyon-related regions
        public static void ProcessAshCanyonRoutes(string sceneName)
        {
            switch (sceneName)
            {
                case "AshCanyonRegion":
                    //Melonlogger.Msg("****************************** Modifying Ash Canyon");
                    ModifyAshCanyon();
                    break;
                case "AshCanyonRegion_SANDBOX":
                    //Melonlogger.Msg("****************************** Modifying Ash Canyon Sandbox");
                    ModifyAshCanyonSandbox();
                    break;
                default:
                    //Melonlogger.Msg($"****************************** No Ash Canyon route modifications for scene: {sceneName}");
                    break;
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // ASH CANYON
        // ------------------------------------------------------------------------------------------------------------------

        private static void ModifyAshCanyon()
        {
            //Melonlogger.Msg("****************************** Starting Ash Canyon modifications");

            void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
            {
                GameObject prefab = GameObject.Find(prefabName);
                SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
            }
            if (SaveDataManager.ashSnow == 0)
            {
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-264.1084f, 128.2418f, 427.6711f), new Vector3(0f, 77.2727f, 350f), new Vector3(0.55f, 8f, 0.6f));
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-255.3939f, 128.5015f, 435.8627f), new Vector3(17.4743f, 221.4987f, 37.2928f), new Vector3(0.4f, 3f, 0.4f));
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-257.994f, 136.5641f, 433.8904f), new Vector3(351.232f, 214.8323f, 48.2179f), new Vector3(0.4f, 2f, 0.4f));
                //Melonlogger.Msg("******************************Placed snow blockers");
            }
            else
            {
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-264.1084f, 112.842f, 427.6711f), new Vector3(0f, 77.2727f, 350f), new Vector3(0.55f, 8f, 0.6f));
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-263.2343f, 132.3051f, 440.145f), new Vector3(73.938f, 237.0918f, -0.0002f), new Vector3(0.3f, 2.5f, 0.3f));
                InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-273.3336f, 136.5641f, 433.8904f), new Vector3(351.232f, 214.8323f, 48.2179f), new Vector3(0.4f, 2f, 0.4f));
                //Melonlogger.Msg("******************************Receeded snow blockers");
            }




            // Disable ropes and anchors
            //Melonlogger.Msg("****************************** Disabling ropes and anchors");
            string[] objectsToDisable = new string[] {
                "Root/Art/Interactive/INTERACTIVE_RopeCliff_08_50m (3)/TRN_RockAnchor01",
                "Root/Art/Interactive/INTERACTIVE_RopeCliff_08_50m (3)/Rope_50m",
                "Root/Art/GrayBlock/INTERACTIVE_RopeCliff_08_50m/TRN_RockAnchor01",
                "Root/Art/GrayBlock/INTERACTIVE_RopeCliff_08_50m/Rope_50m",
                "Root/Art/GrayBlack/INTERACTIVE_RopeCliff_08_50m (2)/TRN_RockAnchor01",
                "Root/Art/GrayBlack/INTERACTIVE_RopeCliff_08_50m (2)/Rope_50m", // homesteaders
                "Root/Art/WestRidgeLogs/OBJ_TreeCedarFelledD2_Prefab",
                "Root/Art/Interactive/INTERACTIVE_RopeCliff_08_100m/Rope_100m/006",
                "Root/Art/Interactive/INTERACTIVE_RopeCliff_08_100m/Rope_100m/007",
                "Root/Art/Interactive/INTERACTIVE_RopeCliff_08_100m/Rope_100m/008"
            };
            RouteUtilities.DisableGameObjects(objectsToDisable);

            // Reposition structures and objects
            var structureObjects = new Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)>
            {
                // Marsh Cabin
                {"Root/Art/GrayBlack/STR_WoodCabinE_Prefab",
                    (new Vector3(330.2019f, 86.5745f, -739.4635f), new Vector3(-0f, 348.0889f, 0f), null)},
                
                // Foreman's Retreat
                {"Root/Art/MiningCamp/STR_WoodCabinD_Prefab",
                    (new Vector3(-101.3544f, 236.096f, -328.364f), new Vector3(-0, 344.5934f, 0f), null)},
                
                // Foreman's Retreat Fence 1
                {"Root/Art/MiningCamp/OBJ_WindbreakD_Prefab (6)",
                    (new Vector3(-111.5859f, 233.0978f, -324.812f), new Vector3(354f, 353.9094f, 0f), null)},
                
                // Foreman's Retreat Fence 2
                {"Root/Art/MiningCamp/OBJ_WindbreakD_Prefab (9)",
                    (new Vector3(-109.293f, 232.7976f, -334.8162f), new Vector3(25f, 151.6573f, 356f), null)},
                
                // Foreman's Retreat Shed
                {"Root/Art/MiningCamp/OBJ_SmallHutA_Prefab",
                    (new Vector3(-248.1807f, 199.7928f, -249.4052f), new Vector3(-0, 292.9999f, 0f), null)},
                
                // Foreman's Retreat Logbridge
                {"Root/Art/GrayBlock/WestPassage_Logs/OBJ_LogBridgeC_Prefab",
                    (new Vector3(-166.9765f, 192.61f, -447.198f), new Vector3(-0, 197.5786f, 33.6392f), new Vector3(.8f, .8f, 1f))},
                
                // Angler's Den
                {"Greybox/structures/STRSPAWN_LakeCabinF_Prefab",
                    (new Vector3(385.835f, 84.4025f, 262.5588f), new Vector3(-0, 59.4365f, 0f), new Vector3(1.2f, 1f, 1f))},
                
                // Angler's Den Vent
                {"Greybox/structures/OBJ_PVCVent_SingleTip_Prefab",
                    (new Vector3(384.6046f, 88.2955f, 260.439f), new Vector3(0f, 0f, 0f), null)},
                
                // Fallen Tree 1
                {"Root/Art/GrayBlock/WestPassage_Logs/OBJ_TreeCedarFelledD_Prefab (3)",
                    (new Vector3(-397.7316f, 48.7236f, -202.0091f), new Vector3(13f, 99.3421f, 121.39f), null)},
                
                // Fallen Tree 2
                {"Root/Art/GrayBlock/WestPassage_Logs/OBJ_TreeCedarFelledF_Prefab (1)",
                    (new Vector3(-597.6268f, 384.9f, 505.44f), new Vector3(0f, 98.0365f, 5f), null)},
                
                // Deployed Rope Climb near mine
                {"Root/Art/GrayBlock/INTERACTIVE_RopeCliff_08_100m (1)",
                    (new Vector3(-595.3011f, 286.6502f, 534.913f), new Vector3(0f, 196.5272f, 0f), null)},
                
                // Undeployed Rope Climb for shortcut
                {"Root/Art/Interactive/INTERACTIVE_RopeCliff_08_100m",
                    (new Vector3(306.496f, 44.6045f, -524.7137f), new Vector3(16.7078f, 318.6815f, 0.944f), null)},
                
                // Snow Drift for overlook
                {"Root/Art/SnowDrifts/TRN_SnowFlatB_Prefab (11)",
                    (new Vector3(-350.199f, 425.9f, 421.498f), new Vector3(47.2467f, 193.8584f, 349.5062f), new Vector3(1.2859f, 1.2859f, 1.5859f))},

                // Wood stand for wagon wheel
                {"Root/Art/MiningCamp/OBJ_WoodStand_B_Prefab (4)",
                    (new Vector3(320.9842f, 233.67f, 593.981f), new Vector3(357.1636f, 183.0888f, 1.4313f), new Vector3(1f, 1f, 1f))}
            };

            RouteUtilities.RepositionObjects(structureObjects, "structures and objects");

            // Disable central peak rock
            //Melonlogger.Msg("****************************** Disabling central peak rock");
            RouteUtilities.DisableChildrenByIndex("Root/Art/GrayBlock/CentralPeak_Rocks", new int[] { 27 });

            //Melonlogger.Msg("****************************** Completed Ash Canyon modifications");
        }

        // ------------------------------------------------------------------------------------------------------------------
        // ASH CANYON SANDBOX 
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyAshCanyonSandbox()
        {
            //Melonlogger.Msg("****************************** Starting Ash Canyon Sandbox modifications");

            // Disable rose hip climb shrub
            RouteUtilities.SafeDisable("Root/Design/Interactive/INTERACTIVE_RoseHipClimbShrubHarvest (3)");

            
            // Reposition misc objects
            var miscObjects = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                // Stick Spawners
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (6)",
                    (new Vector3(-218.99f, 203.65f, -307.62f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (9)",
                    (new Vector3(-142.35f, 229.35f, -230.10f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (26)",
                    (new Vector3(-195.95f, 206.46f, -348.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (36)",
                    (new Vector3(-141.95f, 202.90f, -302.34f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (46)",
                    (new Vector3(-269.62f, 198.31f, -218.14f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Spawners/Sticks/RadialSpawn_sticks (56)",
                    (new Vector3(-311.52f, 202.43f, -213.46f), new Vector3(0.0f, 0.0f, 0.0f))},
                
                // Branch Spawners
                {"Root/Design/NaturalResources/Fertile Riverlands/BranchSpawners/BigBranches/RadialSpawn_branches_soft (7)",
                    (new Vector3(-308.69f, 211.21f, -158.20f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Root/Design/NaturalResources/Fertile Riverlands/BranchSpawners/BigBranches/RadialSpawn_branches_soft (2)",
                    (new Vector3(-239.21f, 202.67f, -154.96f), new Vector3(0.0f, 0.0f, 0.0f))},
                
            };

            RouteUtilities.RepositionObjects(miscObjects, "misc objects");

            //Melonlogger.Msg("****************************** Completed Ash Canyon Sandbox modifications");
        }

        public static void RepositionPlayerSpawnPoints()
        {
            // Structure to hold spawn point data
            var spawnPoints = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                // Player Spawn Points
                {"Design/Scripting/PlayerSpawnPoints/StartRavine",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/StartCave",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/ChasmCave",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/ForestRidge",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/ChasmEnd",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/InterloperRiver",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))},
                {"Design/Scripting/PlayerSpawnPoints/InterloperMiddle",
                    (new Vector3(-396.10f, 51.83f, -204.83f), new Vector3(0.0f, 0.0f, 0.0f))}
            };

            RouteUtilities.RepositionObjects(spawnPoints, "player spawn points");
        }

        public static void ModifyBunker()
        {
            // Reposition bunker using unified method
            //Melonlogger.Msg("****************************** Repositioning bunker");
            var bunkerData = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                {
                    "Root/Design/BunkerHatch/INTERACTIVE_HatchRandomSelect_Prefab",
                    (new Vector3(295.6821f, 146.8913f, -418.0277f), new Vector3(0f, 0f, 0f))
                }
            };



            RouteUtilities.RepositionObjects(bunkerData, "bunker objects");
        }
    }
}