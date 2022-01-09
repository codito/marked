// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Delete file options.
/// </summary>
/// <param name="Recursive">
/// Delete the content recursively if a folder is denoted.
/// </param>
/// <param name="IgnoreIfNotExists">
/// Ignore the operation if the file doesn't exist.
/// </param>
public record DeleteFileOptions(bool? Recursive, bool? IgnoreIfNotExists);
