using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication2.Models
{
    public class BlogPost
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Detta fält är obligatoriskt!")]
        [StringLength(50, ErrorMessage = "Brödtexten måste vara minst 6 och max 2000 tecken långt.", MinimumLength = 4)]
        [Display(Name = "Nytt lösenord")]
        public string HeaderText { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Detta fält är obligatoriskt!")]
        [StringLength(2000, ErrorMessage = "Brödtexten får endast vara max 2000 tecken långt.", MinimumLength = 4)]
        [Display(Name = "Nytt lösenord")]
        public string BodyText { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public int BlogPostID { get; set; }
        public string CategoryName { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
