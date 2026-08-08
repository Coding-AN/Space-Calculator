using System.Linq;
using Avalonia.Controls;
using CalculatorGUI.Models;
using CalculatorGUI.ViewModels;

namespace CalculatorGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Result_LostFocus(object? sender, Avalonia.Input.FocusChangedEventArgs e)
    {
        Result.Focus();
    }
    private void Result_AttachedToVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
    {
        Result.Focus();
    }

    private void Result_TextChanged(object? sender, TextChangedEventArgs e)
    {
        TextBox caretHolder = (TextBox)sender!;
        caretHolder.CaretIndex = caretHolder.Text!.Length;
    }
}