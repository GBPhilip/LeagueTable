using Ardalis.SmartEnum;

namespace LeagueTable.Domain
{
    /// <summary>
    /// Specifies the type result
    /// </summary>
    internal sealed class ResultEnum:SmartEnum<ResultEnum>
    {
        /// <summary>
        /// The Regulation value should be used when the result occurred within regulation time
        /// </summary>
        public static readonly ResultEnum Regulation = new (nameof(Regulation), 0);
        /// <summary>
        /// The Overtime value should be used when the result occurred within overtime or through penalty shoots
        /// </summary>
        public static readonly ResultEnum Overtime = new (nameof(Overtime), 1);

        private ResultEnum(string name, int value): base(name, value) { }
    }
}
