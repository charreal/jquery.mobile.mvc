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
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace jquery.mobile.mvc.Abstract
{
	public abstract class Element
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected IDictionary<String, Object> HtmlAttributes;
		protected String Tag;
		protected String InnerTag;
		protected String ClassToEnsure;

		internal Element(String tag)
		{
			HtmlAttributes = new Dictionary<String, Object>();
			Tag = tag;
		}

		internal Element(String tag, String innerTag)
		{
			HtmlAttributes = new Dictionary<String, Object>();
			Tag = tag;
			InnerTag = innerTag;
		}

		internal String EndTag
		{
			get
			{
				if (!String.IsNullOrEmpty(InnerTag)) return String.Format("</{1}></{0}>", Tag, InnerTag);
				return String.IsNullOrEmpty(Tag) ? String.Empty : String.Format("</{0}>", Tag);
			}
		}

		internal virtual String StartTag
		{
			get
			{
				if (String.IsNullOrEmpty(Tag)) return String.Empty;

				TagBuilder builder = new TagBuilder(Tag);
				builder.MergeAttributes(HtmlAttributes);

				if (!String.IsNullOrEmpty(InnerTag)) return String.Format("{0}<{1}>", builder.ToString(TagRenderMode.StartTag), InnerTag);
				return builder.ToString(TagRenderMode.StartTag);
			}
		}

		protected void MergeHtmlAttribute(String key, String value)
		{
			if (HtmlAttributes != null)
			{
				if (HtmlAttributes.ContainsKey(key))
				{
					HtmlAttributes[key] = value;
				}
				else
				{
					HtmlAttributes.Add(key, value);
				}
			}
			else
			{
				HtmlAttributes = new Dictionary<String, Object>
				{
					{key, value}
				};
			}

			if (!String.IsNullOrEmpty(ClassToEnsure)) EnforceClass(ClassToEnsure);
		}

		protected void EnforceClass(String className)
		{
			if (HtmlAttributes.ContainsKey("class"))
			{
				String currentValue = HtmlAttributes["class"].ToString();
				if (!currentValue.Contains(className))
				{
					HtmlAttributes["class"] += " " + className;
				}
			}
			else
			{
				MergeHtmlAttribute("class", className);
			}
		}

		protected void EnforceClassRemoval(String className)
		{
			if (!HtmlAttributes.ContainsKey("class")) return;

			String currentValue = HtmlAttributes["class"].ToString();
			if (currentValue.Contains(className))
			{
				HtmlAttributes["class"] = currentValue.Replace(className, "").Replace("  ", "").Trim();
			}
		}

		protected void EnforceHtmlAttribute(String key, String value, Boolean replaceExisting = true)
		{
			if (HtmlAttributes.ContainsKey(key))
			{
				if (replaceExisting)
				{
					HtmlAttributes[key] = value;
				}
				else
				{
					HtmlAttributes[key] += " " + value;
				}
			}
			else
			{
				HtmlAttributes.Add(key, value);
			}
		}

		protected void EnforceHtmlAttributeRemoval(String key)
		{
			if (HtmlAttributes.ContainsKey(key))
			{
				HtmlAttributes.Remove(key);
			}
		}
	}
}
