using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp914;
using Interactables.Interobjects;
using UnityEngine;

namespace ElevatorBC
{
    public class ElevatorBC : Plugin<Config, Translation>
    {
        public override string Author => "Antoniofo";

        public override string Name => "ElevatorBC";

        public override Version Version => new Version(1, 2, 0);

        public override Version RequiredExiledVersion => new Version(9, 6, 1);

        public override string Prefix => "elevatorbc";

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.InteractingElevator += OnPlayerInteractElevator;
            Exiled.Events.Handlers.Scp914.Activating += On914Activating;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.InteractingElevator -= OnPlayerInteractElevator;
            Exiled.Events.Handlers.Scp914.Activating -= On914Activating;
            base.OnDisabled();
        }

        private void On914Activating(ActivatingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            foreach (Player ply in Player.List)
            {
                if (ply is null || ply.IsNPC || ply.IsHost || ply.UserId is null)
                    continue;
                if (Vector3.Distance(ply.Position, Exiled.API.Features.Scp914.Transform.position) < Config.Distance)
                {
                    ply.ShowHint(Translation.Scp914Message
                        .Replace("%NAME%", ev.Player.DisplayNickname)
                        .Replace("%MODE%", Exiled.API.Features.Scp914.KnobStatus.ToString()), Config.HintDuration);
                }
            }
        }

        private void OnPlayerInteractElevator(InteractingElevatorEventArgs ev)
        {
            if (!ev.IsAllowed || (ev.Lift.Status != ElevatorChamber.ElevatorSequence.Ready &&
                                  ev.Elevator.CurSequence != ElevatorChamber.ElevatorSequence.Ready)) return;

            var elevatorPosition = ev.Lift.Position;
            foreach (Player ply in Player.List)
            {
                if (ply is null || ply.IsNPC || ply.IsHost || ply.UserId is null)
                    continue;
                if (Vector3.Distance(ply.Position, elevatorPosition) < Config.Distance)
                {
                    ply.ShowHint(Translation.ElevatorMessage.Replace("%NAME%", ev.Player.DisplayNickname),
                        Config.HintDuration);
                }
            }
        }
    }
}