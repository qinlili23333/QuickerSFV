
namespace QuickerSFV
{
    internal class Program
    {
        /// <summary>
        /// Action mode
        /// </summary>
        private enum Mode
        {
            Create,
            Verify
        }
        private enum Algorithm
        {
            CRC32,
            MD5
        }
        /// <summary>
        /// Whether to print verbose output or not
        /// </summary>
        private static bool _verbose = false;
        /// <summary>
        /// Current action mode
        /// </summary>
        private static Mode _mode = Mode.Create;
        /// <summary>
        /// Path to hash file
        /// </summary>
        private static string _hashFile = string.Empty;
        /// <summary>
        /// Path to calculate hash
        /// </summary>
        private static string _folder = string.Empty;

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            ParseArguments(args);
        }

        /// <summary>
        /// Parse command line arguments and put into variables
        /// </summary>
        /// <param name="args">command line arguments</param>
        private static void ParseArguments(string[] args)
        {
            if (args.Length == 0 || args[0] == "-h")
            {
                PrintHelp();
                Environment.Exit(0);
            }
            if (File.Exists(args[0]))
            {
                _mode = Mode.Verify;
                _hashFile = args[0];
                if (args.Length > 1 && !args[1].StartsWith('-'))
                {
                    if (Directory.Exists(args[1]))
                    {
                        _folder = args[1];
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Folder {args[1]} does not exist!");
                    }
                }
                else
                {
                    _folder = System.IO.Directory.GetCurrentDirectory();
                }
            }else if (Directory.Exists(args[0]))
            {
                _mode = Mode.Create;
                _folder = args[0];
                if (args.Length > 1 && !args[1].StartsWith('-'))
                {
                    _hashFile = args[1];
                }
                else
                {
                    _hashFile = Path.GetFileName(args[0]);
                }
            }
            else
            {
                Console.WriteLine($"ERROR: Provided path {args[0]} is neither file nor folder!");
                Environment.Exit(-1);
            }

        }

        /// <summary>
        /// Print help message to console
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("QuickerSFV by Qinlili v" + typeof(Program).Assembly.GetName().Version.ToString());
            Console.WriteLine("To check hash:      QuickerSFV sfv/md5_file <directory> <options>");
            Console.WriteLine("To generate hash:   QuickerSFV directory <sfv/md5_file> <options>");
            Console.WriteLine("Print this help:    QuickerSFV -h");
            Console.WriteLine("Options:");
            Console.WriteLine("  -v   Print verbose output");
            Console.WriteLine("  -md5 MD5 mode (default)");
            Console.WriteLine("  -sfv SFV mode (default only when extension of hash file is .sfv)");

        }
    }
}
