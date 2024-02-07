using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp914;
using UnityEngine;

namespace ElevatorBC
{
    public class ElevatorBC : Plugin<Config>
    {
        public override string Author => "Antoniofo";

        public override string Name => "ElevatorBC";

        public override Version Version => new Version(1,0,0);

        public override string Prefix => "elevatorbc";
        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Player.InteractingElevator += OnPlayerInteractElevator;
            Exiled.Events.Handlers.Scp914.Activating += On914Activating;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.InteractingElevator -= OnPlayerInteractElevator;
        }

        public void On914Activating(ActivatingEventArgs ev)
        {
            foreach (Player ply in Player.List)
            {
                if (Vector3.Distance(ply.Position, Exiled.API.Features.Scp914.Transform.position) < 10.0f)
                {
                    ply.ShowHint(Config.Scp914Message.Replace("%NAME%", ev.Player.DisplayNickname).Replace("%MODE%",Exiled.API.Features.Scp914.KnobStatus.ToString()));
                }
            }
        }
        public void OnPlayerInteractElevator(InteractingElevatorEventArgs ev)
        {

            foreach (Player ply in Player.List)
            {
                if (Vector3.Distance(ply.Position, ev.Elevator.gameObject.transform.position) < 10.0f)
                {
                    ply.ShowHint(Config.ElevatorMessage.Replace("%NAME%", ev.Player.DisplayNickname));
                }
            }

        }
    }
    
}
