using EAD_Assignment04;

namespace MyCalculatorApp;

public partial class Form1 : Form
{

    private List<string> history = new();

    public Form1()
    {
        InitializeComponent();
        History.Items.Add("History");
    }

    private void DigitButton_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        inputTextBox.Text += button.Text;
    }

    private void OperatorButton_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        inputTextBox.Text += button.Text;
    }
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    private void RemoveLastCharacter(object sender, EventArgs e)
    {
        inputTextBox.Text = string.Empty;
    }
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        try
        {
            string equation = inputTextBox.Text;
            bool isCorrectFormat = MyStringSolver.IsInfixExpression(equation);
            if (isCorrectFormat)
            {
                object result = MyStringSolver.Evaluate(equation);

                // Add the result to the history
                string equationWithResult = $"{equation} = {result}";
                history.Add(equationWithResult);
                History.Items.Add(equationWithResult);
                History.Refresh();

                // Clear the input text box
                inputTextBox.Clear();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearButton_Click_1(object sender, EventArgs e)
    {
        if (inputTextBox.Text.Length > 0)
        {
            inputTextBox.Text = inputTextBox.Text.Substring(0, inputTextBox.Text.Length - 1);
        }
    }
}
