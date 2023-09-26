using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyAutoService.Models;

namespace MyAutoService.TagHelpers
{
	[HtmlTargetElement(tag: "div", Attributes = "page-model")]
	public class PageLinkTagHelper : TagHelper
	{
		
		
			private IUrlHelperFactory urlHelperFactory;

			public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
			{
				this.urlHelperFactory =  new UrlHelperFactory();
			}

		
			[ViewContext]
			[HtmlAttributeNotBound]
			//taghire zaher darhalate  addi che klass dashte bashim
			public ViewContext viewContext { get; set; }
			public Paginginfo Paginginfo { get; set; }
			public string PageAction { get; set; }
			public string PageClass { get; set; }
			public string PageClassNormal { get; set; }
			public string PageClassSelected { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
			TagBuilder result = new TagBuilder("div");
			for (int i = 1; i<= Paginginfo.TotalItems; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				string url = Paginginfo.urlParam.Replace(":", i.ToString());
				tag.Attributes["href"] = url;
				tag.AddCssClass(PageClass);
				tag.AddCssClass(i == Paginginfo.CurrentPage ? PageClassSelected :PageClassNormal);
				tag.InnerHtml.Append(i.ToString());
				result.InnerHtml.AppendHtml(tag);
			}
			output.Content.AppendHtml(result.InnerHtml);
		
		}

	}
}
