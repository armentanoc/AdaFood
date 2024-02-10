namespace AdaFood.Application.Services
{
    public class ServiceHelper
    {
        public static string GetDigitsFromCpf(string cpf)
        {
            return new string(cpf.Where(char.IsDigit).ToArray());
        }
    }
}