// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
/// are only valid in the scope of a resource.
/// </summary>
/// <param name="Range">The range at which the message applies.</param>
/// <param name="Severity">
/// The diagnostic's severity. Can be omitted. If omitted it is up to the
/// client to interpret diagnostics as error, warning, info or hint.
/// </param>
/// <param name="Code">
/// The diagnostic's code, which usually appear in the user interface.
/// </param>
/// <param name="CodeDescription">
/// An optional property to describe the error code.
/// Requires the code field (above) to be present/not null.
///
/// Since 3.16.0.
/// </param>
/// <param name="Source">
/// A human-readable string describing the source of this
/// diagnostic, e.g. 'typescript' or 'super lint'. It usually
/// appears in the user interface.
/// </param>
/// <param name="Message">
/// The diagnostic's message. It usually appears in the user interface.
/// </param>
/// <param name="Tags">
/// Additional metadata about the diagnostic.
///
/// Since 3.15.0.
/// </param>
/// <param name="RelatedInformation">
/// An array of related diagnostic information, e.g. when symbol-names within
/// a scope collide all definitions can be marked via this property.
/// </param>
/// <param name="Data">
/// A data entry field that is preserved between a `textDocument/publishDiagnostics`
/// notification and `textDocument/codeAction` request.
///
/// Since 3.16.0.
/// </param>
public record Diagnostics(
    Range Range,
    DiagnosticSeverity? Severity,
    string? Code,
    CodeDescription? CodeDescription,
    string? Source,
    string Message,
    DiagnosticTag[]? Tags,
    DiagnosticRelatedInformation[]? RelatedInformation,
    string[]? Data /* LSPAny */);