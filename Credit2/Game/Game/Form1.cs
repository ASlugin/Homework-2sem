namespace Game;

public partial class Form1 : Form
{
    private int amountOfButtom;
    private Controller controller;

    public Form1(int amountOfButtom)
    {
        if (amountOfButtom % 2 != 0 || amountOfButtom < 0)
        {
            throw new ArgumentException("Invalid size");
        }

        this.amountOfButtom = amountOfButtom;
        controller = new Controller(amountOfButtom);
        InitializeComponent();
        InitializeButtons();
        var sizeOfForm = new Size((controller.sizeOfButton + 5) * amountOfButtom, controller.sizeOfButton * amountOfButtom + 40);
        this.Size = sizeOfForm;
        this.MinimumSize = sizeOfForm;
        this.MaximumSize = sizeOfForm;
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < amountOfButtom; ++i)
        {
            for (int j = 0; j < amountOfButtom; ++j)
            {
                Controls.Add(controller.buttonArray[i, j]);
                controller.buttonArray[i, j].MouseClick += new MouseEventHandler(ClickOnMouse!);
            }
        }
    }

    private void ClickOnMouse(object sender, MouseEventArgs e)
    {
        int i = PointToClient(Cursor.Position).X / controller.sizeOfButton;
        int j = PointToClient(Cursor.Position).Y / controller.sizeOfButton;

        controller.Click(i, j);
        if (controller.CheckWhetherPlayerWins())
        {
            MessageBox.Show("You won!");
        }
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }
}