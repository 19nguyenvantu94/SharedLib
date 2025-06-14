// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using SharedLib.Redis;
using StackExchange.Redis;

[assembly: ConfigurationSchema("Aspire:StackExchange:Redis", typeof(StackExchangeRedisSettings))]
[assembly: ConfigurationSchema("Aspire:StackExchange:Redis:ConfigurationOptions", typeof(ConfigurationOptions))]

[assembly: LoggingCategories("Aspire.StackExchange.Redis")]
