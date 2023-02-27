using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.boilingwater.Framework.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 時刻部分のみを切り出した<see cref="DateTime"/>を作成します。
        /// </summary>
        /// <param name="dateTime">切り出し元の日時データ</param>
        /// <returns></returns>
        public static DateTime ToTimePart(this DateTime dateTime) => DateTime.MinValue + dateTime.TimeOfDay;
    }
}
