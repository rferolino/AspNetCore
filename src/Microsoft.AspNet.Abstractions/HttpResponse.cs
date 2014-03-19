﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Abstractions
{
    public abstract class HttpResponse
    {
        // TODO - review IOwinResponse for completeness

        public abstract HttpContext HttpContext { get; }
        public abstract int StatusCode { get; set; }
        public abstract IHeaderDictionary Headers { get; }
        public abstract Stream Body { get; set; }

        public abstract long? ContentLength { get; set; }
        public abstract string ContentType { get; set; }

        public abstract IResponseCookies Cookies { get; }

        public abstract void OnSendingHeaders(Action<object> callback, object state);

        public abstract void Redirect(string location);

        public abstract Task WriteAsync(string data);
    }
}
