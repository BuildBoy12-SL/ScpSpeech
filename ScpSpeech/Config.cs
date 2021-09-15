// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSpeech
{
    using System.Collections.Generic;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a collection of roles that can speak no matter their permissions.
        /// </summary>
        public List<RoleType> GlobalTalking { get; set; } = new List<RoleType>
        {
            RoleType.Scp049,
        };
    }
}