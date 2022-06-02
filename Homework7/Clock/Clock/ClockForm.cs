namespace Clock;

using System.Windows.Forms;
using System.Runtime.InteropServices;

/// <summary>
/// Class for clock
/// </summary>
public partial class ClockForm : Form
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool ReleaseCapture();

    public ClockForm()
    {
        InitializeComponent();
        this.BackColor = Color.AliceBlue;
        this.TransparencyKey = this.BackColor;
        timer.Tick += new EventHandler(TimerTick);
    }

    private int centerFormX = 175;
    private int centerFormY = 175;

    private int secondHandLength = 100;
    private int minuteHandLength = 90;
    private int hourHandLength = 75;

    private Timer timer = new();

    private void OnClockMouseDown(object sender, MouseEventArgs e)
    {
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        ReleaseCapture();
        PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
    }

    private void OnButtonCloseClick(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ClockForm_Load(object sender, EventArgs e)
    {
        timer.Interval = 1000;
        timer.Start();
    }

    private int[] MinuteOrSecondHandCoordination(int val, int length)
    {
        var coordination = new int[2];
        val *= 6;
        coordination[0] = centerFormX + (int)(length * Math.Sin(Math.PI * val / 180));
        coordination[1] = centerFormY - (int)(length * Math.Cos(Math.PI * val / 180));
        return coordination;
    }

    private int[] HourHandCoordination(int hval, int mval, int length)
    {
        var coordination = new int[2];
        int val = (int)((hval * 30) + (mval * 0.5));
        coordination[0] = centerFormX + (int)(length * Math.Sin(Math.PI * val / 180));
        coordination[1] = centerFormY - (int)(length * Math.Cos(Math.PI * val / 180));
        return coordination;
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        int second = DateTime.Now.Second;
        int minute = DateTime.Now.Minute;
        int hour = DateTime.Now.Hour;

        var handCoordination = new int[2];
        Graphics graphics = pictureBox.CreateGraphics();

        // Erasing previous hands
        handCoordination = MinuteOrSecondHandCoordination(second - 1, secondHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 50f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));
        handCoordination = MinuteOrSecondHandCoordination(minute - 1, minuteHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 50f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));
        handCoordination = HourHandCoordination(hour % 12, minute, hourHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 50f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));

        // Draw new hands
        handCoordination = HourHandCoordination(hour % 12, minute, hourHandLength);
        graphics.DrawLine(new Pen(Color.Gray, 4f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));
        handCoordination = MinuteOrSecondHandCoordination(minute, minuteHandLength);
        graphics.DrawLine(new Pen(Color.Black, 3f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));
        handCoordination = MinuteOrSecondHandCoordination(second, secondHandLength);
        graphics.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(centerFormX, centerFormY), new Point(handCoordination[0], handCoordination[1]));
    }
}