using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MugMarket.Renderer
{
    [RequireComponent(typeof(Text))]
    public sealed class CartRenderer : MonoBehaviour
    {
        private Text Text;

        void Start()
        {
            Text = this.GetComponent<Text>();
            App.Subject
                .StartWith(App.State)
                .Where(state => state.CartState.IsStateChanged)
                .Subscribe(state =>
                {
                    string cartText = "Cart\n\n";
                    int price = 0;
                    foreach (Mug m in state.MugsState.Mugs)
                    {
                        if (state.CartState.Cart.ContainsKey(m.Id))
                        {
                            var count = state.CartState.Cart[m.Id];
                            cartText += m.Name + " : " + m.Price + " : " + count + "\n";
                            price += m.Price * (int)count;
                        }
                        else
                        {
                            state.CartState.Cart.Add(m.Id, 1);
                        }
                    }
                    cartText += "\nTotal : " + price;
                    Text.text = cartText;
                })
                .AddTo(this);
        }
    }
}