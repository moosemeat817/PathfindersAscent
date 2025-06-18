using Il2CppTLD.Gameplay;
using Il2CppTLD.Gameplay.Tunable;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;
using PathfindersAscent;
using Harmony;

namespace PathfindersAscent.Cargo
{
    public static class CargoContainerManager
    {
        /// <summary>
        /// Configures cargo containers based on the current game mode and scene
        /// </summary>
        /// <param name="sceneName">The current scene name</param>
        /// <param name="cargoContainersEnabled">Whether cargo containers feature is enabled</param>
        public static void ConfigureCargoContainers(string sceneName, bool cargoContainersEnabled)
        {
            if (!cargoContainersEnabled || sceneName != "CrashMountainRegion")
            {
                //MelonLogger.Msg("****************************** Cargo container configuration skipped - feature disabled or wrong scene");
                return;
            }

            //MelonLogger.Msg("****************************** Configuring Cargo Containers");

            ExperienceModeType currentMode = ExperienceModeManager.GetCurrentExperienceModeType();
            //MelonLogger.Msg($"****************************** Current game mode: {currentMode}");

            // Handle lower difficulty modes (Pilgrim, Voyageur, Stalker)
            if (currentMode == ExperienceModeType.Pilgrim ||
                currentMode == ExperienceModeType.Voyageur ||
                currentMode == ExperienceModeType.Stalker)
            {
                //MelonLogger.Msg("****************************** Using standard difficulty container configuration");
                ConfigureStandardDifficultyContainers();
            }
            // Handle Interloper and custom modes with minimal resources
            else if (currentMode == ExperienceModeType.Interloper ||
                     currentMode == ExperienceModeType.Misery ||
                     GameManager.GetCustomMode().m_BaseResourceAvailability == CustomTunableLMHV.Low)
            {
                //MelonLogger.Msg("****************************** Using Interloper/minimal resources container configuration");
                ConfigureInterlopeDifficultyContainers();
            }
            else
            {
                //MelonLogger.Msg("****************************** Using standard difficulty container configuration for custom mode");
                ConfigureStandardDifficultyContainers();
            }
            
            // Call MapPatch to hide cargo containers from the map
            // MelonLogger.Msg("****************************** Calling MapPatch to hide cargo containers on map");

        }

