namespace Emne3;

public interface IResult
{
    bool IsOk();
    bool IsError();

    T? InnerValue<T>();
}