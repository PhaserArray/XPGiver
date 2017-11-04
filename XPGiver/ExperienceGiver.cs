using System.IO;
using SDG.Unturned;
using UnityEngine;
using PhaserArray.XPGiver.Config;
using PhaserArray.XPGiver.Serialization;
using PhaserArray.XPGiver.Utilities;

namespace PhaserArray.XPGiver
{
	public class ExperienceGiver : MonoBehaviour
	{
		public ExperienceGiverConfig Config;

		private static string _configPath;

		/// <summary>
		/// Expected path of the config for ExperienceGiver.
		/// </summary>
		public static string ConfigPath
		{
			get
			{
				if (string.IsNullOrEmpty(_configPath))
				{
					// ReSharper disable once AssignNullToNotNullAttribute
					_configPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location),
						"XPGiverConfig.xml");
				}
				return _configPath;
			}
		}       
		
		/// <summary>
		/// Loads the config and invokes repeating on GiveExperience.
		/// </summary>
		public void Start()
		{
			Config = new XmlConfig<ExperienceGiverConfig>(ConfigPath).Instance;
			InvokeRepeating(nameof(GiveExperience), Config.Interval, Config.Interval);
		}

		/// <summary>
		/// Gives all online players an amount of XP defined in the config.
		/// </summary>
		public void GiveExperience()
		{
			if (!Level.isLoaded || !Level.isInitialized || !Provider.isServer) return;
			foreach (var client in Provider.clients)
			{
				ExperienceUtility.ChangeExperience(client.player, Config.Experience);
			}
		}
	}
}
