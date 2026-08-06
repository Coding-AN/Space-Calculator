using CommunityToolkit.Mvvm.ComponentModel;
using CalculatorGUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorGUI.ViewModels;

//Add A Theme Toggle, Calculation History Storage, Unit Conversions, and Keyboard Support
public partial class MainViewModel : ViewModelBase
{
   
}

public partial class CalcViewModel :ViewModelBase
{
    private double firstValue = 0;
    private double secondValue = 0;
    private bool OperationSelected = false;
    private enum Operations
    {
        add,
        subtract,
        multiply,
        divide
    }

    [RelayCommand]
    public void AddDigit()
    {
        
    }
}