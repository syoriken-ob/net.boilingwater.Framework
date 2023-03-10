using System;
using System.Linq;
using System.Reflection;

using net.boilingwater.Framework.Common.Extensions;
using net.boilingwater.Framework.Common.Logging;
using net.boilingwater.Framework.Common.Setting;
using net.boilingwater.Framework.Common.SQLite;
using net.boilingwater.Framework.Common.Utils;

namespace net.boilingwater.Framework.Common.Initialize
{
    /// <summary>
    /// <see cref="Common"/>の各機能を利用する際に必要な初期化処理をまとめたクラス
    /// </summary>
    public static class CommonInitializer
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Initialize()
        {
            Log.Initialize();
            Log.Logger.Info("ログ出力設定の初期化を行いました。");
            Log.Logger.Info("共通フレームワークの初期化処理を開始します。");
            Settings.Initialize();
            DBInitialize();
            Log.Logger.Info("共通フレームワークの初期化処理が完了しました。");
        }

        /// <summary>
        /// DB処理の初期化を行います
        /// </summary>
        private static void DBInitialize()
        {
            if (!Settings.AsString("SQLite3.DBFilePath").HasValue())
            {
                return;
            }

            SQLiteDBDao.CreateDataBase();

            Assembly.GetEntryAssembly()?
                    .CollectReferencedAssemblies(assemblyName => CastUtil.ToString(assemblyName.Name).StartsWith("net.boilingwater"))
                    .ForEach(assembly => assembly?.GetTypes()
                                                  .Where(t => t.IsSubclassOf(typeof(SQLiteDBDao)) && !t.IsAbstract)
                                                  .Select(type => (SQLiteDBDao?)Activator.CreateInstance(type))
                                                  .ForEach(dao =>
                                                  {
                                                      Log.Logger.Debug($"DB初期化実行：{dao?.GetType().Name}");
                                                      dao?.InitializeTable();
                                                  }));
        }
    }
}
