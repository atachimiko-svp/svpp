using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core.Presentations
{
	public abstract class SDocumentViewModelBase : PerspectiveViewModelBase
	{


		#region Private フィールド

		readonly PropertyDataSource m_PropertyData;

		bool m_RBulgeVisibilityFlag = false;

		#endregion Private フィールド


		#region Public コンストラクタ

		public SDocumentViewModelBase()
		{
			m_PropertyData = new PropertyDataSource();
			CompositeDisposable.Add(m_PropertyData);
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public PropertyDataSource PropertyData { get { return m_PropertyData; } }

		public bool RBulgeVisibilityFlag
		{
			get { return m_RBulgeVisibilityFlag; }
			set
			{
				if (m_RBulgeVisibilityFlag == value) return;
				m_RBulgeVisibilityFlag = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ
	}
}
