using HarmonyLib;
using System;
using System.Reflection;
using CoolHome;
using UnityEngine;

namespace PathfindersAscent.Routes
{
    /// <summary>
    /// Patches for CoolHome to add null checks that prevent crashes when IndoorSpaceTriggers have invalid ObjectGuids
    /// </summary>
    [HarmonyPatch(typeof(InteriorSpaceManager), nameof(InteriorSpaceManager.EnterOutdoorScene))]
    internal class EnterOutdoorScenePatch
    {
        static bool Prefix(InteriorSpaceManager __instance)
        {
            try
            {
                var trackedSpacesField = typeof(InteriorSpaceManager).GetField("TrackedSpaces",
                    BindingFlags.Public | BindingFlags.Instance);

                if (trackedSpacesField == null)
                    return true;

                var triggers = UnityEngine.Object.FindObjectsOfType<Il2Cpp.IndoorSpaceTrigger>();

                foreach (Il2Cpp.IndoorSpaceTrigger ist in triggers)
                {
                    try
                    {
                        Il2Cpp.ObjectGuid id = ist.GetComponent<Il2Cpp.ObjectGuid>();

                        // Skip if no ObjectGuid or if PDID is null/empty
                        if (id == null || string.IsNullOrEmpty(id.PDID))
                            continue;

                        string name = id.PDID;
                        var trackedSpaces = trackedSpacesField.GetValue(__instance)
                            as System.Collections.Generic.Dictionary<string, GameObject>;

                        if (trackedSpaces != null && trackedSpaces.ContainsKey(name))
                        {
                            WarmingWalls ww = trackedSpaces[name].GetComponent<WarmingWalls>();
                            if (ww != null)
                                ww.RemoveShadowHeaters();
                        }
                    }
                    catch
                    {
                        // Silently skip any triggers that cause issues
                        continue;
                    }
                }

                return false; // Skip the original method since we've handled it
            }
            catch
            {
                return true; // Let original method run if something goes wrong
            }
        }
    }

    /// <summary>
    /// Patch InteriorSpaceManager.LeaveOutdoorScene to handle null trigger names
    /// </summary>
    [HarmonyPatch(typeof(InteriorSpaceManager), nameof(InteriorSpaceManager.LeaveOutdoorScene))]
    internal class LeaveOutdoorScenePatch
    {
        static bool Prefix(InteriorSpaceManager __instance)
        {
            try
            {
                var trackedSpacesField = typeof(InteriorSpaceManager).GetField("TrackedSpaces",
                    BindingFlags.Public | BindingFlags.Instance);
                var registeredHeatersField = typeof(InteriorSpaceManager).GetField("RegisteredHeaters",
                    BindingFlags.Public | BindingFlags.Instance);

                if (trackedSpacesField == null || registeredHeatersField == null)
                    return true;

                var trackedSpaces = trackedSpacesField.GetValue(__instance)
                    as System.Collections.Generic.Dictionary<string, GameObject>;
                var registeredHeaters = registeredHeatersField.GetValue(__instance)
                    as System.Collections.Generic.Dictionary<string, WarmingWalls>;

                if (trackedSpaces == null || registeredHeaters == null)
                    return true;

                Il2Cpp.IndoorSpaceTrigger[] triggers = UnityEngine.Object.FindObjectsOfType<Il2Cpp.IndoorSpaceTrigger>();
                System.Collections.Generic.List<WarmingWalls> wallComponents = new System.Collections.Generic.List<WarmingWalls>();

                foreach (Il2Cpp.IndoorSpaceTrigger ist in triggers)
                {
                    try
                    {
                        Il2Cpp.ObjectGuid id = ist.GetComponent<Il2Cpp.ObjectGuid>();

                        // Skip if no ObjectGuid or if PDID is null/empty
                        if (id == null || string.IsNullOrEmpty(id.PDID))
                            continue;

                        string name = id.PDID;
                        WarmingWalls ww = trackedSpaces.ContainsKey(name) && trackedSpaces[name] is not null
                            ? trackedSpaces[name].GetComponent<WarmingWalls>()
                            : null;

                        if (ww is not null)
                            wallComponents.Add(ww);
                    }
                    catch
                    {
                        // Silently skip any triggers that cause issues
                        continue;
                    }
                }

                return false; // Skip the original method
            }
            catch
            {
                return true; // Let original method run if something goes wrong
            }
        }
    }
}