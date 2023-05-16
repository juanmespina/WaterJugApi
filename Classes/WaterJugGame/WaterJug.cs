namespace WaterJugGame
{
    public class WaterJug
    {
        public readonly int MaxQtyGallons;
        public int CurrentAmount { get; set; }
        public string Name { get; set; }

        public WaterJug(int maxQtyGallons, string name)
        {
            MaxQtyGallons = maxQtyGallons;
            CurrentAmount = 0;
            Name = name;
        }
    }
}