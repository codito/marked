// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a reference to a command. Provides a title which
/// will be used to represent a command in the UI and, optionally,
/// an array of arguments which will be passed to the command handler
/// function when invoked.
/// </summary>
/// <param name="Title">Title of the command, like `save`.</param>
/// <param name="CommandName">The identifier of the actual command handler.</param>
/// <param name="Arguments">Arguments that the command handler should be invoked with.</param>
public record Command(string Title, string CommandName /* FIXME */, params object[] Arguments);