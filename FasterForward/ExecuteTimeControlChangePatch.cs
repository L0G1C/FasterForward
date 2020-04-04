using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map;

namespace FasterForward
{
    [HarmonyPatch(typeof(MapTimeControlVM), "ExecuteTimeControlChange")]
    public class ExecuteTimeControlChangePatch
    {
        private static void Postfix(MapTimeControlVM instance, int selectedTimeSpeed)
        {
			if (Campaign.Current.CurrentMenuContext == null || (Campaign.Current.CurrentMenuContext.GameMenu.IsWaitActive && !Campaign.Current.TimeControlModeLock))
			{
                if (selectedTimeSpeed == 3)
                    Traverse.Create(instance).Method("SetTimeSpeed").GetValue(selectedTimeSpeed);				
			}
		}       
    }
}
