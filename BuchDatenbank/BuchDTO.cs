using System.ComponentModel.DataAnnotations.Schema;

namespace BuchDatenbank
{
    //DTO für Tabelle aktuelle Bücher
    [Table("aktuelle_buecher")]
    public class BuchDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("buch_name")]
        public string? titel { get; set; }

        [Column("autor")]
        public string? autor { get; set; }

    }
    
    //DTO für Tabelle archivierte Bücher
    [Table("archivierte_buecher")]
    public class Buch2DTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("buch_name")]
        public string? titel { get; set; }

        [Column("autor")]
        public string? autor { get; set; }
    }
    
}