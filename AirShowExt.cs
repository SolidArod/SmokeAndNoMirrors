using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SmokeV3
{
    internal class AirShowExt:MonoBehaviour
    {
        public int colorIdx;
        public AirshowSmoke airshowSmoke;
        public void nextColor()
        {
            colorIdx = airshowSmoke.colorIdx;
            int nextColor = colorIdx + 1;
            if (nextColor == 8)
            {
                nextColor = 0;
            }
            airshowSmoke.SetColor(nextColor);
        }
    }
}
