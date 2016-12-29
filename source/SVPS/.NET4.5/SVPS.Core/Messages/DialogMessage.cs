using Livet.Messaging;
using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SVPS.Core.Messages
{
	public class DialogMessage : ResponsiveInteractionMessage<string>
	{


		#region Private フィールド

		IOnsViewModel m_OnsViewModel;

		UserControl m_OncControl;

		#endregion Private フィールド

		#region Public コンストラクタ

		//Viewでメッセージインスタンスを生成する時のためのコンストラクタ
		public DialogMessage()
		{
		}

		/// <summary>
		/// ViewModelからMessenger経由での発信目的でメッセージインスタンスを生成するためのコンストラクタ
		/// </summary>
		public DialogMessage(IOnsViewModel onsViewModel)
			: this(onsViewModel, "Dialog")
		{
		}

		public DialogMessage(UserControl control)
		: this(null, "Dialog")
		{
			this.m_OncControl = control;
		}

		/// <summary>
		/// ViewModelからMessenger経由での発信目的でメッセージインスタンスを生成するためのコンストラクタ
		/// </summary>
		/// <param name="onsViewModel">表示するダイアログに設定するViewModel</param>
		/// <param name="messageKey"></param>
		public DialogMessage(IOnsViewModel onsViewModel, string messageKey)
			: base(messageKey)
		{
			this.m_OnsViewModel = onsViewModel;
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public IOnsViewModel OnsViewModel { get { return m_OnsViewModel; } }

		public UserControl Control { get { return m_OncControl; } }

		#endregion Public プロパティ

		#region Protected メソッド

		/// <summary>
		/// 派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br/>
		/// 通常このメソッドは、自身の新しいインスタンスを返すように実装します。
		/// </summary>
		/// <returns>自身の新しいインスタンス</returns>
		protected override System.Windows.Freezable CreateInstanceCore()
		{
			var a = new DialogMessage(m_OnsViewModel, MessageKey);
			a.m_OncControl = this.m_OncControl;
			return a;
		}

		#endregion Protected メソッド

	}
}
