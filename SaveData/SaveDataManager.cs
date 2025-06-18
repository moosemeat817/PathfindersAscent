using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModData;
using UnityEngine;
using MelonLoader;


namespace PathfindersAscent.SaveData
{
    internal class SaveDataManager
    {
        public static ModDataManager? dataManager;
        public static bool reloadPending = true;

        // Your data variables
        public static int gateDoor = 0;
        public static int fenceShift = 0;
        public static int ashSnow = 0;

        public static IEnumerator LoadDataAndThen(Action onComplete)
        {
            if (reloadPending)
            {
                float waitSeconds = 0.2f;
                for (float t = 0f; t < waitSeconds; t += Time.deltaTime) yield return null;

                dataManager = new ModDataManager("WanderersHeights", false);
                string serializedData = dataManager.Load();

                if (serializedData != null)
                {
                    string[] deserializedData = serializedData.Split(";");

                    gateDoor = int.TryParse(deserializedData[0], out int result0) ? result0 : 0;
                    fenceShift = int.TryParse(deserializedData[1], out int result1) ? result1 : 0;
                    ashSnow = int.TryParse(deserializedData[2], out int result2) ? result2 : 0;

                    /*
                    Melonlogger.Msg($"[WanderersHeights] Data Loaded:" +
                                    $"\ngateDoor: {gateDoor}" +
                                    $"\nfenceShift: {fenceShift}" +
                                    $"\nashSnow: {ashSnow}");
                    */
                }
                else
                {
                    //Melonlogger.Msg("[WanderersHeights] No saved data found, using defaults");
                }

                reloadPending = false;
            }

            onComplete?.Invoke(); // Run after load
        }


        public static void SaveData()
        {
            if (dataManager != null && !reloadPending)
            {
                string dataToSave = $"{gateDoor};{fenceShift};{ashSnow}";
                dataManager.Save(dataToSave);

                /*
                Melonlogger.Msg($"[YOURMOD] Data Saved:" +
                                $"\ngateDoor: {gateDoor}" +
                                $"\nfenceShift: {fenceShift}" +
                                $"\nashSnow: {ashSnow}");
                */
            }
            else
            {
                if (dataManager == null)
                {
                    //Melonlogger.Msg("[YOURMOD] SaveDataManager not initialized, cannot save data");
                }
                if (reloadPending)
                {
                    //Melonlogger.Msg("[YOURMOD] Data load is pending, skipping save to prevent overwriting saved data");
                }
            }
        }

        public static void ResetData()
        {
            gateDoor = 0;
            fenceShift = 0;
            ashSnow = 0;
            reloadPending = true;
        }
    }
}
