namespace MugMarket
{
    public enum ActionType
    {
        ToggleMenu,
        CreateMug,
        AddToCart,
        Purchase,
        PurchaseSuccess
    }

    public class Action
    {
        public ActionType ActionType;
    }

    public class CreateMugAction : Action
    {
        public Mug Mug;
    }

    public class AddToCartAction : Action
    {
        public uint MugId;
    }

    public class PurchaseSuccessAction : Action
    {
        public int StatusCode;
        public string Body;
    }

    public static class ActionCreator
    {
        public static Action ToggleMenu()
        {
            return new Action() { ActionType = ActionType.ToggleMenu };
        }

        public static Action CreateMug(string name, int price, string color)
        {
            return new CreateMugAction()
            {
                ActionType = ActionType.CreateMug,
                Mug = new Mug()
                {
                    Name = name,
                    Price = price,
                    Color = color
                }
            };
        }

        public static Action AddToCart(uint mugId)
        {
            return new AddToCartAction()
            {
                ActionType = ActionType.AddToCart,
                MugId = mugId
            };
        }

        public static Action Purchase()
        {
            return new Action() { ActionType = ActionType.Purchase };
        }

        public static Action PurchaseSuccess(int statusCode, string body)
        {
            return new PurchaseSuccessAction()
            {
                ActionType = ActionType.PurchaseSuccess,
                StatusCode = statusCode,
                Body = body,
            };
        }
    }
}