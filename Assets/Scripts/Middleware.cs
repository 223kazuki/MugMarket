using System;
using System.Collections;
using Unidux;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

namespace MugMarket
{
    public class Middleware
    {
        public GameObject InjectGameObject { get; set; }

        public Middleware(GameObject gameObject)
        {
            this.InjectGameObject = gameObject;
        }

        public System.Func<System.Func<object, object>, System.Func<object, object>> Process(IStoreObject store)
        {
            return (System.Func<object, object> next) => (object action) =>
            {
                if (action is Action && ((Action)action).ActionType == ActionType.Purchase && this.InjectGameObject != null)
                {
                    var json = Json.Serialize(App.State.CartState.Cart);
                    Observable.FromCoroutine<Action>(observer =>
                            Request(
                                "https://httpbin.org/post",
                                json,
                                data =>
                                {
                                    observer.OnNext(data);
                                    observer.OnCompleted();
                                },
                                error => observer.OnError(new Exception("Network error"))
                            )
                        )
                        .Subscribe(data => next(data), error => next(error))
                        .AddTo(this.InjectGameObject);
                }

                return next(action);
            };
        }

        private IEnumerator Request(string url, string body, Action<Action> success, Action<string> error)
        {
            Debug.Log("POST: " + body);
            UnityWebRequest getRequest = UnityWebRequest.Post(url, body);

            yield return getRequest.SendWebRequest();

            if (getRequest.isNetworkError)
            {
                error.Invoke(getRequest.error);
            }
            else
            {
                var entity = ActionCreator.PurchaseSuccess((int)getRequest.responseCode, getRequest.downloadHandler.text);
                success(entity);
            }
        }
    }
}