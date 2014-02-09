using System;
using System.Collections.Generic;
using System.Linq;

namespace Fehb
{
	public class Builder
	{
		public string Html { get; private set; }

		public Builder EnterHtml()
		{
			Html += "<html>";
			return this;
		}

		public Builder EnterHead()
		{
			Html += "<head>";
			return this;
		}

		public Builder LeaveHead()
		{
			Html += "</head>";
			return this;
		}

		public Builder EnterBody()
		{
			Html += "<body>";
			return this;
		}

		public Builder LeaveBody()
		{
			Html += "</body>";
			return this;
		}

		public Builder LeaveHtml()
		{
			Html += "</html>";
			return this;
		}

		#region Tags

		#region Title

		public Builder CreateTitleTag(string title)
		{
			Html += String.Format("<title>{0}</title>", title);
			return this;
		}

		#endregion

		#region Meta

		public Builder CreateMetaTag(string name)
		{
			return CreateMetaTag(name, null);
		}

		public Builder CreateMetaTag(string name, string content)
		{
			return CreateMetaTag(name, content, null);
		}

		public Builder CreateMetaTag(string name, string content, string httpEquiv)
		{
			return CreateMetaTag(name, content, httpEquiv, null);
		}

		public Builder CreateMetaTag(string name, string content, string httpEquiv, string charSet)
		{
			var tag = "<meta";

			if (name != null)		tag += String.Format(" name=\"{0}\"", name);
			if (content != null)	tag += String.Format(" content=\"{0}\"", content);
			if (httpEquiv != null)	tag += String.Format(" http-equiv=\"{0}\"", httpEquiv);
			if (charSet != null)	tag += String.Format(" charset=\"{0}\"", charSet);

			tag += ">";
			Html += tag;
			return this;
		}

		#endregion

		#region Div

		public Builder EnterDiv(string id = null, string htmlClass = null, Dictionary<string, object> attributes = null)
		{
			var tag = "<div";

			if (id != null) tag += String.Format(" id=\"{0}\"", id);
			if (htmlClass != null) tag += String.Format(" class=\"{0}\"", htmlClass);
			if (attributes != null) tag = attributes.Aggregate(tag, (current, attribute) => current + String.Format(" {0}=\"{1}\"", attribute.Key, attribute.Value));

			tag += ">";
			Html += tag;

			return this;
		}

		public Builder LeaveDiv()
		{
			Html += "</div>";
			return this;
		}

		#endregion

		#region Headings

		public enum HeaderType
		{
			H1,
			H2,
			H3,
			H4,
			H5,
			H6
		}

		public Builder CreateHeading(string content, HeaderType headerType, string id = null, string htmlClass = null, Dictionary<string, object> attributes = null)
		{
			return CreateHeading(headerType, content, id, htmlClass, attributes);
		}

		private Builder CreateHeading(HeaderType headerType, string content, string id, string htmlClass, Dictionary<string, object> attributes = null)
		{
			if (attributes == null) attributes = new Dictionary<string, object>();
			if (id != null) attributes.Add("id", id);
			if (htmlClass != null) attributes.Add("class", htmlClass);

			var htmlAttributes = attributes.Aggregate("", (current, attribute) => current + String.Format(" {0}=\"{1}\"", attribute.Key, attribute.Value));
			var tag = String.Format("<{0}{1}>{2}</{0}>", headerType.ToString().ToLower(), htmlAttributes, content);
			Html += tag;
			return this;
		}

		#endregion

		#endregion
	}
}
