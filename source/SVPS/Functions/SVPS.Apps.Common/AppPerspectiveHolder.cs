using SVPS.Core;
using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Common
{
	public static class AppPerspectiveHolder
	{

		#region Public フィールド

		/// <summary>
		/// FRM-01
		/// </summary>
		public static PerspectiveViewModelHandle? ArtifactListViewModelHandle = null;

		/// <summary>
		/// FRM-03
		/// </summary>
		public static PerspectiveViewModelHandle? AutomatinSearchViewModelHandle = null;

		/// <summary>
		/// FRM-05
		/// </summary>
		public static PerspectiveViewModelHandle? CategoriseTreeViewModelHandle = null;

		/// <summary>
		/// FRM-10
		/// </summary>
		public static PerspectiveViewModelHandle? CategoryAlbumInfoViewModelHandle = null;

		/// <summary>
		/// FRM-09
		/// </summary>
		public static PerspectiveViewModelHandle? ImagePreviewViewModelHandle = null;

		/// <summary>
		/// FRM-06
		/// </summary>
		public static PerspectiveViewModelHandle? ImageThumbnailViewModelHandle = null;

		/// <summary>
		/// FRM-02
		/// </summary>
		public static PerspectiveViewModelHandle? InformationCategoryViewModelHandle = null;

		/// <summary>
		/// FRM-08
		/// </summary>
		public static PerspectiveViewModelHandle? InputMetaControlViewModelHandle = null;

		/// <summary>
		/// FRM-07
		/// </summary>
		public static PerspectiveViewModelHandle? NavigationListViewModelHandle = null;

		#endregion Public フィールド
	}
}
