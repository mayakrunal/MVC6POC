﻿// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="PageLinkTagHelper.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;

namespace SportsStore.Infrastructure
{
    /// <summary>
    /// Class PageLinkTagHelper.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        /// <summary>
        /// The URL helper factory
        /// </summary>
        private IUrlHelperFactory urlHelperFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageLinkTagHelper" /> class.
        /// </summary>
        /// <param name="helperFactory">The helper factory.</param>
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        /// <summary>
        /// Gets or sets the view context.
        /// </summary>
        /// <value>The view context.</value>
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Gets or sets the page model.
        /// </summary>
        /// <value>The page model.</value>
        public PagingInfo PageModel { get; set; }

        /// <summary>
        /// Gets or sets the page action.
        /// </summary>
        /// <value>The page action.</value>
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets a value indicating whether [page classes enabled].
        /// </summary>
        /// <value><c>true</c> if [page classes enabled]; otherwise, <c>false</c>.</value>
        public bool PageClassesEnabled { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the page class.
        /// </summary>
        /// <value>The page class.</value>
        public string PageClass { get; set; }
       
        /// <summary>
        /// Gets or sets the page class normal.
        /// </summary>
        /// <value>The page class normal.</value>
        public string PageClassNormal { get; set; }
        
        /// <summary>
        /// Gets or sets the page class selected.
        /// </summary>
        /// <value>The page class selected.</value>
        public string PageClassSelected { get; set; }

        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage
                    ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
