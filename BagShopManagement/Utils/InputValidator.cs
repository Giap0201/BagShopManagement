// Utils/Validator.cs
namespace BagShopManagement.Utils
{
    public static class InputValidator
    {
        public static bool IsValidQuantity(int qty) => qty > 0;
        public static bool IsNotEmpty(string? s) => !string.IsNullOrWhiteSpace(s);
    }
}
