using UnityEngine;
namespace MugMarket.Dispatcher
{
    public class MugClickDispather : MonoBehaviour
    {
        static public void Dispatch(uint mugId)
        {
            App.Store.Dispatch(ActionCreator.AddToCart(mugId));
        }
    }
}