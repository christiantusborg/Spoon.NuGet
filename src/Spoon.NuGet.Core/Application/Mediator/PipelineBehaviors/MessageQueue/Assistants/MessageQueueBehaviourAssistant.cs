namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Assistants;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Interfaces;
using Attributes;
using EitherCore;
using EitherCore.Extensions;
using Interfaces;
using LogInterceptor;
using Microsoft.Extensions.Logging;

/// <summary>
/// </summary>
[LogInterceptorDefaultLogLevel(LogLevel.Debug)]
public class MessageQueueDefaultBehaviourAssistant : IMessageQueueBehaviourAssistant
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MessageQueueDefaultBehaviourAssistant" /> class.
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public bool HasPipelineBehaviorMessageQueue<TResponse>(TResponse request)
    {
        var has = request is IPipelineBehaviorMessageQueue;
        return has;
    }

    /// <summary>
    ///     Determines whether [has message queue exclude attribute].
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public bool HasMessageQueueExcludeAttribute<TResponse>()
    {
        var has = typeof(TResponse).IsDefined(typeof(MessageQueueExcludeAttribute), true);
        return has;
    }

    /// <summary>
    ///     Gets the either response.
    /// </summary>
    /// <param name="response"></param>
    /// <param name="responseRaw"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public bool GetEitherResponse<TResponse>(TResponse response, out object? responseRaw)
    {
        if (response is null)
        {
            responseRaw = null;
            return false;
        }

        var responseType = typeof(TResponse);

        if (responseType.GetGenericTypeDefinition() != typeof(Either<>))
        {
            responseRaw = response;
            return true;
        }

        if (response is Either<object> eitherResponse && eitherResponse.TryGetResponseRaw(out var raw, out var _))
        {
            responseRaw = raw;
            return true;
        }

        responseRaw = null;
        return false;
    }

    /// <summary>
    ///     Gets the either response.
    /// </summary>
    /// <param name="responseRaw"></param>
    /// <returns></returns>
    public string GetSerializedResponse(object responseRaw)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                new MessageQueueExcludePropertiesConverter(),
            },
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true,
        };

        return JsonSerializer.Serialize(responseRaw, options);
    }
}