// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes the settings for producing output into a log analytics
    /// workspace.
    /// </summary>
    public partial class ConnectionMonitorWorkspaceSettings
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ConnectionMonitorWorkspaceSettings class.
        /// </summary>
        public ConnectionMonitorWorkspaceSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ConnectionMonitorWorkspaceSettings class.
        /// </summary>
        /// <param name="workspaceResourceId">Log analytics workspace resource
        /// ID.</param>
        public ConnectionMonitorWorkspaceSettings(string workspaceResourceId = default(string))
        {
            WorkspaceResourceId = workspaceResourceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets log analytics workspace resource ID.
        /// </summary>
        [JsonProperty(PropertyName = "workspaceResourceId")]
        public string WorkspaceResourceId { get; set; }

    }
}