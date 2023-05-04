using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitytest.Models.Entities;
 
public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_book")]

    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string? Isbn { get; set; }
}