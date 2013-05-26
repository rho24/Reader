namespace Reader.Infrastructure
{
    public interface IQuery<out T>
    {
        T Execute();
    }

    public interface IQuery<in TIn, out TOut>
    {
        TOut Execute(TIn input);
    }
}