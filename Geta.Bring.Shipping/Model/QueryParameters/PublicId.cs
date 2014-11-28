using System;
using System.Collections.Specialized;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    internal class PublicId : IQueryParameter
    {
        public PublicId(string publicId)
        {
            if (publicId == null) throw new ArgumentNullException("publicId");
            Items = new NameValueCollection
            {
                {"pid", publicId}
            };
        }

        public NameValueCollection Items { get; private set; }
    }
}