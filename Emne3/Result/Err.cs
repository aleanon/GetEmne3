using Emne3.Result;

namespace Emne3;

public class Err<T> : IResult where T : notnull, IError
{
    private T _value;

    public Err(T value)
    {
        _value = value;
    }

    public bool IsOk() => false;
    public bool IsError() => true;

    public TInner? InnerValue<TInner>()
    {
        throw new Exception();
    }
}
