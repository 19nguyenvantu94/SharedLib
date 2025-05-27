﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.MySQL
{
    public sealed class PomeloEntityFrameworkCoreMySqlSettings
    {
        /// <summary>
        /// Gets or sets the connection string of the MySQL database to connect to.
        /// </summary>
        public string? ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the server version of the MySQL database to connect to.
        /// </summary>
        public string? ServerVersion { get; set; }

        /// <summary>
        /// Gets or sets whether retries should be disabled.
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        public bool DisableRetry { get; set; }

        /// <summary>
        /// Gets or sets a boolean value that indicates whether the database health check is disabled or not.
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        public bool DisableHealthChecks { get; set; }

        /// <summary>
        /// Gets or sets a boolean value that indicates whether the OpenTelemetry tracing is disabled or not.
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        public bool DisableTracing { get; set; }

        /// <summary>
        /// Gets or sets a boolean value that indicates whether the OpenTelemetry metrics are disabled or not.
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        public bool DisableMetrics { get; set; }

        /// <summary>
        /// Gets or sets the time in seconds to wait for the command to execute.
        /// </summary>
        public int? CommandTimeout { get; set; }
    }
}
