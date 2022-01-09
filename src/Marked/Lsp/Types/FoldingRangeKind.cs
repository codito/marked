// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Known range kinds.
/// </summary>
public enum FoldingRangeKind
{
    /// <summary>
    /// Folding range for a comment.
    /// </summary>
    Comment,

    /// <summary>
    /// Folding range for a imports or includes.
    /// </summary>
    Imports,

    /// <summary>
    /// Folding range for a region.
    /// </summary>
    Region
}
