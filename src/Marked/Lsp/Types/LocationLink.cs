// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using DocumentUri = System.String;

/// <summary>
/// Represents the connection between two locations. Provides additional
/// metadata over normal <see cref="Location"/>, including an origin range.
/// </summary>
/// <param name="OriginSelectionRange">
/// Span of the origin of this link.
///
/// Used as the underlined span for mouse definition hover. Defaults to the word
/// range the definition position.
/// </param>
/// <param name="TargetUri">The target resource identifier of this link.</param>
/// <param name="TargetRange">
/// The full target range of this link. If the target for example is a symbol
/// then target range ios the range enclosing this symbol not including
/// leading/trailing whitespace but everything else like comments. This
/// information is typically used to highlight the range in the editor.
/// </param>
/// <param name="TargetSelectionRange">
/// The range that should be selected and revealed when this link is being
/// followed, e.g. the name of a function. Must be contained by the
/// `targetRange`. See also <c>DocumentSymbol.Range</c>.
/// </param>
public record LocationLink(Range? OriginSelectionRange, DocumentUri TargetUri, Range TargetRange, Range TargetSelectionRange);
