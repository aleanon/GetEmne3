namespace Emne3;

public class Result<T>
{
    private readonly bool _isSuccess;
    private readonly T _value;
    private Exception _error;
    
    public Result(Func<T> function)
    {
        try
        {
            _value = function();
            _isSuccess = true;
        }
        catch(Exception ex)
        {
            _isSuccess = false;
            _error = ex;
        }
    }

    public static Result<T> Err(Exception error) => new Result<T>(error);

    public static Result<T> Ok(T value) => new Result<T>(value);
    
    private Result(Exception ex)
    {
        _isSuccess = false;
        _error = ex;
    }

    private Result(T value)
    {
        _isSuccess = true;
        _value = value;
    }

    public T Catch(Func<Exception, T> errorProvider)
    {
        return _isSuccess ? _value : errorProvider(_error);
    }
    
    public bool IsSuccess => _isSuccess;
    public bool IsError => !_isSuccess;
    
    public T UnwrapOr(T value) => _isSuccess ? _value : value;
    
    public T UnwrapOrElse(Func<T> function) => _isSuccess ? _value : function();
    
    public Result<T> MapError(Func<Exception> function)
    {
        if (_isSuccess) return this;
        _error = function();
        return this;
    }

    public Result<TN> Map<TN>(Func<T, TN> function)
    {
        return _isSuccess ? new Result<TN>(()=>function(_value)) : new Result<TN>(_error);
    }
}