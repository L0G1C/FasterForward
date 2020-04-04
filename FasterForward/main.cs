using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace FasterForward
{
    public class Main : MBSubModuleBase
    {
        
        protected override void OnSubModuleLoad()
        {
            //todo
        }

        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);

            var currentCampaign = Campaign.Current;            

            if (currentCampaign != null 
                && Input.IsKeyPressed(InputKey.D4))
            {
                currentCampaign.SpeedUpMultiplier = 16f;
                currentCampaign.SetTimeSpeed(2);
            }

            if (currentCampaign != null
            && Input.IsKeyPressed(InputKey.D3))
            {
                currentCampaign.SpeedUpMultiplier = 4f;
                currentCampaign.SetTimeSpeed(2);
            }
        }        
    }
}
