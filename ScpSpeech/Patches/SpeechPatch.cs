// -----------------------------------------------------------------------
// <copyright file="SpeechPatch.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSpeech.Patches
{
#pragma warning disable SA1313
    using System;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using HarmonyLib;
    using Mirror;
    using PlayableScps;
    using PlayableScps.Messages;

    /// <summary>
    /// Patches <see cref="Scp939.ServerReceivedVoiceMsg"/> to implement scps speaking to humans.
    /// </summary>
    [HarmonyPatch(typeof(Scp939), nameof(Scp939.ServerReceivedVoiceMsg))]
    internal static class SpeechPatch
    {
        private static bool Prefix(NetworkConnection conn, Scp939VoiceMessage msg)
        {
            if (!ReferenceHub.TryGetHubNetID(conn.identity.netId, out ReferenceHub hub))
                return false;

            Player player = Player.Get(hub);
            if (!player.IsScp)
                return false;

            if (Plugin.Instance.Config.GlobalTalking.Contains(player.Role) ||
                player.CheckPermission($"ss.{ScpToString(player.Role).ToLower()}"))
            {
                hub.dissonanceUserSetup.MimicAs939 = msg.IsMimicking;
            }

            return false;
        }

        private static string ScpToString(RoleType roleType)
        {
            switch (roleType)
            {
                case RoleType.Scp173:
                    return nameof(RoleType.Scp173);
                case RoleType.Scp106:
                    return nameof(RoleType.Scp106);
                case RoleType.Scp049:
                    return nameof(RoleType.Scp049);
                case RoleType.Scp079:
                    return nameof(RoleType.Scp079);
                case RoleType.Scp096:
                    return nameof(RoleType.Scp096);
                case RoleType.Scp0492:
                    return nameof(RoleType.Scp0492);
                case RoleType.Scp93953:
                    return nameof(RoleType.Scp93953);
                case RoleType.Scp93989:
                    return nameof(RoleType.Scp93989);
                default:
                    throw new ArgumentOutOfRangeException(nameof(roleType));
            }
        }
    }
}