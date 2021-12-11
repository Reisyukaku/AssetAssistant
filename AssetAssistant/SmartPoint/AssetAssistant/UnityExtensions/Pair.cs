namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class Pair<T, U>
    {

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        public T First
        {
            get => First;
            set => First = value;
        }

        public U Second
        {
            get => Second;
            set => Second = value;
        }
    }
}
