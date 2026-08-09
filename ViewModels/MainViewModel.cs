using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media;
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
        foreach(Calculation entry in engine.History)
        {
            if(History.Contains(entry))
                continue;
            else
                History.Add(entry);
        }
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

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HistoryDimension))]
    [NotifyPropertyChangedFor(nameof(buttonContent))]
    [NotifyPropertyChangedFor(nameof(HistoryButtonBackground))]
    public partial bool historyOut {get; set;} = false;
    [RelayCommand]
    public void HistoryToggle() => historyOut=!historyOut;
    public int HistoryDimension => historyOut ? 5 : 1;
    public string buttonContent => historyOut ? "↺" : "🗏";
    public string HistoryButtonBackground => historyOut ? "Chocolate" : "Navy"; //Make theme compatible
}