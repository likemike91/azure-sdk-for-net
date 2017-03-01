// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Management.Sql.Models
{
    /// <summary>
    /// Represents the response to a List Azure Sql Server Key request.
    /// </summary>
    public partial class ServerKeyListResponse : AzureOperationResponse, IEnumerable<ServerKey>
    {
        private IList<ServerKey> _serverKeys;
        
        /// <summary>
        /// Optional. Gets or sets the list of Azure Sql Server Key.
        /// </summary>
        public IList<ServerKey> ServerKeys
        {
            get { return this._serverKeys; }
            set { this._serverKeys = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ServerKeyListResponse class.
        /// </summary>
        public ServerKeyListResponse()
        {
            this.ServerKeys = new LazyList<ServerKey>();
        }
        
        /// <summary>
        /// Gets the sequence of ServerKeys.
        /// </summary>
        public IEnumerator<ServerKey> GetEnumerator()
        {
            return this.ServerKeys.GetEnumerator();
        }
        
        /// <summary>
        /// Gets the sequence of ServerKeys.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
