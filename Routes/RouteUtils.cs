using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace PathfindersAscent.Routes
{
    public static class RouteUtilities
    {
        // Utility method to disable game objects
        public static void DisableGameObjects(string[] objectPaths)
        {
            if (objectPaths == null)
            {
                MelonLogger.Warning("****************************** Object paths array is null");
                return;
            }

            MelonLogger.Msg("****************************** Disabling multiple game objects");
            int disabledCount = 0;
            foreach (string path in objectPaths)
            {
                if (string.IsNullOrEmpty(path))
                {
                    MelonLogger.Warning("****************************** Null or empty path found in array");
                    continue;
                }

                GameObject obj = GameObject.Find(path);
                if (obj != null)
                {
                    obj.SetActive(false);
                    disabledCount++;
                    MelonLogger.Msg($"****************************** Disabled object: {path}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find object to disable: {path}");
                }
            }
            MelonLogger.Msg($"****************************** Disabled {disabledCount} out of {objectPaths.Length} objects");
        }

        // Utility method for safely disabling objects (doesn't warn if not found)
        public static void SafeDisable(string objectPath)
        {
            if (string.IsNullOrEmpty(objectPath))
            {
                MelonLogger.Warning("****************************** Null or empty object path provided");
                return;
            }

            GameObject obj = GameObject.Find(objectPath);
            if (obj != null)
            {
                obj.SetActive(false);
                MelonLogger.Msg($"****************************** Safely disabled optional object: {objectPath}");
            }
            else
            {
                MelonLogger.Msg($"****************************** Optional object not found (this is expected): {objectPath}");
            }
        }

        // Utility method to disable children by index
        public static void DisableChildrenByIndex(string parentPath, int[] childIndices)
        {
            if (string.IsNullOrEmpty(parentPath))
            {
                MelonLogger.Warning("****************************** Null or empty parent path provided");
                return;
            }

            if (childIndices == null)
            {
                MelonLogger.Warning("****************************** Child indices array is null");
                return;
            }

            MelonLogger.Msg($"****************************** Disabling children by index for parent: {parentPath}");
            GameObject parent = GameObject.Find(parentPath);
            if (parent != null)
            {
                foreach (int index in childIndices)
                {
                    if (index >= 0 && index < parent.transform.childCount)
                    {
                        Transform child = parent.transform.GetChild(index);
                        if (child != null)
                        {
                            child.gameObject.SetActive(false);
                            MelonLogger.Msg($"****************************** Disabled child at index {index}");
                        }
                        else
                        {
                            MelonLogger.Warning($"****************************** Child at index {index} is null");
                        }
                    }
                    else
                    {
                        MelonLogger.Warning($"****************************** Child index {index} out of range for {parentPath} (childCount: {parent.transform.childCount})");
                    }
                }
            }
            else
            {
                MelonLogger.Warning($"****************************** Parent object not found: {parentPath}");
            }
        }

        // Utility method to enable children by index
        public static void EnableChildrenByIndex(string parentPath, int[] childIndices)
        {
            if (string.IsNullOrEmpty(parentPath))
            {
                MelonLogger.Warning("****************************** Null or empty parent path provided");
                return;
            }

            if (childIndices == null)
            {
                MelonLogger.Warning("****************************** Child indices array is null");
                return;
            }

            MelonLogger.Msg($"****************************** Enabling children by index for parent: {parentPath}");
            GameObject parent = GameObject.Find(parentPath);
            if (parent != null)
            {
                foreach (int index in childIndices)
                {
                    if (index >= 0 && index < parent.transform.childCount)
                    {
                        Transform child = parent.transform.GetChild(index);
                        if (child != null)
                        {
                            child.gameObject.SetActive(true);
                            MelonLogger.Msg($"****************************** Enabled child at index {index}");
                        }
                        else
                        {
                            MelonLogger.Warning($"****************************** Child at index {index} is null");
                        }
                    }
                    else
                    {
                        MelonLogger.Warning($"****************************** Child index {index} out of range for {parentPath} (childCount: {parent.transform.childCount})");
                    }
                }
            }
            else
            {
                MelonLogger.Warning($"****************************** Parent object not found: {parentPath}");
            }
        }

        // Basic utility method to reposition objects (position and rotation only)
        public static void RepositionObjects(Dictionary<string, (Vector3 position, Vector3 rotation)> objects, string objectType = "objects")
        {
            if (objects == null)
            {
                MelonLogger.Warning($"****************************** Objects dictionary is null for {objectType}");
                return;
            }

            MelonLogger.Msg($"****************************** Beginning {objectType} repositioning");

            int repositionedCount = 0;
            foreach (var obj in objects)
            {
                if (string.IsNullOrEmpty(obj.Key))
                {
                    MelonLogger.Warning($"****************************** Null or empty key found in {objectType} dictionary");
                    continue;
                }

                GameObject gameObj = GameObject.Find(obj.Key);
                if (gameObj != null)
                {
                    gameObj.transform.SetPositionAndRotation(
                        obj.Value.position,
                        Quaternion.Euler(obj.Value.rotation)
                    );
                    repositionedCount++;
                    MelonLogger.Msg($"****************************** Repositioned {objectType.TrimEnd('s')}: {obj.Key}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find {objectType.TrimEnd('s')} object: {obj.Key}");
                }
            }
            MelonLogger.Msg($"****************************** Repositioned {repositionedCount} {objectType}");
        }

        // Overloaded utility method to reposition objects with optional scaling
        public static void RepositionObjects(Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)> objects, string objectType = "objects")
        {
            if (objects == null)
            {
                MelonLogger.Warning($"****************************** Objects dictionary is null for {objectType}");
                return;
            }

            MelonLogger.Msg($"****************************** Beginning {objectType} repositioning");

            int repositionedCount = 0;
            foreach (var obj in objects)
            {
                if (string.IsNullOrEmpty(obj.Key))
                {
                    MelonLogger.Warning($"****************************** Null or empty key found in {objectType} dictionary");
                    continue;
                }

                GameObject gameObj = GameObject.Find(obj.Key);
                if (gameObj != null)
                {
                    gameObj.transform.SetPositionAndRotation(
                        obj.Value.position,
                        Quaternion.Euler(obj.Value.rotation)
                    );

                    // Apply scale if provided
                    if (obj.Value.scale.HasValue)
                    {
                        gameObj.transform.localScale = obj.Value.scale.Value;
                        MelonLogger.Msg($"****************************** Applied scale to {objectType.TrimEnd('s')}: {obj.Key}");
                    }

                    repositionedCount++;
                    MelonLogger.Msg($"****************************** Repositioned {objectType.TrimEnd('s')}: {obj.Key}");
                }
                else
                {
                    MelonLogger.Warning($"****************************** Failed to find {objectType.TrimEnd('s')} object: {obj.Key}");
                }
            }
            MelonLogger.Msg($"****************************** Repositioned {repositionedCount} {objectType}");
        }

        // Legacy method names for backwards compatibility
        public static void RepositionMiscObjects(Dictionary<string, (Vector3 position, Vector3 rotation)> objects)
        {
            RepositionObjects(objects, "misc objects");
        }

        public static void RepositionPlayerSpawnPoints(Dictionary<string, (Vector3 position, Vector3 rotation)> objects)
        {
            RepositionObjects(objects, "player spawn points");
        }
    }
}