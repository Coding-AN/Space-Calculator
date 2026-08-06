using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorGUI.ViewModels;

//Add A Theme Toggle, Calculation History Storage, Unit Conversions, and Keyboard Support
public partial class MainViewModel : ViewModelBase
{
   [ObservableProperty]
   public partial string Input {get; set;} = "";

    [RelayCommand]
    public void Calculate()
    {
        //Fix weird errors like 14/2 = 0.5
        try
        {
            int operand = Input.IndexOfAny(new char[]{'+', '-', '×', '÷', '*', '/'});
            float num1 = float.Parse(Input.Substring(0,Input.Length - operand - 1));
            float num2 = float.Parse(Input.Substring(operand + 1));
            switch(Input[operand])
            {
                case '+' :
                    Input = (num1 + num2).ToString();
                    break;
                case '-':
                    Input = (num1 - num2).ToString();
                    break;
                case '×':
                case '*':
                    Input = (num1 * num2).ToString();
                    break;
                case '÷':
                case '/':
                    Input = (num1 / num2).ToString();
                    break;
            }
        }
        catch{}
    }

    [RelayCommand]
    public void AddDigit(string content)
    {
        //Make it work 100% of the time
        if(content.IndexOfAny(new char[]{'+', '-', '×', '÷'}) != -1 && Input.IndexOfAny(new char[]{'+', '-', '×', '÷', '*', '/'}) != -1)
        {
            Calculate();
        }
        Input += content;
    }

    [RelayCommand]
    public void RemoveDigit()
    {
        if(Input.Length >0)
        {
            Input = Input!.Substring(0,Input.Length-1);
        }
    }

    [RelayCommand]
    public void ClearInput()
    {
        Input = "";
    }
}