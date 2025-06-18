using Il2CppTLD.Gameplay;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;
using Harmony;

namespace PathfindersAscent.Routes
{
    public class WildlifeManager
    {
        // Process wildlife for different regions
        public static void ProcessWildlife(string sceneName)
        {
                
            MelonLogger.Msg($"****************************** Processing wildlife for scene: {sceneName}");
            
            switch(sceneName)
            {
                case "AshCanyonRegion_SANDBOX_WILDLIFE":
                    ProcessAshCanyonWildlife();
                    break;
                case "BlackrockRegion_WILDLIFE":
                    ProcessBlackrockWildlife();
                    break;
                case "CrashMountainRegion_WILDLIFE":
                    ProcessTimberwolfMountainWildlife();
                    break;
                default:
                    MelonLogger.Msg($"****************************** No wildlife modifications needed for: {sceneName}");
                    break;
            }
        }

        
        // ------------------------------------------------------------------------------------------------------------------
        // ASH CANYON WILDLIFE
        // ------------------------------------------------------------------------------------------------------------------
        private static void ProcessAshCanyonWildlife()
        {
            MelonLogger.Msg("****************************** Ash Canyon WILDLIFE");
            
            // Enable wolf spawn regions
            // EnableWolfSpawnRegions("Root/Wolf_misc", new int[] { 4, 6, 5, -1, 1, 2, 3, 7 });
            
            // Enable specific objects
            GameObject.Find("Root/MinersFolly/SPAWNREGION_Wolf (2)").gameObject.SetActive(true);
            GameObject timberwolf = GameObject.Find("Root/Wolf_burntForest/SPAWNREGION_Timberwolf");
            if (timberwolf != null)
            {
                timberwolf.SetActive(true);
                timberwolf.transform.SetPositionAndRotation(
                    new Vector3(-42.01f, 127.77f, -95.57f), 
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                );
            }
            
            // Reposition moose and wolves
            RepositionAshCanyonAnimals();
        }
        
        private static void EnableWolfSpawnRegions(string basePath, int[] indices)
        {
            foreach (int index in indices)
            {
                string objectPath = index < 0 ? 
                    $"{basePath}/SPAWNREGION_Wolf" : 
                    $"{basePath}/SPAWNREGION_Wolf ({index})";
                    
                GameObject obj = GameObject.Find(objectPath);
                if (obj != null)
                {
                    obj.SetActive(true);
                    MelonLogger.Msg($"****************************** Enabled {objectPath}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find {objectPath}");
                }
            }
        }
        
        private static void RepositionAshCanyonAnimals()
        {
            // Dictionary to store moose repositioning data
            var mooseRepositioning = new Dictionary<string, Vector3> {
                { "Root/Moose/SPAWNREGION_Moose (2)", new Vector3(186.73f, 139.96f, -314.70f) },
                { "Root/Moose/SPAWNREGION_Moose (3)", new Vector3(427.59f, 56.49f, -465.23f) },
                { "Root/Moose/SPAWNREGION_Moose (4)", new Vector3(-15.68f, 127.09f, -33.12f) }
            };
            
            // Dictionary to store wolf repositioning data
            var wolfRepositioning = new Dictionary<string, Vector3> {
                { "Root/Wolf_misc/SPAWNREGION_Wolf", new Vector3(702.66f, 51.30f, -735.94f) },
                { "Root/Wolf_misc/SPAWNREGION_Wolf (2)", new Vector3(-74.85f, 78.42f, 148.91f) },
                { "Root/Wolf_misc/SPAWNREGION_Wolf (3)", new Vector3(-271.04f, 102.14f, 258.89f) },
                { "Root/Wolf_misc/SPAWNREGION_Wolf (4)", new Vector3(403.18f, 55.47f, -377.91f) },                
                { "Root/Wolf_misc/SPAWNREGION_Wolf (5)", new Vector3(682.62f, 247.24f, 188.53f) },
                { "Root/Wolf_misc/SPAWNREGION_Wolf (6)", new Vector3(5.47f, 77.88f, 348.90f) },
                { "Root/Wolf_misc/SPAWNREGION_Wolf (7)", new Vector3(-519.22f, 298.85f, 697.96f) },
                { "Root/Wolf_burntForest/SPAWNREGION_Wolf_pack", new Vector3(42.49f, 130.72f, -166.97f) },
                { "Root/Wolf_burntForest/SPAWNREGION_Timberwolf", new Vector3(42.49f, 130.72f, -166.97f) },
                { "Root/Wolf_burntForest/wolf_seperated/SPAWNREGION_Wolf (9)", new Vector3(42.05f, 131.11f, -170.57f) },
                { "Root/Wolf_burntForest/wolf_seperated/SPAWNREGION_Wolf (10)", new Vector3(79.20f, 126.08f, -347.21f) }
            };
            
            // Dictionary to store deer repositioning data
            var deerRepositioning = new Dictionary<string, Vector3> {
                { "Root/Deer/SPAWNREGION_Stag (1)", new Vector3(148.14f, 130.24f, -136.19f) },
                { "Root/Deer/SPAWNREGION_Stag (2)", new Vector3(-21.09f, 70.24f, 236.70f) },
                { "Root/Deer/SPAWNREGION_Stag (3)", new Vector3(-665.88f, 112.07f, 222.67f) },
                { "Root/Deer/SPAWNREGION_Stag (4)", new Vector3(637.06f, 225.93f, 74.44f) },
                { "Root/MinersFolly/Passive/SPAWNREGION_Stag", new Vector3(90.63f, 125.06f, -396.98f) }
            };

            // Dictionary to store deer repositioning data
            var rabbitRepositioning = new Dictionary<string, Vector3> {
                { "Root/Bunnies/SPAWNREGION_Rabbit", new Vector3(-210.27f, 211.90f, -150.07f) }
            };

            // Reposition moose, wolves, and deer
            RepositionGameObjects(mooseRepositioning);
            RepositionGameObjects(wolfRepositioning);
            RepositionGameObjects(deerRepositioning);
        }
        
