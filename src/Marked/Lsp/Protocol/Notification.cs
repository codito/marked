// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;

/// <summary>
/// A notification message. A processed notification message must not send a
/// response back. They work like events.
/// </summary>
/// <typeparam name="TParam">Type of notification params.</typeparam>
/// <param name="Method">The method to be invoked.</param>
/// <param name="Params">The notification's params.</param>
public record Notification<TParam>(string Method, List<TParam> Params)
{
    /// <summary>
    /// Gets the language server protocol version. Always set to "2.0".
    /// </summary>
    public string JsonRpc => "2.0";
}
