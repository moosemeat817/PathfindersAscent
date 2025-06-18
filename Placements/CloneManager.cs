using System;
using UnityEngine;

namespace PathfindersAscent.Placements
{
    public class CloneManager : MonoBehaviour
    {
        public static string[,] itemDataArray =
        {
            {"0_Scene", "1_Name"},
            {"BlackrockPrisonSurvivalZone", "STR_Infirmary_Exterior_Prefab"},
            {"BlackrockPrisonSurvivalZone", "STR_InfirmaryWing_Ext_Prefab"},
            {"BlackrockPrisonSurvivalZone", "OBJ_Fence_SecurityMetal_GateA_Prefab"},
            {"BlackrockRegion", "STR_BridgeTrussA_Prefab"},
            {"BlackrockRegion", "EP4_BlackRock_Single"},
            {"BlackrockRegion", "STR_StoneCabinA_Prefab"},
            {"BlackrockRegion", "INTERACTIVE_FirePlace"},
            {"CrashMountainRegion", "INTERACTIVE_FirePlace"},
            {"CrashMountainRegion", "STR_StoneCabinA_Prefab"},
            {"CrashMountainRegion", "CONTAINER_CargoCrate_LOD0"},
            {"AshCanyonRegion", "STR_cabinExteriorD_Damage_Prefab"},
        };

        public static void ChangeObjects()
        {
            for (int i = 1; i < itemDataArray.GetLength(0); i++)
            {
                GameObject findTargetGO = GameObject.Find(itemDataArray[i, 1]);
                if (findTargetGO == null || findTargetGO.scene.name != itemDataArray[i, 0])
                    continue;

                string sceneName = itemDataArray[i, 0];
                string objectName = itemDataArray[i, 1];

                switch (sceneName)
                {
                    case "BlackrockPrisonSurvivalZone":
                        HandleBlackrockPrison(findTargetGO, objectName);
                        break;
                    case "BlackrockRegion":
                        HandleBlackrockRegion(findTargetGO, objectName);
                        break;
                    case "CrashMountainRegion":
                        HandleCrashMountain(findTargetGO, objectName);
                        break;
                    case "AshCanyonRegion":
                        HandleAshCanyon(findTargetGO, objectName);
                        break;
                }
            }
        }

        private static void HandleBlackrockPrison(GameObject original, string objectName)
        {
            switch (objectName)
            {
                case "STR_Infirmary_Exterior_Prefab":
                    CreateCloneIfNotExists(original, "STR_Infirmary_Exterior_Prefab(Clone)",
                        new Vector3(-230.1069f, 230.3524f, 102.9275f),
                        Quaternion.Euler(1.2f, 332.5795f, 0.0f),
                        new Vector3(0.73f, 1f, 1.3f),
                        clone => {
                            clone.transform.GetChild(12).gameObject.SetActive(false);
                            clone.transform.GetChild(13).gameObject.SetActive(false);
                        });
                    break;

                case "OBJ_Fence_SecurityMetal_GateA_Prefab":
                    CreateCloneIfNotExists(original, "OBJ_Fence_SecurityMetal_GateA_Prefab2(Clone)",
                        new Vector3(-227.2538f, 227.1636f, 156.7752f),
                        Quaternion.Euler(0.0f, 329.8691f, 0.0f),
                        new Vector3(1.2f, 1.2f, 1.2f),
                        clone => clone.GetComponent<OpenClose>().CanInteract = false);
                    break;
            }
        }

        private static void HandleBlackrockRegion(GameObject original, string objectName)
        {
            switch (objectName)
            {
                case "STR_BridgeTrussA_Prefab":
                    CreateCloneIfNotExists(original, "STR_BridgeTrussA_Prefab(Clone)",
                        new Vector3(-631.8556f, 103.54f, -130.5659f),
                        Quaternion.Euler(0, 18.2896f, 7.6737f),
                        new Vector3(1f, 0.4f, 0.45f));
                    break;

                case "EP4_BlackRock_Single":
                    CreateCloneIfNotExists(original, "EP4_BlackRock_Single(Clone)",
                        new Vector3(-1409.566f, -395.6659f, -2920.385f),
                        Quaternion.identity,
                        new Vector3(1f, 0.4f, 0.45f));
                    break;

                case "STR_StoneCabinA_Prefab":
                    CreateCloneIfNotExists(original, "STR_StoneCabinA_Prefab(Clone)",
                        new Vector3(-349.5827f, 277.9972f, -150.3508f),
                        Quaternion.Euler(0f, 139.7852f, 0.0f),
                        Vector3.one,
                        clone => {
                            clone.transform.GetChild(0).gameObject.SetActive(false);
                            clone.transform.GetChild(12).gameObject.SetActive(false);
                            clone.transform.GetChild(15).gameObject.SetActive(false);
                        });

                    // Handle repair interaction and roof fix
                    HandleCabinRepair();

                    break;

                case "INTERACTIVE_FirePlace":
                    CreateCloneIfNotExists(original, "INTERACTIVE_FirePlace(Clone)",
                        new Vector3(-351.0852f, 278.2863f, -152.9111f),
                        Quaternion.Euler(0f, 41.2646f, 0f));
                    break;
            }
        }