        /// <summary>
        /// Configures containers for standard difficulty modes (Pilgrim, Voyageur, Stalker)
        /// </summary>
        private static void ConfigureStandardDifficultyContainers()
        {
            //MelonLogger.Msg("****************************** Configuring STALKER, VOYAGEUR, PILGRIM cargo containers");

            // Define cargo container positions and rotations
            var containerPositions = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                {"Design/Loot/CargoCaches/cargo_wing/CONTAINER_CargoCrate_foodA_drinkC",
                    (new Vector3(1387.79f, 239.25f, 121.77f), new Vector3(0.0f, 108f, 84.0182f))},
                {"Design/Loot/CargoCaches/cargo_deerclearing/CONTAINER_CargoCrate_clothesB_shoes",
                    (new Vector3(290.5982f, 264.1899f, 337.81f), new Vector3(26.4546f, 65.9727f, 14.7273f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_foodRareA_drinkA",
                    (new Vector3(543.28f, 337.47f, 995.75f), new Vector3(335.9454f, 0.0f, 85.5273f))},
                {"Design/Loot/CargoCaches/cargo_chasm/CONTAINER_CargoCrate_foodC_drinkB",
                    (new Vector3(1561.29f, 229.03f, 1235.52f), new Vector3(14.0001f, 0.0f, 76f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_foodRareB_drinkB", // 15
                    (new Vector3(1435.36f, 231.07f, 1478.78f), new Vector3(313.1957f, 188.8722f, 55.1275f))},
                {"Design/Loot/CargoCaches/cargo_chasm/CONTAINER_CargoCrate_fire_clothesA",
                    (new Vector3(609.03f, 423.44f, 1629.7f), new Vector3(0.1418f, 0.0f, 78.8182f))},
                {"Design/Loot/CargoCaches/cargo_waterfall/CONTAINER_CargoCrate_foodA_medical", // 14
                    (new Vector3(1617.34f, 159.76f, 1163.34f), new Vector3(344.8727f, 0f, 57.6605f))},
                {"Design/Loot/CargoCaches/cargo_wing/CONTAINER_CargoCrate_miscC_medical",
                    (new Vector3(1229.51f, 263.54f, 1752.98f), new Vector3(0.0f, 0.0f, 88f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_clothingRareC_fire", // 4
                    (new Vector3(925.325f, 469.322f, 1176.702f), new Vector3(358.9965f, 4.3337f, 5.0104f))},
                {"Design/Loot/CargoCaches/cargo_deerclearing/CONTAINER_CargoCrate_materialsB_miscA", // 9
                    (new Vector3(248.23f, 271.18f, 660.96f), new Vector3(347F, -0F, 48.7001f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_tools_materialsRareB", // 3
                    (new Vector3(926.103f, 470.215f, 1174.272f), new Vector3(334.4111f, 319.5067f, 63.4426f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_miscRareA_drinkC", // 7
                    (new Vector3(248.34f, 375.56f, 1540.64f), new Vector3(344.8727f, 0.0f, 137.0909f))},
                {"Design/Loot/CargoCaches/cargo_lakeledge/CONTAINER_CargoCrate_foodB_drinkA", //
                    (new Vector3(1133.22f, 56.8f, 980.7299f), new Vector3(1.3635f, 141f, 22.7273f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_clothingRareA_clothingRareB",
                    (new Vector3(930.989f, 470.535f, 1166.092f), new Vector3(347.6166f, 171.5692f, 82.0898f))},
                {"Design/Loot/PlaneTailStuff/CONTAINER_CargoCrate_rifle_medicalRare",
                    (new Vector3(810.05f, 506.9f, 1477.5f), new Vector3(36.1273f, 0.0f, 64.5273f))},
                {"Design/Loot/CargoCaches/cargo_lakeledge/CONTAINER_CargoCrate_clothesC_miscB", // 5
                    (new Vector3(853.71f, 349.78f, 1813.75f), new Vector3(29.6001f, 188.8724f, 55.1273f))},
                {"Design/Loot/CargoCaches/cargo_creek/CONTAINER_CargoCrate_clothesC_foodC", // 13
                    (new Vector3(965.69f, 271.10f, 1736.64f), new Vector3(342.6876f, 300f, 80.8926f))}

            };

            // Position all containers
            PositionContainers(containerPositions);
        }

        /// <summary>
        /// Configures containers for Interloper and other low resource modes
        /// </summary>
        private static void ConfigureInterlopeDifficultyContainers()
        {
            // Reposition the Interloper spawn point
            GameObject interloperSpawn = GameObject.Find("Design/Scripting/PlayerSpawnPoints/InterloperCrashPeak");
            if (interloperSpawn != null)
            {
                interloperSpawn.transform.SetPositionAndRotation(
                    new Vector3(262.48f, 287.67f, 371.77f),
                    Quaternion.Euler(Vector3.zero)
                );
                //MelonLogger.Msg("****************************** Repositioned Interloper spawn point");
            }
            else
            {
                //MelonLogger.Warning("****************************** Could not find Interloper spawn point");
            }

            //MelonLogger.Msg("****************************** Configuring INTERLOPER or MISERY cargo containers");

            // Define cargo container positions and rotations for Interloper difficulty
            var containerPositions = new Dictionary<string, (Vector3 position, Vector3 rotation)>
            {
                {"Design/Loot/CargoCaches/Interloper_set/CONTAINER_CargoCrate_foodA_drinkB",
                    (new Vector3(248.34f, 375.56f, 1540.64f), new Vector3(344.8727f, 0.0f, 137.0909f))},
                {"Design/Loot/CargoCaches/Interloper_set/CONTAINER_CargoCrate_ClothingB_ClothingA",
                    (new Vector3(290.5982f, 264.1899f, 337.81f), new Vector3(26.4546f, 65.9727f, 14.7273f))},
                {"Design/Loot/CargoCaches/Interloper_set/CONTAINER_CargoCrate_materialsB_miscA (1)", //
                    (new Vector3(610.79f, 422.49f, 1626.84f), new Vector3(3.6878f, 300f, 61.04f))},
                {"Design/Loot/PlaneTailStuff/InterloperOnly_Cargo/CONTAINER_CargoCrate_medical_materialsRare",
                    (new Vector3(925.325f, 469.322f, 1176.702f), new Vector3(358.9965f, 4.3337f, 5.0104f))},
                {"Design/Loot/PlaneTailStuff/InterloperOnly_Cargo/CONTAINER_CargoCrate_foodA_drinkA (1)",
                    (new Vector3(926.103f, 470.215f, 1174.272f), new Vector3(334.4111f, 319.5067f, 63.4426f))},
                {"Design/Loot/PlaneTailStuff/InterloperOnly_Cargo/CONTAINER_CargoCrate_foodC_drinkB (1)",
                    (new Vector3(810.05f, 506.9f, 1477.5f), new Vector3(36.1273f, 0.0f, 64.5273f))},
                {"Design/Loot/PlaneTailStuff/InterloperOnly_Cargo/CONTAINER_CargoCrate_shoes_clothingC (1)",
                    (new Vector3(930.989f, 470.535f, 1166.092f), new Vector3(347.6166f, 171.5692f, 82.0898f))}
            };

            // Position all containers
            PositionContainers(containerPositions);
        }

        /// <summary>
        /// Positions cargo containers according to the provided dictionary
        /// </summary>
        /// <param name="containerPositions">Dictionary mapping container paths to position/rotation tuples</param>
        private static void PositionContainers(Dictionary<string, (Vector3 position, Vector3 rotation)> containerPositions)
        {
            int successCount = 0;
            int failCount = 0;

            foreach (var container in containerPositions)
            {
                GameObject obj = GameObject.Find(container.Key);
                if (obj != null)
                {
                    obj.transform.SetPositionAndRotation(
                        container.Value.position,
                        Quaternion.Euler(container.Value.rotation)
                    );
                    successCount++;
                    //MelonLogger.Msg($"****************************** Positioned container: {container.Key}");
                }
                else
                {
                    failCount++;
                    //MelonLogger.Warning($"****************************** Could not find container: {container.Key}");
                }
            }

            //MelonLogger.Msg($"****************************** Successfully positioned {successCount} containers, failed to find {failCount} containers");
        }
    }
}