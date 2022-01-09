// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// A text edit applicable to a text document.
/// </summary>
/// <param name="Range">
/// The range of the text document to be manipulated. To insert
/// text into a document create a range where start == end.
/// </param>
/// <param name="NewText">
/// The string to be inserted. For delete operations use an
/// empty string.
/// </param>
public record TextEdit(Range Range, string NewText)
{
    /// <summary>
    /// Creates a replace text edit.
    /// </summary>
    /// <param name="range">The range of text to be replaced.</param>
    /// <param name="newText">The new text.</param>
    /// <returns>Replace text edit.</returns>
    public static TextEdit Replace(Range range, string newText)
        => new(range, newText);

    /// <summary>
    /// Creates a insert text edit.
    /// </summary>
    /// <param name="position">The position to insert text at.</param>
    /// <param name="newText">The text to be inserted.</param>
    /// <returns>Insert text edit.</returns>
    public static TextEdit Insert(Position position, string newText)
        => new(new Range(position, position), newText);

    /// <summary>
    /// Creates a delete text edit.
    /// </summary>
    /// <param name="range">Range of text to be deleted.</param>
    /// <returns>Delete text edit.</returns>
    public static TextEdit Del(Range range)
        => new(range, NewText: string.Empty);
}
