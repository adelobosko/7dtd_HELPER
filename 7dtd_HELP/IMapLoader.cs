using System.Collections.Generic;

namespace _7dtd_HELP
{
    public interface IMapLoader
    {
        List<MapPoint> LoadMapPoints(string filename);
    }
}