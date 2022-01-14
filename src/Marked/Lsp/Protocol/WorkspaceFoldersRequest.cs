// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;

// TODO incomplete implementation.
internal class WorkspaceFoldersRequest
{
}

/// <summary>
/// Represent a folder in the Workspace. A client can have multiple
/// roots in a workspace.
/// </summary>
/// <param name="Uri">The associated URI for this workspace folder.</param>
/// <param name="Name">
/// The name of the workspace folder. Used to refer to this
/// workspace folder in the user interface.
/// </param>
public record WorkspaceFolder(string Uri, string Name);
