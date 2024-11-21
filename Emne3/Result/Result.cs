namespace Emne3.Result;


// public class Result<T> where T : notnull, IResult
// {
//     private T _value;
//
//     private Result(T value)
//     {
//         _value = value;
//     }
//
//     public static Result<Ok<TOk>> Ok<TOk>(TOk value) where TOk : notnull
//     {
//         var ok = new Ok<TOk>(value);
//         return new Result<Ok<TOk>>(ok);
//     }
//
//     public static Result<Err<TError>> Err<TError>(TError value) where TError : notnull, IError
//     {
//         var err = new Err<TError>(value);
//         return new Result<Err<TError>>(err);
//     }
//
//     public bool IsOk()
//     {
//         return _value.IsOk();
//     }
//
//     public bool IsErr()
//     {
//         return _value.IsError();
//     }
//
//     public TInner UnwrapOr<TInner>(TInner value) where TInner : notnull
//     {
//         
//         return _value.IsError() ? value : _value.InnerValue<TInner>();
//     }
//     
//     public TInner UnwrapOrElse<TInner>(Func<TInner> function)
//         where TInner : notnull
//     {
//         return _value.IsError() ? function() : _value.InnerValue<TInner>();
//     }
// }


public abstract class Result
{
    protected abstract bool IsOk { get; }
    public bool IsErr => !IsOk;

    // public static Result<T, TE> Ok(T value) => new Result<T, TE>.Ok(value);

    // public static Result<T, TE> Err(TE error) => new ErrResult(error);

}
    public class Ok<T>(T value) : Result
    {
        public T Value { get; } = value;

        protected override bool IsOk => true;
    }

    public class Err<T>(T error) : Result
    {
        public T Error { get; } = error;

        protected override bool IsOk => false;
    }

    enum ResultState
    {
        
    }