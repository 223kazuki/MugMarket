using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MugMarket.Renderer
{
    [RequireComponent(typeof(Image))]
    public sealed class MessageRenderer : MonoBehaviour
    {
        private Image Panel;
        public Text Text;

        void Start()
        {
            Panel = this.GetComponent<Image>();

            App.Subject
                .StartWith(App.State)
                .Where(state => state.CartState.IsStateChanged)
                .Select(state => state.CartState)
                .Subscribe(state =>
                {
                    if (state.PurchaseSuccessMessage != null)
                    {
                        Panel.gameObject.SetActive(true);
                        Text.text = state.PurchaseSuccessMessage;
                    }
                    else
                    {
                        Panel.gameObject.SetActive(false);
                        Text.text = "";
                    }
                })
                .AddTo(this);
        }
    }
}