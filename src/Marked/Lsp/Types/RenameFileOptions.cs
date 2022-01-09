// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Rename file options.
/// </summary>
/// <param name="Overwrite">
/// Overwrite existing file. Overwrite wins over <paramref name="IgnoreIfExists"/>.
/// </param>
/// <param name="IgnoreIfExists">
/// Ignore if exists.
/// </param>
public record RenameFileOptions(bool? Overwrite, bool? IgnoreIfExists);
