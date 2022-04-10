using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.ModHelper;
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
        public Mod(Game _game, IModConfig _config, IReloadedHooks _hooks, IModLogger _logger) : base(_game, _config, _hooks, _logger)
        {
            Logger.WriteLine("Hello World!");

            // Below are 3 examples of using ModEvents
            _game.OnProfileSelected += () => Logger.WriteLine("The player just selected a save file");
            _game.OnMainMenu += OnMainMenu;
            _game.OnGameJoined.AddListener(GameJoined);
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

        private void GameJoined()
        {
            Logger.WriteLine("The game was joined!");
        }
    }
}