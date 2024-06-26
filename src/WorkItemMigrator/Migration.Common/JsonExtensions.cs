﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Migration.Common
{
    public static class JsonExtensions
    {
        public static T ExValue<T>(this JToken token, string path)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            if (!token.HasValues)
                return default;

            var value = token.SelectToken(path, false);

            if (value == null)
                return default;

            return value.Value<T>();
        }

        public static IEnumerable<T> GetValues<T>(this JToken token, string path)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var value = token.SelectToken(path, false);
            return value.Values<T>();
        }
    }
}