// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Additional information that describes document changes.
/// </summary>
/// <param name="Label">
/// A human-readable string describing the actual change. The string is rendered
/// prominent in the user interface.
/// </param>
/// <param name="NeedsConfirmation">
/// A flag which indicates that user confirmation is needed before applying the change.
/// </param>
/// <param name="Description">
/// A human-readable string which is rendered less prominent in the user interface.
/// </param>
/// <remarks>Since 3.16.0.</remarks>
public record ChangeAnnotation(string Label, bool? NeedsConfirmation, string? Description);