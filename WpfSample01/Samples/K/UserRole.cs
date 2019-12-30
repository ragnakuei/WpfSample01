using DevExpress.Mvvm.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace WpfSample01.Samples.K
{
    public enum UserRole {
        [Image("pack://application:,,,/Samples/K/Images/Admin.png"), Display(Name = "Admin", Description = "High level of access")]
        Administrator,
        [Image("pack://application:,,,/Samples/K/Images/Moderator.png"), Display(Name = "Moderator", Description = "Average level of access")]
        Moderator,
        [Image("pack://application:,,,/Samples/K/Images/User.png"), Display(Name = "User", Description = "Low level of access")]
        User
    }
}