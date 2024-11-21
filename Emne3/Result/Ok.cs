using Emne3.Result;

namespace Emne3;

// public class Ok<T>(T value) : Result where T : notnull
// {
//     private T Value => value;
//
//     public bool IsOk() => true;
//     public bool IsError() => false;
//
//     public T IntoInner() { return Value; }
//     
//     public TInner? InnerValue<TInner>()
//     {
//         if (typeof(TInner) == typeof(T))
//         {
//             return (TInner)(object)Value;
//         }
//         throw new InvalidOperationException();
//     }
// }