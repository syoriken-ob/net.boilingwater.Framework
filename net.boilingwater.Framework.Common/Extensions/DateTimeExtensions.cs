using System;

namespace net.boilingwater.Framework.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// DateTime型から日付のみ（<see cref="DateOnly"/>）を取得します。
        /// </summary>
        /// <param name="dateTime">切り出し元の日時データ</param>
        /// <returns>DateOnly</returns>
        public static DateOnly ToDateOnly(this DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        /// <summary>
        /// DateOnly型からDateTime型を生成します。
        /// </summary>
        /// <param name="dateOnly">日付</param>
        /// <returns></returns>
        /// <remarks>時刻は00:00:00で補完されます。</remarks>
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }

        /// <summary>
        /// DateTime型から時刻のみ（<see cref="TimeOnly"/>）を取得します。
        /// </summary>
        /// <param name="dateTime">切り出し元の日時データ</param>
        /// <returns>TimeOnly</returns>
        public static TimeOnly ToTimeOnly(this DateTime dateTime)
        {
            return TimeOnly.FromDateTime(dateTime);
        }

        /// <summary>
        /// TimeOnly型からDateTime型を生成します。
        /// </summary>
        /// <param name="timeOnly">時刻</param>
        /// <returns></returns>
        /// <remarks>日付は0001/01/01で補完されます。</remarks>
        public static DateTime ToDateTime(this TimeOnly timeOnly)
        {
            return DateTime.MinValue + timeOnly.ToTimeSpan();
        }

        /// <summary>
        /// <paramref name="d1"/>と<paramref name="d2"/>の期間を計算します。<br/>
        /// 負の値の場合は、<see cref="TimeSpan.Zero"/>を返します。
        /// </summary>
        /// <param name="d1">切り出し元の日時データ</param>
        /// <returns></returns>
        public static TimeSpan SubtractDefaultZero(this DateTime d1, DateTime d2)
        {
            TimeSpan span = d1 - d2;
            return span > TimeSpan.Zero ? span : TimeSpan.Zero;
        }

        /// <summary>
        /// <paramref name="d1"/>と<paramref name="d2"/>の期間を計算します。<br/>
        /// 負の値の場合は、<see cref="TimeSpan.Zero"/>を返します。
        /// </summary>
        /// <param name="d1">切り出し元の日時データ</param>
        /// <returns></returns>
        public static TimeSpan SubtractDefaultZero(this TimeOnly d1, TimeOnly d2)
        {
            TimeSpan span = d1 - d2;
            return d1 > d2 ? span : TimeSpan.Zero;
        }
    }
}
