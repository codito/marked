// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a color range from a document.
/// </summary>
/// <param name="Range">The range in the document where this color appears.</param>
/// <param name="Color">The actual color value for this color range.</param>
public record ColorInformation(Range Range, Color Color);
