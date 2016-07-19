using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace SharpTimeAndCulture
{
	public class MainViewModel : BindingBase
	{
		public string RemoteTime
		{
			get
			{
				var today = DateTime.Today;
				var localTime = new DateTime(today.Year, today.Month, today.Day, LocalTime.Hours, LocalTime.Minutes, LocalTime.Seconds);
				var time = TimeZoneInfo.ConvertTime(localTime, _selectedZone);
				var result = $"Remote: {_selectedZone.DisplayName.Substring(12)}, Time: { time.ToString("HH:mm:ss", CultureInfo.CurrentCulture) }";
				return result;
			}
		}

		private TimeSpan _localTime;

		public TimeSpan LocalTime
		{
			get { return _localTime; }
			set
			{
				if (_localTime != value)
				{
					_localTime = value;
					OnPropertyChanged();
					OnPropertyChanged(nameof(RemoteTime));
				}
			}
		}

		private TimeZoneInfo _selectedZone;

		public TimeZoneInfo SelectedZone
		{
			get { return _selectedZone; }
			set { _selectedZone = value; OnPropertyChanged(); OnPropertyChanged(nameof(RemoteTime)); }
		}

		public ObservableCollection<TimeZoneInfo> TimeZones { get; }

		public MainViewModel()
		{
			TimeZones = new ObservableCollection<TimeZoneInfo>();
			var zones = TimeZoneInfo.GetSystemTimeZones();
			foreach (var zone in zones)
			{
				TimeZones.Add(zone);
			}
			_selectedZone = zones.First();
		}

		public void ZoneChanged(object sender, SelectionChangedEventArgs e)
		{
			var timeZone = e.AddedItems.First() as TimeZoneInfo;
		}
	}
}
