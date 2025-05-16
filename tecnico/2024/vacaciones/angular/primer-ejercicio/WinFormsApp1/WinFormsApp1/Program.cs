namespace WinFormsApp1
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      int n1 = 5;
      int n2 = 5;

      int n3 = n1 + n2;

      MessageBox.Show(n3.ToString()); 
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      Application.Run(new Form1());
    }
  }
}
