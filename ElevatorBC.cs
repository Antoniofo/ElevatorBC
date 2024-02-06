using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace ElevatorBC
{
    public class ElevatorBC : Plugin<Config>
    {
        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Player.InteractingElevator += OnPlayerInteractElevator;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.InteractingElevator -= OnPlayerInteractElevator;
        }

        public void OnPlayerInteractElevator(InteractingElevatorEventArgs ev)
        {

            foreach (Player ply in Player.List)
            {
                if (Vector3.Distance(ply.Position, ev.Elevator.gameObject.transform.position) < 10.0f)
                {
                    ply.ShowHint(Config.Message.Replace("%NAME%", ev.Player.DisplayNickname));
                }
            }

        }
    }
    
}
