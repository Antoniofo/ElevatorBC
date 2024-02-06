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
        public bool Debug { get; set; } = true;

        public string Message { get; set; } = "<br><br><br><br><br><br><br><br><br><br><br><br><size=18>Le joureur <color=red>%NAME%</color> a appuyer sur le bouton</size>";
    }
}
