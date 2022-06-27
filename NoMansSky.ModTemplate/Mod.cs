using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.ModHelper;
using NoMansSky.Api;
using libMBIN.NMS.Globals;

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
            // Below are 3 examples of using them.
            Game.OnProfileSelected += () => Logger.WriteLine("The player just selected a save file");
            Game.OnMainMenu += OnMainMenu;
            Game.OnGameJoined.AddListener(GameJoined);
        }

        /// <summary>
        /// Called once every frame.
        /// </summary>
        public override void Update()
        {
            // Here is an example of checking for keyboard keys
            if (Keyboard.IsPressed(Key.UpArrow))
            {
                Logger.WriteLine("The Up Arrow was just pressed!");
            }
        }

        private void OnMainMenu()
        {
            Logger.WriteLine("Main Menu shown!");


            // here is an example of modding 
            GlobalMbinModding();
        }

        // here is an example of modding 
        private void GlobalMbinModding()
        {
            var memoryMgr = new MemoryManager(); // create a memory manager.

            // get the address of the global
            long globalAddress = Game.MBinManager.GetMbin("GcSettlementGlobals").Address;
            Logger.WriteLine($"Settlement global address: {globalAddress.ToString("X")}");

            // get the global itself
            var globalMbin = memoryMgr.GetValue<GcSettlementGlobals>(globalAddress);

            // example of messing with variables from the global
            Logger.WriteLine($"GcSettlementGlobals.MaxNPCPopulation: {globalMbin.MaxNPCPopulation}");

            // example of changing it
            globalMbin.MaxNPCPopulation = 6969697;
            memoryMgr.SetValue(globalAddress, globalMbin); // update the global in memory
        }

        private void GameJoined()
        {
            Logger.WriteLine("The game was joined!");
        }
    }
}