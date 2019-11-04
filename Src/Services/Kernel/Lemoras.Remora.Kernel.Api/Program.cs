namespace Lemoras.Remora.Kernel.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Remora.Api.Program.Run<KernelStartup>(args);
        }
    }
}
