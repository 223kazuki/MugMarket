using System;
using System.Collections;
using System.Collections.Generic;
using Unidux;

namespace MugMarket
{
    [Serializable]
    public class State : StateBase
    {
        public bool MenuOpend;
        public MugsState MugsState = new MugsState();
        public CartState CartState = new CartState();
    }

    [Serializable]
    public class MugsState : StateElement
    {
        public uint Index = 0;
        public List<Mug> Mugs = new List<Mug>();
    }

    [Serializable]
    public class CartState : StateElement
    {
        public Dictionary<uint, int> Cart = new Dictionary<uint, int>();
        public string PurchaseSuccessMessage = null;
    }
}