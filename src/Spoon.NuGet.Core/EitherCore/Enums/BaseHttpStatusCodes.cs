namespace Spoon.NuGet.Core.EitherCore.Enums;

/// <summary>
///     Contains constants for the most common HTTP status codes.
/// </summary>
public static class BaseHttpStatusCodes
{
    /// <summary>
    ///     Continue indicates that the client can continue with its request.
    /// </summary>
    public const int Status100Continue = 100;

    /// <summary>
    ///     Switching Protocols indicates that the server will switch to the protocol the client has
    ///     advertised in the Upgrade request header field.
    /// </summary>
    public const int Status101SwitchingProtocols = 101;

    /// <summary>
    ///     Processing is an interim response used to inform the client that the server has accepted the
    ///     complete request but hasn't yet completed it.
    /// </summary>
    public const int Status102Processing = 102;

    /// <summary>
    ///     OK indicates that the request succeeded and that the requested information is in the response.
    /// </summary>
    public const int Status200OK = 200;

    /// <summary>
    ///     Created indicates that the request resulted in a new resource created before the response was sent.
    /// </summary>
    public const int Status201Created = 201;

    /// <summary>
    ///     Accepted indicates that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    public const int Status202Accepted = 202;

    /// <summary>
    ///     Non-Authoritative Information indicates that the returned metainformation is from a
    ///     cached copy instead of the origin server and therefore may be incorrect.
    /// </summary>
    public const int Status203NonAuthoritative = 203;

    /// <summary>
    ///     No Content indicates that the request has been successfully processed and that the response is intentionally blank.
    /// </summary>
    public const int Status204NoContent = 204;

    /// <summary>
    ///     Reset Content indicates that the client should reset (not reload) the current resource.
    /// </summary>
    public const int Status205ResetContent = 205;

    /// <summary>
    ///     Partial Content indicates that the response is a partial response as requested by a GET request that includes a
    ///     range header.
    /// </summary>
    public const int Status206PartialContent = 206;

    /// <summary>
    ///     Multi-Status indicates that the response body contains an XML message that follows the WebDAV standard.
    /// </summary>
    public const int Status207MultiStatus = 207;

    /// <summary>
    ///     Already Reported indicates that the members of a WebDAV binding have already been enumerated in a preceding part of
    ///     the
    ///     (multistatus) response, and are not being included again.
    /// </summary>
    public const int Status208AlreadyReported = 208;

    /// <summary>
    ///     IM Used is an optional status code, primarily intended to be used with the LINK method, to indicate that the result
    ///     of the
    ///     action (a change to the Web resource) is being returned in the message body.
    /// </summary>
    public const int Status226IMUsed = 226;

    /// <summary>
    ///     Multiple Choices indicates that the request has more than one possible response.
    /// </summary>
    public const int Status300MultipleChoices = 300;

    /// <summary>
    ///     Moved Permanently indicates that the requested information has been moved to the URI specified in the Location
    ///     header.
    /// </summary>
    public const int Status301MovedPermanently = 301;

    /// <summary>
    ///     Equivalent to HTTP status 302. Indicates that the requested resource resides temporarily under a different URI.
    /// </summary>
    public const int Status302Found = 302;

    /// <summary>
    ///     Equivalent to HTTP status 303. Indicates that the response to the request can be found under a different URI.
    /// </summary>
    public const int Status303SeeOther = 303;

    /// <summary>
    ///     Equivalent to HTTP status 304. Indicates that the client's cached copy is up to date with the server.
    /// </summary>
    public const int Status304NotModified = 304;

    /// <summary>
    ///     Equivalent to HTTP status 305. This status code is no longer used, it was used in a previous version of the
    ///     HTTP/1.1 specification.
    /// </summary>
    public const int Status305UseProxy = 305;

    /// <summary>
    ///     Equivalent to HTTP status 306. This status code is no longer used, it was used in a previous version of the
    ///     HTTP/1.1 specification.
    /// </summary>
    public const int Status306SwitchProxy = 306;

    /// <summary>
    ///     Equivalent to HTTP status 307. Indicates that the requested resource resides temporarily under a different URI, but
    ///     that the client should continue to use the original URI for future requests.
    /// </summary>
    public const int Status307TemporaryRedirect = 307;

