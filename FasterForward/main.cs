using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace FasterForward
{
    public class Main : MBSubModuleBase
    {
        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            var x = Mission.Current.IsCharacterWindowAccessAllowed;  //this is false when entering mission

            // TODO - find a way to intercept TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames.TounramentCampaignBehavior.game_menu_tournament_join_current_game_on_consequence
        }

    }
}
