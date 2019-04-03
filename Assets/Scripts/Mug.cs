using System;

namespace MugMarket
{
    [Serializable]
    public class Mug
    {
        public uint Id;
        public string Name;
        public int Price;
        public string Color;

        public Mug(uint id = 0, string name = "", int price = 0, string color = "")
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Color = color;
        }
    }
}