﻿using System;
using System.ComponentModel;
using System.Configuration;

namespace Floe.Configuration
{
	public class WindowsElement : ConfigurationElement, INotifyPropertyChanged
	{
		[ConfigurationProperty("placement")]
		public string Placement
		{
			get { return (string)this["placement"]; }
			set { this["placement"] = value; }
		}

		[ConfigurationProperty("customColors", DefaultValue = "")]
		public string CustomColors
		{
			get { return (string)this["customColors"]; }
			set { this["customColors"] = value; }
		}

		[ConfigurationProperty("activeOpacity", DefaultValue=1.0)]
		public double ActiveOpacity
		{
			get { return (double)this["activeOpacity"]; }
			set { this["activeOpacity"] = value; this.OnPropertyChanged("ActiveOpacity"); }
		}

		[ConfigurationProperty("inactiveOpacity", DefaultValue = 1.0)]
		public double InactiveOpacity
		{
			get { return (double)this["inactiveOpacity"]; }
			set { var val = Math.Round(value, 2); this["inactiveOpacity"] = val; this.OnPropertyChanged("InactiveOpacity"); }
		}

		[ConfigurationProperty("chromeOpacity", DefaultValue = 1.0)]
		public double ChromeOpacity
		{
			get { return (double)this["chromeOpacity"]; }
			set { this["chromeOpacity"] = value; this.OnPropertyChanged("ChromeOpacity"); }
		}

		[ConfigurationProperty("backgroundOpacity", DefaultValue = 0.92)]
		public double BackgroundOpacity
		{
			get { return (double)this["backgroundOpacity"]; }
			set { this["backgroundOpacity"] = value; this.OnPropertyChanged("BackgroundOpacity"); }
		}

		[ConfigurationProperty("minimizeToSysTray", DefaultValue=false)]
		public bool MinimizeToSysTray
		{
			get { return (bool)this["minimizeToSysTray"]; }
			set { this["minimizeToSysTray"] = value; this.OnPropertyChanged("MinimizeToSysTray"); }
		}

		[ConfigurationProperty("tabStripPosition", DefaultValue=TabStripPosition.Bottom)]
		public TabStripPosition TabStripPosition
		{
			get { return (TabStripPosition)this["tabStripPosition"]; }
			set { this["tabStripPosition"] = value; this.OnPropertyChanged("TabStripPosition"); }
		}

		[ConfigurationProperty("states")]
		[ConfigurationCollection(typeof(ChannelStateElement))]
		public ChannelStateElementCollection States
		{
			get
			{
				return this["states"] as ChannelStateElementCollection;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string name)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
