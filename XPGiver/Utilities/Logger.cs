using SDG.Framework.Debug;

namespace PhaserArray.XPGiver.Utilities
{
	public class Logger
	{
		private static string _category;

		public static string Category
		{
			get => _category ?? (_category = System.Reflection.Assembly.GetCallingAssembly().GetName().Name);
			set => _category = value;
		}

		public static void Log(object text)
		{
			Terminal.print(text.ToString(), null, Category, null);
		}
	}
}
