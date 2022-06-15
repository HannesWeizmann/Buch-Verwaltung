using System.ComponentModel.DataAnnotations.Schema;

namespace BuchDatenbank
{
    [Table("akutelle_buecher")]
    public class BuchDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("buch_name")]
        public string? titel { get; set; }
        [Column("autor")]
        public string? autor { get; set; }

    }

    //[Table2("archivierte_buecher")]

}