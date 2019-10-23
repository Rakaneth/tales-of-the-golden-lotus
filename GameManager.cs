using System;
using System.Collections.Generic;
using System.Text;
using GoldenLotus.Maps;
using Troschuetz.Random;
using Troschuetz.Random.Generators;
using SadConsole.Actions;


namespace GoldenLotus
{
    public sealed class GameManager
    {
        private static GameManager instance;
        private static readonly object padlock = new object();
        private Dictionary<string, GameMap> maps = new Dictionary<string, GameMap>();
        public ActionStack EventBus = new ActionStack();
        private string curMapID;
        public GameMap CurMap => GetMap(curMapID);
        public IGenerator RNG { get; }

        public static GameManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new GameManager();
                    return instance;
                }
            }
        }

        private GameManager()
        {
            RNG = new XorShift128Generator();
        }

        private GameManager(int seed)
        {
            RNG = new XorShift128Generator(seed);
        }

        public void AddMap(params GameMap[] mapsToAdd)
        {
            foreach (GameMap m in mapsToAdd)
                maps.Add(m.ID, m);
        }

        public GameMap GetMap(string mapID) => maps[mapID];

        public void SetMap(string mapID) 
        {
            curMapID = mapID;
        }
        
    }
}
