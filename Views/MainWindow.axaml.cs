using Avalonia.Controls;
using CalculatorGUI.ViewModels;

namespace CalculatorGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Result_TextInput(object? sender, Avalonia.Input.TextInputEventArgs e)
    {
        string text = e.Text!;

        if(text == "*")
            text = "×";
        else if (text == "/")
            text = "÷";
        
        ((MainViewModel)DataContext!).AddDigit(text);
    }
}