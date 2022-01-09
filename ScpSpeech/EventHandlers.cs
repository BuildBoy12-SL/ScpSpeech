// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSpeech
{
    using Exiled.Events.EventArgs;
    using Exiled.Permissions.Extensions;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnTransmitting(TransmittingEventArgs)"/>
        public void OnTransmitting(TransmittingEventArgs ev)
        {
            if (plugin.Config.GlobalTalking.Contains(ev.Player.Role) ||
                ev.Player.CheckPermission($"ss.{ev.Player.Role.ToString().ToLower()}"))
            {
                ev.Player.DissonanceUserSetup.MimicAs939 = ev.IsTransmitting;
            }
        }
    }
}