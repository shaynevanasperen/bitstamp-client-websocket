using System;
using Bitstamp.Client.Websocket.Channels;
using Bitstamp.Client.Websocket.Messages;
using Bitstamp.Client.Websocket.Utils;

namespace Bitstamp.Client.Websocket.Requests;

/// <summary>
/// Base class for private requests
/// </summary>
public abstract class PrivateDataRequest : RequestBase
{
    readonly string _pair;
    readonly PrivateChannel _channel;
    readonly string _userId;

    string _authToken;

    protected PrivateDataRequest(string pair, PrivateChannel channel, string userId)
    {
        _pair = pair;
        _channel = channel;
        _userId = userId;
    }

    /// <summary>
    /// Sets the authentication token
    /// </summary>
    /// <param name="token">The token to use (expires after 60 seconds).</param>
    public void SetAuthToken(string token) => _authToken = token;

    public PrivateRequestData Data => new()
    {
        Channel = $"{ChannelType}_{CryptoPairsHelper.Clean(_pair)}-{_userId}",
        Auth = _authToken
    };

    string ChannelType => _channel switch
    {
        PrivateChannel.Orders => ChannelPrefixes.PrivateMyOrders,
        PrivateChannel.Ticker => ChannelPrefixes.PrivateMyTrades,
        _ => throw new NotImplementedException()
    };
}