using Ebiscon.CloudCart.Domain.Extensions;

namespace Ebiscon.CloudCart.Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, string error)
        {
            if (isSuccess && error.IsNullOrEmpty())
                throw new InvalidOperationException();

            if (!isSuccess && error.IsNullOrEmpty())
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new(true, string.Empty);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, string.Empty);

        public static Result Failure(string error) => new(false, error);

        public static Result<TValue> Failure<TValue>(string error) => new(default, false, error);

    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, string error)
            : base(isSuccess, error) =>
            _value = value;

        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    }
}
