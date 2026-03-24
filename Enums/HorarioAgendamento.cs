namespace ConnectaMVC.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum HorarioAgendamento
    {
        [Display(Name = "09:00")]
        Horario_09_00h = 1,

        [Display(Name = "10:00")]
        Horario_10_00 = 2,

        [Display(Name = "11:00")]
        Horario_11_00 = 3,

        [Display(Name = "13:00")]
        Horario_13_00 = 4,

        [Display(Name = "14:00")]
        Horario_14_00 = 5,

        [Display(Name = "15:00")]
        Horario_15_00 = 6,

        [Display(Name = "16:00")]
        Horario_16_00 = 7,

        [Display(Name = "17:00")]
        Horario_17_00 = 8,

        [Display(Name = "18:00")]
        Horario_18_00 = 9,

        [Display(Name = "19:00")]
        Horario_19_00 = 10
    }
}
