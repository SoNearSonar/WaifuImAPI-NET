using WaifuImAPI_NET.Models;

namespace WaifuImAPI_NET.Utilities
{
    internal static class QueryUtility
    {
        internal static string FormatQueryParams(WaifuImSearchSettings settings)
        {
            string query = "?";
            if (settings != null)
            {
                query += AddQueryParam("included_tags", settings.IncludedTags);
                query += AddQueryParam("excluded_tags", settings.ExcludedTags);
                query += AddQueryParam("is_nsfw", settings.IsNsfw);
                query += AddQueryParam("gif", settings.OnlyGif);
                query += AddQueryParam("order_by", settings.OrderBy);
                query += AddQueryParam("orientation", settings.Orientation);
                query += AddQueryParam("height", settings.ExcludedTags);
                query += AddQueryParam("width", settings.ExcludedTags);
                query += AddQueryParam("byte_size", settings.ByteSize);
                query += AddQueryParam("many", settings.ManyFiles);
                query += AddQueryParam("full", settings.FullResult);
                query += AddQueryParam("included_files", settings.IncludedFiles);
                query += AddQueryParam("excluded_files", settings.ExcludedFiles);

                return query.Substring(0, query.Length - 1);
            }

            return query.Substring(0, query.Length - 1);
        }

        internal static string FormatQueryParams(WaifuImFavoriteSettings settings)
        {
            string query = "?";
            if (settings != null)
            {
                query += AddQueryParam("user_id", settings.UserId);
                query += AddQueryParam("image_id", settings.ImageId);

                return query.Substring(0, query.Length - 1);
            }

            return query.Substring(0, query.Length - 1);
        }

        private static string AddQueryParam(string key, Tags[] value)
        {
            if (value != null)
            {
                string result = string.Empty;
                foreach (object item in value)
                {
                    result += AddQueryParam(key, item.ToString().ToLowerInvariant());
                }

                return result;
            }

            return string.Empty;
        }

        private static string AddQueryParam(string key, string[] value)
        {
            if (value != null)
            {
                string result = string.Empty;
                foreach (object item in value)
                {
                    result += AddQueryParam(key, item.ToString().ToLowerInvariant());
                }

                return result;
            }

            return string.Empty;
        }

        private static string AddQueryParam(string key, object value)
        {
            if (value != null)
            {
                return $"{key}={value.ToString().ToLowerInvariant()}&";
            }

            return string.Empty;
        }
    }
}
