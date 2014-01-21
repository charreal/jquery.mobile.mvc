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
using jquery.mobile.mvc.Abstract;
using jquery.mobile.mvc.Interfaces;

namespace jquery.mobile.mvc.Core
{
	public class Widget<T> : Element, IWidget<T> where T : Widget<T>
	{
		private String _innerHtml;

		public Widget(string _tag) 
			: base(_tag)
		{
			_innerHtml = "";
		}

		public T Id(String id)
		{
			EnforceHtmlAttribute("id", id);
			return (T)this;
		}

		public T Data(string key, string val)
		{
			EnforceHtmlAttribute(String.Format("data-{0}", key), val);

			return (T)this;
		}

		public T Theme(String theme)
		{
			return Data("theme", theme);
		}

		public T Role(String role)
		{
			return Data("role", role);
		}

		public T AddClass(String className)
		{
			EnforceClass(className);
			return (T)this;
		}

		public T RemoveClass(String className)
		{
			EnforceClassRemoval(className);
			return (T)this;
		}

		public T InnerHtml(string innerHtml)
		{
			_innerHtml = innerHtml;

			return (T)this;
		}

		public T Icon(String iconName, bool noText = false)
		{
			AddClass(String.Format("ui-icon-{0}", iconName));
			if (noText) AddClass("ui-btn-icon-notext");
			return (T) this;
		}

		public string ToHtmlString()
		{
			return StartTag + _innerHtml + EndTag;
		}
	}
}