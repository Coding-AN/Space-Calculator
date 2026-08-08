using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using Avalonia.Input;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static CalculatorGUI.Models.Help;

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
        if(string.IsNullOrEmpty(Input) &&  content.IsOperand())
            return;
        
        if(content.Equals("."))
        {
            if(string.IsNullOrEmpty(Input) || Input[^1].IsOperand())
                Input += "0";
        }

        if(content.IsOperand() && Input[^1].IsOperand())
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

    [ObservableProperty]
    public partial int HistoryDimension{get; set;} = 1;

    [ObservableProperty]
    public partial string buttonContent{get; set;} = "History";

    [ObservableProperty]
    //Make more Object Oriented and theme compatible
    public partial SolidColorBrush historyBackground {get; set;} = new SolidColorBrush(Colors.Navy);

    [ObservableProperty]
    public partial bool historyOut {get; set;} = false;

    [RelayCommand]
    public void HistoryToggle()
    {
        if(!historyOut)
        {
            HistoryDimension = 5;
            historyBackground.Color = Colors.Black;
            buttonContent = "Close";
            historyOut=!historyOut;
        }   
        else
        {
            HistoryDimension = 1;
            historyBackground.Color = Colors.Navy;
            buttonContent = "History";
            historyOut=!historyOut;
        }
    }
}