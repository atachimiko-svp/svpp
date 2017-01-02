using Livet;
using Livet.EventListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPS.Core
{
	public interface IPropertyData
	{


		#region Public プロパティ

		string Name { get; }
		object Value { get; }

		#endregion Public プロパティ

	}

	public class PropertyData : Livet.NotificationObject, IPropertyData
	{


		#region Private フィールド

		readonly ObservableSynchronizedCollection<PropertyData> m_children = new ObservableSynchronizedCollection<PropertyData>();
		string m_Name;
		ReadOnlyDispatcherCollection<PropertyData> m_roChildren;
		object m_Value;

		#endregion Private フィールド


		#region Public コンストラクタ

		public PropertyData()
		{
			m_roChildren = ViewModelHelper.CreateReadOnlyDispatcherCollection(m_children,
				prop =>
				{
					return prop;
				}, DispatcherHelper.UIDispatcher);
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public ReadOnlyDispatcherCollection<PropertyData> Children { get { return m_roChildren; } }

		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
				RaisePropertyChanged();
			}
		}

		public object Value
		{
			get { return m_Value; }
			set
			{
				m_Value = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ

	}

	public class PropertyDataSet : Livet.NotificationObject, IDisposable
	{


		#region Private フィールド

		readonly ObservableSynchronizedCollection<PropertyData> m_children = new ObservableSynchronizedCollection<PropertyData>();
		string m_DataName;
		ReadOnlyDispatcherCollection<ReadonlyPropertyData> m_roChildren;

		#endregion Private フィールド


		#region Public コンストラクタ

		public PropertyDataSet()
		{
			m_roChildren = ViewModelHelper.CreateReadOnlyDispatcherCollection(m_children,
				prop =>
				{
					return new ReadonlyPropertyData(prop);
				}, DispatcherHelper.UIDispatcher);
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public ReadOnlyDispatcherCollection<ReadonlyPropertyData> Children { get { return m_roChildren; } }

		public string DataName
		{
			get { return m_DataName; }
			set
			{
				m_DataName = value;
				RaisePropertyChanged();
			}
		}

		#endregion Public プロパティ


		#region Public メソッド

		public PropertyData AddProperty(string name, object value)
		{
			var pd = new PropertyData { Name = name, Value = value };
			m_children.Add(pd);
			return pd;
		}

		public void RemoveProperty(PropertyData pd)
		{
			m_children.Remove(pd);
		}

		public void Dispose()
		{
			foreach (var prop in m_roChildren)
			{
				prop.Dispose();
			}
		}

		#endregion Public メソッド

	}

	public class PropertyDataSource : IDisposable
	{


		#region Private フィールド

		readonly ObservableSynchronizedCollection<PropertyDataSet> m_children = new ObservableSynchronizedCollection<PropertyDataSet>();
		ReadOnlyDispatcherCollection<PropertyDataSet> m_roChildren;

		#endregion Private フィールド


		#region Public コンストラクタ

		public PropertyDataSource()
		{
			m_roChildren = ViewModelHelper.CreateReadOnlyDispatcherCollection(m_children,
			prop =>
			{
				return prop;
			}, DispatcherHelper.UIDispatcher);
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public ReadOnlyDispatcherCollection<PropertyDataSet> Items { get { return m_roChildren; } }

		#endregion Public プロパティ


		#region Public メソッド

		public PropertyDataSet AddPropertyDataSet(string datasetName)
		{
			var pd = new PropertyDataSet { DataName = datasetName };
			m_children.Add(pd);
			return pd;
		}

		public void Clear()
		{
			foreach (var prop in m_roChildren)
			{
				prop.Dispose();
			}

			m_children.Clear();
		}

		public void Dispose()
		{
			foreach (var prop in m_roChildren)
			{
				prop.Dispose();
			}
		}

		public void RemovePropertyDataSet(PropertyDataSet target)
		{
			if (m_children.Remove(target))
				target.Dispose();
		}

		#endregion Public メソッド
	}
	public class ReadonlyPropertyData : Livet.NotificationObject, IPropertyData, IDisposable
	{


		#region Private フィールド

		readonly PropertyData m_data;

		readonly PropertyChangedEventListener m_listener;

		#endregion Private フィールド


		#region Public コンストラクタ

		public ReadonlyPropertyData(PropertyData propertyData)
		{
			m_data = propertyData;
			m_listener = new PropertyChangedEventListener(propertyData)
			{
				{()=>propertyData.Name,(sender,prop)=>OnRaisePropertyUpdate("Name") },
				{()=>propertyData.Value,(sender,prop)=>OnRaisePropertyUpdate("Value") }
			};
		}

		#endregion Public コンストラクタ


		#region Public プロパティ

		public string Name { get { return m_data.Name; } }

		public object Value { get { return m_data.Value; } }

		#endregion Public プロパティ


		#region Public メソッド

		public void Dispose()
		{
			m_listener.Dispose();
		}

		#endregion Public メソッド


		#region Private メソッド

		private void OnRaisePropertyUpdate(string updatePropertyName)
		{
			RaisePropertyChanged(updatePropertyName);
		}

		#endregion Private メソッド

	}
}
