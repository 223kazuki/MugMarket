using Unidux;
using UnityEngine;
using System.Collections.Generic;

namespace MugMarket
{
    public class Reducer : ReducerBase<State, Action>
    {
        public override State Reduce(State state, Action action)
        {
            switch (action.ActionType)
            {
                case ActionType.ToggleMenu:
                    state.MenuOpend = !state.MenuOpend;
                    state.CartState.PurchaseSuccessMessage = null;
                    state.CartState.SetStateChanged();
                    break;
                case ActionType.CreateMug:
                    var createMugAction = (CreateMugAction)action;
                    state.MugsState = AddMug(state.MugsState, createMugAction.Mug.Name, createMugAction.Mug.Price, createMugAction.Mug.Color);
                    break;
                case ActionType.AddToCart:
                    var addToCartAction = (AddToCartAction)action;
                    state.CartState = AddToCart(state.CartState, addToCartAction.MugId);
                    break;
                case ActionType.PurchaseSuccess:
                    var purchaseSuccessAction = (PurchaseSuccessAction)action;
                    if (purchaseSuccessAction.StatusCode == 200)
                    {
                        state.CartState = PurchaseSuccess(state.CartState);
                    }

                    break;
            }
            return state;
        }

        public static MugsState AddMug(MugsState state, string name, int price, string color)
        {
            state.Mugs.Add(new Mug(
                id: state.Index,
                name: name,
                color: color,
                price: price
            ));
            state.Index = state.Index + 1;
            state.SetStateChanged();
            return state;
        }

        public static CartState AddToCart(CartState state, uint mugId)
        {
            if (state.Cart.ContainsKey(mugId))
            {
                int count = (int)state.Cart[mugId];
                state.Cart[mugId] = count + 1;
            }
            else
            {
                state.Cart.Add(mugId, 1);
            }


            state.SetStateChanged();
            return state;
        }

        public static CartState PurchaseSuccess(CartState state)
        {
            state.PurchaseSuccessMessage = "Puchase Success!!";
            state.Cart = new Dictionary<uint, int>();
            state.SetStateChanged();
            return state;
        }
    }
}