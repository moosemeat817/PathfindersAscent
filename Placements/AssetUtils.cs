using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PathfindersAscent.Placements
{
    internal static class AssetUtils
    {
        static Dictionary<string, GameObject> cachedPrefabs = new Dictionary<string, GameObject>();

        public static GameObject GetPrefab(string prefabName)
        {
            if (!cachedPrefabs.ContainsKey(prefabName))
            {
                GeneratePrefab(prefabName);
            }
            else if (cachedPrefabs.ContainsKey(prefabName) && cachedPrefabs[prefabName] == null)
            {
                cachedPrefabs.Remove(prefabName);
                GeneratePrefab(prefabName);
            }
            // Return the prefab reference directly instead of instantiating it
            return cachedPrefabs[prefabName];
        }

        private static void GeneratePrefab(string prefabName)
        {
            GameObject go = new GameObject();
            go.name = prefabName;

            MeshFilter meshFilter = go.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
            MeshCollider meshCollider = go.AddComponent<MeshCollider>();

            switch (prefabName)
            {
                case "OBJ_WoodPlankSingle":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodPole_A02.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_MineRock23":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Objects/OBJ_MineRocks/OBJ_MineRock23.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Unique/OBJ_MineRocksA_Mat.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_MineRock11":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Objects/OBJ_MineRocks/OBJ_MineRock11.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Unique/OBJ_MineRocksA_Mat.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "STR_CoastalHouseHFloorWood":
                    meshFilter.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseH/STR_CoastalHouseHFloorWood.fbx").WaitForCompletion();
                    meshRenderer.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WallWoodNatural_B03.mat").WaitForCompletion();
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

            }

            cachedPrefabs.Add(prefabName, go);
        }
    }
}