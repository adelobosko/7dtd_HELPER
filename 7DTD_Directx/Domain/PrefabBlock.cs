using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("Blocks", Schema = "Prefab")]
    public class Block
    {
        [Key]
        public string Name { get; set; }

        protected Block()
        {

        }

        public Block(string name)
        {
            Name = name;
        }
    }
}
