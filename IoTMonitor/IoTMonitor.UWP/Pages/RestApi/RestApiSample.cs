﻿using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Linq;
using AppStudio.DataProviders.Core;

namespace AppStudio.Uwp.Samples
{
    class RestApiSampleParser : IParser<RestApiSampleSchema>
    {
        private string _mainRoot;
        private string _property1;
        private string _property2;
        private string _property3;
      

        public void InitializeSample(string mainRoot, string pathProperty1, string pathProperty2, string pathProperty3)
        {
            _mainRoot = mainRoot;
            _property1 = pathProperty1;
            _property2 = pathProperty2;
            _property3 = pathProperty3;
          
        }

        public IEnumerable<RestApiSampleSchema> Parse(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var result = new Collection<RestApiSampleSchema>();
            JObject o = JObject.Parse(data);
            IEnumerable<JToken> elements = o.SelectToken(_mainRoot)?.Select(s => s);
            if (elements != null)
            {
                foreach (JToken item in elements)
                {
                    var itemResult = new RestApiSampleSchema();
                    try
                    {
                        
                        if (!string.IsNullOrEmpty(_property1))
                        {
                            itemResult.TextProperty1 = item.SelectToken(_property1)?.ToString().DecodeHtml();
                        }
                        if (!string.IsNullOrEmpty(_property2))
                        {
                            itemResult.TextProperty2 = item.SelectToken(_property2)?.ToString().DecodeHtml();
                        }
                        if (!string.IsNullOrEmpty(_property3))
                        {
                            itemResult.ImageProperty = item.SelectToken(_property3)?.ToString();
                        }                        
                    }
                    catch (Exception)
                    {
                        //Json Parsing Error
                    }
                    result.Add(itemResult);
                }    
            }
            return result;
        }
    }

    public class RestApiSampleSchema : SchemaBase
    {
        public string TextProperty1 { get; set; }
        public string TextProperty2 { get; set; }
        public string ImageProperty { get; set; }       

    }

    public enum PaginationParameterType
    {
        None,
        PageNumber,
        ItemOffset,
        Token,
        NextPageUrl
    }

    public enum RestApiSampleType
    {
        PageNumberPaginationSample,
        ItemOffsetPaginationSample,
        TokenPaginationSample,
        NextPageUrlPaginationSample,
        Custom
    }   
}
