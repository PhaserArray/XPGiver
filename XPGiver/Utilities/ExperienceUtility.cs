using System;
using SDG.Unturned;

namespace PhaserArray.XPGiver.Utilities
{
	public class ExperienceUtility
	{
		/// <summary>
		/// Sets the player's experience to a value.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="experience"></param>
		public static void SetExperience(Player player, uint experience)
		{
			player.skills.channel.send("tellExperience", ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_BUFFER, experience);
			player.skills.channel.send("tellExperience", ESteamCall.OWNER, ESteamPacket.UPDATE_RELIABLE_BUFFER, experience);
		}

		/// <summary>
		/// Gets the player's experience value.
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public static uint GetExperience(Player player)
		{
			return player.skills.experience;
		}

		/// <summary>
		/// Changes the player's experience by a given amount. Checks for overflow.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="experience"></param>
		public static void ChangeExperience(Player player, int experience)
		{
			SetExperience(player, (uint)Math.Min(uint.MaxValue, Math.Max(uint.MinValue, GetExperience(player) + experience)));
		}
	}
}