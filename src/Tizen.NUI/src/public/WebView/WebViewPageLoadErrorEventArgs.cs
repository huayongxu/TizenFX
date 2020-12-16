/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Event arguments that passed via the WebView.PageLoadError.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class WebViewPageLoadErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for the load error code
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum LoadErrorCode
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown,
            /// <summary>
            /// User canceled.
            /// </summary>
            Canceled,
            /// <summary>
            /// Can't show the page for this MIME type.
            /// </summary>
            CantSupportMimetype,
            /// <summary>
            /// File IO error.
            /// </summary>
            FailedFileIo,
            /// <summary>
            /// Cannot connect to the network.
            /// </summary>
            CantConnect,
            /// <summary>
            /// Fail to look up host from the DNS.
            /// </summary>
            CantLookupHost,
            /// <summary>
            /// Fail to SSL/TLS handshake.
            /// </summary>
            FailedTlsHandshake,
            /// <summary>
            /// Received certificate is invalid.
            /// </summary>
            InvalidCertificate,
            /// <summary>
            /// Connection timeout.
            /// </summary>
            RequestTimeout,
            /// <summary>
            /// Too many redirects.
            /// </summary>
            TooManyRedirects,
            /// <summary>
            /// Too many requests during this load.
            /// </summary>
            TooManyRequests,
            /// <summary>
            /// Malformed URL.
            /// </summary>
            BadUrl,
            /// <summary>
            /// Unsupported scheme.
            /// </summary>
            UnsupportedScheme,
            /// <summary>
            /// User authentication failed on the server.
            /// </summary>
            Authentication,
            /// <summary>
            /// Web server has an internal server error.
            /// </summary>
            InternalServer,
        }

        /// <summary>
        /// The view for displaying webpages.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView WebView { get; set; }

        /// <summary>
        /// The url string of current webpage.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PageUrl { get; set; }

        /// <summary>
        /// The code for the current error.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadErrorCode ErrorCode { get; set; }
    }
}
