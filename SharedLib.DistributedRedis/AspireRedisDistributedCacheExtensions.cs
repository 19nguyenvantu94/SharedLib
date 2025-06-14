﻿using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLib.Redis;
using StackExchange.Redis;

namespace SharedLib.DistributedRedis
{
    public static class AspireRedisDistributedCacheExtensions
    {
        /// <summary>
        /// Adds Redis distributed caching services, <see cref="IDistributedCache"/>, in the services provided by the <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHostApplicationBuilder"/> to read config from and add services to.</param>
        /// <param name="connectionName">A name used to retrieve the connection string from the ConnectionStrings configuration section.</param>
        /// <param name="configureSettings">An optional method that can be used for customizing the <see cref="StackExchangeRedisSettings"/>. It's invoked after the settings are read from the configuration.</param>
        /// <param name="configureOptions">An optional method that can be used for customizing the <see cref="ConfigurationOptions"/>. It's invoked after the options are read from the configuration.</param>
        /// <remarks>
        /// Reads the configuration from "Aspire:StackExchange:Redis" section.
        ///
        /// Also registers <see cref="IConnectionMultiplexer"/> as a singleton in the services provided by the <paramref name="builder"/>.
        /// Enables retries, corresponding health check, logging, and telemetry.
        /// </remarks>
        public static void AddRedisDistributedCache(this IHostApplicationBuilder builder, string connectionName, Action<StackExchangeRedisSettings>? configureSettings = null, Action<ConfigurationOptions>? configureOptions = null)
        {
            builder.AddRedis(connectionName, configureSettings, configureOptions);

            builder.AddRedisDistributedCacheCore((RedisCacheOptions options, IServiceProvider sp) =>
            {
                options.ConnectionMultiplexerFactory = () => Task.FromResult(sp.GetRequiredService<IConnectionMultiplexer>());
            });
        }

        /// <summary>
        /// Adds Redis distributed caching services, <see cref="IDistributedCache"/>, in the services provided by the <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHostApplicationBuilder"/> to read config from and add services to.</param>
        /// <param name="name">The name of the component, which is used as the <see cref="ServiceDescriptor.ServiceKey"/> of the service and also to retrieve the connection string from the ConnectionStrings configuration section.</param>
        /// <param name="configureSettings">An optional method that can be used for customizing the <see cref="StackExchangeRedisSettings"/>. It's invoked after the settings are read from the configuration.</param>
        /// <param name="configureOptions">An optional method that can be used for customizing the <see cref="ConfigurationOptions"/>. It's invoked after the options are read from the configuration.</param>
        /// <remarks>
        /// Reads the configuration from "Aspire:StackExchange:Redis:{name}" section.
        ///
        /// Also registers <see cref="IConnectionMultiplexer"/> as a singleton in the services provided by the <paramref name="builder"/>.
        /// Enables retries, corresponding health check, logging, and telemetry.
        /// </remarks>
        public static void AddKeyedRedisDistributedCache(this IHostApplicationBuilder builder, string name, Action<StackExchangeRedisSettings>? configureSettings = null, Action<ConfigurationOptions>? configureOptions = null)
        {
            builder.AddKeyedRedis(name, configureSettings, configureOptions);

            builder.AddRedisDistributedCacheCore((RedisCacheOptions options, IServiceProvider sp) =>
            {
                options.ConnectionMultiplexerFactory = () => Task.FromResult(sp.GetRequiredKeyedService<IConnectionMultiplexer>(name));
            });
        }

        private static void AddRedisDistributedCacheCore(this IHostApplicationBuilder builder, Action<RedisCacheOptions, IServiceProvider> configureRedisOptions)
        {
            builder.Services.AddStackExchangeRedisCache(static _ => { });

            builder.Services.AddOptions<RedisCacheOptions>() // note that RedisCacheOptions doesn't support named options
                .Configure(configureRedisOptions);
        }
    }
}
