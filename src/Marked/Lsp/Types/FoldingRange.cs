// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a folding range. To be valid, start and end line must be bigger
/// than zero and smaller than the number of lines in the document. Clients are
/// free to ignore invalid ranges.
/// </summary>
/// <param name="StartLine">
/// The zero-based start line of the range to fold. The folded area starts after
/// the line's last character. To be valid, the end must be zero or larger and
/// smaller than the number of lines in the document.
/// </param>
/// <param name="StartCharacter">
/// The zero-based character offset from where the folded range starts. If not
/// defined, defaults to the length of the start line.
/// </param>
/// <param name="EndLine">
/// The zero-based end line of the range to fold. The folded area ends with the
/// line's last character. To be valid, the end must be zero or larger and
/// smaller than the number of lines in the document.
/// </param>
/// <param name="EndCharacter">
/// The zero-based character offset before the folded range ends. If not
/// defined, defaults to the length of the end line.
/// </param>
/// <param name="Kind">
/// Describes the kind of the folding range such as `comment' or 'region'. The
/// kind is used to categorize folding ranges and used by commands like 'Fold
/// all comments'. See <see cref="FoldingRangeKind"/> for an enumeration of
/// standardized kinds.
/// </param>
public record FoldingRange(
    uint StartLine,
    uint? StartCharacter,
    uint EndLine,
    uint? EndCharacter,
    FoldingRangeKind? Kind);