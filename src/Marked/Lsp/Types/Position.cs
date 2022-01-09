// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Position in a text document expressed as zero-based line and character offset.
/// The offsets are based on a UTF-16 string representation. So a string of the form
/// `a𐐀b` the character offset of the character `a` is 0, the character offset of `𐐀`
/// is 1 and the character offset of b is 3 since `𐐀` is represented using two code
/// units in UTF-16.
///
/// Positions are line end character agnostic. So you can not specify a position that
/// denotes `\r|\n` or `\n|` where `|` represents the character offset.
/// </summary>
/// <param name="Line">Line position in a document (zero-based).</param>
/// <param name="Character">
/// Character offset on a line in a document(zero-based). Assuming that the line is
/// represented as a string, the `character` value represents the gap between the
/// `character` and `character + 1`.
///
/// If the character value is greater than the line length it defaults back to the
/// line length.
/// </param>
public record Position(uint Line, uint Character);
