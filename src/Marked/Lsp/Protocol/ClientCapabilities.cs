// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Protocol;

using Marked.Lsp.Types;

/// <summary>
/// ClientCapabilities define capabilities for dynamic registration, workspace
/// and text document features the client supports.
/// </summary>
/// <param name="Workspace">Workspace specific client capabilities.</param>
/// <param name="TextDocument">Text document specific client capabilities.</param>
/// <param name="Window">Window specific client capabilities.</param>
/// <param name="General">
/// General client capabilities.
///
/// Since 3.16.0.
/// </param>
/// <param name="Experimental">Experiment client capabilities.</param>
/// <remarks>
/// For future compatibility a ClientCapabilities object literal can have more
/// properties set than currently defined. Servers receiving a
/// ClientCapabilities object literal with unknown properties should ignore
/// these properties. A missing property should be interpreted as an absence of
/// the capability. If a missing property normally defines sub properties, all
/// missing sub properties should be interpreted as an absence of the
/// corresponding capability.
/// </remarks>
public record ClientCapabilities(
    WorkspaceClientCapabilities? Workspace,
    TextDocumentClientCapabilities? TextDocument,
    WindowClientCapabilities? Window,
    GeneralClientCapabilities? General,
    object? Experimental);

/// <summary>
/// Workspace specific client capabilities.
/// </summary>
/// <param name="ApplyEdit">
/// The client supports applying batch edits to the workspace by supporting the
/// request 'workspace/applyEdit'.
/// </param>
/// <param name="WorkspaceEdit">Capabilities specific to `WorkspaceEdit`s.</param>
/// <param name="DidChangeConfiguration">
/// Capabilities specific to the `workspace/didChangeConfiguration`
/// notification.
/// </param>
/// <param name="DidChangeWatchedFiles">
/// Capabilities specific to the `workspace/didChangeWatchedFiles` notification.
/// </param>
/// <param name="Symbol">Capabilities specific to the `workspace/symbol` request.</param>
/// <param name="ExecuteCommand">Capabilities specific to the `workspace/executeCommand` request.</param>
/// <param name="WorkspaceFolders">
/// The client has support for workspace folders.
///
/// Since 3.16.0.
/// </param>
/// <param name="Configuration">
/// The client supports `workspace/configuration` requests.
///
/// Since 3.6.0.
/// </param>
/// <param name="SemanticTokens">
/// Capabilities specific to the semantic token requests scoped to the workspace.
///
/// Since 3.16.0.
/// </param>
/// <param name="CodeLens">
/// Capabilities specific to the code lens requests scoped to the workspace.
///
/// Since 3.16.0.
/// </param>
/// <param name="FileOperations">
/// The client has support for file requests/notifications.
///
/// Since 3.16.0.
/// </param>
public record WorkspaceClientCapabilities(
    bool? ApplyEdit,
    WorkspaceEditClientCapabilities? WorkspaceEdit,
    DidChangeConfigurationClientCapabilities? DidChangeConfiguration,
    DidChangeWatchedFilesClientCapabilities? DidChangeWatchedFiles,
    WorkspaceSymbolClientCapabilities? Symbol,
    ExecuteCommandClientCapabilities? ExecuteCommand,
    bool? WorkspaceFolders,
    bool? Configuration,
    SemanticTokenWorkspaceClientCapabilities? SemanticTokens,
    CodeLensWorkspaceClientCapabilities? CodeLens,
    FileOperationsClientCapabilities? FileOperations);

public record TextDocumentClientCapabilities;

/// <summary>
/// Window specific client capabilities.
/// </summary>
/// <param name="WorkDoneProgress">
/// Whether client supports handling progress notifications.If set
/// servers are allowed to report in `workDoneProgress` property in the
/// request specific server capabilities.
///
/// Since 3.15.0.
/// </param>
/// <param name="ShowMessage">
/// Capabilities specific to the showMessage request.
///
/// Since 3.16.0.
/// </param>
/// <param name="ShowDocument">
/// Client capabilities for the show document request.
///
/// Since 3.16.0.
/// </param>
public record WindowClientCapabilities(
    bool? WorkDoneProgress,
    ShowMessageRequestClientCapabilities? ShowMessage,
    ShowDocumentClientCapabilities? ShowDocument);

public record GeneralClientCapabilities(
    StaleRequestSupport? StaleRequestSupport,
    RegularExpressionsClientCapabilities? RegularExpressions,
    MarkdownClientCapabilities? Markdown);

#region Workspace Client Capabilities

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

public record DidChangeConfigurationClientCapabilities;

public record WorkspaceSymbolClientCapabilities;

public record DidChangeWatchedFilesClientCapabilities;

public record ExecuteCommandClientCapabilities;

public record SemanticTokenWorkspaceClientCapabilities;

public record CodeLensWorkspaceClientCapabilities;

/// <summary>
/// The client has support for file requests/notifications.
///
/// Since 3.16.0.
/// </summary>
/// <param name="DynamicRegistration">
/// Whether the client supports dynamic registration for file requests/notifications.
/// </param>
/// <param name="DidCreate">The client has support for sending didCreateFiles notifications.</param>
/// <param name="WillCreate">The client has support for sending willCreateFiles requests.</param>
/// <param name="DidRename">The client has support for sending didRenameFiles notifications.</param>
/// <param name="WillRename">The client has support for sending willRenameFiles requests.</param>
/// <param name="DidDelete">The client has support for sending didDeleteFiles notifications.</param>
/// <param name="WillDelete">The client has support for sending willDeleteFiles requests.</param>
public record FileOperationsClientCapabilities(
    bool? DynamicRegistration,
    bool? DidCreate,
    bool? WillCreate,
    bool? DidRename,
    bool? WillRename,
    bool? DidDelete,
    bool? WillDelete);

#endregion

#region Window specific Client Capabilities

public record ShowMessageRequestClientCapabilities;

public record ShowDocumentClientCapabilities;

#endregion

#region General Client Capabilities

public record StaleRequestSupport(bool Cancel, string[] RetryOnContentModified);

public record RegularExpressionsClientCapabilities;

public record MarkdownClientCapabilities;

#endregion
