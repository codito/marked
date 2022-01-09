// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using URI = System.String;

/// <summary>
/// The diagnostic tags.
/// </summary>
/// <remarks>Since 3.15.0.</remarks>
public enum DiagnosticTag
{
    /// <summary>
    /// Unused or unnecessary code.
    ///
    /// Clients are allowed to render diagnostics with this tag faded out
    /// instead of having an error squiggle.
    /// </summary>
    Unnecessary = 1,

    /// <summary>
    /// Deprecated or obsolete code.
    ///
    /// Clients are allowed to render diagnostics with this tag strike through.
    /// </summary>
    Deprecated = 2
}
