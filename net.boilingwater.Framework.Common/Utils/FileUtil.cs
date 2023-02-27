using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using net.boilingwater.Framework.Common.Logging;

namespace net.boilingwater.Framework.Common.Utils
{
    /// <summary>
    /// ファイル操作のユーティリティクラス
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// ディレクトリを作成します。
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns><see langword="true"/>: 作成成功 / <see langword="false"/>: 作成失敗</returns>
        public static bool CreateDirectory(string dirPath)
        {
            try
            {
                Directory.CreateDirectory(dirPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("ディレクトリの作成に失敗しました。", ex);
            }
            return false;
        }

        /// <summary>
        /// ファイルを新規作成します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="shouldRenew">ファイルが存在していた場合作成し直すか</param>
        /// <returns>作成したファイルの<see cref="FileStream"/></returns>
        public static FileStream? CreateFile(string filePath, bool shouldRenew = true)
        {
            string fullPath;
            try
            {
                fullPath = Path.GetFullPath(filePath);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("パス文字列の解析に失敗しました。", ex);
                return null;
            }

            try
            {
                if (shouldRenew && File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                if (!(Directory.GetParent(filePath)?.Exists ?? true))
                {
                    CreateDirectory(Directory.GetParent(filePath)!.FullName);
                }
                return File.Open(filePath, FileMode.OpenOrCreate);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("ファイル操作に失敗しました。", ex);
                return null;
            }
        }

        /// <summary>
        /// ファイルを開きます。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="readOnly">読み取り専用でファイルを開くかどうか</param>
        /// <returns>開いたファイルの<see cref="FileStream"/></returns>
        /// <remarks>ファイルが存在しない場合は新規に作成します。</remarks>
        public static FileStream? OpenFile(string filePath, bool readOnly = false)
        {
            string fullPath;
            try
            {
                fullPath = Path.GetFullPath(filePath);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("パス文字列の解析に失敗しました。", ex);
                return null;
            }

            try
            {
                if (!(Directory.GetParent(filePath)?.Exists ?? true))
                {
                    CreateDirectory(Directory.GetParent(filePath)!.FullName);
                }

                if (readOnly)
                {
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }
                    return File.OpenRead(filePath);
                }
                else
                {
                    return File.Open(filePath, FileMode.OpenOrCreate);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error("ファイル操作に失敗しました。", ex);
                return null;
            }
        }

        /// <summary>
        /// ファイルを削除します。
        /// </summary>
        /// <param name="filePaths">ファイルパス（可変長引数）</param>
        /// <returns>
        /// result: すべてのファイルが正常に削除できたか<br/>
        /// undeletedFiles: 削除に失敗したファイルパス
        /// </returns>
        public static (bool result, List<string> undeletedFiles) DeleteFiles(params string?[] filePaths)
        {
            var undeletedFiles = new List<string>(filePaths.Length);
            foreach (var path in filePaths)
            {
                if (path == null)
                {
                    continue;
                }

                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    Log.Logger.Error($"ファイル削除に失敗しました。： {path}", ex);
                    undeletedFiles.Add(path);
                }
            }
            return (!undeletedFiles.Any(), undeletedFiles);
        }
    }
}
