// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Describes textual changes on a text document. A TextDocumentEdit describes all changes
/// on a document version Si and after they are applied move the document to version Si+1.
/// So the creator of a TextDocumentEdit doesn't need to sort the array of edits or do any
/// kind of ordering.However the edits must be non overlapping.
/// </summary>
/// <param name="TextDocument">The text document to change.</param>
/// <param name="Edits">
/// The edits to be applied.
///
/// Since 3.16.0 - support for <see cref="AnnotatedTextEdit"/>. This is guarded by a client
/// capability.
/// </param>
public record TextDocumentEdit(OptionalVersionedTextDocumentIdentifier TextDocument, AnnotatedTextEdit[] Edits);
