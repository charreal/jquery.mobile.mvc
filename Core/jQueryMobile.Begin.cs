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
using jquery.mobile.mvc.Builders;
using jquery.mobile.mvc.Widgets;

namespace jquery.mobile.mvc.Core
{
	public partial class jQueryMobile<TModel>
	{
		public PageBuilder<TModel> Begin(Page page)
		{
			return new PageBuilder<TModel>(Html, page);
		}

		public PageBuilder<TModel> BeginPage(String id)
		{
			return new PageBuilder<TModel>(Html, new Page(id));
		}

		public FormBuilder<TModel> Begin(Form form)
		{
			return new FormBuilder<TModel>(Html, form);
		}

		public FormBuilder<TModel> BeginForm()
		{
			return new FormBuilder<TModel>(Html, new Form());
		}

		public ButtonBuilder<TModel> Begin(Button button)
		{
			return new ButtonBuilder<TModel>(Html, button);
		}

		public ButtonBuilder<TModel> BeginButton()
		{
			return new ButtonBuilder<TModel>(Html, new Button());
		}
	}
}