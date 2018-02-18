using System;
using System.Linq;
using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Threading
{
    [PSerializable]
    public class BackgroundThreadAttribute:MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Task.Run(() => args.Proceed());
        }
        public override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            return Task.Run(async () => await args.ProceedAsync());
        }
    }
}