    /// <summary>
    ///     Equivalent to HTTP status 308. Indicates that the requested resource has permanently moved to a new URI, and all
    ///     future requests should be directed to the new URI.
    /// </summary>
    public const int Status308PermanentRedirect = 308;

    /// <summary>
    ///     Equivalent to HTTP status 400. Indicates that the server cannot or will not process the request due to an apparent
    ///     client error.
    /// </summary>
    public const int Status400BadRequest = 400;

    /// <summary>
    ///     Equivalent to HTTP status 401. Indicates that the request requires authentication, and the user has not provided
    ///     valid authentication credentials.
    /// </summary>
    public const int Status401Unauthorized = 401;

    /// <summary>
    ///     Equivalent to HTTP status 402. This status code is no longer used, it was reserved for future use in a previous
    ///     version of the HTTP/1.1 specification.
    /// </summary>
    public const int Status402PaymentRequired = 402;

    /// <summary>
    ///     Equivalent to HTTP status 403. Indicates that the server understands the request, but refuses to authorize it.
    /// </summary>
    public const int Status403Forbidden = 403;

    /// <summary>
    ///     Equivalent to HTTP status 404. Indicates that the server cannot find the requested resource.
    /// </summary>
    public const int Status404NotFound = 404;

    /// <summary>
    ///     Equivalent to HTTP status 405. Indicates that the method specified in the request is not allowed for the resource
    ///     identified by the request URI.
    /// </summary>
    public const int Status405MethodNotAllowed = 405;

    /// <summary>
    ///     Equivalent to HTTP status 406. Indicates that the server cannot generate a response that matches the list of
    ///     acceptable values defined in the request's proactive content negotiation headers.
    /// </summary>
    public const int Status406NotAcceptable = 406;

    /// <summary>
    ///     The client must first authenticate itself with the proxy.
    /// </summary>
    public const int Status407ProxyAuthenticationRequired = 407;

    /// <summary>
    ///     The server timed out waiting for the request.
    /// </summary>
    public const int Status408RequestTimeout = 408;

    /// <summary>
    ///     The request could not be completed due to a conflict with the current state of the target resource.
    /// </summary>
    public const int Status409Conflict = 409;

    /// <summary>
    ///     The requested resource is no longer available at the server and no forwarding address is known.
    /// </summary>
    public const int Status410Gone = 410;

    /// <summary>
    ///     The server requires the request to be conditional.
    /// </summary>
    public const int Status411LengthRequired = 411;

    /// <summary>
    ///     The precondition given in one or more of the request-header fields evaluated to false when it was tested on the
    ///     server.
    /// </summary>
    public const int Status412PreconditionFailed = 412;

    /// <summary>
    ///     The server is refusing to process a request because the request entity is larger than the server is willing or able
    ///     to process.
    /// </summary>
    public const int Status413RequestEntityTooLarge = 413;

    /// <summary>
    ///     The server is refusing to process a request because the payload is larger than the server is willing or able to
    ///     process.
    /// </summary>
    public const int Status413PayloadTooLarge = 413;

    /// <summary>
    ///     The server is refusing to service the request because the request-target is longer than the server is willing to
    ///     interpret.
    /// </summary>
    public const int Status414RequestUriTooLong = 414;

    /// <summary>
    ///     The server is refusing to service the request because the URI is longer than the server is willing to interpret.
    /// </summary>
    public const int Status414UriTooLong = 414;

    /// <summary>
    ///     The server is refusing to service the request because the entity of the request is in a format not supported by the
    ///     requested resource for the requested method.
    /// </summary>
    public const int Status415UnsupportedMediaType = 415;

    /// <summary>
    ///     None of the ranges in the request's Range header field overlap the current extent of the selected resource or that
    ///     the set of ranges requested has been rejected due to invalid ranges or an excessive request of small or overlapping
    ///     ranges.
    /// </summary>
    public const int Status416RangeNotSatisfiable = 416;

    /// <summary>
    ///     The expectation given in an Expect request-header field could not be met by this server.
    /// </summary>
    public const int Status417ExpectationFailed = 417;

