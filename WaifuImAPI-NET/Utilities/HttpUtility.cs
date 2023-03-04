using System.Collections.Specialized;
using WaifuImAPI_NET.Models.Enums;
using WaifuImAPI_NET.Models.Objects;

namespace WaifuImAPI_NET.Utilities
{
    public class HttpUtility
    {
        public string CreateAPICall(string uri, WaifuImSettings settings = null)
        {
            if (settings != null)
            {
                NameValueCollection query = System.Web.HttpUtility.ParseQueryString(string.Empty);
                FormatTagArrayToString(query, "included_tags", settings.IncludedTags);
                FormatTagArrayToString(query, "excluded_tags", settings.ExcludedTags);
                FormatStringArrayToString(query, "included_files", settings.IncludedFiles);
                FormatStringArrayToString(query, "excluded_files", settings.ExcludedFiles);

                query.Add("is_nsfw", settings.IsNsfw.GetLowerString());
                query.Add("gif", settings.OnlyGif.GetLowerString());
                query.Add("order_by", settings.OrderBy.GetEnumMemberValue());
                query.Add("orientation", settings.Orientation.GetEnumMemberValue());
                query.Add("many", settings.ManyFiles.GetLowerString());
                query.Add("full", settings.FullResult.GetLowerString());
                string result =  uri + "/?" + query.ToString();
                return result;
            }

            return uri;
        }

        private void FormatTagArrayToString(NameValueCollection query, string key, Tags[] tags)
        {
            foreach (Tags tag in tags)
            {
                query.Add(key, tag.GetEnumMemberValue());
            }
        }

        private void FormatStringArrayToString(NameValueCollection query, string key, string[] tags)
        {
            foreach (string tag in tags)
            {
                query.Add(key, tag.ToString());
            }
        }
    }
}
