using System.Timers;

namespace WinFormsApp1;
public partial class Form1 : Form
{
    // timer
    System.Timers.Timer timer;
    // timer count
    public int currentCount = 0;
    // delegate
    public delegate void SetControlValue(string value);

    Random rand = new Random();

    public Form1()
    {
        InitializeComponent();

        // do initial timer
        InitTimer();
    }
        
    /// <summary>
    /// initial timer
    /// </summary>
    private void InitTimer()
    {
        //设置定时间隔(毫秒为单位)
        int interval = 1000;
        timer = new System.Timers.Timer(interval);
        //设置执行一次（false）还是一直执行(true)
        timer.AutoReset = true;
        //设置是否执行System.Timers.Timer.Elapsed事件
        timer.Enabled = true;
        //绑定Elapsed事件
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
    }

    /// <summary>
    /// do stuff per second
    /// </summary>
    private void Timer_Tick(object sender, ElapsedEventArgs e)
    {
        currentCount += 1;
        this.Invoke(new SetControlValue(SetTextBoxText), currentCount.ToString());
    }

    /// <summary>
    /// delegate handler
    /// </summary>
    private void SetTextBoxText(string strValue)
    {
        // update timer text
        this.lb_Timer.Text = "Time: " + strValue;

        // refresh winform to update panel
        this.Refresh();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        // set color
        Pen pen = new Pen(Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
        // draw a line
        e.Graphics.DrawLine(pen, rand.Next(0, 200), rand.Next(0, 100), rand.Next(0, 200), rand.Next(0, 100));

        // set color
        pen = new Pen(Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
        // draw a circle
        e.Graphics.DrawEllipse(pen, rand.Next(0, 200), rand.Next(0, 100), rand.Next(0, 200), rand.Next(0, 100));

        // set color
        pen = new Pen(Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
        // draw a rect
        e.Graphics.DrawRectangle(pen, rand.Next(0, 200), rand.Next(0, 100), rand.Next(0, 200), rand.Next(0, 100));
    }
}
