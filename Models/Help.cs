
namespace CalculatorGUI.Models;
public static class Help
{
    public static bool IsOperand(this string test)
    {
        return test is "+" or "-" or "×" or "÷";
    }

    public static bool IsOperand(this char test)
    {
        return test is '+' or '-' or '×' or '÷';
    }
}