using Il2CppTLD.Gameplay;
using Il2CppTLD.Gameplay.Tunable;
using MelonLoader;
using MelonLoader.Utils;
using PathfindersAscent.Cargo;
using PathfindersAscent.Placements;
using PathfindersAscent.Routes;
using PathfindersAscent.SaveData;
using UnityEngine.Rendering.PostProcessing;
using ModData;
using HarmonyLib;
using UnityEngine;

namespace PathfindersAscent
{
    public class Main : MelonMod
    {
        private static readonly string[] EXTREME_ROUTE_SCENES = {
            "BlackrockPrisonSurvivalZone",
            "AshCanyonRegion",
            "CrashMountainRegion",
            "BlackrockRegion"
        };

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initializing Pathfinder's Ascent Mod");
            try
            {
                Settings.OnLoad();
                //MelonLogger.Msg("Settings loaded successfully");
            }
            catch (System.Exception ex)
            {
                //MelonLogger.Error($"Failed to load settings: {ex.Message}");
            }


        }

        public static void DisableMapDetail(GameObject obj)
        {
            if (!IsModEnabled()) return;

            if (obj == null)
            {
                //MelonLogger.Warning("DisableMapDetail called with null GameObject");
                return;
            }

            string activeScene = GameManager.m_ActiveScene;
            if (activeScene != "CrashMountainRegion")
                return;

            //MelonLogger.Msg("MapPatch - Processing CrashMountainRegion");

            var mapDetail = obj.GetComponent<MapDetail>();
            if (mapDetail != null)
            {
                mapDetail.enabled = false;
                //MelonLogger.Msg("MapPatch - MapDetail component disabled");
            }
        }


        public void UpdateGateDoor(int newValue)
        {
            SaveDataManager.gateDoor = newValue;
            SaveDataManager.SaveData(); // Save immediately when changed
            //MelonLogger.Msg("******************************UpdateGateDoor Saved!");
        }


        public void UpdateFenceShift(int newValue)
        {
            SaveDataManager.fenceShift = newValue;
            SaveDataManager.SaveData(); // Save immediately when changed
            //MelonLogger.Msg("******************************UpdateFenceShift Saved!");
        }


        public void UpdateAshSnow(int newValue)
        {
            SaveDataManager.ashSnow = newValue;
            SaveDataManager.SaveData(); // Save immediately when changed
            //MelonLogger.Msg("******************************UpdateAshSnow Saved!");
        }


        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            //MelonLogger.Msg($"****************************** Scene initialized: {sceneName} (Build Index: {buildIndex})");

            // REPAIR OBJECTGUIDS FIRST - Before any other processing
            // This must happen before CoolHome tries to access triggers
            if (IsExtremeRouteScene(sceneName))
            {
                //ObjectGuidRepair.RepairAllIndoorSpaceTriggers();
            }

