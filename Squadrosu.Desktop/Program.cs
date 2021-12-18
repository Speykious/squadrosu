using osu.Framework.Platform;
using osu.Framework;
using Squadrosu.Game;

namespace Squadrosu.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"Squadrosu"))
            using (osu.Framework.Game game = new SquadrosuGame())
                host.Run(game);
        }
    }
}
