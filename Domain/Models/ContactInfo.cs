using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class ContactInfo
{
    [Display(Name = "Contact Id")]
    [ScaffoldColumn(false)]
    public Guid Id { get; set; }

    [Display(Name = "Ad")]
    [RegularExpression(@"\w+$", ErrorMessage = "Ad alanına sadece harf girişi yapınız.")]
    [Required]
    public string FirstName { get; set; }

    [Display(Name = "Soyad")]
    [RegularExpression(@"\w+$", ErrorMessage = "Soyad alanına sadece harf girişi yapınız.")]
    [Required]
    public string LastName { get; set; }

    [Display(Name = "Sicil")]
    [RegularExpression(@"\w+$", ErrorMessage = "Sicil alnına sadece sayı girişi yapınız.")]
    [Required]
    public int EmployeeRegistrationNumber { get; set; }

    [Display(Name = "Ünite")]
    [Required]
    public string Department { get; set; }

    [Display(Name = "Fabrika/Bina")]
    [Required]
    public string Location { get; set; }

    [Display(Name = "Pozisyon")]
    [Required]
    public string Position { get; set; }

    [Display(Name = "İş Telefonu")]
    [RegularExpression(@"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$", ErrorMessage = "İş Telefonu uygun formatta değil.")]
    [Required]
    public string WorkPhoneNumber { get; set; }

    [Display(Name = "Diğer İş Telefonu")]
    [RegularExpression(@"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$", ErrorMessage = "Diğer İş Telefonu uygun formatta değil.")]
    [Required]
    public string OtherWorkPhoneNumber { get; set; }

    [Display(Name = "Kurumsal Telefonu")]
    [RegularExpression(@"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$", ErrorMessage = "Kurımsal İş Telefonu uygun formatta değil.")]
    [Required]
    public string CorporatePhoneNumber { get; set; }

    [Display(Name = "Telsiz Numarası")]
    [RegularExpression(@"\d+$", ErrorMessage = "Telsiz Numarası alanına sadece sayı girişi yapınız.")]
    [Required]
    public string WalkieTalkieNumber { get; set; }

    [Display(Name = "Email")]
    [Required]
    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email adresi uygun formatta değil.")]
    public string Email { get; set; }

    [Display(Name = "Statu")]
    [Required]
    public bool IsDeleted { get; set; }

    public DateTime InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
