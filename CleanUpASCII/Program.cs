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
      string fileCopy = "fileCopy.fil";
      //FileStream inputFile = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
			Encoding e = Encoding.GetEncoding(1250);
			char[] buffer = new char[1024];
      int szam;
      char[] bufferCopy = new char[1024];
      long p = 0;
			using (StreamReader inputFileStreamRead = new StreamReader(file, e))
			{
				StreamWriter fileToWrite = new StreamWriter(fileCopy, true, e);
				while((szam = inputFileStreamRead.Read(buffer, 0, 1024)) > 0)
				{
					for (int i = 0; i < szam; i++)
					{
						if (32 < buffer[i] && buffer[i] < 126)
						{
              bufferCopy[i] = buffer[i];
						}
					}
					fileToWrite.WriteLine(bufferCopy, 0, szam);
				}
				fileToWrite.Close();
			}
		}
	}
}
