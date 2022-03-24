

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreatingFile obj = new CreatingFile("Folder", 100);
            obj.createDirectory();
            obj.generateFiles();
            obj.report("Report", "ReportFile");
            obj.delete();
        }
    }
}