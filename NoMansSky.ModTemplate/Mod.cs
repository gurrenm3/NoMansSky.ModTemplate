using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.ModHelper;
using NoMansSky.Api;
using libMBIN.NMS;
using libMBIN.NMS.Globals;
using libMBIN.NMS.GameComponents;
using Random = Reloaded.ModHelper.Random;
using System;

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
        public Mod(IModConfig _config, IReloadedHooks _hooks, IModLogger _logger) : base(_config, _hooks, _logger)
        {
            // This is how to log a message to the Reloaded II Console.
            Logger.WriteLine("Hello World!");


            // The API relies heavily on Mod Events.
            // Below are 4 examples of using them.
            Game.OnProfileSelected += () => Logger.WriteLine("The player just selected a save file");
            Game.OnMainMenu += OnMainMenu;            
            Game.OnGameJoined.AddListener(GameJoined);
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


            MbinModdingExample();
        }

        // here is an example of modding globals with the new MemoryManager
        private void MbinModdingExample()
        {
            // example of getting the run speed from the player globals
            float currentRunSpeed = GetValue<float>("GcPlayerGlobals.GroundRunSpeed");

            // example of settng the run speed to twice it's original value.
            SetValue("GcPlayerGlobals.GroundRunSpeed", currentRunSpeed * 2);
        }

        private void GameJoined()
        {
            Logger.WriteLine("The game was joined!");
        }
    }
}