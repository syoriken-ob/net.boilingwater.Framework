﻿using RomajiToHiraganaLibrary;

namespace net.boilingwater.Framework.Common.Extensions
{
    /// <summary>
    /// <see cref="string"/>型の拡張メソッドを管理するクラス
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 文字列中のローマ字表現をひらがなに変換します。
        /// </summary>
        /// <param name="romaji">文字列（ローマ字）</param>
        /// <returns><paramref name="romaji"/>中のローマ字をひらがなに変換した文字列</returns>
        /// <remarks>文字列中のローマ字は全て小文字に変換されます。</remarks>
        public static string GetHiragana(this string romaji)
        {
            if (string.IsNullOrEmpty(romaji) || string.IsNullOrWhiteSpace(romaji))
            {
                return "";
            }
            return RomajiToHiragana.Convert(romaji.ToLower());
        }

        /// <summary>
        /// 文字列がnullでないもしくは空文字でないかを判断します。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks><see cref="string.IsNullOrEmpty(string?)"/>を利用して処理します。</remarks>
        public static bool HasValue(this string? text) => !string.IsNullOrEmpty(text);

        /// <summary>
        /// 文字列の前後に付与された引用符を削除します。
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns></returns>
        public static string? TrimQuotes(this string? str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.StartsWith('\"') && str.EndsWith('\"'))
            {
                return str.Trim('\"');
            }

            if (str.StartsWith('\'') && str.EndsWith('\''))
            {
                return str.Trim('\'');
            }

            return str;
        }
    }
}
