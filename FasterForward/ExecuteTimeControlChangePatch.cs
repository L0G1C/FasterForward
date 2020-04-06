using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map;
using TaleWorlds.Core;

namespace FasterForward
{
    [HarmonyPatch(typeof(MapTimeControlVM), "ExecuteTimeControlChange")]
    public class ExecuteTimeControlChangePatch
    {
        private static void Postfix(int selectedTimeSpeed)
        {            
            if (Campaign.Current.CurrentMenuContext == null || (Campaign.Current.CurrentMenuContext.GameMenu.IsWaitActive && !Campaign.Current.TimeControlModeLock))
            {
                var currentCampaign = Campaign.Current;

                //Handle Normal FastForward
                if (selectedTimeSpeed == 2)
                {
                    currentCampaign.SpeedUpMultiplier = 4f;                    
                }
                //Handle FasterForward
                else if (selectedTimeSpeed == 3)
                {                                        
                    currentCampaign.SpeedUpMultiplier = 8f;                        
                }

                currentCampaign.SetTimeSpeed(2);
            }
        }       
    }
}
