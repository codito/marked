// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;
using System.Collections.Generic;

/// <summary>
/// A request message to describe a request between the client and the server.
/// </summary>
/// <typeparam name="T">Type of the <see cref="Params"/>.</typeparam>
/// <param name="Id">Request id.</param>
public abstract record Request<T>(string Id)
{
    /// <summary>
    /// Gets the language server protocol version. Always set to "2.0".
    /// </summary>
    public string JsonRpc => "2.0";

    /// <summary>
    /// Gets the method to be invoked.
    /// </summary>
    public abstract string Method { get; }

    /// <summary>
    /// Gets the params for the method.
    /// </summary>
    public abstract List<T> Params { get; init; }
}
