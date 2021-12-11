using Bitstamp.Client.Websocket.Channels;
using Bitstamp.Client.Websocket.Messages;

namespace Bitstamp.Client.Websocket.Requests;

/// <summary>
/// Private subscribe request
/// </summary>
public class PrivateSubscribeRequest : PrivateDataRequest
{
    public PrivateSubscribeRequest(string pair, PrivateChannel channel, string userId) : base(pair, channel, userId) { }

    /// <inheritdoc />
    public override string Event => ControlEventNames.Subscribe;
}