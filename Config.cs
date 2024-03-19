using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace ElevatorBC
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public string ElevatorMessage { get; set; } = "<br><br><br><br><br><br><br><br><br><br><br><br><size=18>Le joureur <color=red>%NAME%</color> a appuyé sur le bouton</size>";

        public string Scp914Message { get; set; } = "<br><br><br><br><br><br><br><br><br><br><br><br><size=18>Le joureur <color=red>%NAME%</color> a lancer 914 en <color=red>%MODE%</color></size>";
    }
}
