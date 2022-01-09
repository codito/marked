// Copyright (c) Arun Mahapatra. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Marked.Lsp.Types;

using ChangeAnnotationIdentifier = System.String;

/// <summary>
/// A generic resource operation.
/// </summary>
/// <param name="Kind">The resource operation kind.</param>
/// <param name="AnnotationId">
/// An optional annotation identifier describing the operation.
///
/// Since 3.16.0.
/// </param>
public record ResourceOperation(string Kind, ChangeAnnotationIdentifier? AnnotationId);