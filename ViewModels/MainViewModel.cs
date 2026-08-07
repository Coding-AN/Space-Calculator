using System.Data;
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

    [RelayCommand]
    public void AddDigit(string content)
    {
        if(string.IsNullOrEmpty(content))
            return;
        if(content is "+" or "-" or "×" or "÷" && Input[^1] is '+' or '-' or '×' or '÷')
            Input = Input[..^1];

        Input += content;
    }

    [RelayCommand]
    public void RemoveDigit()
    {
        if(Input.Length >0)
            Input = Input[..^1];
    }

    [RelayCommand]
    public void ClearInput()
    {
        Input = "";
    }
}