// 매개 변수를 입력하지 않으면 현재 디렉토리 조회
// 매개 변수 입력하면, 입력한 디렉터리 조회
// 출력
// 디렉터리: 이름, 속성 
// 파일:이름, 크기, 속성
namespace Dir
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Practice2(args);
            Practice1(args);
        }

        static void Practice1(string[] args)
        {
            string directory;
            if (args.Length < 1)
                directory = ".";
            else
                directory = args[0];

            Console.WriteLine($"{directory} directory Info");
            Console.WriteLine("- Directories :");
            var directories = new DirectoryInfo(directory).GetDirectories();

            foreach (var d in directories)
                Console.WriteLine($"{d.Name} : {d.Attributes}");

            Console.WriteLine("- Files :");
            var files = from fi in new DirectoryInfo(directory).GetFiles()
                        select new { fi.Name, FileSize = fi.Length, fi.Attributes };
            foreach (var f in files)
                Console.WriteLine(
                    $"{f.Name} : {f.FileSize}, {f.Attributes}");
        }

        static void Practice2(string[] args)
        {
            
            if (args.Length < 2)
                return;

            string type;
            string path;

            type = args[0];
            path = args[1];

            if (type == "File")
            {
                if (File.Exists(path))
                {
                    var fi = new FileInfo(path);
                    fi.LastWriteTime = DateTime.Now;
                }
                else
                {
                    File.Create(path);
                }

            }
            else if (type == "Directory")
            {
                if (Directory.Exists(path))
                {
                    var fi = new DirectoryInfo(path);
                    fi.LastWriteTime = DateTime.Now;
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

    }
}