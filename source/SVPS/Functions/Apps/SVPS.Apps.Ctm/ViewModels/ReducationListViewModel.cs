using log4net;
using SVPS.Apps.Common;
using SVPS.Core;
using SVPS.Core.Attributes;
using SVPS.Core.Criterias;
using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Ctm.ViewModels
{
	[PerspectiveFrame("ArtifactListDocument")]
	public class ReducationListViewModel : AppsDocumentViewModelBase
	{


		#region Private フィールド

		static ILog LOG = LogManager.GetLogger(typeof(ReducationListViewModel));

		IReadOnlyCollection<IContentLazyItem> m_Items;

		string m_ListViewStyleName;

		#endregion Private フィールド


		#region Public コンストラクタ

		public ReducationListViewModel()
		{
			this.ReducationViewExtRibbonMenuVisibleFlag = true;
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public IReadOnlyCollection<IContentLazyItem> Items
		{
			get { return m_Items; }
			private set
			{
				m_Items = value;
				RaisePropertyChanged();
			}
		}

		public string ListViewStyleName
		{
			get { return m_ListViewStyleName; }
			set
			{
				//if (m_ListViewStyleName == null) return;
				m_ListViewStyleName = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ


		#region Public メソッド

		public async void ChangeIconViewStyle()
		{
			this.ListViewStyleName = "IconView";
		}

		public async void ChangeListViewStyle()
		{
			this.ListViewStyleName = "ListView";
		}
		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			Console.WriteLine("Execute OnActiveViewModel   " + perspectiveName);
			this.RBulgeVisibilityFlag = false;

			RunStartServerDataLoad();

			Console.WriteLine("Execute OnActiveViewModel   読み込み完了");
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{

		}

		#endregion Public メソッド


		#region Private メソッド

		private async Task RunStartServerDataLoad()
		{
			await ((ISearchContent)ApplicationContext.ContentRepository).ExecFindByCategory();
			this.Items = ApplicationContext.ContentRepository.Items;
		}

		#endregion Private メソッド

	}
}