            if (IsModEnabled())
            {

                // Reset on main menu
                if (GameManager.IsMainMenuActive())
                {
                    SaveDataManager.ResetData();
                }
                // Load data when entering game scenes
                else if (sceneName != "Empty" && sceneName != "Boot")
                {
                    if (sceneName == "AshCanyonRegion_SANDBOX")
                    {
                        MelonLogger.Msg("Calling AshCanyonManager immediately for sandbox");
                        AshCanyonManager.ProcessAshCanyonRoutes(sceneName);
                    }
                    else if (sceneName == "BlackrockRegion_SANDBOX")
                    {
                        MelonLogger.Msg("Calling BlackrockManager immediately for sandbox");
                        BlackrockManager.ProcessBlackrockRoutes(sceneName);
                    }
                    /*
                    else if (sceneName == "CrashMountainRegion_SANDBOX")
                    {
                        MelonLogger.Msg("Calling TimberwolfMountainManager immediately for sandbox");
                        TimberwolfMountainManager.ProcessTimberwolfMountainRoutes(sceneName);
                    }
                    */
                    else if (!sceneName.Contains("_"))
                    {
                        MelonCoroutines.Start(SaveDataManager.LoadDataAndThen(() => ProcessSceneRoutes(sceneName)));

                    }
                }


                // Call the appropriate region manager based on the scene name
                //ProcessSceneRoutes(sceneName);
            }
            else
            {
                MelonLogger.Msg("****************************** Mod is Disabled");
            }
        }



        private void ProcessSceneRoutes(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                //MelonLogger.Warning("ProcessSceneRoutes called with null or empty scene name");
                return;
            }

            //MelonLogger.Msg($"Processing routes for {sceneName}");

            if (sceneName.Contains("Blackrock"))
            {
                //MelonLogger.Msg("Calling BlackrockManager");
                BlackrockManager.ProcessBlackrockRoutes(sceneName);
            }
            else if (sceneName.Contains("AshCanyon"))
            {
                //MelonLogger.Msg("Calling AshCanyonManager");
                AshCanyonManager.ProcessAshCanyonRoutes(sceneName);
            }
            else if (sceneName.Contains("CrashMountain"))
            {
                //MelonLogger.Msg("Calling TimberwolfMountainManager");
                TimberwolfMountainManager.ProcessTimberwolfMountainRoutes(sceneName);
            }
            else
            {
                //MelonLogger.Msg($"No extreme route modifications for scene: {sceneName}");
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "CrashMountainRegion_WILDLIFE")
            {
                // Disable Chasm Bear Spawn and Bones
                GameObject.Find("WildlifeSpawns/BearSpawns/BearSpawnChasm").gameObject.SetActive(false);
            }

            if (string.IsNullOrEmpty(sceneName))
            {
                //MelonLogger.Warning("OnSceneWasLoaded called with null or empty scene name");
                return;
            }

            if (!IsModEnabled())
            {
                //MelonLogger.Msg("Pathfinders Ascent mod is disabled - skipping scene loading operations");
                return;
            }

            ProcessSceneSpecificUpdates(sceneName);
            ProcessCommonSceneOperations(sceneName);

            /*
            if (!Settings.options.disableWildlife)
            {
                ProcessWildlife(sceneName);
            }
            */

            if (sceneName == "CrashMountainRegion_SANDBOX")
            {
                //MelonLogger.Msg("Calling TimberwolfMountainManager immediately for sandbox");
                TimberwolfMountainManager.ProcessTimberwolfMountainRoutes(sceneName);
            }
            else if (sceneName == "BlackrockRegion_SANDBOX")
            {
                //MelonLogger.Msg("Calling BlackrockManager immediately for sandbox");
                BlackrockManager.ModifyBunker();
            }
            else if (sceneName == "AshCanyonRegion_SANDBOX")
            {
                //MelonLogger.Msg("Calling AshCanyonManager immediately for sandbox");
                AshCanyonManager.ModifyBunker();
            }
        }

        private void ProcessSceneSpecificUpdates(string sceneName)
        {
            switch (sceneName)
            {
                case "AshMine":
                    if (SaveDataManager.ashSnow == 0)
                    {
                        UpdateAshSnow(1);
                    }
                    break;
                case "BlackrockInteriorASurvival":
                    if (SaveDataManager.fenceShift == 0)
                    {
                        UpdateFenceShift(1);
                    }
                    break;
                case "BlackrockPrisonSurvivalZone":
                    if (SaveDataManager.gateDoor == 0)
                    {
                        UpdateGateDoor(1);
                    }
                    break;
            }
        }

        private void ProcessCommonSceneOperations(string sceneName)
        {
            if (!IsExtremeRouteScene(sceneName))
                return;

            try
            {
                //MelonLogger.Msg("Calling PlaceTerrain");
                PlacementManager.PlaceTerrain();

                //MelonLogger.Msg("Calling PlaceAssets");
                MelonCoroutines.Start(PlacementManager.PlaceAssetsAsync());

                //MelonLogger.Msg("Calling Clones");
                CloneManager.ChangeObjects();

                ProcessSceneSpecificSpawns(sceneName);
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error processing common scene operations for {sceneName}: {ex.Message}");
            }
        }

        private void ProcessSceneSpecificSpawns(string sceneName)
        {
            switch (sceneName)
            {
                case "BlackrockRegion":
                    //MelonLogger.Msg("Processing Blackrock Spawns");
                    BlackrockManager.RepositionPlayerSpawnPoints();
                    break;
                case "AshCanyonRegion":
                    //MelonLogger.Msg("Processing Ash Canyon Spawns");
                    AshCanyonManager.RepositionPlayerSpawnPoints();
                    break;
                case "CrashMountainRegion":
                    //MelonLogger.Msg("Processing Timberwolf Mountain Spawns");
                    TimberwolfMountainManager.RepositionPlayerSpawnPoints();
                    break;
            }
        }

        private bool IsExtremeRouteScene(string sceneName) =>
            System.Array.Exists(EXTREME_ROUTE_SCENES, scene => scene == sceneName);

        private void ProcessWildlife(string sceneName)
        {
            //MelonLogger.Msg("Wildlife Relocation enabled - Processing wildlife");
            WildlifeManager.ProcessWildlife(sceneName);
        }

        /// <summary>
        /// Helper method to check if the mod is enabled via settings
        /// </summary>
        private static bool IsModEnabled()
        {
            return Settings.options != null && Settings.options.pathfindersAscent;
        }


    }
}