﻿using Livet;
using Livet.EventListeners;
using SVPS.Contrib.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Contrib
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="SV">サーバから取得するデータ型</typeparam>
	public abstract class LazyDataSourceBase<T, SV> : IDataSource<DispatcherCollection<T>>, IDisposable
		where T : ILazyLoadingItem<SV>
		where SV : new()
	{


		#region フィールド

		DispatcherCollection<T> _Items;

		ObservableSynchronizedCollection<EventListener<EventHandler<LazyItemLoadedEventArgs>>> _Listeners = new ObservableSynchronizedCollection<EventListener<EventHandler<LazyItemLoadedEventArgs>>>();

		#endregion フィールド


		#region コンストラクタ

		public LazyDataSourceBase()
		{
			this._Items = new DispatcherCollection<T>(DispatcherHelper.UIDispatcher);
		}

		#endregion コンストラクタ


		#region プロパティ

		/// <summary>
		/// 
		/// </summary>
		public DispatcherCollection<T> Items { get { return _Items; } }

		#endregion プロパティ

		#region メソッド

		/// <summary>
		/// 新しいItemDataを追加する
		/// </summary>
		/// <param name="item"></param>
		public void AddItem(T item)
		{
			var listener = new EventListener<EventHandler<LazyItemLoadedEventArgs>>(
				h => item.Loaded += h,
				h => item.Loaded -= h,
				(sender, e) => { OnLazyDataLoad((T)sender,e.ForceLoadFlag); }
			);
			_Listeners.Add(listener);

			this.Items.Insert(this.Items.Count, item);
		}

		public void Dispose()
		{
			foreach (var @d in _Listeners)
			{
				@d.Dispose();
			}
		}

		/// <summary>
		/// 遅延ロードによりデータを取得するタイミングで呼び出される非同期メソッド
		/// 
		/// 実装部では非同期タスクにより別タスク・別スレッドを使用した処理を行い、UIスレッドへのパフォーマンスを維持しながら
		/// データの取得を行うことができます。
		/// 
		/// ※ネットワークの向こうのデータをとってくるイメージ
		/// </summary>
		/// <returns></returns>
		protected virtual async Task<SV> GetData(T sender, bool force)
		{
			return await Task.Delay(0).ContinueWith(_ =>
			{
				return new SV();
			});
		}

		async void OnLazyDataLoad(T sender,bool force)
		{
			//Console.WriteLine("OnPropertyChangedIsLoaded " + sender.IdText);

			await DispatcherHelper.UIDispatcher.InvokeAsync(async () =>
			{
				SV results = await this.GetData(sender, force);
				sender.LoadedFromData(results, force);
			});
		}

		#endregion メソッド

	}
}
