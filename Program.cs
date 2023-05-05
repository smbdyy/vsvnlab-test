class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("2 command line arguments required");
            return;
        }

        var inputFilename = args[0];
        var outputFilename = args[1];

        if (!File.Exists(inputFilename))
        {
            Console.WriteLine($"file '{inputFilename}' is not found");
            return;
        }

        if (File.Exists(outputFilename))
        {
            Console.WriteLine($"file '{outputFilename}' already exists");
            return;
        }

        using var inputFileStream = new FileStream(inputFilename, FileMode.Open, FileAccess.Read);

        if (inputFileStream.Length == 0)
        {
            Console.WriteLine($"File '{inputFilename}' is empty.");
            return;
        }

        using var outputFileStream = new FileStream(outputFilename, FileMode.Create, FileAccess.Write);
        byte[] bytes = new byte[inputFileStream.Length];
        inputFileStream.Read(bytes, 0, bytes.Length);

        byte[] reversedBytes = new byte[bytes.Length];
        for (int i = 0; i < bytes.Length; i++)
        {
            reversedBytes[i] = bytes[bytes.Length - i - 1];
        }

        outputFileStream.Write(reversedBytes, 0, reversedBytes.Length);
    }
}