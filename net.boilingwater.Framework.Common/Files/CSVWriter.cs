using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using CsvHelper;
using CsvHelper.Configuration;

using net.boilingwater.Framework.Common.Logging;
using net.boilingwater.Framework.Common.Utils;

namespace net.boilingwater.Framework.Common.Files
{
    public static class CSVWriter
    {
        /// <summary>
        /// オブジェクトのリストをCSVに出力します。
        /// </summary>
        /// <typeparam name="T">出力するオブジェクトの型情報</typeparam>
        /// <param name="values">出力対象の<typeparamref name="T"/>のリスト</param>
        /// <param name="filePath">出力ファイルパス</param>
        /// <returns></returns>
        public static bool WriteCSVFile<T>(List<T> values, string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                NewLine = Environment.NewLine,
            };

            try
            {
                using FileStream? fileStream = FileUtil.CreateFile(filePath);
                if (fileStream == null)
                {
                    return false;
                }
                using var writer = new StreamWriter(fileStream);
                using var csv = new CsvWriter(writer, config);
                csv.WriteRecords(values);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex);
            }
            return false;
        }
    }
}
