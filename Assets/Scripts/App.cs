using Unidux;
using UniRx;

namespace MugMarket
{
    public class App
    : SingletonMonoBehaviour<App>, IStoreAccessor
    {
        private Store<State> m_store;

        public IStoreObject StoreObject { get { return Store; } }

        public static State State { get { return Store.State; } }

        public static Subject<State> Subject { get { return Store.Subject; } }

        private static IReducer[] Reducers
        {
            get { return new IReducer[] { new Reducer() }; }
        }

        public static Store<State> Store
        {
            get
            {
                return Instance.m_store =
                    Instance.m_store ??
                    new Store<State>(new State(), new Reducer());
            }
        }

        public static object Dispatch<TAction>(TAction action)
        {
            return Store.Dispatch(action);
        }

        void Start()
        {
            Store.ApplyMiddlewares(new Middleware(this.gameObject).Process);
        }

        private void Update()
        {
            Store.Update();
        }
    }
}