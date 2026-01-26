using ModSettings;

namespace PathfindersAscent
{
    internal class PathfindersAscent : JsonModSettings
    {

        [Name("Enable Mod")]
        [Description("You can disable the mod and play other saves.  Then turn it back on when you are ready to continue Pathfinder's Ascent.")]
        public bool pathfindersAscent = false;

        /*
        [Name("Disable WildLife Adjustments")]
        [Description("This will disable all wildlife related adjustments.")]
        public bool disableWildlife = false;
        */
    }

    internal static class Settings
    {
        public static PathfindersAscent options;

        public static void OnLoad()
        {
            options = new PathfindersAscent();
            options.AddToModSettings("Pathfinders Ascent", MenuType.Both);
        }
    }

}