using MelonLoader.Utils;
using UnityEngine.AddressableAssets;
using Il2CppSystem;
using UnityEngine.UIElements;
using UnityEngine;
using Il2Cpp;
using PathfindersAscent.SaveData;
using MelonLoader;
namespace PathfindersAscent.Placements
{
    public static class PlacementManager
    {
        public static void PlaceTerrain()
        {
            string mActiveScene = GameManager.m_ActiveScene;
            try
            {
                if (mActiveScene == "BlackrockPrisonSurvivalZone")
                {
                    ////Melonlogger.Msg("******************************PlaceTerrain BRP");
                    // Define a helper method to instantiate objects
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }

                    InstantiatePrefab("OBJ_FloodLightTall_A_Prefab (22)", new Vector3(-239.7088f, 224.4004f, 49.2276f), new Vector3(-0f, 181.5559f, 277.3775f), new Vector3(1f, 1f, 1f));
                }
                else if (mActiveScene == "BlackrockRegion")
                {
                    ////Melonlogger.Msg("******************************PlaceTerrain BRM");
                    // Define a helper method to instantiate objects
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }
                    

                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab", new Vector3(-152.7338f, 85.6127f, -885.751f), new Vector3(0f, 190.1946f, 340.9956f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTreeLog_SingleC_Prefab (47)", new Vector3(-66.8777f, 97.466f, -870.9772f), new Vector3(359.6008f, 171.5741f, 318.0867f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTreeLog_SingleC_Prefab (47)", new Vector3(-47.4251f, 128.4474f, -894.5868f), new Vector3(327.1292f, 2.2043f, 33.6207f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_E_Prefab", new Vector3(-63.3882f, 114.5196f, -884.916f), new Vector3(7.3455f, 179.3278f, 45.4473f), new Vector3(0.5f, 0.5f, 0.5f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-104.7845f, 84.5422f, -870.916f), new Vector3(13.5292f, 163.8164f, 180f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-91.3278f, 96.595f, -866.916f), new Vector3(27.9191f, 117.9361f, 1.8826f), new Vector3(0.5f, 0.5f, 0.5f));
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab", new Vector3(496.8632f, 182.9044f, 655.0308f), new Vector3(89.8658f, 5.9986f, 6.9986f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab", new Vector3(-449.4752f, 213.8069f, -32.5058f), new Vector3(339.9855f, 49.0749f, 20.0001f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-355.4506f, 240.958f, -140.0657f), new Vector3(0f, 150.1557f, 0f), new Vector3(.7f, 1f, 1f));  // for new cabin
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(599.5984f, 131.0374f, 641.7964f), new Vector3(348.273f, 175.2491f, 326.1276f), new Vector3(2f, 2f, 2f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(584.5476f, 166.9873f, 660.4342f), new Vector3(13.5291f, 332.601f, 22.2009f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-352.1424f, 202.3663f, -140.6371f), new Vector3(0f, 166.6305f, 358f), new Vector3(1f, 2f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-344.7332f, 274.4995f, -146.5752f), new Vector3(356f, 53.9502f, 0f), new Vector3(0.3f, 0.1f, 0.3f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-342.0966f, 259.7129f, -154.3511f), new Vector3(0.7f, 323.8776f, 2.7831f), new Vector3(0.7f, 0.5f, 0.5f)); //
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-350.6062f, 259.5347f, -151.7818f), new Vector3(4.3f, 219.9999f, 0.5f), new Vector3(1f, .5f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-362.2609f, 263.6891f, -120.1175f), new Vector3(346.9869f, 184.446f, 359.3655f), new Vector3(0.5f, 0.3f, 0.9f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_E_Prefab", new Vector3(-341.7004f, 239.4916f, -145.3508f), new Vector3(3.3992f, 321.6589f, 19.226f), new Vector3(1.1f, 1f, 2.3f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_E_Prefab", new Vector3(-362.1017f, 243.9588f, -149.4614f), new Vector3(10.399f, 296.4774f, 6.226f), new Vector3(0.5f, 0.5f, 0.5f)); 



                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-462.6118f, 180.382f, -84.0286f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)); //
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-429.2778f, 153.3438f, -299.3846f), new Vector3(5f, 145.4243f, -0f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_E_Prefab", new Vector3(-386.9094f, 210.0539f, -210.6487f), new Vector3(4.3f, 230.9998f, 0.5f), new Vector3(2.8f, 1f, 1.5f));
                    InstantiatePrefab("OBJ_LogBridge_E Variant", new Vector3(-546.3568f, 146.6169f, -158.5659f), new Vector3(-0, 298.2949f, 28.8205f), new Vector3(1f, .8f, 1f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_E_Prefab", new Vector3(-413.1189f, 72.7534f, -704.3912f), new Vector3(10.399f, 263.929f, 6.226f), new Vector3(1f, 1f, 1.2f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(162.4993f, 117.0716f, -554.14f), new Vector3(26.3991f, 243.6015f, 32.226f), new Vector3(1f, .5f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(163.4993f, 119.0716f, -548.14f), new Vector3(26.3991f, 243.6015f, 32.226f), new Vector3(1f, 0.5f, 1f));
                    InstantiatePrefab("TRN_RockCliff_09_Big_A_HS_Prefab", new Vector3(-704.1669f, 62.5626f, -35.4028f), new Vector3(0f, 204.7032f, 0f), new Vector3(1.5f, 1.5f, 1.2f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-357.7235f, 276.7299f, -150.7161f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-350.0479f, 276.8298f, -156.6607f), new Vector3(0f, 0f, 0f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-358.9943f, 275.2297f, -136.552f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleM2_Prefab_437", new Vector3(-346.4695f, 278.1299f, -142.4859f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-362.1641f, 285.2401f, -39.5249f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-354.8374f, 277.7397f, -67.0245f), new Vector3(0f, 0f, 0f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-374.686f, 269.9514f, -75.4547f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-428.3152f, 228.2193f, -17.3868f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-416.3204f, 241.1299f, -62.9794f), new Vector3(0f, 0f, 0f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-433.5198f, 222.1517f, 2.9003f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-342.4955f, 206.4351f, -282.6548f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-352.8116f, 205.8351f, -268.0052f), new Vector3(0f, 0f, 0f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab_326", new Vector3(-386.332f, 187.729f, -280.6362f), new Vector3(0f, 0f, 0f), new Vector3(.8f, .8f, .8f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-409.0704f, 218.2214f, 1.9064f), new Vector3(1f, 254.0139f, 7f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-389.2143f, 241.7691f, -31.8738f), new Vector3(2f, 58.0138f, 358f), new Vector3(1f, 1.2f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-434.7366f, 156.5654f, -246.0001f), new Vector3(1f, 196.0684f, 2f), new Vector3(1.3f, 1.5f, 1.3f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-439.0648f, 167.5654f, -243.3623f), new Vector3(349.7992f, 168.0231f, 1.8f), new Vector3(0.8f, 1.3f, 1.1f));
                    InstantiatePrefab("STRSPAWN_HuntersBlind_Prefab", new Vector3(-439.0648f, 167.5654f, -243.3623f), new Vector3(349.7992f, 168.0231f, 1.8f), new Vector3(1.5f, 1f, 1.5f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-335.1143f, 263.2086f, 45.9324f), new Vector3(-0f, 69.1227f, 0f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-354.1143f, 240.1014f, 56.9324f), new Vector3(2f, 167.5846f, 358f), new Vector3(1f, 1.2f, 1f));
                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(-377.7567f, 245.856f, 52.0975f), new Vector3(356.0001f, 38.7071f, -0f), new Vector3(.9f, 1f, 1f));

                    InstantiatePrefab("TRN_RockCliff_08_Big_C_Prefab", new Vector3(897.4969f, 230.2189f, -97.9197f), new Vector3(13.0001f, 254.9626f, 353.9999f), new Vector3(.14f, .03f, .1f));

                }
                else if (mActiveScene == "AshCanyonRegion")
                {
                    //Melonlogger.Msg("******************************Place Snow Blockage AC");
                    // Define a helper method to instantiate objects
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }
          
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(273.0341f, 100.3001f, -522.3516f), new Vector3(4.9095f, 88.5202f, 297.0022f), new Vector3(1.45f, 4f, 0.5f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(317.237f, 85.301f, -495.3124f), new Vector3(4.9095f, 14.3463f, 294.0021f), new Vector3(1.75f, 4f, 0.5f));
                    //InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(322.6992f, 231.6779f, 593.4512f), new Vector3(0f, 77.1727f, 350f), new Vector3(0.35f, 1.5f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-572.2637f, 379.1223f, 420.7404f), new Vector3(18f, 175.7546f, 327f), new Vector3(0.6f, 1f, 0.4f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-572.4636f, 382.0225f, 425.7407f), new Vector3(23.0001f, 175.7546f, 335f), new Vector3(0.6f, 1f, 0.4f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-355.4285f, 424.2502f, 451.458f), new Vector3(5f, 139.1818f, 30f), new Vector3(0.6f, 5f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-295.2386f, 436.0544f, 402.4355f), new Vector3(0.1f, 36.7727f, 349.2003f), new Vector3(0.5f, 2.5f, 0.25f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-462.4967f, 409.8177f, 441.0381f), new Vector3(10.5939f, 104.9668f, 342f), new Vector3(0.2f, 0.7f, 0.15f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-506.8507f, 397.2568f, 415.95f), new Vector3(0f, 0f, 31f), new Vector3(0.2f, 1f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-505.0506f, 398.7569f, 415.95f), new Vector3(0f, 0f, 31f), new Vector3(0.2f, 1f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-467.9951f, 406.1188f, 429.9808f), new Vector3(0f, 0f, 0f), new Vector3(0.3f, 1f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-458.7507f, 414.4045f, 455.5002f), new Vector3(-0f, 155f, 331.2818f), new Vector3(0.3f, 1.4f, 0.3f)); //
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-435.7779f, 415.7192f, 464.4364f), new Vector3(0f, 13f, 356f), new Vector3(0.5f, 2.5f, 0.5f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-577.561f, 377.1993f, 419.8569f), new Vector3(8.9481f, 337.9001f, 27.0383f), new Vector3(0.3f, 1.4f, 0.24f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-559.5278f, 386.6047f, 433.0854f), new Vector3(352.2898f, 355.3818f, 26.8198f), new Vector3(1f, 5f, 0.8f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-614.3828f, 385.1183f, 451.5314f), new Vector3(20.7274f, 2.6909f, 344.5455f), new Vector3(1f, 1.2f, 1f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-607.3373f, 386.9515f, 449.5399f), new Vector3(35.7275f, 27.8182f, 352.4455f), new Vector3(0.5f, 1f, 0.5f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-608.0023f, 389.1516f, 447.3036f), new Vector3(40.7277f, 36.8182f, 355.4455f), new Vector3(0.5f, 1f, 0.5f));                    
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-278.6765f, 432.3819f, 396.3102f), new Vector3(20.7278f, 356.8182f, 355.4455f), new Vector3(0.2f, 1f, 0.2f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-597.1249f, 387.0095f, 442.661f), new Vector3(0f, 179.8f, 329.2817f), new Vector3(0.3f, 1f, 0.3f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-383.5206f, 421.1918f, 437.6736f), new Vector3(317.9999f, 38f, 350f), new Vector3(0.4f, 1f, 0.4f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-392.6859f, 426.6399f, 467.0757f), new Vector3(6.9992f, 77.2728f, 20.5852f), new Vector3(0.35f, 3.1f, 0.3f)); //
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-379.3069f, 419.9167f, 434.6685f), new Vector3(357.2919f, 111.0367f, 307.6563f), new Vector3(0.15f, 1.9075f, 0.7f));
                    //InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(146.669f, 46.1902f, -585.95f), new Vector3(0f, 0f, 0f), new Vector3(1f, 4f, 1f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-393.9511f, 46.8107f, -186.5789f), new Vector3(355.7277f, 36.8181f, 19.8458f), new Vector3(0.7f, 6f, 0.7f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-398.1861f, 44.2705f, -178.9128f), new Vector3(35.676f, 189.9801f, 342.327f), new Vector3(0.7f, 6f, 0.7f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-398.1861f, 50.1704f, -178.9128f), new Vector3(16.6761f, 189.9801f, 341.027f), new Vector3(0.7f, 6f, 0.7f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(-395.1292f, 48.7981f, -193.0132f), new Vector3(355.7277f, 76.2881f, 330.5439f), new Vector3(0.7f, 4f, 0.7f));
                    InstantiatePrefab("TRN_Snow_TerrainSectionB_prefab", new Vector3(54.2633f, 70.752f, 182.4722f), new Vector3(6.1f, 0f,  0f), new Vector3(0.3f, 1f, 0.3f));
                }
                else if (mActiveScene == "CrashMountainRegion")
                {
                    //Melonlogger.Msg("******************************PlaceTerrain TWM");
                    // Define a helper method to instantiate objects
                    void InstantiatePrefab(string prefabName, Vector3 position, Vector3 rotation, Vector3 scale)
                    {
                        GameObject prefab = GameObject.Find(prefabName);
                        SceneUtils.InstantiateObjectInScene(prefab, position, rotation, scale);
                    }
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(688.8666f, 188.6204f, 1039.567f), new Vector3(-0, 319.2487f, 0f), new Vector3(.8f, 1f, .8f));
                    InstantiatePrefab("TRN_PineTree_SingleG_Prefab_1289", new Vector3(978.4892f, 513.6282f, 1311.25f), new Vector3(-0, 4.6943f, 0f), new Vector3(0.8f, 0.6f, 0.8f));
                    InstantiatePrefab("TRN_PineTree_SingleG_Prefab_1289", new Vector3(973.524f, 514.428f, 1308.932f), new Vector3(-0, 4.6943f, 0f), new Vector3(0.8f, 0.5f, 0.8f));
                    InstantiatePrefab("TRN_PineTree_SingleG_Prefab_1289", new Vector3(986.3619f, 515.2054f, 1298.542f), new Vector3(-0, 4.6943f, 0f), new Vector3(0.9f, 0.9f, 0.9f));
                    InstantiatePrefab("TRN_PineTree_SingleK_Prefab_1298", new Vector3(971.8334f, 514.5565f, 1322.116f), new Vector3(-0, 4.6943f, 0f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1812.479f, 123.6733f, 1071.984f), new Vector3(-0, 4.6943f, 0f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1190.477f, 77.0589f, 1028.988f), new Vector3(17.9999f, 81.308f, 197.5997f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1376.34f, 107.76f, 1179.39f), new Vector3(0.5093f, 348.9445f, 3.6f), new Vector3(1f, 1.2f, 0.6f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1616.66f, 5.73f, 788.17f), new Vector3(333.6722f, 276.8987f, 325.2998f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab (8)", new Vector3(1616.66f, 5.73f, 788.17f), new Vector3(17.9999f, 81.308f, 197.5997f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1612.317f, 71.6697f, 816.3009f), new Vector3(16.2645f, 340.4881f, 79.9623f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab (8)", new Vector3(1604.064f, 69.273f, 829.3009f), new Vector3(17.9999f, 163.4933f, 196.5997f), new Vector3(1f, 1f, 1f)); //
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab (8)", new Vector3(1525.744f, 48.0577f, 899.746f), new Vector3(16.9999f, 61.6192f, 171.5997f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1612.717f, 58.8939f, 847.5398f), new Vector3(351.2648f, 122.5622f, 81.9624f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockGroupMidB_Top_Prefab", new Vector3(1681.458f, 26.6996f, 799.207f), new Vector3(354.3271f, 87.0002f, 26.391f), new Vector3(1.3f, 2f, 1.3f));
                    InstantiatePrefab("TRN_RockGroupMidB_Top_Prefab", new Vector3(1465.242f, -4.8639f, 924.3494f), new Vector3(356.5816f, 68.4842f, 284.5508f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1604.698f, 70.0516f, 812.3574f), new Vector3(89.5888f, 214.3175f, 321.997f), new Vector3(.3f, .3f, .3f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1610.269f, 95.3606f, 760.7543f), new Vector3(23.2081f, 290.0013f, 212.3431f), new Vector3(.3f, .3f, .3f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1597.944f, 99.2567f, 746.6385f), new Vector3(317.0926f, 290.8908f, 159.616f), new Vector3(.3f, .3f, .3f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1562.827f, 92.1129f, 702.7678f), new Vector3(28.1974f, 290f, 299.4631f), new Vector3(.3f, .3f, .3f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1601.919f, 84.9835f, 772.7495f), new Vector3(22.0991f, 41.7022f, 15.7571f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("OBJ_TreeCedarFelledB_Prefab (1)", new Vector3(1554.678f, 106.3684f, 746.0217f), new Vector3(19.2247f, 60.5829f, 357.2851f), new Vector3(1f, 1f, 1f));               
                    InstantiatePrefab("TRN_RockGroupMidB_Top_Prefab", new Vector3(1311.558f, 42.6228f, 867.1832f), new Vector3(341.9628f, 47.6026f, 15.6432f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1304.122f, 15.1922f, 914.7496f), new Vector3(319.1254f, 47.6027f, 15.6432f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_RockGroupMidB_Top_Prefab", new Vector3(1185.378f, 41.7955f, 906.0656f), new Vector3(341.9628f, 270.5204f, 16.8432f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1290.706f, 27.5465f, 918.4792f), new Vector3(3.2022f, 47.6027f, 10.6432f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(1277.812f, 19.477f, 869.0453f), new Vector3(347.9017f, 169.9889f, 14.9761f), new Vector3(.7f, .7f, .7f));
                    InstantiatePrefab("OBJ_TreeCedarFelledC_Prefab (8)", new Vector3(1331.382f, 43.6198f, 891.42f), new Vector3(335.9628f, 204.2916f, 28.7362f), new Vector3(1f, 1f, 1f)); //
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1308.41f, 48.6285f, 910.0856f), new Vector3(13.8616f, 43.4027f, 17.2034f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledB_Prefab (1)", new Vector3(1306.752f, 46.1127f, 911.2485f), new Vector3(7.2937f, 116.5667f, 53.5163f), new Vector3(1.3f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTreeLog_SingleC_Prefab (13)", new Vector3(1171.585f, 77.8092f, 1039.137f), new Vector3(7.2938f, 274.3029f, 14.8727f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1178.04f, 88.6013f, 1029.336f), new Vector3(21.2938f, 57.0742f, 89.2643f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledB_Prefab (1)", new Vector3(1190.477f, 77.0589f, 1028.988f), new Vector3(7.2937f, 116.5667f, 53.5163f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledB_Prefab (1)", new Vector3(1162.271f, 55.7004f, 991.5901f), new Vector3(7.2938f, 352.9673f, 26.8834f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarFelledB_Prefab (1)", new Vector3(1211.651f, 54.6999f, 938.6595f), new Vector3(7.2937f, 79.5667f, 355.0076f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTreeLog_SingleC_Prefab (13)", new Vector3(1125.801f, 94.4588f, 1087.186f), new Vector3(308.9031f, 259.4617f, -0.0002f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_PineTree_SingleJ_Prefab (3)", new Vector3(1144.651f, 113.8131f, 1129.062f), new Vector3(334.8069f, 57.0741f, 337.8216f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(669.92f, 140.99f, 755.49f), new Vector3(0.5093f, 261.3082f, 338.6f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(1255.796f, 113.8f, 959.7994f), new Vector3(352.5093f, 306.3083f, 304.5999f), new Vector3(0.7f, 0.5f, 0.8f));
                    InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(886.355f, 456.51f, 1503.602f), new Vector3(65.5094f, 181.3082f, 18.6f), new Vector3(0.5f, 0.5f, 0.5f));
                    InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(865.355f, 472.51f, 1500.602f), new Vector3(59.4927f, 26.3081f, 198.5997f), new Vector3(0.5f, 0.5f, 0.5f));
                    InstantiatePrefab("OBJ_TreeCedarMultiA_Prefab", new Vector3(1127.337f, 67.2283f, 839.6924f), new Vector3(2.6093f, 236.9448f, 357.5f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("OBJ_TreeCedarMultiA_Prefab", new Vector3(1105.618f, 57.3727f, 916.6015f), new Vector3(355.6093f, 115.3993f, 358.6f), new Vector3(1.2f, 1f, 1.2f)); //
                    InstantiatePrefab("TRN_PineTree_SingleE_Prefab_1279", new Vector3(1257.436f, 50.3727f, 900.0551f), new Vector3(355.6093f, 115.3993f, 358.6f), new Vector3(.9f, .8f, .9f));
                    InstantiatePrefab("TRN_PineTree_SingleE_Prefab_1279", new Vector3(1272.436f, 56.3727f, 871.0551f), new Vector3(355.6093f, 115.3993f, 358.6f), new Vector3(.7f, .6f, .7f));
                    //InstantiatePrefab("TRN_PineTree_SingleE_Prefab_1279", new Vector3(1256.436f, 50.3727f, 886.0551f), new Vector3(355.6093f, 115.3993f, 358.6f), new Vector3(1f, 1f, 1f));
                    InstantiatePrefab("TRN_RockCliffBig06_ClimbA_Prefab", new Vector3(984.2405f, 479.1928f, 1341.24f), new Vector3(324.6196f, 145.0333f, 340.9999f), new Vector3(0.5f, 0.5f, 0.7f));
                    InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(969.854f, 477.2132f, 1313.572f), new Vector3(359.9334f, 144.7419f, 8.7f), new Vector3(1f, 0.5f, 0.8f));
                    //InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(969.854f, 477.4732f, 1314.273f), new Vector3(1.3833f, 144.7419f, 8f), new Vector3(1f, 0.5f, 0.8f));
                    //InstantiatePrefab("TRN_RockCliffBig07_Prefab", new Vector3(968.2544f, 477.5233f, 1313.173f), new Vector3(3.1833f, 144.7419f, 8f), new Vector3(1f, 0.5f, 0.8f));
                    //InstantiatePrefab("TRN_RockGroupMidB_Top_Prefab", new Vector3(967.3226f, 496.6082f, 1279.672f), new Vector3(1.6005f, 105.6439f, 333.9835f), new Vector3(0.4f, 0.7f, 0.5f));



                    InstantiatePrefab("TRN_RockBig02SnowA_LOD0", new Vector3(975.0262f, 512.9679f, 1303.474f), new Vector3(2.9f, 40.8361f, 356.4f), new Vector3(0.8f, 0.2f, 0.4f));
                    InstantiatePrefab("TRN_RockBig02SnowA_LOD0", new Vector3(981.9415f, 513.788f, 1302.806f), new Vector3(350.728f, 145.8046f, 359.5091f), new Vector3(0.35f, 0.1f, 0.1f));
                    InstantiatePrefab("TRN_RockBig02SnowA_LOD0", new Vector3(976.6136f, 513.7918f, 1308.069f), new Vector3(8.9001f, 322.9513f, 1.5f), new Vector3(0.4f, 0.1f, 0.1f));
                }
                else
                {
                    //Melonlogger.Msg($"Error: Unhandled scene '{mActiveScene}'. No terrain objects placed.");
                }
            }
            catch (System.Exception ex)
            {
                //Melonlogger.Msg($"Exception occurred while placing terrain: {ex.Message}\n{ex.StackTrace}");
            }
        }
        public static void PlaceAssets()
        {
            string scene = GameManager.m_ActiveScene;
            if (scene == "BlackrockPrisonSurvivalZone")
            {
                //Melonlogger.Msg("******************************PlaceAssets BRP");
                // Placing OBJ_MineRock23
                Vector3 pos2 = new Vector3(-212.2483f, 226.8166f, 143.2502f);
                Vector3 rot2 = new Vector3(359f, 313.5636f, 357.7269f);
                Vector3 scale2 = new Vector3(0.7f, 0.5f, 0.6f);
                SceneUtils.PlaceAssetsInScene("OBJ_MineRock23", pos2, rot2, scale2);


                Vector3 pos4 = new Vector3(-212.2482f, 226.9166f, 144.2502f);
                Vector3 rot4 = new Vector3(359f, 313.5636f, 353.7269f);
                Vector3 scale4 = new Vector3(0.7f, 0.5f, 0.6f);
                SceneUtils.PlaceAssetsInScene("OBJ_MineRock23", pos4, rot4, scale4);
            }
            else if (scene == "BlackrockRegion")
            {
                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing STR_CoastalHouseHFloorWood
                Vector3 pos = new Vector3(-349.8026f, 278.0271f, -149.2507f);
                Vector3 rot = new Vector3(0.0182f, 229.7852f, 359.88f);
                Vector3 scale = new Vector3(0.67f, 2f, 1.04f);
                SceneUtils.PlaceAssetsInScene("STR_CoastalHouseHFloorWood", pos, rot, scale);


                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos2 = new Vector3(-350.3057f, 282.2212f, -148.9428f);
                Vector3 rot2 = new Vector3(-0f, 51.094f, 35f);
                Vector3 scale2 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos2, rot2, scale2);



                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos3 = new Vector3(-350.6457f, 282.0612f, -148.9428f);
                Vector3 rot3 = new Vector3(-0f, 51.094f, 35f);
                Vector3 scale3 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos3, rot3, scale3);


                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos4 = new Vector3(-350.1058f, 282.2812f, -148.7828f);
                Vector3 rot4 = new Vector3(-0f, 51.094f, 34.5001f);
                Vector3 scale4 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos4, rot4, scale4);


                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos5 = new Vector3(-349.6557f, 282.2411f, -148.4428f);
                Vector3 rot5 = new Vector3(-0f, 51.094f, 35f);
                Vector3 scale5 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos5, rot5, scale5);


                //Melonlogger.Msg("******************************PlaceAssets BRM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos6 = new Vector3(-349.9053f, 282.2212f, -148.593f);
                Vector3 rot6 = new Vector3(-0f, 51.094f, 35f);
                Vector3 scale6 = new Vector3(0.6043f, 1.204f, 0.9287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos6, rot6, scale6);


            }
            else if (scene == "CrashMountainRegion")
            {
                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing Cabin Floor
                Vector3 pos = new Vector3(977.8206f, 514.5352f, 1305.487f);
                Vector3 rot = new Vector3(358.64f, 232.8071f, 0.1197f);
                Vector3 scale = new Vector3(0.67f, 40f, 1.04f);
                SceneUtils.PlaceAssetsInScene("STR_CoastalHouseHFloorWood", pos, rot, scale);
            
                
                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos2 = new Vector3(979.0076f, 518.4626f, 1302.983f);
                Vector3 rot2 = new Vector3(2.3f, 54.4506f, 325.3022f);
                Vector3 scale2 = new Vector3(0.6043f, 1.204f, 0.9287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos2, rot2, scale2);



                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos3 = new Vector3(979.2538f, 518.4526f, 1303.133f);
                Vector3 rot3 = new Vector3(2.3f, 54.907f, 325.3022f);
                Vector3 scale3 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos3, rot3, scale3);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos4 = new Vector3(979.2891f, 518.6428f, 1303.503f);
                Vector3 rot4 = new Vector3(2.3f, 54.4506f, 325.3022f);
                Vector3 scale4 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos4, rot4, scale4);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos5 = new Vector3(979.5192f, 518.6227f, 1303.647f);
                Vector3 rot5 = new Vector3(2.3f, 54.4506f, 325.3022f);
                Vector3 scale5 = new Vector3(0.6043f, 1.204f, 0.8287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos5, rot5, scale5);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_WoodPlankSingle
                Vector3 pos6 = new Vector3(979.8314f, 518.5507f, 1303.703f);
                Vector3 rot6 = new Vector3(2.3f, 54.4506f, 325.3022f);
                Vector3 scale6 = new Vector3(0.6043f, 1.204f, 0.9287f);
                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", pos6, rot6, scale6);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_MineRock23
                Vector3 pos7 = new Vector3(1186.87f, 348.5399f, 1356.884f);
                Vector3 rot7 = new Vector3(0.0f, 0.0f, 0.0f);
                Vector3 scale7 = new Vector3(2.5f, 2.5f, 2.5f);
                SceneUtils.PlaceAssetsInScene("OBJ_MineRock23", pos7, rot7, scale7);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_MineRock23
                Vector3 pos8 = new Vector3(1343.703f, 50.828f, 870.0862f);
                Vector3 rot8 = new Vector3(0.0f, 16.1009f, 0.0f);
                Vector3 scale8 = new Vector3(1.5f, 1.5f, 1.5f);
                SceneUtils.PlaceAssetsInScene("OBJ_MineRock23", pos8, rot8, scale8);


                //Melonlogger.Msg("******************************PlaceAssets TWM");
                // Placing OBJ_MineRock23
                Vector3 pos9 = new Vector3(1329.064f, 50.928f, 876.6658f);
                Vector3 rot9 = new Vector3(-0, 224.0159f, 0f);
                Vector3 scale9 = new Vector3(1.5f, 1.5f, 1.5f);
                SceneUtils.PlaceAssetsInScene("OBJ_MineRock23", pos9, rot9, scale9);
            }
        }
    }
}
