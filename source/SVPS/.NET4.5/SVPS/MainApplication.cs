using Livet;
using log4net;
using SVPS.Core;
using SVPS.Data.ViewModels;
using SVPS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SVPS
{
	public static class MainApplication
	{


		#region Private フィールド

		static App application;

		static ILog LOG = LogManager.GetLogger(typeof(MainApplication));

		#endregion Private フィールド


		#region Public メソッド

		[STAThread]
		public static int Main(string[] args)
		{
			MainWindow mainWindow;

			System.Threading.Thread.CurrentThread.Name = "SVPS";

#if !DEBUG
			// Don't catch exceptions when debugging - we want to have Visual Studio catch them where and when
			// they are thrown
			try {

			System.Threading.Mutex mutex = new System.Threading.Mutex(false, System.Threading.Thread.CurrentThread.Name);
			if (mutex.WaitOne(0, false) == false)
			{
				MessageBox.Show("アプリケーションはすでに起動中です。\nこのアプリケーションの多重起動はできません。", "アプリケーションの起動エラー | Saku", MessageBoxButton.OK, MessageBoxImage.Stop);
			}
			else
			{
#endif

			application = new App();
			DispatcherHelper.UIDispatcher = application.Dispatcher;
			CreateApplicationContext();

			LOG.Info("アプリケーションを開始します。");

			using (var workspace = new WorkspaceViewModel())
			{
				_InitializeFunctionBlock(((ApplicationContextImpl)ApplicationContextImpl.GetInstance()));
				_InitializeApplicationContext(((ApplicationContextImpl)ApplicationContextImpl.GetInstance()));

				// [アプリケーションの実行]
				//	- アプリケーションが終了するまで、リターンはブロックされます。
				//  - コメントアウトすると、ウィンドウを表示せずにアプリケーションは終了します。
				((ApplicationContextImpl)ApplicationContextImpl.GetInstance()).Workspace = workspace;
				//ApplicationContext.Watch("メインウィンドウの作成");

				mainWindow = new MainWindow();

				mainWindow.DataContext = workspace;
				((ApplicationContextImpl)ApplicationContextImpl.GetInstance()).MainWindow = mainWindow;

				// メインウィンドウの表示
				SettingConfigWindowsStatus(mainWindow);
				application.Run(mainWindow);

				// アプリケーション終了時の、ウィンドウの位置を設定に保存する
				ApplicationContext.AppConfigInfo.WindowLocation = new Point(mainWindow.Left, mainWindow.Top);


				// アプリケーション終了時に行う処理の呼び出しを行います
				((ApplicationContextImpl)ApplicationContextImpl.GetInstance()).ShutdownProcess();
			}

#if !DEBUG
				//ミューテックスを解放する
				mutex.ReleaseMutex();
			}

			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("There was a program exception: " + e);
				MessageBox.Show("There was a program exception: " + e);
				return -1;
			}//catch
#endif

			LOG.Info("アプリケーションを終了します。");

			return 1;
		}

		#endregion Public メソッド

		#region Private メソッド

		/// <summary>
		/// アプリケーションの初期化処理を実装します
		/// </summary>
		static void _InitializeApplicationContext(ApplicationContextImpl impl)
		{
			impl.InitializeApplication();
		}

		/// <summary>
		/// ファンクションブロック初期化登録
		/// </summary>
		static void _InitializeFunctionBlock(ApplicationContextImpl impl)
		{
			// 下記のようなコードを追加していく。
			//var f1 = new UbiFunctionBlock();
			//impl.ApplicationManager.RegisterFunctionBlock(f1);
		}

		/// <summary>
		/// アプリケーションの起動
		/// </summary>
		static void CreateApplicationContext()
		{
			ApplicationContext.SetupApplicationContextImpl(ApplicationContextImpl.CreateInstance(application));
			//var version = ((ApplicationContextImpl)ApplicationContextImpl.GetInstance()).ApplicationFileVersionInfo;
			//LOG.InfoFormat("アプリケーション(Version {0})を起動します", version.ProductVersion);
		}

		/// <summary>
		///  アプリケーション設定情報から取得した
		///  ウィンドウの表示位置や大きさを設定します。
		/// </summary>
		/// <param name="window"></param>
		static void SettingConfigWindowsStatus(MainWindow mainWindow)
		{
			if (ApplicationContext.AppConfigInfo.WindowSize != null)
			{
				if (ApplicationContext.AppConfigInfo.WindowSize.Width > 0.0)
					mainWindow.Width = ApplicationContext.AppConfigInfo.WindowSize.Width;
				if (ApplicationContext.AppConfigInfo.WindowSize.Height > 0.0)
					mainWindow.Height = ApplicationContext.AppConfigInfo.WindowSize.Height;

				if (ApplicationContext.AppConfigInfo.WindowLocation.X > 0.0)
				{
					mainWindow.WindowStartupLocation = WindowStartupLocation.Manual;
					mainWindow.Left = ApplicationContext.AppConfigInfo.WindowLocation.X;
				}

				if (ApplicationContext.AppConfigInfo.WindowLocation.Y > 0.0)
				{
					mainWindow.WindowStartupLocation = WindowStartupLocation.Manual;
					mainWindow.Top = ApplicationContext.AppConfigInfo.WindowLocation.Y;
				}
			}
		}

		#endregion Private メソッド

	}
}
