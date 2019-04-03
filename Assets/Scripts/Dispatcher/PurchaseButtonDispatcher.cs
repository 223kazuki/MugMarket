using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace MugMarket.Dispatcher
{
    [RequireComponent(typeof(Button))]
    public class PurchaseButtonDispatcher : MonoBehaviour
    {
        private Button Button;

        void OnEnable()
        {
            Button = this.GetComponent<Button>();
            Button.OnClickAsObservable()
                .TakeUntilDisable(this)
                .Subscribe(_ => this.Dispatch())
                .AddTo(this);
        }

        void Dispatch()
        {
            App.Store.Dispatch(ActionCreator.Purchase());
        }

    }
}