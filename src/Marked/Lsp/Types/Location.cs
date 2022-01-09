// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;
using ProgressToken = System.String;

/// <summary>
/// Represents a location inside a resource, such as a line inside a text file.
/// </summary>
/// <param name="Uri">Document uri.</param>
/// <param name="Range">Location range in the resource.</param>
public record Location(DocumentUri Uri, Range Range);

/// <summary>
/// The kind of resource operations supported by the client.
/// </summary>
public enum ResourceOperationKind
{
    /// <summary>
    /// Supports creating new files and folders.
    /// </summary>
    Create = 1,

    /// <summary>
    /// Supports renaming existing files and folders.
    /// </summary>
    Rename = 2,

    /// <summary>
    /// Supports deleting existing files and folders.
    /// </summary>
    Delete = 3
}

/// <summary>
/// The kind of failure handling supported by the client.
/// </summary>
public enum FailureHandlingKind
{
    /// <summary>
    /// Applying the workspace change is simply aborted if one of the changes
    /// provided fails. All operations executed before the failing operation
    /// stay executed.
    /// </summary>
    Abort = 1,

    /// <summary>
    /// All operations are executed transactional. That means they either all
    /// succeed or no changes at all are applied to the workspace.
    /// </summary>
    Transactional = 2,

    /// <summary>
    /// If the workspace edit contains only textual file changes they are
    /// executed transactional. If resource changes (create, rename or delete
    /// file) are part of the change the failure handling strategy is abort.
    /// </summary>
    TextOnlyTransactional = 3,

    /// <summary>
    /// The client tries to undo the operations already executed. But there is no
    /// guarantee that this is succeeding.
    /// </summary>
    Undo = 4,
}

/// <summary>
/// Client capabilities for <see cref="WorkspaceEdit"/>.
/// </summary>
/// <param name="DocumentChanges">
/// The client supports versioned document changes in <see cref="WorkspaceEdit"/>.
/// </param>
/// <param name="ResourceOperations">
/// The resource operations the client supports. Clients should at least
/// support 'create', 'rename' and 'delete' files and folders.
///
/// Since 3.13.0.
/// </param>
/// <param name="FailureHandlingKind">
/// The failure handling strategy of a client if applying the workspace edit
/// fails.
///
/// Since 3.13.0.
/// </param>
/// <param name="NormalizeLineEndings">
/// Whether the client normalizes line endings to the client specific
/// setting.
/// If set to `true` the client will normalize line ending characters
/// in a workspace edit to the client specific new line character(s).
///
/// Since 3.16.0.
/// </param>
/// <param name="ChangeAnnotationSupport">
/// Whether the client in general supports change annotations on text edits,
/// create file, rename file and delete file changes.
///
/// Since 3.16.0.
/// </param>
public record WorkspaceEditClientCapabilities(
    bool? DocumentChanges,
    ResourceOperationKind[] ResourceOperations,
    FailureHandlingKind[] FailureHandlingKind,
    bool? NormalizeLineEndings,
    ChangeAnnotationSupport? ChangeAnnotationSupport);

/// <summary>
/// Settings to represent client support for change annotations on text edits.
/// <seealso cref="WorkspaceEditClientCapabilities.ChangeAnnotationSupport"/>.
///
/// Since 3.16.0.
/// </summary>
/// <param name="GroupsOnLabel">
/// Whether the client groups edits with equal labels into tree nodes,
/// for instance all edits labelled with "Changes in Strings" would
/// be a tree node.
/// </param>
public record ChangeAnnotationSupport(bool? GroupsOnLabel);

/// <summary>
/// An identifier for text documents at protocol level.
/// </summary>
/// <param name="URI">The text document's uri.</param>
public record TextDocumentIdentifier(DocumentUri URI);

/// <summary>
/// An identifier to denote a specific version of a text document. This
/// information usually flows from the client to the server.
/// </summary>
public record VersionedTextDocumentIdentifer : TextDocumentIdentifier
{
    public VersionedTextDocumentIdentifer(DocumentUri uri, int version)
        : base(uri)
    {
        this.Version = version;
    }

    public int Version { get; private set; }
}

public record OptionalVersionedTextDocumentIdentifier : TextDocumentIdentifier
{
    public OptionalVersionedTextDocumentIdentifier(DocumentUri uri, int? version)
        : base(uri)
    {
        this.Version = version;
    }

    /// <summary>
    /// Gets the version number of this document.If an optional versioned text
    /// document identifier is sent from the server to the client and the file
    /// is not open in the editor(the server has not received an open
    /// notification before) the server can send `null` to indicate that the
    /// version is known and the content on disk is the master(as specified with
    /// document content ownership).
    ///
    /// The version number of a document will increase after each change,
    /// including undo/redo.The number doesn't need to be consecutive.
    /// </summary>
    public int? Version { get; private set; }
}

/// <summary>
/// An item to transfer a text document from the client to the server.
/// </summary>
/// <param name="URI">The text document's URI.</param>
/// <param name="LanguageId">The text document's language identifier.</param>
/// <param name="Version">
/// The version number of this document (it will increase after each change,
/// including undo/redo).
/// </param>
/// <param name="Text">The content of the opened text document.</param>
/// <remarks>
/// See
/// https://microsoft.github.io/language-server-protocol/specifications/specification-3-17/#textDocumentItem
/// for details of language id.
/// </remarks>
public record TextDocumentItem(
    DocumentUri URI,
    string LanguageId,
    int Version,
    string Text);

/// <summary>
/// A parameter literal used in requests to pass a text document and a position inside that document.
/// </summary>
/// <param name="TextDocument">
/// The text document.
/// </param>
/// <param name="Position">
/// The position inside the text document.
/// </param>
public record TextDocumentPositionParams(TextDocumentIdentifier TextDocument, Position Position);

/// <summary>
/// A document filter denotes a document through properties like language, scheme or pattern.
/// </summary>
/// <param name="Language">A language id, like `typescript`.</param>
/// <param name="Scheme">A Uri [scheme](#Uri.scheme), like `file` or `untitled`.</param>
/// <param name="Pattern">
/// A glob pattern, like `*.{ts,js}`.
///
/// Glob patterns can have the following syntax:
/// - `*` to match one or more characters in a path segment
/// - `?` to match on one character in a path segment
/// - `**` to match any number of path segments, including none
/// - `{}` to group sub patterns into an OR expression. (e.g. `**​/*.{ts,js}`
///   matches all TypeScript and JavaScript files)
/// - `[]` to declare a range of characters to match in a path segment
///   (e.g., `example.[0-9]` to match on `example.0`, `example.1`, …)
/// - `[!...]` to negate a range of characters to match in a path segment
///   (e.g., `example.[!0-9]` to match on `example.a`, `example.b`, but
///   not `example.0`).
/// </param>
public record DocumentFilter(
    string? Language,
    string? Scheme,
    string? Pattern);

public record WorkDoneProgressParams(ProgressToken? WorkDoneToken);
