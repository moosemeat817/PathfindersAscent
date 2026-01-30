using HarmonyLib;
using System;
using System.Reflection;

namespace PathfindersAscent.Routes
{
    /// <summary>
    /// This patches CoolHomeCandlelight's vulnerable method to add a try-catch wrapper
    /// We use a Transpiler to inject error handling into the bytecode
    /// </summary>
    [HarmonyPatch]
    internal class CoolHomeCandlelightErrorHandler
    {
        // This is a nuclear option - we'll just disable the patch by making it do nothing
        static bool Prepare()
        {
            try
            {
                // Check if CoolHomeCandlelight is loaded
                var candlelightAsm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "DynamicTemperatureCandlelight");
                return candlelightAsm != null;
            }
            catch
            {
                return false;
            }
        }

        static MethodBase TargetMethod()
        {
            try
            {
                var candlelightAsm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "DynamicTemperatureCandlelight");

                if (candlelightAsm == null)
                    return null;

                var coolHomeType = candlelightAsm.GetType("DynamicTemperatureCandlelight.DynamicTemperatureCandlelight");
                var patchClass = coolHomeType?.GetNestedType("LeaveOutdoorSceneWithCandlesPatch",
                    System.Reflection.BindingFlags.NonPublic);
                var prefixMethod = patchClass?.GetMethod("Prefix",
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

                return prefixMethod;
            }
            catch
            {
                return null;
            }
        }

        static Exception Finalizer(Exception __exception)
        {
            // Catch ArgumentNullException and suppress it
            if (__exception is ArgumentNullException ex && ex.ParamName == "key")
            {
                MelonLoader.MelonLogger.Msg($"[PA] Suppressed null key error in DynamicTemperatureCandlelight");
                return null; // Suppress the exception
            }
            return __exception;
        }
    }
}