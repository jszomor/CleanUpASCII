using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpASCII
{
	class Program
	{
		static void Main(string[] args)
		{
			string file = "file.fil";
			FileStream inputFile = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
			Encoding e = Encoding.GetEncoding(1250);
			char[] buffer = new char[1024];
			int szam;
			long p = 0;
			using (StreamReader inputFileStreamRead = new StreamReader(inputFile, e))
			{
				StreamWriter fileToWrite = new StreamWriter(inputFile, e);
				while((szam = inputFileStreamRead.Read(buffer, 0, 1024)) > 0)
				{
					for (int i = 0; i < szam; i++)
					{
						if (buffer[i] > 126)
						{
							buffer[i] = ' ';
						}
						else if (buffer[i] < 32)
						{
							buffer[i] = ' ';
						}
					}
					inputFile.Position = p;
					fileToWrite.WriteLine(buffer, 0, szam);
					p = inputFile.Position;
				}
				fileToWrite.Close();
			}
		}
	}
}
