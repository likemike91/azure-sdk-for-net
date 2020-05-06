// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Synapse.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Properties of integration runtime node.
    /// </summary>
    public partial class ManagedIntegrationRuntimeNode
    {
        /// <summary>
        /// Initializes a new instance of the ManagedIntegrationRuntimeNode
        /// class.
        /// </summary>
        public ManagedIntegrationRuntimeNode()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ManagedIntegrationRuntimeNode
        /// class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="nodeId">The managed integration runtime node
        /// id.</param>
        /// <param name="status">The managed integration runtime node status.
        /// Possible values include: 'Starting', 'Available', 'Recycling',
        /// 'Unavailable'</param>
        /// <param name="errors">The errors that occurred on this integration
        /// runtime node.</param>
        public ManagedIntegrationRuntimeNode(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string nodeId = default(string), string status = default(string), IList<ManagedIntegrationRuntimeError> errors = default(IList<ManagedIntegrationRuntimeError>))
        {
            AdditionalProperties = additionalProperties;
            NodeId = nodeId;
            Status = status;
            Errors = errors;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Gets the managed integration runtime node id.
        /// </summary>
        [JsonProperty(PropertyName = "nodeId")]
        public string NodeId { get; private set; }

        /// <summary>
        /// Gets the managed integration runtime node status. Possible values
        /// include: 'Starting', 'Available', 'Recycling', 'Unavailable'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// Gets or sets the errors that occurred on this integration runtime
        /// node.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public IList<ManagedIntegrationRuntimeError> Errors { get; set; }

    }
}