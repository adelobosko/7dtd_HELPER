using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("AvailablePrefabBlocks", Schema = "Prefab")]
    public class AvailablePrefabBlock
    {
        public Guid AvailablePrefabBlockID { get; private set; }
        public Block Block { get; private set; }
        public int Count { get; private set; }

        public PrefabInfo PrefabInfo { get; private set; }


        protected AvailablePrefabBlock()
        {

        }


        public AvailablePrefabBlock(PrefabInfo prefabInfo, Block block, int count)
        {
            AvailablePrefabBlockID = Guid.NewGuid();
            PrefabInfo = prefabInfo;
            Block = block;
            Count = count;
        }
    }
}
