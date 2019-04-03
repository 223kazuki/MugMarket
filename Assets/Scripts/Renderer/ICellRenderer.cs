namespace MugMarket.Renderer
{
    public interface ICellRenderer<TValue>
    {
        void Render(int index, TValue item);
    }
}