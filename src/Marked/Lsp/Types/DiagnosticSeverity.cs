// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// The diagnostic's severity.
/// </summary>
public enum DiagnosticSeverity
{
    /// <summary>
    /// Reports an error.
    /// </summary>
    Error = 1,

    /// <summary>
    /// Reports a warning.
    /// </summary>
    Warning = 2,

    /// <summary>
    /// Reports an information.
    /// </summary>
    Information = 3,

    /// <summary>
    /// Reports a hint.
    /// </summary>
    Hint = 4
}
