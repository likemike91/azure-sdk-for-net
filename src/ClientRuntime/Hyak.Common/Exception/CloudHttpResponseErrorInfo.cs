﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Hyak.Common.Internals;

namespace Hyak.Common
{
    /// <summary>
    /// Describes HTTP responses associated with error conditions.
    /// </summary>
    public class CloudHttpResponseErrorInfo
        : CloudHttpErrorInfo
    {
        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode StatusCode { get; protected set; }

        /// <summary>
        /// Gets or sets the reason phrase which typically is sent by servers together
        /// with the status code.
        /// </summary>
        public string ReasonPhrase { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the CloudHttpResponseErrorInfo class.
        /// </summary>
        protected CloudHttpResponseErrorInfo()
            : base()
        {
        }

        /// <summary>
        /// Creates a new CloudHttpResponseErrorInfo from a HttpResponseMessage.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <returns>A CloudHttpResponseErrorInfo instance.</returns>
        public static CloudHttpResponseErrorInfo Create(HttpResponseMessage response)
        {
            return Create(response, response.Content.AsString());
        }

        /// <summary>
        /// Creates a new CloudHttpResponseErrorInfo from a HttpResponseMessage.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <param name="content">
        /// The response content, which may be passed separately if the
        /// response has already been disposed.
        /// </param>
        /// <returns>A CloudHttpResponseErrorInfo instance.</returns>
        public static CloudHttpResponseErrorInfo Create(HttpResponseMessage response, string content)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            CloudHttpResponseErrorInfo info = new CloudHttpResponseErrorInfo();

            // Copy CloudHttpErrorInfo properties
            info.Content = content;
            info.Version = response.Version;
            info.CopyHeaders(response.Headers);
            info.CopyHeaders(response.GetContentHeaders());

            // Copy CloudHttpResponseErrorInfo properties
            info.StatusCode = response.StatusCode;
            info.ReasonPhrase = response.ReasonPhrase;
            
            return info;
        }
    }
}
