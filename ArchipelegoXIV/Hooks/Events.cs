using ArchipelegoXIV.Rando;
using Dalamud.Game.ClientState;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Text;
using Dalamud.Plugin.Services;
using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchipelegoXIV.Hooks
{
    internal class Events(ApState apState)
    {
        private ContentFinderCondition last_pop;

        public void Enable()
        {
            DalamudApi.DutyState.DutyCompleted += DutyState_DutyCompleted;
            DalamudApi.ClientState.CfPop += ClientState_CfPop;
            DalamudApi.ClientState.TerritoryChanged += ClientState_TerritoryChanged;

            if (DalamudApi.ClientState.IsLoggedIn)
                ClientState_TerritoryChanged(DalamudApi.ClientState.TerritoryType);
        }

        private void ClientState_CfPop(ContentFinderCondition obj)
        {
            DalamudApi.Echo(obj.Name);
            this.last_pop = obj;
        }

        public void Disable() {
            DalamudApi.DutyState.DutyCompleted -= DutyState_DutyCompleted;
            DalamudApi.ClientState.TerritoryChanged -= ClientState_TerritoryChanged;
        }

        private void DutyState_DutyCompleted(object? sender, ushort e)
        {
            var territory = apState.territory = Data.Territories.FirstOrDefault(row => row.RowId == e);
            var duty = Data.GetDuty(e);
            string name = duty.Name;
            if (name.StartsWith("the"))
                name = "The" + name[2..];
            DalamudApi.Echo($"{name} Completed");
            if (!apState.Connected)
                return;
            var canReach = RegionContainer.CanReach(apState, apState.territoryName);
            if (canReach && Logic.Level(duty.ClassJobLevelRequired)(apState))
            {
                DalamudApi.Echo("Dry Marking Check");
            }
            else
            {
                DalamudApi.Echo("You do not meet the requirements, not submitting check");
            }
        }

        private void ClientState_TerritoryChanged(ushort e)
        {
            var territory = apState.territory = Data.Territories.First(row => row.RowId == e);
            apState.territoryName = territory.PlaceName?.Value?.Name ?? "Unknown";
            apState.territoryRegion = territory.PlaceNameRegion?.Value?.Name ?? "Unknown";

            if (!apState.Connected)
                return;
            var canReach = RegionContainer.CanReach(apState, apState.territoryName);
            if (canReach)
                DalamudApi.SetStatusBar("In Logic");
            else
                DalamudApi.SetStatusBar("Out of Logic");
        }
    }
}
