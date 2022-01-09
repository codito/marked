// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

/// <summary>
/// Represents a color in RGBA space.
/// </summary>
/// <param name="Red">Red component of the color in range [0-1].</param>
/// <param name="Green">Green component of the color in range [0-1].</param>
/// <param name="Blue">Blue component of the color in range [0-1].</param>
/// <param name="Alpha">Alpha component of the color in range [0-1].</param>
public record Color(float Red, float Green, float Blue, float Alpha);
