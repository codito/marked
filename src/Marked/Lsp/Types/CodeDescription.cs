// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using URI = System.String;

/// <summary>
/// Structure to capture a description for an error code.
/// </summary>
/// <param name="Href">An URI to open with more information about the diagnostic error.</param>
/// <remarks>Since 3.16.0.</remarks>
public record CodeDescription(URI Href);
