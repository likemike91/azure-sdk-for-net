// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Billing
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BillingSubscriptionsOperations operations.
    /// </summary>
    public partial interface IBillingSubscriptionsOperations
    {
        /// <summary>
        /// Lists the subscriptions for a customer. The operation is supported
        /// only for billing accounts with agreement type Microsoft Partner
        /// Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='customerName'>
        /// The ID that uniquely identifies a customer.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByCustomerWithHttpMessagesAsync(string billingAccountName, string customerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions for a billing account. The operation is
        /// supported for billing accounts with agreement type Microsoft
        /// Customer Agreement or Microsoft Partner Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingAccountWithHttpMessagesAsync(string billingAccountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions that are billed to a billing profile. The
        /// operation is supported for billing accounts with agreement type
        /// Microsoft Customer Agreement or Microsoft Partner Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='billingProfileName'>
        /// The ID that uniquely identifies a billing profile.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingProfileWithHttpMessagesAsync(string billingAccountName, string billingProfileName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions that are billed to an invoice section. The
        /// operation is supported only for billing accounts with agreement
        /// type Microsoft Customer Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='billingProfileName'>
        /// The ID that uniquely identifies a billing profile.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// The ID that uniquely identifies an invoice section.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByInvoiceSectionWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a subscription by its ID. The operation is supported for
        /// billing accounts with agreement type Microsoft Customer Agreement
        /// and Microsoft Partner Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription>> GetWithHttpMessagesAsync(string billingAccountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the properties of a billing subscription. Currently, cost
        /// center can be updated. The operation is supported only for billing
        /// accounts with agreement type Microsoft Customer Agreement.
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters that are provided to the update billing
        /// subscription operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription>> UpdateWithHttpMessagesAsync(string billingAccountName, BillingSubscription parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Moves a subscription's charges to a new invoice section. The new
        /// invoice section must belong to the same billing profile as the
        /// existing invoice section. This operation is supported for billing
        /// accounts with agreement type Microsoft Customer Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters that are provided to the move subscription
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription,BillingSubscriptionsMoveHeaders>> MoveWithHttpMessagesAsync(string billingAccountName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Validates if a subscription's charges can be moved to a new invoice
        /// section. This operation is supported for billing accounts with
        /// agreement type Microsoft Customer Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters that are provided to the validate move
        /// eligibility operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ValidateSubscriptionTransferEligibilityResult>> ValidateMoveWithHttpMessagesAsync(string billingAccountName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Moves a subscription's charges to a new invoice section. The new
        /// invoice section must belong to the same billing profile as the
        /// existing invoice section. This operation is supported for billing
        /// accounts with agreement type Microsoft Customer Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// The ID that uniquely identifies a billing account.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters that are provided to the move subscription
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription,BillingSubscriptionsMoveHeaders>> BeginMoveWithHttpMessagesAsync(string billingAccountName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions for a customer. The operation is supported
        /// only for billing accounts with agreement type Microsoft Partner
        /// Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByCustomerNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions for a billing account. The operation is
        /// supported for billing accounts with agreement type Microsoft
        /// Customer Agreement or Microsoft Partner Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingAccountNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions that are billed to a billing profile. The
        /// operation is supported for billing accounts with agreement type
        /// Microsoft Customer Agreement or Microsoft Partner Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingProfileNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the subscriptions that are billed to an invoice section. The
        /// operation is supported only for billing accounts with agreement
        /// type Microsoft Customer Agreement.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByInvoiceSectionNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
