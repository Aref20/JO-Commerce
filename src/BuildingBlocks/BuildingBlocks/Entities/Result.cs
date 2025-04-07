using BuildingBlocks.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.BaseEntity
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public int StatusCode => IsSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string error, int statusCode)
        {
            if (isSuccess && !string.IsNullOrEmpty(error))
                throw new InvalidOperationException("A successful result cannot contain an error message");

            if (!isSuccess && string.IsNullOrEmpty(error))
                throw new InvalidOperationException("A failure result must contain an error message");


            IsSuccess = isSuccess;
            Error = error;
       
        }

        public static Result Success() => new Result(true, string.Empty, (int)HttpStatusCode.OK);
        public static Result<T> Success<T>(T value) => new Result<T>(value, true, string.Empty, (int)HttpStatusCode.OK);
        public static Result Failure(string error) => new Result(false, error, (int)HttpStatusCode.BadRequest);
        public static Result<T> Failure<T>(string error) => new Result<T>(default!, false, error, (int)HttpStatusCode.BadRequest);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected internal Result(T value, bool isSuccess, string error, int statusCode) : base(isSuccess, error, statusCode)
        {
            Value = value;
        }
    }


}
