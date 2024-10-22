using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SmokeV3
{
    [HarmonyPatch(typeof(Actor), "Start")]
    internal class PlayerSpawnPatch
    {
        public static void Postfix(Actor __instance)
        {
            if (__instance.isPlayer)
            {
                if (__instance.GetComponent<PlayerEntityIdentifier>() != null)
                {
                    PlayerVehicle playerVehicle = __instance.gameObject.GetComponentInChildren<VehicleMaster>(true).playerVehicle;
                    if (playerVehicle != null)
                    {
                        if (playerVehicle.vehicleName != "T55")
                        {
                            Logger.Log("Adding objects");

                            GameObject intAirshowSmoke = UnityEngine.Object.Instantiate<GameObject>(Main.AirshowSmoke, __instance.transform.root);
                            GameObject intsmokeAimTf = Main.aimTf;
                            GameObject intsmokeEmitter = Main.SmokeEmitter;

                            if (playerVehicle.vehicleName == "F/A-26B")
                            {
                                intAirshowSmoke.transform.localPosition = new Vector3(-0.1940f, -0.03f, -5.53f);
                                intAirshowSmoke.transform.localEulerAngles = new Vector3(-180f, 0f, 180f);
                                intAirshowSmoke.transform.localScale = new Vector3(4.2134f, 4.2134f, 4.2134f);

                                intsmokeEmitter.transform.localPosition = new Vector3(0f, 0f, 1.049f);
                                intsmokeEmitter.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                            } else if (playerVehicle.vehicleName == "AV-42C")
                            {
                                intAirshowSmoke.transform.localPosition = new Vector3(-0.1940f, -0.03f, -5.53f);
                                intAirshowSmoke.transform.localEulerAngles = new Vector3(-180f, 0f, 180f);
                                intAirshowSmoke.transform.localScale = new Vector3(4.2134f, 4.2134f, 4.2134f);

                                intsmokeEmitter.transform.localPosition = new Vector3(0f, 0.432f, 1.049f);
                                intsmokeEmitter.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                            }
                            else if (playerVehicle.vehicleName == "AH-94")
                            {
                                intAirshowSmoke.transform.localPosition = new Vector3(-0.1940f, -0.03f, -5.53f);
                                intAirshowSmoke.transform.localEulerAngles = new Vector3(-180f, 0f, 180f);
                                intAirshowSmoke.transform.localScale = new Vector3(4.2134f, 4.2134f, 4.2134f);

                                intsmokeEmitter.transform.localPosition = new Vector3(0f, 0.259f, 1.049f);
                                intsmokeEmitter.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                            }
                            else
                            {
                                intAirshowSmoke.transform.localPosition = new Vector3(-0.1940f, -0.03f, -5.53f);
                                intAirshowSmoke.transform.localEulerAngles = new Vector3(-180f, 0f, 180f);
                                intAirshowSmoke.transform.localScale = new Vector3(4.2134f, 4.2134f, 4.2134f);

                                intsmokeEmitter.transform.localPosition = new Vector3(0f, 0f, 1.049f);
                                intsmokeEmitter.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                            }
                        }
                    }
                }
            }
        }
    }
}
