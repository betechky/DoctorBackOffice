using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class IntakeForm
{
[Key]
public  int Id {set;  get;}
[Required]
[MaxLength(500, ErrorMessage = "Ailment connot be greater than 500 character")]
public string Ailment {set; get;}
[ForeignKey("DoctorId")]
public int  DoctorId {set; get;}
// public Doctor Doctor {set; get;}
[ForeignKey("PatientId")]
public int  PatientId {set; get;}
// public Patient Patient {set; get;}
}