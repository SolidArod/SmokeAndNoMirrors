using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace SmokeV3
{
    [HarmonyPatch(typeof(MFDPage), "Awake")]
    internal class MFDPatch
    {
        public static void Prefix(MFDPage __instance)
        {
            string pageNameString = (string)__instance.pageName;
            if (__instance.pageName == "options")
            {
                Actor component = __instance.transform.root.GetComponent<Actor>();
                if (component.isPlayer)
                {
                    if (component.GetComponent<PlayerEntityIdentifier>() != null)
                    {
                        PlayerVehicle playerVehicle = component.gameObject.GetComponentInChildren<VehicleMaster>(true).playerVehicle;
                        if (playerVehicle != null)
                        {
                            if (playerVehicle.vehicleName != "T-55")
                            {
                                AirshowSmoke smokeAirShow = __instance.transform.root.GetComponentInChildren<AirshowSmoke>();
                                AirShowExt ext = __instance.transform.root.gameObject.AddComponent<AirShowExt>();
                                ext.airshowSmoke = smokeAirShow;

                                int num = __instance.buttons.Length + 2;
                                Array.Resize<MFDPage.MFDButtonInfo>(ref __instance.buttons, num);
                                MFDPage.MFDButtonInfo mfdbuttonInfo1 = new()
                                {
                                    button = MFD.MFDButtons.B3,
                                    label = "SMOKE",
                                    toolTip = "Toggles Smoke"
                                };
                                MFDPage.MFDButtonInfo mfdbuttonInfo2 = new()
                                {
                                    button = MFD.MFDButtons.B2,
                                    label = "NEXT COLOR",
                                    toolTip = "Next Smoke Color"
                                };
                                __instance.buttons[num - 2] = mfdbuttonInfo1;
                                __instance.buttons[num - 1] = mfdbuttonInfo2;

                                mfdbuttonInfo1.OnPress = new UnityEvent();
                                mfdbuttonInfo1.OnPress.AddListener(new UnityAction(smokeAirShow.Toggle));

                                mfdbuttonInfo2.OnPress = new UnityEvent();
                                mfdbuttonInfo2.OnPress.AddListener(new UnityAction(ext.nextColor));
                            }
                        }
                    }
                }
            }
        }
    }
}
