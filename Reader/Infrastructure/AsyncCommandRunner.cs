using System.Threading.Tasks;

namespace Reader.Infrastructure
{
    public class AsyncCommandRunner
    {
        public void Execute<T>(ICommand<T> command, T input) {
            Task.Factory.StartNew(() => command.Execute(input))
                .ContinueWith(t => {

                }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}