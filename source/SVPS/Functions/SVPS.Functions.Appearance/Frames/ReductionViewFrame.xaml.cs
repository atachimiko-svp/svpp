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
	/// <summary>
	/// ReductionViewFrame.xaml の相互作用ロジック
	/// </summary>
	public partial class ReductionViewFrame : UserControl
	{
		public ReductionViewFrame()
		{
			InitializeComponent();

			var l = (ViewBase)(ReducationViewFrame_ListView.TryFindResource("IconView")); ;
			ReducationViewFrame_ListView.View = l;
		}
	}
}
