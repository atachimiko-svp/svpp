using SVPS.Apps.Common;
using SVPS.Apps.Ctm.ViewModels;
using SVPS.Core;
using SVPS.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Apps.Ctm
{
	public class CtmFunctionBlock : IFunctionBlock
	{
		public void OnInitializeFunction(object sender, EventArgs args)
		{
			if(!AppPerspectiveHolder.ArtifactListViewModelHandle.HasValue)
				AppPerspectiveHolder.ArtifactListViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new ReducationListViewModel());

			if (!AppPerspectiveHolder.ImagePreviewViewModelHandle.HasValue)
				AppPerspectiveHolder.ImagePreviewViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new ImagePreviewViewModel());

			if (!AppPerspectiveHolder.InputMetaControlViewModelHandle.HasValue)
				AppPerspectiveHolder.InputMetaControlViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new InputMetaControlViewModel());

			if (!AppPerspectiveHolder.ImageThumbnailViewModelHandle.HasValue)
				AppPerspectiveHolder.ImageThumbnailViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new ContentThumbnailViewModel());

			if (!AppPerspectiveHolder.NavigationListViewModelHandle.HasValue)
				AppPerspectiveHolder.NavigationListViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new NavigationListViewModel());

			if (!AppPerspectiveHolder.CategoryAlbumInfoViewModelHandle.HasValue)
				AppPerspectiveHolder.CategoryAlbumInfoViewModelHandle = ApplicationContext.Ux.AddPerspectiveViewModel(new CategoryAlbumInfoViewModel());


			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.ContentList_Thumbnail.ToString(),
				Core.ViewpositionNames.Document,
				AppPerspectiveHolder.ArtifactListViewModelHandle.Value);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Preview.ToString(),
				Core.ViewpositionNames.Document,
				AppPerspectiveHolder.ImagePreviewViewModelHandle.Value);

			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.Document,
				AppPerspectiveHolder.ImageThumbnailViewModelHandle.Value);
			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockKeel,
				AppPerspectiveHolder.InputMetaControlViewModelHandle.Value);
			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockLeft,
				AppPerspectiveHolder.NavigationListViewModelHandle.Value);
			ApplicationContext.Ux.SetPerspectiveViewModel(
				PerspectiveNames.Seiri.ToString(),
				Core.ViewpositionNames.DockRight,
				AppPerspectiveHolder.CategoryAlbumInfoViewModelHandle.Value);
		}
	}
}
