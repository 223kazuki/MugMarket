using UniRx;
using UnityEngine;

namespace MugMarket.Renderer
{
    [RequireComponent(typeof(Canvas))]
    public sealed class MenuRenderer : MonoBehaviour
    {
        private Canvas Menu;

        void Start()
        {
            Menu = GetComponent<Canvas>();
            App.Subject
                .StartWith(App.State)
                .Subscribe(state => Menu.gameObject.SetActive(state.MenuOpend))
                .AddTo(this);
        }
    }
}