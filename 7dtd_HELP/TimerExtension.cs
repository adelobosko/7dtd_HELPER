namespace _7dtd_HELP
{
    public static class TimerExtension
    {

        public static void Restart(this System.Windows.Forms.Timer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }
}