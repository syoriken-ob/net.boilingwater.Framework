﻿using System;
using System.ComponentModel;

namespace net.boilingwater.Framework.Common.Utils
{
    /// <summary>
    /// 型変換のユーティリティクラス
    /// </summary>
    public static class CastUtil
    {
        /// <summary>
        /// <paramref name="obj"/>を<see cref="int"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="int"/>型に変換した引数</returns>
        public static int ToInteger(object? obj)
        {
            if (obj is int @int)
            {
                return @int;
            }

            return (int)ToDecimal(obj);
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="uint"/>型に変換します。
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns>
        /// <see cref="uint"/>型に変換した引数
        /// <para>引数が負数の場合、既定値を返却します。</para>
        /// </returns>
        public static uint ToUnsignedInteger(object? obj)
        {
            if (obj is uint @int)
            {
                return @int;
            }

            var dec = ToDecimal(obj);

            if (dec < 0)
            {
                return default;
            }

            return (uint)dec;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="long"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="long"/>型に変換した<paramref name="obj"/></returns>
        public static long ToLong(object? obj)
        {
            if (obj is long @long)
            {
                return @long;
            }

            return (long)ToDecimal(obj);
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="ulong"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns>
        ///     <see cref="ulong"/>型に変換した<paramref name="obj"/>
        ///     <para>引数が負数の場合、既定値を返却します。</para>
        /// </returns>
        public static ulong ToUnsignedLong(object? obj)
        {
            if (obj is ulong @long)
            {
                return @long;
            }

            var dec = ToDecimal(obj);

            if (dec < 0)
            {
                return default;
            }

            return (ulong)ToDecimal(obj);
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="double"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="double"/>型に変換した<paramref name="obj"/></returns>
        public static double ToDouble(object? obj)
        {
            if (obj is double @double)
            {
                return @double;
            }

            return (double)ToDecimal(obj);
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="decimal"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="decimal"/>型に変換した<paramref name="obj"/></returns>
        public static decimal ToDecimal(object? obj)
        {
            if (obj is decimal @decimal)
            {
                return @decimal;
            }

            if (decimal.TryParse(ToString(obj), out var @result))
            {
                return @result;
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="bool"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="bool"/>型に変換した<paramref name="obj"/></returns>
        public static bool ToBoolean(object? obj)
        {
            if (obj is bool @bool)
            {
                return @bool;
            }

            if (bool.TryParse(ToString(obj), out var @result))
            {
                return result;
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="Guid"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="Guid"/>型に変換した<paramref name="obj"/></returns>
        public static Guid ToGuid(object? obj)
        {
            if (obj is Guid guid)
            {
                return guid;
            }

            if (Guid.TryParse(ToString(obj), out guid))
            {
                return guid;
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="DateTime"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="DateTime"/>型に変換した<paramref name="obj"/></returns>
        public static DateTime ToDateTime(object? obj)
        {
            if (obj is DateTime dateTime)
            {
                return dateTime;
            }

            if (DateTime.TryParse(ToString(obj), out dateTime))
            {
                return dateTime;
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="DateOnly"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="DateOnly"/>型に変換した<paramref name="obj"/></returns>
        public static DateOnly ToDateOnly(object? obj)
        {
            if (obj is DateOnly dateOnly)
            {
                return dateOnly;
            }

            if (DateOnly.TryParse(ToString(obj), out dateOnly))
            {
                return dateOnly;
            }

            if (DateTime.TryParse(ToString(obj), out DateTime dateTime))
            {
                return DateOnly.FromDateTime(dateTime);
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="TimeOnly"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns><see cref="TimeOnly"/>型に変換した<paramref name="obj"/></returns>
        public static TimeOnly ToTimeOnly(object? obj)
        {
            if (obj is TimeOnly timeOnly)
            {
                return timeOnly;
            }

            if (TimeOnly.TryParse(ToString(obj), out timeOnly))
            {
                return timeOnly;
            }

            if (DateTime.TryParse(ToString(obj), out DateTime dateTime))
            {
                return TimeOnly.FromDateTime(dateTime);
            }

            return default;
        }

        /// <summary>
        /// <paramref name="obj"/>を<see cref="string"/>型に変換します
        /// </summary>
        /// <param name="obj">変換する値</param>
        /// <returns>
        ///     <see cref="string"/>型に変換した<paramref name="obj"/>
        ///     <para>※objectはJSONに変換します。</para>
        /// </returns>
        public static string ToString(object? obj)
        {
            switch (obj)
            {
                case null:
                    return string.Empty;

                case string @string:
                    return @string;
            }

            var str = obj.ToString();
            return str ?? string.Empty;
        }

        /// <summary>
        /// <paramref name="obj"/>を<typeparamref name="T"/>型に変換します
        /// </summary>
        /// <typeparam name="T">変換先の型</typeparam>
        /// <param name="obj">変換する値</param>
        /// <returns>
        ///     <typeparamref name="T"/>型に変換した<paramref name="obj"/><br/>
        ///     ※変換できない場合はdefault値を返却します。
        /// </returns>
        public static T? ToObject<T>(object? obj)
        {
            if (obj == null)
            {
                return default;
            }

            if (obj is T @t)
            {
                return @t;
            }

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null)
                {
                    return (T?)converter.ConvertFrom(obj);
                }
            }
            catch (Exception) { }

            return default;
        }
    }
}
