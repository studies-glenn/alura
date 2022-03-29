using System.Text;

partial class Program
{

	static void FileStreamAndUsing()
	{
		using (var fs = new FileStream(Root, FileMode.Open))
		{
			var buffer = new byte[1024];
			var readBytes = -1;
			while (readBytes != 0)
			{
				readBytes = fs.Read(buffer, 0, 1024);
				WriteBuffer(buffer);
			}
		}
	}

	static void FileStreamReading()
	{
		var fileStream = new FileStream(Root, FileMode.Open);
		var buffer = new byte[1024];
		var readBytes = -1;

		while (readBytes != 0)
		{
			readBytes = fileStream.Read(buffer, 0, 1024);
			WriteBuffer(buffer);
		}
		fileStream.Close();
	}

	static void WriteBuffer(byte[] buffer)
	{
		var utf = Encoding.Default;
		System.Console.WriteLine(utf.GetString(buffer));

		// Reding buffer, but it will show only integers because it's not converted to text.
		// foreach (var item in buffer)
		// {
		//     System.Console.WriteLine(item);
		//     System.Console.WriteLine(" ");
		// }
	}

}