using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SVPS.Core;
using SVPS.Apps.Common;

namespace SVPS.Views
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow
	{

		#region Public コンストラクタ

		public MainWindow()
		{
			InitializeComponent();
		}

		#endregion Public コンストラクタ


		#region Protected メソッド

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);

			var hwnd = PresentationSource.FromVisual(this) as HwndSource;
			ApplicationContext.MainWindowSourceInitialize(hwnd);
		}

		#endregion Protected メソッド

		private void ShowPropertyButton_Click(object sender, RoutedEventArgs e)
		{
			var textName = Enum.GetName(typeof(PerspectiveNames), PerspectiveNames.ContentList_Thumbnail);
			ApplicationContext.Ux.ChangePerspective(textName);
		}

		private void ShowPreviewButton_Click(object sender, RoutedEventArgs e)
		{
			var textName = Enum.GetName(typeof(PerspectiveNames), PerspectiveNames.Preview);
			ApplicationContext.Ux.ChangePerspective(textName);
		}

		private void ShowSeiriButton_Click(object sender, RoutedEventArgs e)
		{
			var textName = Enum.GetName(typeof(PerspectiveNames), PerspectiveNames.Seiri);
			ApplicationContext.Ux.ChangePerspective(textName);

		}

		private void ShowTimelineButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
