﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SVPS.Functions.Views.Frames
{
	public class Person
	{
		public string Title { get; set; }
		public string Caption { get; set; }
	}

	/// <summary>
	/// NavigationListFrame.xaml の相互作用ロジック
	/// </summary>
	public partial class NavigationListFrame : UserControl
	{
		public NavigationListFrame()
		{
			InitializeComponent();

			var people = from age in Enumerable.Range(10, 10)
						 select new Person { Title = "タイトル" + age, Caption = "キャプション" + age };
			this.DataContext = people;
		}
	}
}
