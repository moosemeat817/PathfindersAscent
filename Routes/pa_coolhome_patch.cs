using HarmonyLib;
using System;
using System.Reflection;
using System.Linq;

namespace PathfindersAscent.Routes
{
    /// <summary>
    /// Patches for CoolHome to suppress null key errors when IndoorSpaceTriggers have invalid ObjectGuids
    /// Uses a Finalizer to catch and suppress ArgumentNullException
    /// </summary>
    [HarmonyPatch]
    internal class CoolHomeEnterOutdoorSceneErrorHandler
    {
        static bool Prepare()
        {
            try
            {
                var asm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "CoolHome");
                return asm != null;
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
                var asm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "CoolHome");
                if (asm == null) return null;

                var type = asm.GetType("CoolHome.InteriorSpaceManager");
                return type?.GetMethod("EnterOutdoorScene", BindingFlags.Public | BindingFlags.Instance);
            }
            catch
            {
                return null;
            }
        }

        static Exception Finalizer(Exception __exception)
        {
            if (__exception is ArgumentNullException ex && ex.ParamName == "key")
            {
                return null; // Suppress the exception
            }
            return __exception;
        }
    }

    [HarmonyPatch]
    internal class CoolHomeLeaveOutdoorSceneErrorHandler
    {
        static bool Prepare()
        {
            try
            {
                var asm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "CoolHome");
                return asm != null;
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
                var asm = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "CoolHome");
                if (asm == null) return null;

                var type = asm.GetType("CoolHome.InteriorSpaceManager");
                return type?.GetMethod("LeaveOutdoorScene", BindingFlags.Public | BindingFlags.Instance);
            }
            catch
            {
                return null;
            }
        }

        static Exception Finalizer(Exception __exception)
        {
            if (__exception is ArgumentNullException ex && ex.ParamName == "key")
            {
                return null; // Suppress the exception
            }
            return __exception;
        }
    }
}