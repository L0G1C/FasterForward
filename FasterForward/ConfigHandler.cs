using TaleWorlds.InputSystem;

namespace TourneySaveScum
{
    public class ConfigHandler
    {
        public InputKey FasterForwardKey { get; set; }

        public ConfigHandler()
        {
            FasterForwardKey = InputKey.D4;
        }
    }
}