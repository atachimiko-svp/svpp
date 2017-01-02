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

		#endregion Public プロパティ
	}
}
