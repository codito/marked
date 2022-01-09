// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents color presentation.
/// </summary>
/// <param name="Label">
/// The label of this color presentation. It will be shown on the color picker
/// header.By default this is also the text that is inserted when selecting this
/// color presentation.
/// </param>
/// <param name="TextEdit">
/// An <see cref="TextEdit"/> which is applied to a document when selecting this
/// presentation for the color. When `falsy` the <paramref name="Label"/> is
/// used.
/// </param>
/// <param name="AdditionalTextEdits">
/// An optional array of additional <see cref="TextEdit"/> that are applied when
/// selecting this color presentation. Edits must not overlap with the main
/// <paramref name="TextEdit"/>.
/// </param>
public record ColorPresentation(string Label, TextEdit? TextEdit, TextEdit[]? AdditionalTextEdits);
