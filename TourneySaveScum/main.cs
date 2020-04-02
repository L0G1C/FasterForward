using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace TourneySaveScum
{
    public class Main : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Message",
            new TextObject("Message", null),
            9990,
            () => { InformationManager.DisplayMessage(new InformationMessage("Tournament Save Scumming Enabled.")); },
            false));
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {            
            if (game.GameType.SupportsSaving == false)
            {
                InformationManager.DisplayMessage(new InformationMessage("THIS IS A SAVE FREE ZONE"));
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            var x = Mission.Current.IsCharacterWindowAccessAllowed;  //this is false when entering mission
        }
        
    }
}
