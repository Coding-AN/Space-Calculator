using System.Collections.ObjectModel;
using System.Linq;
using CalculatorGUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorGUI.ViewModels;
public partial class MainViewModel : ViewModelBase
{
    private readonly CalculatorEngine engine = new();
    public ObservableCollection<Calculation> History {get; set;}= new ObservableCollection<Calculation>();

    [ObservableProperty]
    public partial string Input{get; set;} = "";

    [RelayCommand]
    public void Calculate()
    {
        engine.Calculate();
        Input = engine.Input;
        SyncHistory();
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
    [RelayCommand]
    public void MakeNegative()
    {
        engine.MakeNegative();
        Input = engine.Input;
    }

    void SyncHistory()
    {
        foreach(Calculation entry in engine.History)
        {
            if(History.Contains(entry))
                continue;
            else
                History.Add(entry);
        }
        Calculation[] temp = History.ToArray();
        foreach(Calculation entry in temp)
        {
            if(!engine.History.Contains(entry))
                History.Remove(entry);
        }
    }

    [RelayCommand]
    public void InsertLastAnswer()
    {
        engine.InsertLastAnswer();
        Input = engine.Input;
    }

    [RelayCommand]
    public void InsertAnswer(Calculation calc)
    {
        engine.InsertAnswer(calc);
        Input = engine.Input;
    }
    [RelayCommand]
    public void RemoveCalculation(Calculation calculation)
    {
        engine.RemoveCalculation(calculation);
        SyncHistory();
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HistoryDimension), nameof(buttonContent), nameof(HistoryButtonBackground))]
    public partial bool historyOut {get; set;} = false;
    [RelayCommand]
    public void HistoryToggle() => historyOut=!historyOut;
    public int HistoryDimension => historyOut ? 5 : 1;
    public string buttonContent => historyOut ? "↺" : "🗏";
    public string HistoryButtonBackground => historyOut ? "Chocolate" : "Navy";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AdvancedZ), nameof(AdvancedZDown), nameof(advancedContent))]
    public partial bool AdvancedOut {get; set;} = false;
    [RelayCommand]
    public void SwapAdvanced() => AdvancedOut=!AdvancedOut;
    public int AdvancedZ => AdvancedOut ? 1 : 0;
    public int AdvancedZDown => AdvancedOut ? 0 : 1;

    public string advancedContent => AdvancedOut ? "⇑" : "⇓";
}