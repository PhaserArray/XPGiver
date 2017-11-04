using PhaserArray.XPGiver.Config;

namespace PhaserArray.XPGiver.Serialization
{
	public class ExperienceGiverConfig : IDefaultable
	{
		public int Experience;
		public float Interval;

		public void LoadDefaults()
		{
			Experience = 500;
			Interval = 600f;
		}
	}
}