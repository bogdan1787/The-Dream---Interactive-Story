namespace StoryTeller.App.V3.Sounds.Effects
{
    public class SoundEffect
    {
        public string SoundName { get; set; }
        public double Volume { get; set; }

        public SoundEffect(string name, double volume)
        {
            SoundName = name;
            Volume = volume;
        }


        public static SoundEffect ChurchBellTubular => new SoundEffect("ChurchBell_Tubular.mp3", 0.3d);
        public static SoundEffect FourWhispers => new SoundEffect("Four_Whispers.mp3", 0.4d);


    }
}
