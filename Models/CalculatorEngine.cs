using System.Data;

namespace CalculatorGUI.Models;
public class CalculatorEngine
{
    public string Input {get; private set;} = "";
    public void Calculate()
    {
        try
        {
            string expression = Input.Replace('×', '*').Replace('÷', '/');
            var result = new DataTable().Compute(expression, null);
            Input = result.ToString() ?? "0";
        }
        catch
        {
            Input = "Error";
        }
    }
    public void AddDigit(string content)
    {
        if(Input.Contains("Error") || Input.Contains("NaN"))
            ClearInput();
        if(string.IsNullOrEmpty(Input) && content is "+" or "×" or "÷")
            return;

        if(content.Equals("."))
        {
            if(string.IsNullOrEmpty(Input) || Input[^1].IsOperand())
                Input += "0";
        }

        if(content.Equals("-") && string.IsNullOrEmpty(Input))
        {
            Input += "-";
            return;
        }
        else if(content.IsOperand() && Input[^1].IsOperand())
            Input = Input[..^1];

        Input += content;
    }
    public void RemoveDigit()
    {
        if(Input.Contains("Error") || Input.Contains("NaN"))
            ClearInput();

        if(Input.Length > 0)
            Input = Input[..^1];
    }
    public void MakeNegative()
    {
        if(!string.IsNullOrEmpty(Input) && Input[^1] != '0')
            Input+="×(-1)";
    }
    public void ClearInput()
    {
        Input = "";
    }
}