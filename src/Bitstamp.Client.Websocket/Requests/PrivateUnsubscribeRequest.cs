using Bitstamp.Client.Websocket.Channels;
using Bitstamp.Client.Websocket.Messages;

namespace Bitstamp.Client.Websocket.Requests;

/// <summary>
/// Private unsubscribe request
/// </summary>
public class PrivateUnsubscribeRequest : PrivateDataRequest
{
    public PrivateUnsubscribeRequest(string pair, PrivateChannel channel, string userId) : base(pair, channel, userId) { }

    /// <inheritdoc />
    public override string Event => ControlEventNames.Unsubscribe;
}