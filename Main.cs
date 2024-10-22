using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SmokeV3
{
    [ItemId("Smoke.ytheBear")] // Harmony ID for your mod, make sure this is unique
    public class Main : VtolMod
    {
        public string ModFolder;

        private void Awake()
        {
            Logger.Log("Awake at " + modFolder);

            GameObject pvPrefab = VTResources.GetPlayerVehicle("T-55").vehiclePrefab;

            Transform[] ts = pvPrefab.transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in ts)
            {
                if (t.gameObject.name == "AirshowSmoke")
                {
                    AirshowSmoke = t.gameObject;
                }
                else if (t.gameObject.name == "smokeAimTf")
                {
                    aimTf = t.gameObject;
                } 
                else if (t.gameObject.name == "smokeEmitter")
                {
                    SmokeEmitter = t.gameObject;
                }
            }

        }

        static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
        {
            Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in ts)
            {
                Logger.Log(t.gameObject);
                if (t.gameObject.name == withName)
                {
                    return t.gameObject;
                }
            }
            return null;
        }

        public override void UnLoad()
        {
            // Destroy any objects
        }

        public static GameObject SmokeEmitter;
        public static GameObject aimTf;
        public static GameObject AirshowSmoke;
        public static Main instance;
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}