using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using NoMansSky.Api;

namespace NoMansSky.ModTemplate
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : NMSMod
    {
        /// <summary>
        /// Initializes your mod along with some necessary info.
        /// </summary>
        public Mod(Game _game, IModConfig _config, IReloadedHooks _hooks, ILogger _logger) : base(_game, _config, _hooks, _logger)
        {
            Logger.WriteLine("Hello World!");

            // Below are 2 examples of using ModEvents
            _game.OnProfileSelected += () => Logger.WriteLine("The player just selected a save file");
            _game.OnMainMenu += OnMainMenu;
        }

        /// <summary>
        /// Called once every frame.
        /// </summary>
        public override void Update()
        {
            
        }

        private void OnMainMenu()
        {
            Logger.WriteLine("Main Menu shown!");
        }
    }
}