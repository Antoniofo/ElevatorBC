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
    public class ElevatorBC : Plugin<Config, Translation>
    {
        public override string Author => "Antoniofo";

        public override string Name => "ElevatorBC";

        public override Version Version => new Version(1,1,0);

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
                if (Vector3.Distance(ply.Position, Exiled.API.Features.Scp914.Transform.position) < Config.Distance)
                {
                    ply.ShowHint(Translation.Scp914Message.Replace("%NAME%", ev.Player.DisplayNickname).Replace("%MODE%",Exiled.API.Features.Scp914.KnobStatus.ToString()), Config.HintDuration);
                }
            }
        }
        public void OnPlayerInteractElevator(InteractingElevatorEventArgs ev)
        {

            foreach (Player ply in Player.List)
            {
                if (Vector3.Distance(ply.Position, ev.Elevator.gameObject.transform.position) < Config.Distance)
                {
                    ply.ShowHint(Translation.ElevatorMessage.Replace("%NAME%", ev.Player.DisplayNickname), Config.HintDuration);
                }
            }

        }
    }    
}