    /// <summary>
    ///     This code was defined in 1998 as one of the traditional IETF April Fools' jokes, in RFC 2324, Hyper Text Coffee Pot
    ///     Control Protocol, and is not expected to be implemented by actual HTTP servers.
    /// </summary>
    public const int Status418ImATeapot = 418;

    /// <summary>
    ///     Represents a HTTP status code for when the client's authentication has expired.
    /// </summary>
    public const int Status419AuthenticationTimeout = 419;

    /// <summary>
    ///     Represents a HTTP status code for when the server cannot produce a response due to a misdirected request.
    /// </summary>
    public const int Status421MisdirectedRequest = 421;

    /// <summary>
    ///     Represents a HTTP status code for when the server understands the content of the request, but was unable to process
    ///     it.
    /// </summary>
    public const int Status422UnprocessableEntity = 422;

    /// <summary>
    ///     Represents a HTTP status code for when the resource that is being accessed is locked.
    /// </summary>
    public const int Status423Locked = 423;

    /// <summary>
    ///     Represents a HTTP status code for when the requested resource depends on another resource that has failed to load.
    /// </summary>
    public const int Status424FailedDependency = 424;

    /// <summary>
    ///     Represents a HTTP status code for when the client must switch to a different protocol to access the resource.
    /// </summary>
    public const int Status426UpgradeRequired = 426;

    /// <summary>
    ///     Represents a HTTP status code for when the server requires the client to include a precondition header in the
    ///     request.
    /// </summary>
    public const int Status428PreconditionRequired = 428;

    /// <summary>
    ///     Represents a HTTP status code for when the client has sent too many requests in a given amount of time.
    /// </summary>
    public const int Status429TooManyRequests = 429;

    /// <summary>
    ///     Represents a HTTP status code for when the server cannot process the request because the request headers are too
    ///     large.
    /// </summary>
    public const int Status431RequestHeaderFieldsTooLarge = 431;

    /// <summary>
    ///     Represents a HTTP status code for when the requested resource is unavailable for legal reasons.
    /// </summary>
    public const int Status451UnavailableForLegalReasons = 451;

    /// <summary>
    ///     Represents a HTTP status code for when the provided token is invalid.
    /// </summary>
    public const int Status498InvalidToken = 498;

    /// <summary>
    ///     Represents a HTTP status code for when a token is required to access the requested resource.
    /// </summary>
    public const int Status499TokenRequired = 499;

    /// <summary>
    ///     Represents a HTTP status code for when the server encountered an unexpected condition that prevented it from
    ///     fulfilling the request.
    /// </summary>
    public const int Status500InternalServerError = 500;

    /// <summary>
    ///     Represents a HTTP status code for when the requested resource has not been implemented by the server.
    /// </summary>
    public const int Status501NotImplemented = 501;

    /// <summary>
    ///     Represents a HTTP status code for when the server received an invalid response from the upstream server while
    ///     acting as a gateway or proxy.
    /// </summary>
    public const int Status502BadGateway = 502;

    /// <summary>
    ///     Represents a HTTP status code for when the server is currently unable to handle the request due to a temporary
    ///     overload or maintenance of the server.
    /// </summary>
    public const int Status503ServiceUnavailable = 503;

    /// <summary>
    ///     The server timed out while waiting for the request to complete.
    /// </summary>
    public const int Status504GatewayTimeout = 504;

    /// <summary>
    ///     The HTTP version used in the request is not supported by the server.
    /// </summary>
    public const int Status505HttpVersionNotSupported = 505;

    /// <summary>
    ///     The server has an internal configuration error: the chosen variant resource is configured to engage in transparent
    ///     content negotiation itself, and is therefore not a proper endpoint in the negotiation process.
    /// </summary>
    public const int Status506VariantAlsoNegotiates = 506;

    /// <summary>
    ///     The server has insufficient space to complete the request.
    /// </summary>
    public const int Status507InsufficientStorage = 507;

    /// <summary>
    ///     The server detected an infinite loop while processing the request.
    /// </summary>
    public const int Status508LoopDetected = 508;

    /// <summary>
    ///     Further extensions to the request are required for the server to fulfill it.
    /// </summary>
    public const int Status510NotExtended = 510;

    /// <summary>
    ///     The client needs to authenticate to gain network access.
    /// </summary>
    public const int Status511NetworkAuthenticationRequired = 511;
}