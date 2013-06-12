using System.Threading.Tasks;

namespace Reader.Infrastructure
{
    public class AsyncCommandRunner
    {
        public void Execute<T>(ICommand<T> command, T input) {
            var t = Task.Run(() => command.Execute(input));
        }
    }
}