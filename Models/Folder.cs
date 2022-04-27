using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Models
{
    public class Folder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required]
        public string FolderName { get; set; }

        public Guid Guid { get; set; } 

        public DateTime DateCreated { get; set; }

        public string FirstImage { get; set; }

    }
    
}
