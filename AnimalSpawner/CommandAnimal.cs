using System;
using System.Collections.Generic;
using System.Threading;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using SDG.Unturned;


namespace AnimalSpawner
{
    class CommandAnimal : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "summon";

        public string Help => "Como En El Minecraft";

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            


            int cantidad = int.Parse(command[1]);



            


            
           
            
          
            ThreadPool.QueueUserWorkItem(delegate (object item)
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;

               

                while (cantidad > 0)
                {
                    Thread.Sleep(1000);
                    Animal animal = AnimalManager.getAnimal(ushort.Parse(command[0]));
                    AnimalManager.spawnAnimal(animal.index, player.Player.look.aim.position, UnityEngine.Quaternion.AngleAxis(1f, player.Player.look.aim.position));
                    cantidad--;
                    
                }
            });
            
            

            
            
        }
    }
}
