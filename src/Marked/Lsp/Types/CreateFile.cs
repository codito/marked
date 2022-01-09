// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;
using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// Create file operation.
/// </summary>
public record CreateFile : ResourceOperation
{
    public CreateFile(DocumentUri uri, CreateFileOptions? options, ChangeAnnotationIdentifier? annotation)
        : base(Kind: "create", annotation)
    {
        this.Uri = uri;
        this.Options = options;
    }

    /// <summary>
    /// Gets or sets the resource to create.
    /// </summary>
    public DocumentUri Uri { get; set; }

    /// <summary>
    /// Gets or sets additional options.
    /// </summary>
    public CreateFileOptions? Options { get; set; }
}
