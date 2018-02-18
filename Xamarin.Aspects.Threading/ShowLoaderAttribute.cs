using Acr.UserDialogs;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Threading
{
    [PSerializable]
    public class ShowLoaderAttribute: OnMethodBoundaryAspect
    {
       

        public override void OnEntry(MethodExecutionArgs args)
        {
            Forms.Device.BeginInvokeOnMainThread(() => {
            UserDialogs.Instance.Loading().Show();
            });
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Forms.Device.BeginInvokeOnMainThread(() => {

                UserDialogs.Instance.Loading().Hide();
            });

            base.OnExit(args);
        }
    }
}