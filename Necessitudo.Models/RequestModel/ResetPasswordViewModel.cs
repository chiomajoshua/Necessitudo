namespace Necessitudo.Models.RequestModel
{
    public class ResetPasswordViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}