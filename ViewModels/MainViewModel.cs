using CalculatorGUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorGUI.ViewModels;

//Add A Theme Toggle, Calculation History Storage, and Unit Conversions
public partial class MainViewModel : ViewModelBase
{
    private readonly CalculatorEngine engine = new();
    [ObservableProperty]
    public partial string Input{get; set;} = "";

    [RelayCommand]
    public void Calculate()
    {
        engine.Calculate();
        Input = engine.Input;
    }
    [RelayCommand]
    public void AddDigit(string content)
    {
        engine.AddDigit(content);
        Input = engine.Input;
    }
    [RelayCommand]
    public void RemoveDigit()
    {
        engine.RemoveDigit();
        Input = engine.Input;
    }
    [RelayCommand]
    public void ClearInput()
    {
        engine.ClearInput();
        Input = engine.Input;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HistoryDimension))]
    [NotifyPropertyChangedFor(nameof(buttonContent))]
    [NotifyPropertyChangedFor(nameof(HistoryButtonBackground))]
    public partial bool historyOut {get; set;} = false;
    [RelayCommand]
    public void HistoryToggle() => historyOut=!historyOut;
    public int HistoryDimension => historyOut ? 5 : 1;
    public string buttonContent => historyOut ? "Close" : "History";
    public string HistoryButtonBackground => historyOut ? "Black" : "Navy"; //Make theme compatible
}