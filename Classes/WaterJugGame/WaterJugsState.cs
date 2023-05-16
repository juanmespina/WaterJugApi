namespace WaterJugGame
{
    public class WaterJugsState
    {

        public WaterJugsState(WaterJug smallerJug, WaterJug biggerJug, string explanation)
        {
            if (smallerJug.Name == "x")
            {
                X = smallerJug.CurrentAmount;
                Y = biggerJug.CurrentAmount;

            }
            else
            {
                X = biggerJug.CurrentAmount;
                Y = smallerJug.CurrentAmount;
            }

            Explanation = explanation;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Explanation { get; set; }
    }

}