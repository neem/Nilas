﻿using System;
using System.Windows;

namespace Floe.UI
{
	[TemplatePart(Name="PART_ChatPresenter", Type=typeof(ChatPresenter))]
	public class ChatBox : ChatBoxBase
	{
		private ChatPresenter _presenter;

		public ChatBox()
		{
			this.DefaultStyleKey = typeof(ChatBox);
			this.ApplyTemplate();
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_presenter = base.GetTemplateChild("PART_ChatPresenter") as ChatPresenter;
			if (_presenter == null)
			{
				throw new Exception("Missing template part.");
			}
		}

		public void AppendLine(ChatLine line)
		{
			_presenter.AppendLine(line);
		}

		public void Clear()
		{
			_presenter.Clear();
		}

		public void PageUp()
		{
			_presenter.PageUp();
		}

		public void PageDown()
		{
			_presenter.PageDown();
		}

		public void MouseWheelUp()
		{
			_presenter.MouseWheelUp();
		}

		public void MouseWheelDown()
		{
			_presenter.MouseWheelDown();
		}
	}
}
