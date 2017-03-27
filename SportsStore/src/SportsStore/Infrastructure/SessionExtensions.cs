﻿// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="SessionExtensions.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SportsStore.Infrastructure
{
    /// <summary>
    /// Class SessionExtensions.
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets the json.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
            ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
