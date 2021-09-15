// -----------------------------------------------------------------------
// <copyright file="SpeechPatch.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSpeech.Patches
{
    using Assets._Scripts.Dissonance;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using HarmonyLib;

    /// <summary>
    /// Patches <see cref="DissonanceUserSetup.UserCode_CmdAltIsActive"/> to implement scps speaking to humans.
    /// </summary>
    [HarmonyPatch(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.UserCode_CmdAltIsActive))]
    internal static class SpeechPatch
    {
        private static bool Prefix(DissonanceUserSetup __instance, bool value)
        {
            Player player = Player.Get(__instance.gameObject);
            if (player == null || !player.IsScp)
                return true;

            if (Plugin.Instance.Config.GlobalTalking.Contains(player.Role) ||
                player.CheckPermission($"ss.{player.Role.ToString().ToLower()}"))
            {
                __instance.MimicAs939 = value;
            }

            return false;
        }
    }
}