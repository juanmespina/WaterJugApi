namespace WaterJugGame
{
    public class WaterJugsState
    {
        public WaterJugsState(int x, int y, string explanation)
        {
            X = x;
            Y = y;
            Explanation = explanation;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Explanation { get; set; }
    }

}