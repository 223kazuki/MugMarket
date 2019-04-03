using UnityEngine;
using UniRx;

namespace MugMarket.Dispatcher
{
    public class KeyInputDispatcher : MonoBehaviour
    {
        private IObservable<long> keyStream;

        void OnEnable()
        {
            keyStream = Observable.EveryUpdate();

            // Space key にメニュー開閉割り当て
            keyStream
                .TakeUntilDisable(this)
                .Where(_ => Input.GetKeyDown(KeyCode.Space))
                .Subscribe(_ => this.SpaceKeyDispatch())
                .AddTo(this);
        }

        void SpaceKeyDispatch()
        {
            App.Store.Dispatch(ActionCreator.ToggleMenu());
        }

    }
}