using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString EventLinks(this HtmlHelper html, Event eventModel)
        {
            StringBuilder result = new StringBuilder();

            /*TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(i));
            tag.InnerHtml = i.ToString();
            if (i == pagingInfo.CurrentPage)
            {
                tag.AddCssClass("selected");
                tag.AddCssClass("btn-primary");
            }
            tag.AddCssClass("btn btn-default");
            result.Append(tag.ToString());*/
            MvcHtmlString res = MvcHtmlString.Create(result.ToString());
            return res;
        }
    }
}