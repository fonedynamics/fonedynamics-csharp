using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoneDynamics.Http;
using FoneDynamics.Utility;

namespace FoneDynamics.Rest.V2
{
    /// <summary>
    /// Represents a message and contains messaging functionality.
    /// </summary>
    public class MessageResource
    {
        /// <summary>
        /// The message secure identifier which uniquely identifies this message.
        /// </summary>
        public string MessageSid { get; internal set; }

        /// <summary>
        /// The account secure identifier associated with the message.
        /// </summary>
        public string AccountSid { get; internal set; }

        /// <summary>
        /// The property secure identifier associated with the message.
        /// </summary>
        public string PropertySid { get; internal set; }

        /// <summary>
        /// The alphanumeric or E164 formatted sender ID of the message.
        /// If composing a message, a null or empty value indicates that a number should
        /// be dynamically leased for this message.
        /// </summary>
        public string From { get; internal set; }

        /// <summary>
        /// The E164 formatted recipient of the SMS message.
        /// </summary>
        public string To { get; internal set; }

        /// <summary>
        /// The content of the SMS message.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Set to true if a delivery receipt was requested and false otherwise.
        /// </summary>
        public bool DeliveryReceipt { get; internal set; }

        /// <summary>
        /// The number of message segments.
        /// </summary>
        public int? NumSegments { get; internal set; }

        /// <summary>
        /// The message status. See below table for possible values.
        /// </summary>
        public MessageStatus? Status { get; internal set; }

        /// <summary>
        /// The direction of the message.
        /// </summary>
        public MessageDirection? Direction { get; internal set; }

        /// <summary>
        /// Timestamp of when the message is/was scheduled to be sent.
        /// </summary>
        public int? Scheduled { get; internal set; }

        /// <summary>
        /// Timestamp of when the message resource was created.
        /// </summary>
        public int? Created { get; internal set; }

        /// <summary>
        /// Timestamp of when the message was submitted to the SMS Center.
        /// </summary>
        public int? Submitted { get; internal set; }

        /// <summary>
        /// Timestamp of when the message delivery occurred.
        /// </summary>
        public int? Delivered { get; internal set; }

        /// <summary>
        /// Timestamp of when an inbound message was received.
        /// </summary>
        public int? Received { get; internal set; }

        /// <summary>
        /// Error code (if message submission or delivery failed).
        /// </summary>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// The UTC time in seconds since Unix Epoch to send the message. This can be at most
        /// 14 days in the future. If the value is in the past, the request will fail, unless
        /// the value is less than 1 hour in the past, in which case the request will succeed
        /// and the message will be sent immediately.
        /// </summary>
        public int? Schedule { get; internal set; }

        /// <summary>
        /// The callback URI to invoke when a delivery receipt is received. Note that
        /// DeliveryReceipt must be set to true for this to be triggered.
        /// </summary>
        public string DeliveryReceiptWebhookUri { get; internal set; }

        /// <summary>
        /// The method to use for delivery receipt callbacks. Valid options are POST and GET.
        /// Default is POST.
        /// </summary>
        public WebhookMethod? DeliveryReceiptWebhookMethod { get; internal set; }

        /// <summary>
        /// When a response is received, forward it to this number in E164 format.
        /// </summary>
        public string ForwardToSms { get; internal set; }

        /// <summary>
        /// When forwarding via SMS, send from this E164 formatted number or alphanumeric sender
        /// ID. By default the sender ID will be the sender ID of the responding party.
        /// </summary>
        public string ForwardFromSms { get; internal set; }

        /// <summary>
        /// When a response is received, forward it over email to this email address.
        /// </summary>
        public string ForwardToEmail { get; internal set; }

        /// <summary>
        /// When forwarding via email, send from this email address. By default this is a
        /// "no reply" email address.
        /// </summary>
        public string ForwardFromEmail { get; internal set; }

        /// <summary>
        /// The callback URI to invoke when a response is received.
        /// </summary>
        public string WebhookUri { get; internal set; }

        /// <summary>
        /// The method to use for response callbacks. Valid options are POST and GET.
        /// Default is POST.
        /// </summary>
        public WebhookMethod? WebhookMethod { get; internal set; }

        /// <summary>
        /// Hidden parameterless constructor.
        /// </summary>
        private MessageResource()
        {
        }

