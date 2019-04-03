using UnityEngine;

namespace MugMarket.Dispatcher
{
    public class CreateMugsDispatcher : MonoBehaviour
    {
        void OnEnable()
        {
            this.Dispatch();
        }

        void Dispatch()
        {
            App.Store.Dispatch(ActionCreator.CreateMug("Mug1", 100, "black"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug2", 200, "yellow"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug3", 300, "green"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug4", 400, ""));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug5", 100, "purple"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug6", 600, "red"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug7", 1000, "black"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug8", 200000, "yellow"));
            App.Store.Dispatch(ActionCreator.CreateMug("Mug9", 1, "blue"));
        }
    }
}