using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using net.boilingwater.Framework.Common.Extensions;

namespace net.boilingwater.Framework.Common.SQLite
{
    /// <summary>
    /// SQLiteでパラメータ化クエリを実行する時に利用するパラメータを保持するリスト
    /// </summary>
    public class SQLiteParameterList : List<SQLiteParameter>
    {
        /// <summary>
        /// クエリに含まれるパラメータを追加します。
        /// </summary>
        /// <param name="name">パラメータ名（※@を付けないこと）</param>
        /// <param name="type">パラメータの型</param>
        /// <param name="value">値</param>
        public void Add(string name, DbType type, object? value)
        {
            var parameter = new SQLiteParameter
            {
                ParameterName = name,
                DbType = type,
                Value = NormalizeValue(value)
            };
            Add(parameter);
        }

        /// <summary>
        /// IConvertibleをサポートしていない型を手動で変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private object? NormalizeValue(object? value)
        {
            switch (value)
            {
                case DateOnly dateOnly:
                    return dateOnly.ToDateTime();
                case TimeOnly timeOnly:
                    return timeOnly.ToDateTime();
                default:
                    return value;
            }
        }
    }
}
