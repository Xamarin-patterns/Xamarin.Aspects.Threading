using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Threading
{
    [PSerializable]

    public class ForegroundThreadAttribute : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Forms.Device.BeginInvokeOnMainThread(args.Proceed);
        }

        public override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            var taskcompletionSource=new TaskCompletionSource<object>();
            Forms.Device.BeginInvokeOnMainThread(async ()=>
            {
                await args.ProceedAsync();
                taskcompletionSource.SetResult(new object());
            });
            return taskcompletionSource.Task;
        }
    }
}