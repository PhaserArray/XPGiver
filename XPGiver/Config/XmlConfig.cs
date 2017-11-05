using System;
using System.IO;
using System.Xml.Serialization;
using JetBrains.Annotations;
using PhaserArray.XPGiver.Utilities;

namespace PhaserArray.XPGiver.Config
{
	public class XmlConfig<T> where T : class, IDefaultable
	{
		public T Instance;

		private readonly XmlSerializer _serializer;
		private readonly string _file;

		public XmlConfig(string file)
		{
			_serializer = new XmlSerializer(typeof(T));
			_file = file;
			Load();
		}

		/// <summary>
		/// Loads the config, creates a new one if it is not found or is corrupt. Replaces the current config instance.
		/// </summary>
		/// <returns>Config</returns>
		public T Load()
		{
			T config = null;
			try
			{
				if (File.Exists(_file))
				{
					using (var reader = new StreamReader(_file))
					{
						config = (T)_serializer.Deserialize(reader);
					}
				}
			}
			catch (Exception e)
			{
				Logger.Log("Could not parse existing config: " + e);
			}
			if (config == null)
			{
				config = Activator.CreateInstance<T>();
				config.LoadDefaults();
				Save(config);
			}
			Instance = config;
			return config;
		}

		/// <summary>
		/// Saves the current config Instance. If another config is provided, replaces the current config instance and saves it.
		/// </summary>
		/// <param name="config">Optional Config</param>
		public void Save([CanBeNull] T config=null)
		{
			if (config == null)
			{
				config = Instance;
			}
			else
			{
				Instance = config;
			}
			// ReSharper disable once AssignNullToNotNullAttribute
			try
			{
				if (!Directory.Exists(Path.GetDirectoryName(_file))) return;
				using (var writer = new StreamWriter(_file))
				{
					_serializer.Serialize(writer, config);
				}
			}
			catch (UnauthorizedAccessException)
			{
				Logger.Log("Not authorized to write to config file, file may be read-only!");
			}
			catch (Exception e)
			{
				Logger.Log("Error writing to config file, config will not be saved: " + e);
			}
		}
	}
}