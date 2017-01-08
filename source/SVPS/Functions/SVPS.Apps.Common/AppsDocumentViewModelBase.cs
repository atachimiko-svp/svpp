using SVPS.Core;
using SVPS.Core.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Common
{
	public abstract class AppsDocumentViewModelBase : SDocumentViewModelBase, IAppPerspectiveViewModel
	{

		#region Private フィールド

		bool m_InputMetaViewExtRibbonMenuVisibleFlag = false;

		bool m_ReducationViewExtRibbonMenuVisibleFlag = false;

		#endregion Private フィールド


		#region Public プロパティ

		public bool InputMetaViewExtRibbonMenuVisibleFlag
		{
			get { return m_InputMetaViewExtRibbonMenuVisibleFlag; }
			protected set
			{
				m_InputMetaViewExtRibbonMenuVisibleFlag = value;
				RaisePropertyChanged();
			}
		}

		public bool ReducationViewExtRibbonMenuVisibleFlag
		{
			get { return m_ReducationViewExtRibbonMenuVisibleFlag; }
			protected set
			{
				m_ReducationViewExtRibbonMenuVisibleFlag = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ


		#region Public メソッド

		public async void ToggleCategoryAlubumVisibility()
		{
			if (!AppPerspectiveHolder.CategoryAlbumInfoViewModelHandle.HasValue) return;
			var vm = ApplicationContext.Ux.GetPerspectiveViewModel(AppPerspectiveHolder.CategoryAlbumInfoViewModelHandle.Value) as AppsPaneViewModelBase;
			vm.VisibilityFlag = !vm.VisibilityFlag;
		}

		public async void ToggleNavigationListVisibility()
		{
			if (!AppPerspectiveHolder.NavigationListViewModelHandle.HasValue) return;
			var vm = ApplicationContext.Ux.GetPerspectiveViewModel(AppPerspectiveHolder.NavigationListViewModelHandle.Value) as AppsPaneViewModelBase;
			vm.VisibilityFlag = !vm.VisibilityFlag;
		}

		public void StartPerspective(PerspectiveNames perspectiveName, object param = null)
		{
			var textName = Enum.GetName(typeof(PerspectiveNames), perspectiveName);
			ApplicationContext.Ux.ChangePerspective(textName, param);
		}

		#endregion Public メソッド

	}
}
