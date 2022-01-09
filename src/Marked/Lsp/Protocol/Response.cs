// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;

/// <summary>
/// A Response Message sent as a result of a request.
///
/// If a request doesn't provide a result value the receiver of a request still
/// needs to return a response message to conform to the JSON RPC specification.
/// The result property of the ResponseMessage should be set to null in this
/// case to signal a successful request.
/// </summary>
/// <typeparam name="TResult">Type of <see cref="Result"/>.</typeparam>
/// <typeparam name="TError">Type of <see cref="Error"/>.</typeparam>
/// <param name="Id">The request id.</param>
/// <param name="Result">
/// The result of a request. This member is REQUIRED on success.
/// This member MUST NOT exist if there was an error invoking the method.
/// </param>
/// <param name="Error">The error object in case a request fails.</param>
public abstract record Response<TResult, TError>(string Id, TResult? Result, ResponseError<TError>? Error);

/// <summary>
/// Represents an error in <see cref="Response{TResult, TError}"/>.
/// </summary>
/// <typeparam name="TError">Type of the error.</typeparam>
/// <param name="Code">A number indicating the error type that occurred.</param>
/// <param name="Message">A string providing a short description of the error.</param>
/// <param name="Data">A primitive or structured value that contains additional information about the error. Can be omitted.</param>
public record ResponseError<TError>(ErrorCodes Code, string Message, TError? Data);

/// <summary>
/// Well known error codes in Language Server Protocol.
/// </summary>
public enum ErrorCodes
{
    // Defined by JSON RPC

    /// <summary>
    /// A parse error.
    /// </summary>
    ParseError = -32700,

    /// <summary>
    /// Request is invalid.
    /// </summary>
    InvalidRequest = -32600,

    /// <summary>
    /// Invalid method is provided.
    /// </summary>
    MethodNotFound = -32601,

    /// <summary>
    /// Invalid params are provided.
    /// </summary>
    InvalidParams = -32602,

    /// <summary>
    /// Unknown error in json rpc.
    /// </summary>
    InternalError = -32603,

    /// <summary>
    /// This is the start range of JSON RPC reserved error codes.
    /// It doesn't denote a real error code. No LSP error codes should
    /// be defined between the start and end range. For backwards
    /// compatibility the `ServerNotInitialized` and the `UnknownErrorCode`
    /// are left in the range.
    ///
    /// Since 3.16.0.
    /// </summary>
    JsonrpcReservedErrorRangeStart = -32099,

    /// <summary>
    /// @deprecated use JsonrpcReservedErrorRangeStart.
    /// </summary>
    ServerErrorStart = JsonrpcReservedErrorRangeStart,

    /// <summary>
    /// Error code indicating that a server received a notification or
    /// request before the server has received the `initialize` request.
    /// </summary>
    ServerNotInitialized = -32002,

    /// <summary>
    /// Unknown error code.
    /// </summary>
    UnknownErrorCode = -32001,

    /// <summary>
    /// This is the end range of JSON RPC reserved error codes.
    /// It doesn't denote a real error code.
    ///
    /// Since 3.16.0.
    /// </summary>
    JsonrpcReservedErrorRangeEnd = -32000,

    /// <summary>
    /// @deprecated use jsonrpcReservedErrorRangeEnd.
    /// </summary>
    ServerErrorEnd = JsonrpcReservedErrorRangeEnd,

    /// <summary>
    /// This is the start range of LSP reserved error codes.
    /// It doesn't denote a real error code.
    ///
    /// Since 3.16.0.
    /// </summary>
    LspReservedErrorRangeStart = -32899,

    /// <summary>
    /// A request failed but it was syntactically correct, e.g the
    /// method name was known and the parameters were valid. The error
    /// message should contain human readable information about why
    /// the request failed.
    ///
    /// Since 3.17.0.
    /// </summary>
    RequestFailed = -32803,

    /// <summary>
    /// The server cancelled the request. This error code should
    /// only be used for requests that explicitly support being
    /// server cancellable.
    ///
    /// Since 3.17.0.
    /// </summary>
    ServerCancelled = -32802,

    /// <summary>
    /// The server detected that the content of a document got
    /// modified outside normal conditions. A server should
    /// NOT send this error code if it detects a content change
    /// in it unprocessed messages. The result even computed
    /// on an older state might still be useful for the client.
    ///
    /// If a client decides that a result is not of any use anymore
    /// the client should cancel the request.
    /// </summary>
    ContentModified = -32801,

    /// <summary>
    /// The client has canceled a request and a server as detected
    /// the cancel.
    /// </summary>
    RequestCancelled = -32800,

    /// <summary>
    /// This is the end range of LSP reserved error codes.
    /// It doesn't denote a real error code.
    ///
    /// Since 3.16.0.
    /// </summary>
    LspReservedErrorRangeEnd = -32800,
}
