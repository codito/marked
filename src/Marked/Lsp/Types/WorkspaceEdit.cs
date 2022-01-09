// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;
using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// A workspace edit represents changes to many resources managed in the
/// workspace.The edit should either provide <paramref name="Changes"/> or
/// <paramref name="DocumentChanges"/>. If documentChanges are present they are
/// preferred over <paramref name="Changes"/> if the client can handle versioned
/// document edits.
///
/// Since version 3.13.0 a workspace edit can contain resource operations as well.If resource
/// operations are present clients need to execute the operations in the order in which they
/// are provided. So a workspace edit for example can consist of the following two changes:
/// (1) a create file a.txt and (2) a text document edit which insert text into file a.txt.
///
/// An invalid sequence (e.g. (1) delete file a.txt and(2) insert text into file a.txt) will
/// cause failure of the operation.How the client recovers from the failure is described by
/// the client capability: `workspace.workspaceEdit.failureHandling`.
/// </summary>
/// <param name="Changes">Holds changes to existing resources.</param>
/// <param name="DocumentChanges">
/// Depending on the client capability
/// `workspace.workspaceEdit.resourceOperations` document changes are either an
/// array of `TextDocumentEdit`s to express changes to n different text
/// documents where each text document edit addresses a specific version of a
/// text document.Or it can contain above `TextDocumentEdit`s mixed with create,
/// rename and delete file / folder operations.
///
/// Whether a client supports versioned document edits is expressed via
/// `workspace.workspaceEdit.documentChanges` client capability.
///
/// If a client neither supports `documentChanges` nor
/// `workspace.workspaceEdit.resourceOperations` then only plain `TextEdit`s
/// using the `changes` property are supported.
/// </param>
/// <param name="ChangeAnnotations">
/// A map of change annotations that can be referenced in `AnnotatedTextEdit`s
/// or create, rename and delete file / folder operations.
///
/// Whether clients honor this property depends on the client capability
/// `workspace.changeAnnotationSupport`.
///
/// Since 3.16.0.
/// </param>
public record WorkspaceEdit(
    Dictionary<DocumentUri, TextEdit[]>? Changes,
    TextDocumentEdit[]? DocumentChanges, /* TODO (TextDocumentEdit | CreateFile | RenameFile | DeleteFile)[]; */
    Dictionary<ChangeAnnotationIdentifier, ChangeAnnotation>? ChangeAnnotations);
