namespace Spoon.NuGet.Mediator
{
    using System.Text.Json;
    using Core.Domain;

    /// <summary>
    ///     Class MediatorBaseQueryWithSearchAndPagination.
    ///     Implements the <see cref="MediatorBase" />.
    /// </summary>
    /// <seealso cref="MediatorBase" />
    public abstract class MediatorBaseQueryWithSearchAndPagination : MediatorBase
    {
        private readonly List<Filter> _filters = new ();

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorBaseQueryWithSearchAndPagination" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected MediatorBaseQueryWithSearchAndPagination(Type query)
            : base(query)
        {
        }

        /// <summary>
        /// </summary>
        public List<Filter> Filters
        {
            get => this._filters;
            init => this._filters = this.Map(value);
        }

        private List<Filter> Map(List<Filter> value)
        {
            foreach (var filter in value)
            {
                if (filter.Value is JsonElement json)
                {
                    switch (json.ValueKind)
                    {
                        case JsonValueKind.Undefined:
                        case JsonValueKind.Object:
                        case JsonValueKind.Array:
                        case JsonValueKind.Null:
                            break;
                        case JsonValueKind.String:

                            if (json.TryGetDateTime(out var dateTime))
                            {
                                filter.Value = dateTime;
                                break;
                            }

                            if (json.TryGetGuid(out var guid))
                            {
                                filter.Value = guid;
                                break;
                            }

                            filter.Value = json.GetString();
                            break;
                        case JsonValueKind.Number:

                            if (json.TryGetInt32(out var int32))
                            {
                                filter.Value = int32;
                                break;
                            }

                            if (json.TryGetDouble(out var doubleValue))
                            {
                                filter.Value = doubleValue;
                            }

                            break;
                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            filter.Value = json.GetBoolean();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return value;
        }


        /// <summary>
        ///     Gets the skip.
        /// </summary>
        /// <value>The skip.</value>
        public int Skip => (this.Page - 1) * this.PageLength;

        /// <summary>
        ///     Gets the take.
        /// </summary>
        /// <value>The take.</value>
        public int Take => this.PageLength;

        /// <summary>
        ///     Gets the page.
        /// </summary>
        /// <value>The page.</value>
        public int Page { get; init; }

        /// <summary>
        ///     Gets the length of the page.
        /// </summary>
        /// <value>The length of the page.</value>
        public int PageLength { get; init; }

        /// <summary>
        /// </summary>
        /// <param name="filter"></param>
        internal void AddFilter(Filter filter)
        {
            this._filters.Add(filter);
        }
    }
}