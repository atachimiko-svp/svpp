using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SVPS.Functions.Views.Behaviors
{
	/// <summary>
	/// "ReducationViewFrame_ListView"のアイテム表示形式を切り替える。
	/// 切り替え契機はバインディングで提供する。
	/// </summary>
	public class ReducationViewListStyleChangeBehavior : Behavior<ListView>
	{


		#region Public フィールド

		public static readonly DependencyProperty MessageProperty =
			DependencyProperty.Register("Message", typeof(string), typeof(ReducationViewListStyleChangeBehavior),
				new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnMessageChanged)));

		#endregion Public フィールド


		#region Public プロパティ

		public string Message
		{
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}

		#endregion Public プロパティ


		#region Private メソッド

		private static void OnMessageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{

			var bv = obj as ReducationViewListStyleChangeBehavior;
			var listView = bv.AssociatedObject as ListView;
			if (e.NewValue != null && !string.IsNullOrEmpty(e.NewValue.ToString()))
			{
				if (e.NewValue.ToString() == "ListView")
				{
					var l = (ViewBase)(listView.TryFindResource("ListView")); ;
					listView.View = l;
				}else if(e.NewValue.ToString() == "IconView")
				{
					var l = (ViewBase)(listView.TryFindResource("IconView")); ;
					listView.View = l;
				}
			}
		}

		#endregion Private メソッド

	}
}
