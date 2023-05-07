namespace Spoon.NuGet.Core.Domain;

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

/// <summary>
/// Provides extension methods to build LINQ expressions for filtering entities based on a list of filter criteria.
/// </summary>
public static class WhereBuilderExtension
{
    /// <summary>
    /// The <see cref="MethodInfo"/> for the <c>string.Contains</c> method.
    /// </summary>
    private static readonly MethodInfo? ContainsMethod = typeof(string).GetMethod("Contains");

    /// <summary>
    /// The <see cref="MethodInfo"/> for the <c>string.StartsWith</c> method.
    /// </summary>
    private static readonly MethodInfo? StartsWithMethod =
        typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

    /// <summary>
    /// The <see cref="MethodInfo"/> for the <c>string.EndsWith</c> method.
    /// </summary>
    private static readonly MethodInfo? EndsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

    /// <summary>
    /// Builds an <see>
    ///     <cref>Expression{Func{T,bool}}</cref>
    /// </see>
    /// that represents the filtering criteria.
    /// </summary>
    /// <typeparam name="T">The type of the entity to filter.</typeparam>
    /// <param name="filters">A list of <see cref="Filter"/> instances that define the filtering criteria.</param>
    /// <param name="expression">An optional existing <see>
    ///         <cref>Expression{Func{T,bool}}</cref>
    ///     </see>
    ///     to which the new filtering criteria will be added with an AND operator.</param>
    /// <returns>An <see>
    ///         <cref>Expression{Func{T, bool}}</cref>
    ///     </see>
    ///     that represents the filtering criteria.</returns>
    public static Expression<Func<T, bool>>? GetExpression<T>(IList<Filter> filters, Expression? expression = null)
    {
        if (filters.Count == 0 && expression == null) return null;

        var parameter = Expression.Parameter(typeof(T), "t");

        if (filters.Count == 0 && expression != null) return Expression.Lambda<Func<T, bool>>(expression, parameter);

        if (filters.Count == 1 && expression == null)
            expression = GetExpression<T>(parameter, filters[0]);
        else if (filters.Count == 2 && expression == null)
            expression = GetExpression<T>(parameter, filters[0], filters[1]);

        if (filters.Count == 1 && expression != null)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            expression = Expression.AndAlso(expression, GetExpression<T>(parameter, filters[0]));
#pragma warning restore CS8604 // Possible null reference argument.
        }
        else if (filters.Count == 2 && expression != null)
        {
            expression = Expression.AndAlso(expression, GetExpression<T>(parameter, filters[0], filters[1]));
        }
        else
        {
            while (filters.Count > 0)
            {
                var f1 = filters[0];
                var f2 = filters[1];

                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (expression == null)
                    expression = GetExpression<T>(parameter, filters[0], filters[1]);
                else
                    expression = Expression.AndAlso(expression, GetExpression<T>(parameter, filters[0], filters[1]));

                filters.Remove(f1);
                filters.Remove(f2);

                if (filters.Count == 1)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    expression = Expression.AndAlso(expression, GetExpression<T>(parameter, filters[0]));
#pragma warning restore CS8604 // Possible null reference argument.
                    filters.RemoveAt(0);
                }
            }
        }

#pragma warning disable CS8604 // Possible null reference argument.
        return Expression.Lambda<Func<T, bool>>(expression, parameter);
#pragma warning restore CS8604 // Possible null reference argument.
    }

    /// <summary>
    /// Returns an <see cref="Expression"/> object that represents a filter based on the specified <paramref name="filter"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object being filtered.</typeparam>
    /// <param name="param">The <see cref="ParameterExpression"/> object that represents the parameter of the lambda expression.</param>
    /// <param name="filter">The <see cref="Filter"/> object that represents the filter criteria.</param>
    /// <returns>An <see cref="Expression"/> object that represents a filter based on the specified <paramref name="filter"/>, or <c>null</c> if the filter operation is not supported.</returns>
    [SuppressMessage("ReSharper", "SwitchStatementHandlesSomeKnownEnumValuesWithDefault" , Justification = "Some enum values are handled in the switch statement, others are handled by the default case.")]
    private static Expression? GetExpression<T>(ParameterExpression param, Filter filter)
    {
        var member = Expression.Property(param, filter.PropertyName);

        var constant = Expression.Constant(filter.Value, member.Type);

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (filter.Operation)
        {
            case Operation.Equals:
                    return Expression.Equal(member, constant);
            case Operation.GreaterThan:
                return Expression.GreaterThan(member, constant);
            case Operation.GreaterThanOrEqual:
                return Expression.GreaterThanOrEqual(member, constant);
            case Operation.LessThan:
                return Expression.LessThan(member, constant);
            case Operation.LessThanOrEqual:
                return Expression.LessThanOrEqual(member, constant);
            case Operation.Contains:
#pragma warning disable CS8604 // Possible null reference argument.
                return Expression.Call(member, ContainsMethod, constant);
#pragma warning restore CS8604 // Possible null reference argument.
            case Operation.StartsWith:
#pragma warning disable CS8604 // Possible null reference argument.
                return Expression.Call(member, StartsWithMethod, constant);
#pragma warning restore CS8604 // Possible null reference argument.
            case Operation.EndsWith:
#pragma warning disable CS8604 // Possible null reference argument.
                return Expression.Call(member, EndsWithMethod, constant);
            case Operation.NotEqual:
#pragma warning disable CS8604 // Possible null reference argument.
                return Expression.NotEqual(member, constant);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        return null;
    }

    /// <summary>
    /// Gets the binary expression for two filters by combining them with the AND operator.
    /// </summary>
    /// <typeparam name="T">The type of the expression.</typeparam>
    /// <param name="param">The parameter expression.</param>
    /// <param name="filter1">The first filter.</param>
    /// <param name="filter2">The second filter.</param>
    /// <returns>The binary expression.</returns>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter filter2)
    {
        var bin1 = GetExpression<T>(param, filter1);
        var bin2 = GetExpression<T>(param, filter2);

#pragma warning disable CS8604 // Possible null reference argument.
        return Expression.AndAlso(bin1, bin2);
#pragma warning restore CS8604 // Possible null reference argument.
    }

    /// <summary>
    /// Combines two lambda expressions with the "and" operator and returns a new lambda expression.
    /// </summary>
    /// <typeparam name="T">The type of the input parameter of the lambda expressions.</typeparam>
    /// <param name="left">The left lambda expression.</param>
    /// <param name="right">The right lambda expression.</param>
    /// <returns>A new lambda expression that represents the combination of the two input expressions with the "and" operator.</returns>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable once UnusedMember.Local
    private static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.AndAlso(Expression.Invoke(left, param), Expression.Invoke(right, param));
        var lambda = Expression.Lambda<Func<T, bool>>(body, param);

        return lambda;
    }
}