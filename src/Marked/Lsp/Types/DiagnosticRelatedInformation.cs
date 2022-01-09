// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a related message and source code location for a diagnostic. This should be
/// used to point to code locations that cause or related to a diagnostics, e.g when duplicating
/// a symbol in a scope.
/// </summary>
/// <param name="Location">The location of this related diagnostic information.</param>
/// <param name="Message">The message of this related diagnostic information.</param>
public record DiagnosticRelatedInformation(Location Location, string Message);
