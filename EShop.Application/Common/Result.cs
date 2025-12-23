using System.Net;

namespace EShop.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public int StatusCode { get; private set; }

        private Result(bool isSuccess, T? value, HttpStatusCode statusCode)
        {
            IsSuccess = isSuccess;
            Value = value;
            StatusCode = (int)statusCode;
        }

        public static Result<T> Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(true, value, statusCode);
        public static Result<T> Failure(T value, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(false, value, statusCode);
        public static Result<T> InternalError(T value, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            => new(false, value, statusCode);

    }
}
