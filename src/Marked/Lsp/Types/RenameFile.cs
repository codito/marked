// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;
using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// Rename file operation.
/// </summary>
public record RenameFile : ResourceOperation
{
    public RenameFile(DocumentUri oldUri, DocumentUri newUri, RenameFileOptions? options, ChangeAnnotationIdentifier? annotation)
        : base(Kind: "rename", annotation)
    {
        this.OldUri = oldUri;
        this.NewUri = newUri;
        this.Options = options;
    }

    /// <summary>
    /// Gets or sets the old (existing) location.
    /// </summary>
    public DocumentUri OldUri { get; set; }

    /// <summary>
    /// Gets or sets the new location.
    /// </summary>
    public DocumentUri NewUri { get; set; }

    /// <summary>
    /// Gets or sets additional options.
    /// </summary>
    public RenameFileOptions? Options { get; set; }
}
