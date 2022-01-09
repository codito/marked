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

public class InitializeParams
{
}

public record InitializeResult;

public record InitializeError;
