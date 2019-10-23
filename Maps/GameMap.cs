using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Tiles;
using GoRogue;

namespace GoldenLotus.Maps
{
    public class GameMap : TileMap
    {
        public enum MapType
        {
            CAVE,
            CITY,
            DUNGEON
        }

        public enum ConnectionType
        {
            UP,
            DOWN,
            OUT
        }

        static private ConnectionType opposite(ConnectionType typ)
        {
            switch (typ)
            {
                case ConnectionType.UP:
                    return ConnectionType.DOWN;
                case ConnectionType.DOWN:
                    return ConnectionType.UP;
                default:
                    return ConnectionType.OUT;
            }
        }

        public class MapConnection
        {
            public string ToMap { get; }
            public Coord ToCoord { get; }
            public MapConnection(string toMap, Coord toCoord)
            {
                ToMap = toMap;
                ToCoord = toCoord;
            }
        }

        public bool Lit { get; set; }
        public string ID { get; }
        public string DisplayName { get; set; }
        private Dictionary<Coord, MapConnection> connections;
        private GameMap(int width, int height, bool lit, string id, string displayName) : base(width, height, 4, Distance.CHEBYSHEV) 
        {
            Lit = lit;
            ID = id;
            DisplayName = displayName;
        }

        public void Connect(string toMapID, Coord fromCoord, Coord toCoord, bool twoWay, ConnectionType connectionType)
        {
            //TODO: Add glyphs
            MapConnection conn = new MapConnection(toMapID, toCoord);
            connections.Add(fromCoord, conn);
            if (twoWay)
            {
                GameMap toMap = GameManager.Instance.GetMap(toMapID);
                toMap.Connect(ID, toCoord, fromCoord, false, opposite(connectionType));
            }
        }

        public MapConnection GetConnection(Coord c)
        {
            MapConnection conn = null;
            if (connections.TryGetValue(c, out conn))
                return conn;
            else
                return null;
        }
    }
}
