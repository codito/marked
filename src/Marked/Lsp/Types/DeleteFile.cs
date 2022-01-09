// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;
using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// Delete file operation.
/// </summary>
public record DeleteFile : ResourceOperation
{
    public DeleteFile(DocumentUri uri, DeleteFileOptions? options, ChangeAnnotationIdentifier? annotation)
        : base(Kind: "delete", annotation)
    {
        this.Uri = uri;
        this.Options = options;
    }

    /// <summary>
    /// Gets or sets the file to delete.
    /// </summary>
    public DocumentUri Uri { get; set; }

    /// <summary>
    /// Gets or sets delete options.
    /// </summary>
    public DeleteFileOptions? Options { get; set; }
}
