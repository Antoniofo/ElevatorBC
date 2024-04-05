using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace ElevatorBC
{
    public class Translation : ITranslation
    {
        public string ElevatorMessage { get; set; } = "<br><br><br><br><br><br><br><br><br><br><br><br><size=18>The player <color=red>%NAME%</co
lor> has pressed the button</size>";

        public string Scp914Message { get; set; } = "<br><br><br><br><br><br><br><br><br><br><br><br><size=18>The player <color=red>%NAME%</colo
r> started 914 in <color=red>%MODE%</color></size>";
    }
}
