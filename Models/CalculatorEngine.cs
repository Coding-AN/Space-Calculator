using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace CalculatorGUI.Models;
public class CalculatorEngine
{
    public string Input {get; private set;} = "";
    public void Calculate()
    {
        try
        {
            string pureExpression = Input;
            string expression = Input.Replace('×', '*').Replace('÷', '/');
            var result = new DataTable().Compute(expression, null);
            Input = result.ToString() ?? "0";
            History.Add(new Calculation(pureExpression, Math.Round(double.Parse(Input), 5, MidpointRounding.AwayFromZero)));
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
        if(string.IsNullOrEmpty(Input))
        {
            if(content is "+" or "×" or "÷")
                return;
            if(content.Equals("."))
                Input += 0;
            if(content.Equals("-"))
            {
                Input += "-";
                return;
            }
        }
        else
        {
            if(content.Equals("."))
            {
                if(Input[^1].IsOperand())
                    Input += "0";
            }
            if(content.IsOperand() && Input[^1].IsOperand())
                Input = Input[..^1];

            if(char.IsDigit(Input[^1]) && content.Equals("(") || !Input.Contains("(") && content.Equals(")")) //Fix range exception
                return;
        }

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
        if(Input.Contains("Error") || Input.Contains("NaN"))
            ClearInput();
        if(!string.IsNullOrEmpty(Input) && !Input[^1].IsOperand())
            Input += "×(-1)";
    }
    public void ClearInput()
    {
        Input = "";
    }

    public Collection<Calculation> History {get; private set;} = new();

    public void InsertLastAnswer()
    {
        string backup = Input;
        try
        {
                Input += History[History.Count - 1].Value;
        }
        catch
        {
            Input = backup;
        }
    }
    public void InsertAnswer(Calculation calc)
    {
        string backup = Input;
        try
        {
                Input += calc.Value;
        }
        catch
        {
            Input = backup;
        }
    }

    public void RemoveCalculation(Calculation calculation)
    {
        foreach(Calculation c in History)
        {
            if(c == calculation)
            {
                History.Remove(c);
                break;
            }
        }
    }
}

public class Calculation
{
    public string Expression {get;}
    public double Value {get;}

    public override string ToString()
    {
        return $"{Expression}={Value}";
    }

    public Calculation(string expression, double value)
    {
        Value = value;
        Expression = expression;
    }
}

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