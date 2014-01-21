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
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using jquery.mobile.mvc.Core;

namespace jquery.mobile.mvc.Abstract
{
	public abstract class Builder<TModel, T> : IDisposable where T : Widget<T>
	{
		protected readonly T element;

		protected readonly TextWriter textWriter;
		protected readonly HtmlHelper<TModel> htmlHelper;
		protected readonly AjaxHelper<TModel> ajaxHelper;

		internal Builder(HtmlHelper<TModel> _htmlHelper, T _element)
        {
			if (_element == null)
            {
				throw new ArgumentNullException("_element");
            }

			element = _element;
			htmlHelper = _htmlHelper;
            textWriter = htmlHelper.ViewContext.Writer;
			textWriter.WriteLine(element.StartTag);
        }

		internal Builder(AjaxHelper<TModel> _ajaxHelper, T _element)
        {
			if (_element == null)
            {
				throw new ArgumentNullException("_element");
            }

			element = _element;
			ajaxHelper = _ajaxHelper;
            textWriter = ajaxHelper.ViewContext.Writer;
			textWriter.WriteLine(element.StartTag);
        }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void Dispose()
		{
			textWriter.WriteLine(element.EndTag);
			textWriter.WriteLine();
		}
	}
}
