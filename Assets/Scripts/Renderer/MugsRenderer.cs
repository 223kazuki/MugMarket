using UniRx;
using UniRx.Triggers;
using MugMarket.Dispatcher;

namespace MugMarket.Renderer
{
    using UnityEngine;

    public class MugsRenderer : BaseListRenderer<MugRenderer, Mug>
    {
        public MugRenderer Cell;

        void Start()
        {
            App.Subject
                .Where(state => state.MugsState.IsStateChanged)
                .StartWith(App.State)
                .Subscribe(state => this.Render(this.transform, this.Cell, state.MugsState.Mugs))
                .AddTo(this);
        }

        protected override void RenderCell(int index, MugRenderer renderer, Mug value, bool init)
        {
            if (init)
            {
                renderer.gameObject.OnMouseDownAsObservable()
                    .TakeUntilDisable(this)
                    .Subscribe(_ => MugClickDispather.Dispatch(value.Id))
                    .AddTo(this);
                var transform = renderer.transform;
                transform.position = new Vector3(-1.2f + (index * 0.3f), 1.0f, -3f);
                Color MyColour = Color.clear;
                ColorUtility.TryParseHtmlString(value.Color, out MyColour);
                renderer.GetComponent<Renderer>().material.color = MyColour;
            }

            base.RenderCell(index, renderer, value, init);
        }
    }
}