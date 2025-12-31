using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MelonLoader;

namespace PathfindersAscent.Placements
{
    internal static class AssetUtils
    {
        public static Dictionary<string, GameObject> cachedPrefabs = new Dictionary<string, GameObject>();
        static Dictionary<string, bool> loadingPrefabs = new Dictionary<string, bool>();

        public static IEnumerator LoadPrefabAsync(string prefabName, Action<GameObject> onComplete)
        {
            if (cachedPrefabs.ContainsKey(prefabName) && cachedPrefabs[prefabName] != null)
            {
                onComplete?.Invoke(cachedPrefabs[prefabName]);
                yield break;
            }

            if (loadingPrefabs.ContainsKey(prefabName) && loadingPrefabs[prefabName])
            {
                // Wait for the other load to complete
                while (loadingPrefabs[prefabName])
                {
                    yield return null;
                }
                onComplete?.Invoke(cachedPrefabs[prefabName]);
                yield break;
            }

            loadingPrefabs[prefabName] = true;
            yield return MelonCoroutines.Start(GeneratePrefabAsync(prefabName, onComplete));
            loadingPrefabs[prefabName] = false;
        }

        private static IEnumerator GeneratePrefabAsync(string prefabName, Action<GameObject> onComplete)
        {
            GameObject go = new GameObject();
            go.name = prefabName;

            MeshFilter meshFilter = go.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
            MeshCollider meshCollider = go.AddComponent<MeshCollider>();

            AsyncOperationHandle<Mesh> meshHandle = default;
            AsyncOperationHandle<Material> materialHandle = default;

            switch (prefabName)
            {
                case "OBJ_WoodPlankSingle":
                    meshHandle = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx");
                    yield return meshHandle;

                    materialHandle = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WoodPole_A02.mat");
                    yield return materialHandle;

                    meshFilter.sharedMesh = meshHandle.Result;
                    meshRenderer.sharedMaterial = materialHandle.Result;
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_MineRock23":
                    meshHandle = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Objects/OBJ_MineRocks/OBJ_MineRock23.fbx");
                    yield return meshHandle;

                    materialHandle = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Unique/OBJ_MineRocksA_Mat.mat");
                    yield return materialHandle;

                    meshFilter.sharedMesh = meshHandle.Result;
                    meshRenderer.sharedMaterial = materialHandle.Result;
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "OBJ_MineRock11":
                    meshHandle = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Objects/OBJ_MineRocks/OBJ_MineRock11.fbx");
                    yield return meshHandle;

                    materialHandle = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Unique/OBJ_MineRocksA_Mat.mat");
                    yield return materialHandle;

                    meshFilter.sharedMesh = meshHandle.Result;
                    meshRenderer.sharedMaterial = materialHandle.Result;
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;

                case "STR_CoastalHouseHFloorWood":
                    meshHandle = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Structures/STR_CoastalHouseH/STR_CoastalHouseHFloorWood.fbx");
                    yield return meshHandle;

                    materialHandle = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Materials/Global/GLB_WallWoodNatural_B03.mat");
                    yield return materialHandle;

                    meshFilter.sharedMesh = meshHandle.Result;
                    meshRenderer.sharedMaterial = materialHandle.Result;
                    meshCollider.sharedMesh = meshFilter.sharedMesh;
                    break;
            }

            cachedPrefabs[prefabName] = go;
            onComplete?.Invoke(go);
        }
    }
}