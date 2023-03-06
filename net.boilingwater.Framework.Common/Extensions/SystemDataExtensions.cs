using System;
using System.Data;

using net.boilingwater.Framework.Common.Utils;

namespace net.boilingwater.Framework.Common.Extensions
{
    public static class SystemDataExtensions
    {
        /// <summary>
        /// DataRowの指定カラムの値を<see cref="string"/>で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static string GetAsString(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToString(row![columnName]) : "";
        }

        /// <summary>
        /// DataRowの指定カラムの値を<see cref="int"/>で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static int GetAsInteger(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToInteger(row![columnName]) : 0;
        }

        /// <summary>
        /// DataRowの指定カラムの値を<see cref="ulong"/>で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static ulong GetAsULong(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToUnsignedLong(row![columnName]) : 0UL;
        }

        /// <summary>
        /// DataRowの指定カラムの値を<see cref="DateTime"/>型で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static DateTime GetAsDateTime(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToDateTime(row![columnName]) : DateTime.MinValue;
        }

        /// <summary>
        /// DataRowの指定カラムの値を<see cref="DateOnly"/>型で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static DateOnly GetAsDateOnly(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToDateOnly(row![columnName]) : DateOnly.MinValue;
        }

        /// <summary>
        /// DataRowの指定カラムの値を<see cref="TimeOnly"/>型で取得します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns><paramref name="row"/>[<paramref name="columnName"/>]</returns>
        /// <remarks>型変換には<see cref="CastUtil"/>を利用します。</remarks>
        public static TimeOnly GetAsTimeOnly(this DataRow? row, string columnName)
        {
            return ColumnExists(row, columnName) ? CastUtil.ToTimeOnly(row![columnName]) : TimeOnly.MinValue;
        }

        /// <summary>
        /// 指定した名前のカラムが存在するか確認します。
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="columnName">カラム名</param>
        /// <returns></returns>
        private static bool ColumnExists(DataRow? row, string columnName) => row?.Table.Columns.Contains(columnName) ?? false;
    }
}
