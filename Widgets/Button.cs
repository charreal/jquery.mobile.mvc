﻿/*
Copyright (c) 2014 Darren Horrocks

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/
using System;
using jquery.mobile.mvc.Core;
using jquery.mobile.mvc.Interfaces;

namespace jquery.mobile.mvc.Widgets
{
	public class Button : Widget<Button>
	{
		public enum ButtonType
		{
			Button,
			Submit,
			Reset,
			Link
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Button"/> class.
		/// </summary>
		/// <param name="type"><see cref="Button"/> type.</param>
		public Button(ButtonType type = ButtonType.Button)
			: base(GetButtonType(type))
		{
			EnforceClass("ui-btn");
			if (type == ButtonType.Submit)
			{
				EnforceHtmlAttribute("type", "submit");
			}
		}

		public Button Href(String href)
		{
			EnforceHtmlAttribute("href", href);

			return this;
		}

		public Button Inline(bool inline)
		{
			return Data("inline", inline.ToString());
		}

		public Button Icon(Icon.IconType ico)
		{
			return AddClass(String.Format("ui-icon-{0}", Core.Icon.IconTypeToString(ico)));
		}

		public static String GetButtonType(ButtonType type)
		{
			switch (type)
			{
				case ButtonType.Submit:
					return "input";
				case ButtonType.Link:
					return "a";
				default:
					return "button";
			}
		}
	}
}
