// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// A range in a text document expressed as (zero-based) start and end positions.
///
/// If you want to specify a range that contains a line including the line ending
/// character(s) then use an end position denoting the start of the next line.
/// For example:
/// <code>
/// {
///     start: { line: 5, character: 23 }
///     end : { line 6, character: 0 }
/// }
/// </code>
/// </summary>
/// <param name="Start">Start position of the Range.</param>
/// <param name="End">End position of the Range.</param>
public record Range(Position Start, Position End)
{
    public Range(uint startLine, uint startCharacter, uint endLine, uint endCharacter)
        : this(new Position(startLine, startCharacter), new Position(endLine, endCharacter))
    {
    }
}
