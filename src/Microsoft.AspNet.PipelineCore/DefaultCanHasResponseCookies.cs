﻿using Microsoft.AspNet.Abstractions;
using Microsoft.AspNet.FeatureModel;
using Microsoft.AspNet.HttpFeature;
using Microsoft.AspNet.PipelineCore.Collections;
using Microsoft.AspNet.PipelineCore.Infrastructure;

namespace Microsoft.AspNet.PipelineCore
{
    public class DefaultCanHasResponseCookies : ICanHasResponseCookies
    {
        private readonly IFeatureCollection _features;
        private readonly FeatureReference<IHttpResponseInformation> _request = FeatureReference<IHttpResponseInformation>.Default;
        private IResponseCookies _cookiesCollection;

        public DefaultCanHasResponseCookies(IFeatureCollection features)
        {
            _features = features;
        }

        public IResponseCookies Cookies
        {
            get
            {
                if (_cookiesCollection == null)
                {
                    var headers = _request.Fetch(_features).Headers;
                    _cookiesCollection = new ResponseCookies(new HeaderDictionary(headers));
                }

                return _cookiesCollection;
            }
        }
    }
}