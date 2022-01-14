// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The initialize request is sent as the first request from the client to the server.
/// </summary>
/// <remarks>See https://github.com/Microsoft/language-server-protocol/blob/gh-pages/_specifications/specification-3-17.md#initialize.
/// </remarks>
public record InitializeRequest(string Id, List<InitializeParams> Params) : Request<InitializeParams>(Id)
{
    public override string Method => "initialize";
}

public record InitializeResponse(string Id, InitializeResult? Result, ResponseError<InitializeError>? Error) : Response<InitializeResult, InitializeError>(Id, Result, Error);

/// <summary>
/// Initialization parameters from client to server.
/// </summary>
/// <param name="ProcessId">
/// The process Id of the parent process that started the server.Is null if
/// the process has not been started by another process.If the parent
/// process is not alive then the server should exit (see exit notification)
/// its process.
/// </param>
/// <param name="ClientInfo">
/// Information about the client.
///
/// Since 3.15.0.
/// </param>
/// <param name="Locale">
/// The locale the client is currently showing the user interface
/// in. This must not necessarily be the locale of the operating
/// system.
///
/// Uses IETF language tags as the value's syntax
/// (See https://en.wikipedia.org/wiki/IETF_language_tag)
///
/// Since 3.16.0.
/// </param>
/// <param name="InitializationOptions">User provided initialization options.</param>
/// <param name="Capabilities">The capabilities provided by the client (editor or tool).</param>
/// <param name="Trace">The initial trace setting. If omitted trace is disabled ('off').</param>
/// <param name="WorkspaceFolders">
/// The workspace folders configured in the client when the server starts.
/// This property is only available if the client supports workspace folders.
/// It can be `null` if the client supports workspace folders but none are
/// configured.
///
/// Since 3.6.0.
/// </param>
public record InitializeParams(
    int? ProcessId,
    ClientInfo? ClientInfo,
    string? Locale,
    object? InitializationOptions,
    ClientCapabilities Capabilities,
    string? Trace,  // TraceValue = 'off' | 'messages' | 'verbose'
    WorkspaceFolder[]? WorkspaceFolders);

public record InitializeResult;

public record InitializeError;

/// <summary>
/// Information about the client.
/// </summary>
/// <param name="Name">The name of the client as defined by the client.</param>
/// <param name="Version">The client's version as defined by the client.</param>
public record ClientInfo(string Name, string? Version);