        /// <summary>
        /// Constructs a new message resource.  This does not send the message.
        /// To send a message, use MessageResource.Send().
        /// </summary>
        /// <param name="to">The recipient of the SMS message in E164 format (including + prefix).</param>
        /// <param name="text">The content of the SMS message.</param>
        /// <param name="from">
        /// The sender ID. This can be a mobile phone number in E164 format (including + prefix),
        /// an alphanumeric string, or blank or null to send from a leased number.
        /// </param>
        /// <param name="schedule">
        /// The UTC time in seconds since Unix Epoch to send the message.
        /// This can be at most 14 days in the future. If the value is in the past, the request will
        /// fail, unless the value is less than 1 hour in the past, in which case the request will
        /// succeed and the message will be sent immediately.
        /// </param>
        /// <param name="webhookUri">The callback URI to invoke when a response is received.</param>
        /// <param name="webhookMethod">
        /// The method to use for response callbacks. Valid options are POST and GET. Default is POST.
        /// </param>
        /// <param name="deliveryReceipt">Whether to request a delivery receipt.</param>
        /// <param name="deliveryReceiptWebhookUri">
        /// The callback URI to invoke when a delivery receipt is received.
        /// Note that DeliveryReceipt must be set to true for this to be triggered.
        /// </param>
        /// <param name="deliveryReceiptWebhookMethod">
        /// The method to use for delivery receipt callbacks. Valid options are POST and GET.
        /// Default is POST.
        /// </param>
        /// <param name="forwardToSms">
        /// When a response is received, forward it to this number in E164 format.
        /// </param>
        /// <param name="forwardFromSms">
        /// When forwarding via SMS, send from this E164 formatted number or alphanumeric sender ID.
        /// By default the sender ID will be the sender ID of the responding party.
        /// </param>
        /// <param name="forwardToEmail">
        /// When a response is received, forward it over email to this email address.
        /// </param>
        /// <param name="forwardFromEmail">
        /// When forwarding via email, send from this email address.  By default this is a "no reply"
        /// email address.
        /// </param>
        public MessageResource(
            string to,
            string text,
            string from = null,
            int? schedule = null,
            string webhookUri = null,
            WebhookMethod? webhookMethod = null,
            bool deliveryReceipt = true,
            string deliveryReceiptWebhookUri = null,
            WebhookMethod? deliveryReceiptWebhookMethod = null,
            string forwardToSms = null,
            string forwardFromSms = null,
            string forwardToEmail = null,
            string forwardFromEmail = null)
        {
            // persist
            To = to;
            Text = text;
            From = from;
            Schedule = schedule;
            WebhookUri = webhookUri;
            WebhookMethod = webhookMethod;
            DeliveryReceipt = deliveryReceipt;
            DeliveryReceiptWebhookUri = deliveryReceiptWebhookUri;
            DeliveryReceiptWebhookMethod = deliveryReceiptWebhookMethod;
            ForwardToSms = forwardToSms;
            ForwardFromSms = forwardFromSms;
            ForwardToEmail = forwardToEmail;
            ForwardFromEmail = forwardFromEmail;
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message to send constructed using the MessageResource constructor.</param>
        /// <param name="propertySid">
        /// The PropertySid of the property against which to send the message.
        /// If null, the default PropertySid will be used, unless it is undefined,
        /// in which case an exception will be thrown.
        /// </param>
        /// <param name="foneDynamicsClient">
        /// The FoneDynamicsClient instance to use.  If null, the default instance will be used.
        /// </param>
        /// <returns>The MessageResource that was sent, or an exception on failure.</returns>
        public static MessageResource Send(
            MessageResource message,
            string propertySid = null,
            FoneDynamicsClient foneDynamicsClient = null)
        {
            // validate
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message.MessageSid != null) throw new InvalidOperationException("Cannot send an existing message.");

            // set defaults
            FoneDynamicsClient.SetDefaults(ref propertySid, ref foneDynamicsClient);

            // construct the request
            Request request = new Request(HttpMethod.Post, $"/v2/Properties/{Web.UrlEncode(propertySid)}/Messages",
                foneDynamicsClient.AccountSid, foneDynamicsClient.Token);

            // set the request body
            request.SetBody(Json.Serialize(message), Json.CONTENT_TYPE);

            // perform the request and get the response
            HttpResponse response = foneDynamicsClient.HttpClient.Send(request);

            // throw if failed
            if (!response.IsSuccess) throw Errors.ErrorResponse.CreateException(response);

            // deserialise and return
            MessageResponse msg = Json.Deserialize<MessageResponse>(response.Content);
            return msg.Message;
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="to">The recipient of the SMS message in E164 format (including + prefix).</param>
        /// <param name="text">The content of the SMS message.</param>
        /// <param name="from">
        /// The sender ID. This can be a mobile phone number in E164 format (including + prefix),
        /// an alphanumeric string, or blank or null to send from a leased number.
        /// </param>
        /// <param name="schedule">
        /// The UTC time in seconds since Unix Epoch to send the message.
        /// This can be at most 14 days in the future. If the value is in the past, the request will
        /// fail, unless the value is less than 1 hour in the past, in which case the request will
        /// succeed and the message will be sent immediately.
        /// </param>
        /// <param name="webhookUri">The callback URI to invoke when a response is received.</param>
        /// <param name="webhookMethod">
        /// The method to use for response callbacks. Valid options are POST and GET. Default is POST.
        /// </param>
        /// <param name="deliveryReceipt">Whether to request a delivery receipt.</param>
        /// <param name="deliveryReceiptWebhookUri">
        /// The callback URI to invoke when a delivery receipt is received.
        /// Note that DeliveryReceipt must be set to true for this to be triggered.
        /// </param>
        /// <param name="deliveryReceiptWebhookMethod">
        /// The method to use for delivery receipt callbacks. Valid options are POST and GET.
        /// Default is POST.
        /// </param>
        /// <param name="forwardToSms">
        /// When a response is received, forward it to this number in E164 format.
        /// </param>
        /// <param name="forwardFromSms">
        /// When forwarding via SMS, send from this E164 formatted number or alphanumeric sender ID.
        /// By default the sender ID will be the sender ID of the responding party.
        /// </param>
        /// <param name="forwardToEmail">
        /// When a response is received, forward it over email to this email address.
        /// </param>
        /// <param name="forwardFromEmail">
        /// When forwarding via email, send from this email address.  By default this is a "no reply"
        /// email address.
        /// </param>
        /// <param name="propertySid">
        /// The PropertySid of the property against which to send the message.
        /// If null, the default PropertySid will be used, unless it is undefined,
        /// in which case an exception will be thrown.
        /// </param>
        /// <param name="foneDynamicsClient">
        /// The FoneDynamicsClient instance to use.  If null, the default instance will be used.
        /// </param>
        /// <returns>The MessageResource that was sent, or an exception on failure.</returns>
        public static MessageResource Send(
            string to,
            string text,
            string from = null,
            int? schedule = null,
            string webhookUri = null,
            WebhookMethod? webhookMethod = null,
            bool deliveryReceipt = true,
            string deliveryReceiptWebhookUri = null,
            WebhookMethod? deliveryReceiptWebhookMethod = null,
            string forwardToSms = null,
            string forwardFromSms = null,
            string forwardToEmail = null,
            string forwardFromEmail = null,
            string propertySid = null,
            FoneDynamicsClient foneDynamicsClient = null)
        {
            // build new MessageResource
            MessageResource msg = new MessageResource(
                to, text, from, schedule, webhookUri, webhookMethod, deliveryReceipt, deliveryReceiptWebhookUri,
                deliveryReceiptWebhookMethod, forwardToSms, forwardFromSms, forwardToEmail, forwardFromEmail);

            // send
            return Send(msg, propertySid, foneDynamicsClient);
        }

        /// <summary>
        /// Gets a message against the account by its MessageSid.
        /// </summary>
        /// <param name="messageSid">The MessageSid of the message to retrieve.</param>
        /// <param name="foneDynamicsClient">
        /// The FoneDynamicsClient instance to use.  If null, the default instance will be used.
        /// </param>
        /// <returns>The MessageResource that was sent, or an exception on failure.</returns>
        public static MessageResource Get(
            string messageSid,
            string propertySid = null,
            FoneDynamicsClient foneDynamicsClient = null)
        {
            // validate
            if (messageSid == null) throw new ArgumentNullException(nameof(messageSid));

            // set defaults
            FoneDynamicsClient.SetDefaults(ref propertySid, ref foneDynamicsClient);

            // construct the request
            Request request = new Request(HttpMethod.Get, $"/v2/Messages/{Web.UrlEncode(messageSid)}",
                foneDynamicsClient.AccountSid, foneDynamicsClient.Token);

            // perform the request and get the response
            HttpResponse response = foneDynamicsClient.HttpClient.Send(request);

            // throw if failed
            if (!response.IsSuccess) throw Errors.ErrorResponse.CreateException(response);

            // deserialise and return
            MessageResponse msg = Json.Deserialize<MessageResponse>(response.Content);
            return msg.Message;
        }
    }
}