        private static void RepositionGameObjects(Dictionary<string, Vector3> repositioningData)
        {
            foreach (var pair in repositioningData)
            {
                GameObject obj = GameObject.Find(pair.Key);
                if (obj != null)
                {
                    obj.transform.SetPositionAndRotation(
                        pair.Value, 
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                    );
                    MelonLogger.Msg($"****************************** Repositioned {pair.Key}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find {pair.Key}");
                }
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // BLACKROCK WILDLIFE
        // ------------------------------------------------------------------------------------------------------------------
        private static void ProcessBlackrockWildlife()
        {
            MelonLogger.Msg("****************************** Blackrock Wildlife");
            
            // Enable wolf spawn regions
            // EnableBlackrockWolves();
            
            // Reposition Timberwolves and other wildlife
            RepositionBlackrockAnimals();
            
            // Disable moose scratch decals
            DisableMooseScratchDecals("Design/Moose/Moose/Moose1/MooseScratchDecal_2 (1)");
            DisableMooseScratchDecals("Design/Moose/Moose/Moose2/MooseScratchDecal_2");
        }
        
        private static void EnableBlackrockWolves()
        {
            string[] wolfSpawnRegions = {
                "Design/Wolves/regular/SPAWNREGION_Wolf_ravine",
                "Design/Wolves/regular/SPAWNREGION_Wolf_ravine2",
                "Design/Wolves/regular/SPAWNREGION_Wolf_ravine3",
                "Design/Wolves/regular/SPAWNREGION_Wolf_workshopcreek",
                "Design/Wolves/regular/SPAWNREGION_Wolf_single_deadend"
            };
            
            foreach (string region in wolfSpawnRegions)
            {
                GameObject obj = GameObject.Find(region);
                if (obj != null)
                {
                    obj.SetActive(true);
                    MelonLogger.Msg($"****************************** Enabled {region}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find {region}");
                }
            }
        }
        
        private static void RepositionBlackrockAnimals()
        {
            // Dictionary for timberwolf repositioning
            var timberwolfRepositioning = new Dictionary<string, Vector3> {

                { "Design/Wolves/timber/MineLower/SPAWNREGION_Timberwolf_mineRoad1", new Vector3(-524.51f, 100.20f, -484.98f) },
                { "Design/Wolves/timber/MineLower/SPAWNREGION_Timberwolf_mineRoad2", new Vector3(-524.51f, 100.20f, -484.98f) },
                { "Design/Wolves/timber/MineLower/SPAWNREGION_Timberwolf_mineRoad3", new Vector3(-524.51f, 100.20f, -484.98f) },
                { "Design/Wolves/timber/MineLower/SPAWNREGION_Wolf_ForemanClearcut", new Vector3(-524.51f, 100.20f, -484.98f) },

                { "Design/Wolves/timber/MineUpper/SPAWNREGION_Timberwolf_forest", new Vector3(-466.04f, 81.76f, 398.23f) },
                { "Design/Wolves/timber/MineUpper/SPAWNREGION_Timberwolf_bridgecollapse", new Vector3(-466.04f, 81.76f, 398.23f) },
                { "Design/Wolves/timber/MineUpper/SPAWNREGION_Timberwolf_lake", new Vector3(-466.04f, 81.76f, 398.23f) },

                { "Design/Wolves/timber/Prison/SPAWNREGION_Timberwolf_road1", new Vector3(-9.86f, 158.21f, -526.55f) },
                { "Design/Wolves/timber/Prison/SPAWNREGION_Timberwolf_substation2", new Vector3(-9.86f, 158.21f, -526.55f) },
                { "Design/Wolves/timber/Prison/SPAWNREGION_Wolf_single_brokenbridge", new Vector3(-9.86f, 158.21f, -526.55f) },

                { "Design/Wolves/timber/Power/SPAWNREGION_Timberwolf_powerplant", new Vector3(-671.59f, 81.28f, 84.03f) },
                { "Design/Wolves/timber/Power/SPAWNREGION_Timberwolf_powerplant (1)", new Vector3(-671.59f, 81.28f, 84.03f) },
                { "Design/Wolves/timber/Power/SPAWNREGION_Wolf_single_powerplantgate", new Vector3(-671.59f, 81.28f, 84.03f) },

                { "Design/Wolves/timber/SPAWNREGION_Timberwolf_road2", new Vector3(288.44f, 187.48f, -122.64f) }
            };
            
            // Dictionary for regular wolf and other animal repositioning
            var otherRepositioning = new Dictionary<string, Vector3> {
                //{ "Design/Rabbits/SPAWNREGION_Rabbit (4)", new Vector3(-911.62f, 128.02f, 273.63f) },
                { "Design/Moose/Moose/Moose1/SPAWNREGION_Moose", new Vector3(746.20f, 298.34f, 340.20f) },
                { "Design/Moose/Moose/Moose2/SPAWNREGION_Moose", new Vector3(862.14f, 306.40f, 511.43f) },
                { "Design/Wolves/regular/SPAWNREGION_Wolf_ravine", new Vector3(-746.38f, 77.70f, 354.99f) },
                { "Design/Wolves/regular/SPAWNREGION_Wolf_ravine2", new Vector3(826.82f, 260.00f, 265.53f) },
                { "Design/Wolves/regular/SPAWNREGION_Wolf_ravine3", new Vector3(361.56f, 244.36f, 139.51f) },
                { "Design/Wolves/regular/SPAWNREGION_Wolf_workshopcreek", new Vector3(-861.35f, 77.46f, -314.72f) },
                { "Design/Wolves/regular/SPAWNREGION_Wolf_single_deadend", new Vector3(-637.94f, 82.77f, 355.04f) },

                { "Design/Deer/Deer_Herd/MineRoadherd/SPAWNREGION_Stag", new Vector3(-617.23f, 92.74f, -356.89f) },
                { "Design/Deer/Deer_Herd/Prisonherd/SPAWNREGION_Stag", new Vector3(-617.23f, 92.74f, -356.89f) },
                { "Design/Deer/Deer_Herd/Foragersherd/SPAWNREGION_Stag", new Vector3(-209.12f, 203.39f, -71.19f) },
                { "Design/Deer/Deer_Herd/Ruinedhouseherd/SPAWNREGION_Stag", new Vector3(447.60f, 242.75f, 179.57f) },
                { "Design/Deer/Deer_Herd/Lakeherd/SPAWNREGION_Stag", new Vector3(447.60f, 242.75f, 179.57f) },

                { "Design/Deer/Deer_Singles/SPAWNREGION_Stag", new Vector3(-890.41f, 90.66f, -438.05f) },

                { "Design/Rabbits/SPAWNREGION_Rabbit (6)", new Vector3(-282.95f, 240.95f, -252.89f) }

            };
            
            // Reposition timberwolves and other animals
            RepositionGameObjects(timberwolfRepositioning);
            RepositionGameObjects(otherRepositioning);
        }
        
        private static void DisableMooseScratchDecals(string decalPath)
        {
            GameObject decal = GameObject.Find(decalPath);
            if (decal != null)
            {
                decal.SetActive(false);
                MelonLogger.Msg($"****************************** Disabled moose scratch decal: {decalPath}");
            }
            else
            {
                MelonLogger.Warning($"****************************** Failed to find moose scratch decal: {decalPath}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // TIMBERWOLF MOUNTAIN WILDLIFE
        // ------------------------------------------------------------------------------------------------------------------
        private static void ProcessTimberwolfMountainWildlife()
        {
            MelonLogger.Msg("****************************** TWM WILDLIFE");
            
            // Reposition Timberwolves
            RepositionTWMTimberwolves();
            
            // Process TWM moose
            ProcessTWMMoose();
            
            // Enable and reposition wolf singles
            ProcessTWMWolfSingles();
            
            // Reposition wolf packs
            RepositionTWMWolfPacks();
            
            // Reposition deer
            RepositionTWMDeer();

            // Disable Chasm Bear Spawn and Bones
            GameObject.Find("WildlifeSpawns/BearSpawns/BearSpawnChasm").gameObject.SetActive(false);
        }
        
        private static void RepositionTWMTimberwolves()
        {
            var timberwolfRepositioning = new Dictionary<string, Vector3> {
                { "WildlifeSpawns/Wolves/CrystalLake_t/SPAWNREGION_TimberwolfLake", new Vector3(1291.52f, 169.03f, 318.63f) },
                { "WildlifeSpawns/Wolves/PlaneWing_t/SPAWNREGION_TimberwolfWing1", new Vector3(1348.94f, 146.73f, 436.22f) },
                { "WildlifeSpawns/Wolves/EricsFalls_t/SPAWNREGION_Timberwolf_ericfalls", new Vector3(505.17f, 346.90f, 1702.59f) }
            };
            
            RepositionGameObjects(timberwolfRepositioning);
            
            // Enable specific wolf
            GameObject surpriseWolf = GameObject.Find("WildlifeSpawns/Wolves/planesurprise/SPAWNREGION_Wolf");
            if (surpriseWolf != null)
            {
                surpriseWolf.SetActive(true);

                surpriseWolf.transform.SetPositionAndRotation(
                    new Vector3(745.23f, 208.71f, 83.22f),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                );
                MelonLogger.Msg("****************************** Enabled plane surprise wolf");
            }
        }
        
        private static void ProcessTWMMoose()
        {
            MelonLogger.Msg("****************************** TWM WILDLIFE - Moose 1");
            
            // Reposition first moose
            GameObject moose1 = GameObject.Find("WildlifeSpawns/Moose/MooseSetPlane/SPAWNREGION_Moose");
            if (moose1 != null)
            {
                moose1.transform.SetPositionAndRotation(
                    new Vector3(1049.91f, 260.44f, 1724.78f),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                );
                
                // Disable moose scratch decals
                DisableTWMMooseDecals("WildlifeSpawns/Moose/MooseSetPlane", "FX_DecalMooseScratchBirchTree_A01", 3, 5);
                DisableTWMMooseDecals("WildlifeSpawns/Moose/MooseSetPlane", "FX_DecalMooseScratchDeadTree_A01", 6, 8);
            }
            
            MelonLogger.Msg("****************************** TWM WILDLIFE - Moose 2");
            
            // Reposition second moose
            GameObject moose2 = GameObject.Find("WildlifeSpawns/Moose/MooseSetRiver/SPAWNREGION_Moose");
            if (moose2 != null)
            {
                moose2.transform.SetPositionAndRotation(
                    new Vector3(634.83f, 350.66f, 1809.21f),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                );
                
                // Disable moose scratch decals
                DisableTWMMooseDecals("WildlifeSpawns/Moose/MooseSetRiver", "FX_DecalMooseScratchDeadTree_A01", 2, 5);
            }
            
            // Reposition cargo moose
            GameObject cargoMoose = GameObject.Find("WildlifeSpawns/Wolves/Cargo_m/SPAWNREGION_Moose");
            if (cargoMoose != null)
            {
                cargoMoose.transform.SetPositionAndRotation(
                    new Vector3(476.75f, 356.41f, 1570.05f),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                );
            }
        }
        
        private static void DisableTWMMooseDecals(string basePath, string decalPrefix, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                string decalPath = $"{basePath}/{decalPrefix} ({i})";
                GameObject decal = GameObject.Find(decalPath);
                if (decal != null)
                {
                    decal.SetActive(false);
                    MelonLogger.Msg($"****************************** Disabled decal: {decalPath}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find decal: {decalPath}");
                }
            }
        }

        private static void ProcessTWMWolfSingles()
        {
            MelonLogger.Msg("****************************** TWM WILDLIFE - wolf singles");

            // Dictionary for wolf singles repositioning
            var wolfSingles = new Dictionary<string, Vector3> {
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_river", new Vector3(1579.20f, 125.14f, 464.06f) },
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_river2", new Vector3(445.00f, 272.88f, 1144.66f) },
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_nearcabin", new Vector3(1471.60f, 223.77f, 1752.81f) },
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_nearcabin (1)", new Vector3(1377.77f, 133.77f, 722.30f) },
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_chasm", new Vector3(1442.98f, 128.52f, 501.27f) },
        { "WildlifeSpawns/Wolves/SPAWNREGION_Wolf_peak", new Vector3(980.24f, 264.47f, 1739.66f) }
            };

            foreach (var wolf in wolfSingles)
            {
                GameObject wolfObj = GameObject.Find(wolf.Key);
                if (wolfObj != null)
                {
                    wolfObj.SetActive(true);

                    wolfObj.transform.SetPositionAndRotation(
                        wolf.Value,
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))
                    );

                    MelonLogger.Msg($"****************************** Processed wolf: {wolf.Key}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find wolf: {wolf.Key}");
                }
            }
        }

        private static void RepositionTWMWolfPacks()
        {
            MelonLogger.Msg("****************************** TWM WILDLIFE - Packs");
            
            // Dictionary for wolf pack repositioning
            var wolfPacks = new Dictionary<string, Vector3> {
                { "WildlifeSpawns/Wolves/CrystalLake_t/SPAWNREGION_Wolf_lakePack", new Vector3(1291.52f, 169.03f, 318.63f) },
                { "WildlifeSpawns/Wolves/CrystalLake_t/SPAWNREGION_Wolf_lakeSmall", new Vector3(1291.52f, 169.03f, 318.63f) },
                { "WildlifeSpawns/Wolves/CrystalLake_t/SPAWNREGION_Wolf_lakeSmall2", new Vector3(1291.52f, 169.03f, 318.63f) },
                { "WildlifeSpawns/Wolves/PlaneWing_t/SPAWNREGION_Wolf_planewing", new Vector3(1348.94f, 146.73f, 436.22f) },
                { "WildlifeSpawns/Wolves/Cargo_m/SPAWNREGION_Wolf_cargoBig", new Vector3(1512.90f, 208.04f, 1398.02f) },
                { "WildlifeSpawns/Wolves/Cargo_m/SPAWNREGION_Wolf_cargoSml", new Vector3(1512.90f, 208.04f, 1398.02f) },
                { "WildlifeSpawns/Wolves/Cargo_m/SPAWNREGION_Moose", new Vector3(1512.90f, 208.04f, 1398.02f) },
                { "WildlifeSpawns/Wolves/UpperChasm/SPAWNREGION_Wolf_upperChasm1", new Vector3(534.34f, 165.65f, 312.36f) },
                { "WildlifeSpawns/Wolves/UpperChasm/SPAWNREGION_Wolf_upperChasm2", new Vector3(534.34f, 165.65f, 312.36f) },
                { "WildlifeSpawns/Wolves/UpperChasm/SPAWNREGION_Wolf_upperChasm3", new Vector3(534.34f, 165.65f, 312.36f) }
            };
            
            RepositionGameObjects(wolfPacks);
            
        }
        
        private static void RepositionTWMDeer()
        {
            MelonLogger.Msg("****************************** TWM WILDLIFE - deer");
            
            // Dictionary for deer repositioning
            var deer = new Dictionary<string, Vector3> {
                
                { "WildlifeSpawns/Deer/SPAWNREGION_Stag_planewing", new Vector3(1475.26f, 125.33f, 459.27f) },
                { "WildlifeSpawns/Deer/SPAWNREGION_Stag_lake", new Vector3(1543.4f, 152.29f, 229.99f) },
                { "WildlifeSpawns/Deer/SPAWNREGION_Stag_neardeerclearing", new Vector3(325.95f, 366.89f, 1593.03f) },
            };
            
            RepositionGameObjects(deer);
        }
    }
}