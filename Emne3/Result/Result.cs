namespace Emne3;
public interface IResult;


public class Result<TR>(TR value)
    where TR : IResult
{
    private TR _value = value;
}

public class Err<TE>(TE value) : IResult
{
    private TE _value = value;
}


public class Ok<T>(T value): IResult;

// private T value = value;