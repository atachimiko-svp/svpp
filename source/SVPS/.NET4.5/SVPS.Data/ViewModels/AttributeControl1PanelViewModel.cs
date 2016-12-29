using log4net;
using SVPC.Domain;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;

namespace SVPS.Data.ViewModels
{
	public class AttributeControl1PanelViewModel : PaneViewModelBase
	{


		#region Private フィールド

		static ILog LOG = LogManager.GetLogger(typeof(AttributeControl1PanelViewModel));

		PART_TagShortcutItemViewModel m_SelectedTabItem;

		DispatcherCollection<PART_TagShortcutItemViewModel> m_TabItems;

		#endregion Private フィールド


		#region Public コンストラクタ

		public AttributeControl1PanelViewModel()
		{
			m_TabItems = new DispatcherCollection<PART_TagShortcutItemViewModel>(Livet.DispatcherHelper.UIDispatcher);
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public PART_TagShortcutItemViewModel SelectedTabItem
		{
			get { return m_SelectedTabItem; }
			set
			{
				if (m_SelectedTabItem == value) return;
				m_SelectedTabItem = value;
				RaisePropertyChanged();
			}
		}

		public IReadOnlyCollection<PART_TagShortcutItemViewModel> TabItems { get { return m_TabItems; } }

		#endregion Public プロパティ


		#region Public メソッド

		public override void OnActiveViewModel(string perspectiveName, object param)
		{
			m_TabItems.Add(new PART_TagShortcutItemViewModel { TagLabel = "SVP_Nightmare" });
			this.SelectedTabItem = m_TabItems[0];
		}

		public override void OnDeActiveViewModel(string perspectiveName)
		{
			m_TabItems.Clear();
		}

		public async void SetLabelAsync(AttributeControlPanelSetting.LabelItem item)
		{
			LOG.DebugFormat("選択ラベル項目 {0}", item.Name);
		}

		#endregion Public メソッド


		#region Public 内部クラス

		public class PART_TagShortcutItemViewModel : Livet.ViewModel
		{


			#region Public コンストラクタ

			public PART_TagShortcutItemViewModel()
			{
				this.Buttons = new DispatcherCollection<AttributeControlPanelSetting.LabelItem>(Livet.DispatcherHelper.UIDispatcher);
				this.Buttons.Add(new AttributeControlPanelSetting.LabelItem { Name = "ButtonA" });
				this.Buttons.Add(new AttributeControlPanelSetting.LabelItem { Name = "ButtonB" });
			}

			#endregion Public コンストラクタ


			#region Public プロパティ

			public ICollection<AttributeControlPanelSetting.LabelItem> Buttons { get; private set; }
			public string TagLabel { get; set; }

			#endregion Public プロパティ

		}

		#endregion Public 内部クラス

	}
}