        private static void HandleCrashMountain(GameObject original, string objectName)
        {
            switch (objectName)
            {
                case "CONTAINER_CargoCrate_LOD0":
                    // First crate
                    CreateCloneIfNotExists(original, "CONTAINER_CargoCrate_LOD0(Clone)",
                        new Vector3(1577.731f, 124.8122f, 435.9039f),
                        Quaternion.Euler(5.6238f, 70.2498f, 49.7736f));

                    // Second crate
                    CreateCloneIfNotExists(original, "CONTAINER_CargoCrate_LOD02(Clone)",
                        new Vector3(896.9089f, 226.375f, 700.7637f),
                        Quaternion.Euler(5.6238f, 70.2498f, 49.7736f));

                    // Third crate
                    CreateCloneIfNotExists(original, "CONTAINER_CargoCrate_LOD03(Clone)",
                        new Vector3(1486.77f, 220.2721f, 1632.949f),
                        Quaternion.Euler(6.424f, 211.2498f, 77.5065f));
                    break;

                case "STR_StoneCabinA_Prefab":
                    CreateCloneIfNotExists(original, "STR_StoneCabinA_Prefab(Clone)",
                        new Vector3(978.7657f, 514.4164f, 1305.089f),
                        Quaternion.Euler(0.34f, 322.5837f, 358.4498f),
                        Vector3.one,
                        clone => {
                            clone.transform.GetChild(0).gameObject.SetActive(false);
                            clone.transform.GetChild(12).gameObject.SetActive(false);
                            clone.transform.GetChild(15).gameObject.SetActive(false);
                        });

                    // Handle repair interaction and roof fix
                    HandleCabinRepair();
                    break;

                case "INTERACTIVE_FirePlace":
                    CreateCloneIfNotExists(original, "INTERACTIVE_FirePlace(Clone)",
                        new Vector3(980.2257f, 514.634f, 1307.617f),
                        Quaternion.Euler(0f, 221.386f, 359.9f));
                    break;
            }
        }

        private static void HandleAshCanyon(GameObject original, string objectName)
        {
            if (objectName == "STR_cabinExteriorD_Damage_Prefab")
            {
                // First cabin
                CreateCloneIfNotExists(original, "STR_cabinExteriorD_Damage_Prefab(Clone)",
                    new Vector3(55.016f, 72.6173f, 179.3412f),
                    Quaternion.Euler(0f, 266.4365f, 0f),
                    new Vector3(1.2f, 1f, 1f));

                // Second cabin
                CreateCloneIfNotExists(original, "STR_cabinExteriorD_Damage_Prefab2(Clone)",
                    new Vector3(736.7206f, 90.3804f, -313.9921f),
                    Quaternion.Euler(0f, 123.5161f, 0f),
                    new Vector3(1.2f, 1f, 1f));

                // Third cabin (duplicate position - might be intentional?)
                CreateCloneIfNotExists(original, "STR_cabinExteriorD_Damage_Prefab3(Clone)",
                    new Vector3(736.7206f, 90.3804f, -313.9921f),
                    Quaternion.Euler(0f, 123.5161f, 0f));
            }
        }

        private static void CreateCloneIfNotExists(GameObject original, string cloneName, Vector3 position,
            Quaternion rotation, Vector3? scale = null, Action<GameObject> postSetup = null)
        {
            if (GameObject.Find(cloneName) != null)
                return;

            GameObject clone = Instantiate(original, position, rotation);

            if (scale.HasValue)
                clone.transform.localScale = scale.Value;

            postSetup?.Invoke(clone);
        }

        private static void HandleCabinRepair()
        {
            GameObject roofInteract = GameObject.Find("STR_StoneCabinA_Prefab(Clone)/Repair/RepairInteract");
            if (roofInteract != null)
            {
                roofInteract.SetActive(false);
                Debug.Log("Repair interaction disabled successfully");
            }
            else
            {
                Debug.LogWarning("Failed to find repair interaction object");
            }
           
        }
    }
}