using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers 
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PageInfo pagingInfo)
        {
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", string.Format("/Product/Index/?page={0}", i));
                tagBuilder.InnerHtml = i.ToString();
                if(pagingInfo.CurrentPage == i)
                {
                    tagBuilder.AddCssClass("Active");
                }

                stringBuilder.Append(tagBuilder);
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}