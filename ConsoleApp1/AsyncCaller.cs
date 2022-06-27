using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AsyncCaller
    {
        readonly EventHandler handler;

        public AsyncCaller(EventHandler handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler), "Null value is invalid");
        }

        public bool Invoke(int timeout, object sender, EventArgs e)
        {
            var task = Task.Run(() => handler.Invoke(sender, e));

            return task.Wait(timeout);
        }
    }
}
