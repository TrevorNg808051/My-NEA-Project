using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_NEA_Project
{
    internal class World
    {
        private List<Entity> listOfLoadedEntities;
        private Map WorldMap;
        private int seed;

        public Material SquareFinder(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Entity thingToAdd,Form form)
        {
            listOfLoadedEntities.Add(thingToAdd);
        }

        public void WorldUpdate()
        {

        }
    }
}
