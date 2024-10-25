// ------------------------------------------------------------------------------------------
//  <copyright file = "EnumerableExtension.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Validation.Api.Extension;

public static class EnumerableExtension
{
    public static IEnumerable<(T, T)> PairAssert<T>(this IReadOnlyList<T> source)
    {
        return source.Zip(source.Skip(1), (a, b) => (a, b));
    }
}