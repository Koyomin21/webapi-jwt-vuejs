using System.Collections.Generic;
using System.Linq;


namespace SberTaskInfrastructure.Models
{
    public class ResponseResult
    {
        public bool Succeeded { get; private set; }
        public List<string> Errors { get; private set; }

        public ResponseResult(bool isSuccess, List<string> errors = null)
        {
            this.Succeeded = isSuccess;
            this.Errors = errors;
        }

        public static ResponseResult Ok()
        {
            return new ResponseResult(true);
        }
        public static ResponseResult Fail()
        {
            return new ResponseResult(false);
        }
        public static ResponseResult Fail(string error)
        {
            return new ResponseResult(false, new List<string>() { error });
        }

        public static ResponseResult Fail(IEnumerable<string>errors)
        {
            return new ResponseResult(false, errors.ToList());
        }

    }
    public class ResponseResult<T>
    {
        public bool Succeeded { get; private set; }
        public T Data { get; private set; }
        public List<string> Errors { get; private set; }

        public ResponseResult(bool isSuccess, List<string> errors = null, T data = default(T))
        {
            this.Succeeded = isSuccess;
            this.Errors = errors;
            this.Data = data;
        }

        public static ResponseResult<T> Ok(T result)
        {
            return new ResponseResult<T>(true, null, result);
        }

        public static ResponseResult<T> Fail()
        {
            return new ResponseResult<T>(false);
        }

        public static ResponseResult<T> Fail(string error)
        {
            return new ResponseResult<T>(false, new List<string> { error });
        }

        public static ResponseResult<T> Fail(IEnumerable<string> errors)
        {
            return new ResponseResult<T>(false, errors.ToList());
        }

    }
}
