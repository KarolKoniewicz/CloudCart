namespace Ebiscon.CloudCart.Domain.Extensions
{
    public static class NullExtensions
    {
        public static bool IsNullOrEmpty(this string value)
         => string.IsNullOrWhiteSpace(value);

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
            => value == null || !value.Any();
    }
}
