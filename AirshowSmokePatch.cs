using HarmonyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI.Extensions;
using static AirshowSmoke;

namespace SmokeV3
{
    [HarmonyPatch(typeof(AirshowSmoke), "Awake")]
    internal class AirshowSmokePatch
    {
        public static void Prefix(AirshowSmoke __instance)
        {
            Logger.Log("Airshow Patched");

            __instance.pSystems = Main.getChildGameObject(__instance.gameObject, "smokeEmitter").GetComponentsInChildren<ParticleSystem>();

            PlayerVehicle playerVehicle = __instance.transform.root.GetComponent<Actor>().gameObject.GetComponentInChildren<VehicleMaster>(true).playerVehicle;
            if (playerVehicle != null)
            {
                if (playerVehicle.vehicleName == "F/A-26B")
                {
                    GameObject lEngine = Main.getChildGameObject(__instance.transform.root.gameObject, "fa26-leftEngine");
                    __instance.engine=lEngine.GetComponent<ModuleEngine>();
                } else if (playerVehicle.vehicleName == "AV-42C")
                {
                    GameObject lEngine = Main.getChildGameObject(__instance.transform.root.gameObject, "Kes_LeftEngine");
                    __instance.engine = lEngine.GetComponent<ModuleEngine>();
                }
                else if (playerVehicle.vehicleName == "AH-94")
                {
                    GameObject lEngine = Main.getChildGameObject(__instance.transform.root.gameObject, "TurbineEngine 1");
                    __instance.engine = lEngine.GetComponent<ModuleEngine>();
                }
                else if (playerVehicle.vehicleName == "Lockheed Martin F-16C")
                {
                    GameObject lEngine = Main.getChildGameObject(__instance.transform.root.gameObject, "mainEngine");
                    __instance.engine = lEngine.GetComponent<ModuleEngine>();
                }
                else
                {
                    __instance.engine = __instance.transform.root.GetComponentInChildren<ModuleEngine>();
                }
            }

            __instance.health = __instance.transform.root.GetComponent<Health>();

            __instance.aimTf = __instance.transform.GetChild(0);

            __instance.colorIdx = 0;

            __instance.flightInfo = __instance.transform.root.GetComponent<FlightInfo>();

            __instance.emitting = false;

            printInstance(__instance);
        }

        static public void printInstance(AirshowSmoke __instance)
        {
            Logger.Log("Instance: " + __instance);
            Logger.Log("Instance's Engine: " + __instance.engine);
            Logger.Log("Instance's pSystem: " + __instance.pSystems);
            Logger.Log("Instance's health: " + __instance.health);
            Logger.Log("Instance's aimTf: " + __instance.aimTf);
            Logger.Log("Instance's flightInfo: " + __instance.flightInfo);
        }
    }
}
