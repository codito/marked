// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// A special text edit with an additional change annotation.
/// </summary>
/// <remarks>Since 3.16.0.</remarks>
public record AnnotatedTextEdit : TextEdit
{
    public AnnotatedTextEdit(Range range, string newText, ChangeAnnotationIdentifier annotationId)
        : base(range, newText)
    {
        this.AnnotationId = annotationId;
    }

    /// <summary>
    /// Gets or sets the actual identifier of the change annotation.
    /// </summary>
    public ChangeAnnotationIdentifier? AnnotationId { get; set; }

    /// <summary>
    /// Creates an annotated replace text edit.
    /// </summary>
    /// <param name="range">The range of text to be replaced.</param>
    /// <param name="newText">The new text.</param>
    /// <param name="annotation">The annotation.</param>
    /// <returns>An annotated text edit.</returns>
    public static AnnotatedTextEdit Replace(Range range, string newText, ChangeAnnotationIdentifier annotation)
    {
        return new AnnotatedTextEdit(range, newText, annotation);
    }

    /// <summary>
    /// Created an annotated insert text edit.
    /// </summary>
    /// <param name="position">The position to insert text at.</param>
    /// <param name="newText">The text to be inserted.</param>
    /// <param name="annotation">The annotation.</param>
    /// <returns>An annotated insert text edit.</returns>
    public static AnnotatedTextEdit Insert(Position position, string newText, ChangeAnnotationIdentifier annotation)
    {
        return new AnnotatedTextEdit(new Range(Start: position, End: position), newText, annotation);
    }

    /// <summary>
    /// Creates an annotated delete text edit.
    /// </summary>
    /// <param name="range">The range of text to be deleted.</param>
    /// <param name="annotation">The annotation.</param>
    /// <returns>An annotated delete text edit.</returns>
    public static AnnotatedTextEdit Del(Range range, ChangeAnnotationIdentifier annotation)
    {
        return new AnnotatedTextEdit(range, newText: string.Empty, annotation);
    }
}