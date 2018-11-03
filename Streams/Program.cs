using System;
using System.IO;
using System.Text;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            /*you have to write lot of code for reading/writing a string from a FileSream in the FileInfo class project. 
             *The same read/write operation can be done easily using StreamReader and StreamWriter.
             */
            //Create FileInfo object for DummyFile.txt
            FileInfo fi = new FileInfo(@"D:\DummyFile.txt");

            //open DummyFile.txt for read operation
            FileStream fsToRead = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            //or without FileInfo oject
            //FileStream fsToRead = new FileStream(@"D:\DummyFile.txt", FileMode.OpenOrCreate);
            
            //get the StreamReader
            StreamReader sr = new StreamReader(fsToRead);

            //read all texts using StreamReader object
            string fileContent = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(fileContent);

            //open DummyFile.txt for write operation
            FileStream fsToWrite = new FileStream(@"D:\DummyFile.txt", FileMode.OpenOrCreate);

            //get the StreamWriter
            StreamWriter sw = new StreamWriter(fsToWrite);

            //write some text using StreamWriter
            sw.WriteLine("Another line from streamwriter");
            sw.Close();

            //close all Stream objects
            fsToRead.Close();
            fsToWrite.Close();

            Console.WriteLine("_2-------------------------------------------------------------");
            /*If you need the capability to change the file pointer to any arbitrary position,
             * you cannot use StreamWriter or StreamReader classes, 
             * but random access file technique
             */
            byte[] byteDataWrite;
            char[] charDataWrite;
            try
            {
                FileStream aFile = new FileStream("Temp.txt", FileMode.Create);
                string dummyLines = "This is first line." + Environment.NewLine +
                    "This is second line." + Environment.NewLine +
                    "This is third line.";
                charDataWrite = dummyLines.ToCharArray(); 

                byteDataWrite = new byte[charDataWrite.Length];
                Encoder e = Encoding.UTF8.GetEncoder();

                /*
                 * This time, an Encoder object is created based on the UTF-8 encoding. 
                 * You used Unicode for the decoding as well, and this time you need to 
                 * encode the character data into the correct byte format before you can 
                 * write to the stream. The GetBytes() method is where the magic happens. 
                 * It converts the character array to the byte array. It accepts a character 
                 * array as the first parameter (charData in this example), and the index to 
                 * start in that array as the second parameter (0 for the start of the array). 
                 * The third parameter is the number of characters to convert 
                 * (charData.Length—the number of elements in the charData array). 
                 * The fourth parameter is the byte array to place the data into (byteData), 
                 * and the fifth parameter is the index to start writing from in the byte array 
                 * (0 for the start of the byteData array). The sixth, and final, parameter 
                 * determines whether the Encoder object should flush its state after completion.
                 * This reflects the fact that the Encoder object retains an in-memory record of 
                 * where it was in the byte array. This aids in subsequent calls to the Encoder object 
                 * but is meaningless when only a single call is made. The final call to the 
                 * Encoder must set this parameter to true to clear its memory and free the object 
                 * for garbage collection.
                 */
                e.GetBytes(charDataWrite, 0, charDataWrite.Length, byteDataWrite, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);

                //Like the Read() method, the Write() method has three parameters: a byte array containing 
                //the data to write to the file stream, the index in the array to start writing from, and 
                //the number of bytes to write.
                aFile.Write(byteDataWrite, 0, byteDataWrite.Length);

                aFile.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                return;
            }

            byte[] byteDataRead = new byte[200];
            char[] charDataRead = new char[200];
            try
            {
                FileStream aFile = new FileStream("Temp.txt", FileMode.Open);

                //moves the file pointer to byte number 174 in the file. This is the 3rd line 
                //of the Temp.txt file;
                aFile.Seek(21, SeekOrigin.Begin);

                /*
                 * Read() the primary means to access data from a file that a FileStream object points 
                 * to. This method reads the data from a file and then writes this data into a 
                 * byte array. There are three parameters, the first being a byte array passed 
                 * in to accept data from the FileStream object. The second parameter is the 
                 * position in the byte array to begin writing data to—this is normally zero, 
                 * to begin writing data from the file at the beginning of the array. The last
                 * parameter specifies how many bytes to read from the file.
                 */
                aFile.Read(byteDataRead, 0, 200);//eads the next 200 bytes into the byte array byteDataRead.
                aFile.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                return;
            }

            /*
             * Once you have the byte array from the file, you need to convert it into a 
             * character array so that you can display it to the Console. 
             * To do this, use the Decoder class from the System.Text namespace. This
             * class is designed to convert raw bytes into more useful items, such 
             * as characters.
             * These following line create a Decoder object based on the UTF-8 encoding 
             * schema, which is the Unicode encoding schema.
             */
            Decoder d = Encoding.UTF8.GetDecoder();

            //GetChars() method is called, which takes an array of bytes and converts it 
            //to an array of characters.
            d.GetChars(byteDataRead, 0, byteDataRead.Length, charDataRead, 0);

            //The character array is written to the Console.
            Console.WriteLine(charDataRead);
        }
    }
}
/* 
 * A stream is an abstract representation of a serial device that you can read from or write 
 * to a byte at a time. Files are an example of such a device. There are two types of 
 * streams—input and output—for reading from and writing to devices, respectively.
 * 
 * All input and output in the .NET Framework involves the use of streams. A stream is an 
 * abstract representation of a serial device. A serial device is something that stores 
 * and/or accesses data in a linear manner, that is, one byte at a time, sequentially. 
 * This device can be a disk file, a network channel, a memory location, or any other object 
 * that supports linear reading, writing, or both. By keeping the device abstract, the 
 * underlying destination/source of the stream can be hidden. This level of abstraction 
 * enables code reuse, and enables you to write more generic routines because you don’t have 
 * to worry about the specifics of how data transfer actually occurs. Therefore, similar 
 * code can be transferred and reused when the application is reading from a file input 
 * stream, a network input stream, or any other kind of stream. Because you can ignore 
 * the physical mechanics of each device, you don’t need to worry about, for example, 
 * hard disk heads or memory allocation when dealing with a file stream.
 * 
 * 
 * C# includes following standard IO (Input/Output) classes to read/write from different 
 * sources like a file, memory, network, isolated storage, etc.
 * 
 * Stream: System.IO.Stream is an abstract class that provides standard methods to transfer 
 * bytes (read, write, etc.) to the source. It is like a wrapper class to transfer bytes. 
 * Classes that need to read/write bytes from a particular source must implement the Stream 
 * class.
 * 
 *******************************************************************************************
 * The following classes inherits Stream class to provide functionality to Read/Write bytes 
 * from a particular source:
 * FileStream: reads or writes bytes from/to a physical file whether 
 * it is a .txt, .exe, .jpg or any other file. FileStream is derived from the Stream class.
 * Represents a file that can be written to, read from, or both. This file can be
 * written to and read from asynchronously or synchronously.

 * MemoryStream: MemoryStream reads or writes bytes that are stored in memory.
 * 
 * BufferedStream: BufferedStream reads or writes bytes from other Streams to 
 * improve the performance of certain I/O operations.
 * 
 * NetworkStream: NetworkStream reads or writes bytes from a network socket.
 * 
 * PipeStream: PipeStream reads or writes bytes from different processes.
 * 
 * CryptoStream: CryptoStream is for linking data streams to cryptographic transformations.
 * 
 *******************************************************************************************
 * Stream Readers and Writers:
 * StreamReader: StreamReader is a helper class for reading characters from a Stream by 
 * converting bytes into characters using an encoded value. It can be used to read strings 
 * (characters) from different Streams like FileStream, MemoryStream, etc.
 * Reads character data from a stream and can be created by using a FileStream as a base.
 * 
 * StreamWriter: StreamWriter is a helper class for writing a string to a Stream by 
 * converting characters into bytes. It can be used to write strings to different Streams 
 * such as FileStream, MemoryStream, etc.
 * Writes character data to a stream and can be created by using a FileStream as a base.
 * 
 * BinaryReader: BinaryReader is a helper class for reading primitive datatype from bytes.
 * 
 * BinaryWriter: BinaryWriter writes primitive types in binary.
 ******************************************************************************************* 
 * Stream is an abstract class for transfering bytes from different sources. 
 * It is base class for all other class that reads\writes bytes to different sources.
 * 
 * FileStream class provides reading and writing functionality of bytes to physical file.
 * 
 * Reader & writer classes provides functionality to read bytes from Stream classes 
 * (FileStream, MemoryStream etc) and converts bytes into appropriate encoding.
 * 
 * StreamReader provides a helper method to read string from FileStream by converting 
 * bytes into strings. StreamWriter provides a helper method to write string to 
 * FileStream by converting strings into bytes.
 * 
 * FileStream reads bytes from a physical file and then StreamReader reads strings by 
 * converting those bytes to strings. In the same way, StreamWriter takes a string and 
 * converts it into bytes and writes to FileStream and then FileStream writes the bytes 
 * to a physical file. So FileStream deals with bytes where as StreamReader & StreamWriter 
 * deals with strings.
 * 
 * The FileStream object represents a stream pointing to a file on a disk or a network path. 
 * Although the class does expose methods for reading and writing bytes from and to the files,
 * most often you will use a StreamReader or StreamWriter to perform these functions. 
 * That’s because the FileStream class operates on bytes and byte arrays, whereas the Stream 
 * classes operate on character data. Character data is easier to work with, 
 * but certain operations, such as random file access (access to data at some point in the 
 * middle of a file), can be performed only by a FileStream object.
 * You’ll learn more about this later in the chapter.
 * 
 * There are several ways to create a FileStream object. The constructor has many different 
 * overloads, but the simplest takes just two arguments: the filename and a FileMode 
 * enumeration value:
 *      FileStream aFile = new FileStream(filename, FileMode.<Member>);
 * The FileMode enumeration has several members that specify how the file is opened or 
 * created. You’ll see the possibilities shortly. Another commonly used constructor is 
 * as follows:
 *      FileStream aFile = new FileStream(filename, FileMode.<Member>, FileAccess.<Member>);
 * The third parameter is a member of the FileAccess enumeration and is a way of specifying 
 * the purpose of the stream.
 * 
 * FileAccess Enumeration Members
        MEMBER      DESCRIPTION
        Read        Opens the file for reading only
        Write       Opens the file for writing only
        ReadWrite   Opens the file for reading or writing
 *
 * FileMode Enumeration Members
        MEMBER      FILE EXISTS BEHAVIOR                                NO FILE EXISTS BEHAVIOR
        Append      The file is opened, with the stream positioned at   A new file is created. Can
                    the end of the file. Can be used only               be used only in conjunction
                    in conjunction with FileAccess.Write.               with FileAccess.Write.
                    
        Create      The file is destroyed, and a new file is            A new file is created.
                    created in its place.
                    
        CreateNew   An exception is thrown.                             A new file is created.

        Open        The file is opened, with the stream                 An exception is thrown.
                    positioned at the beginning of the file.
        
        OpenOrCreate The file is opened, with the stream                A new file is created.
                     positioned at the beginning of the file.
        
        Truncate    The file is opened and erased. The stream           An exception is thrown. 
                    is positioned at the beginning of the file.
                    The original file creation date is retained.
 * 
 * The FileStream constructor that doesn’t use a FileAccess enumeration parameter, 
 * the default value is used, which is FileAccess.ReadWrite.
 * 
 * Both the File and FileInfo classes expose OpenRead() and OpenWrite() methods that make it
 * easier to create FileStream objects. The first opens the file for read-only access, and the 
 * second allows write-only access. These methods provide shortcuts, so you do not have to 
 * provide all the information required in the form of parameters to the FileStream constructor. 
 * For example, the following line of code opens the Data.txt file for read-only access:
 *      FileStream aFile = File.OpenRead("Data.txt");
 * The following code performs the same function:
 *      FileInfo aFileInfo = new FileInfo("Data.txt");
 *      FileStream aFile = aFileInfo.OpenRead();
 * 
 * Random Access Files: The FileStream class maintains an internal file pointer that points 
 * to the location within the file where the next read or write operation will occur. 
 * In most cases, when a file is opened, it points to the beginning of the file, but this 
 * pointer can be modified. This enables an application to read or write anywhere within the 
 * file, which in turn enables random access to a file and the capability to jump directly 
 * to a specific location in the file. This can save a lot of time when dealing with very
 * large files because you can instantly move to the location you want.
 * The method that implements this functionality is the Seek() method, which takes two parameters. 
 * The first parameter specifies how far to move the file pointer, in bytes. 
 * The second parameter specifies where to start counting from, in the form of a value from 
 * the SeekOrigin enumeration. 
 * The SeekOrigin enumeration contains three values: Begin, Current, and End.
 * For example, the following line would move the file pointer to the eighth byte in the file, 
 * starting from the very first byte in the file:
 *      aFile.Seek(8, SeekOrigin.Begin);
 * The following line would move the file pointer two bytes forward, starting from the 
 * current position. If this were executed directly after the previous line, then the file 
 * pointer would now point to the tenth byte in the file:
 *      aFile.Seek(2, SeekOrigin.Current);
 * When you read from or write to a file, the file pointer changes as well. After you have 
 * read 10 bytes, the file pointer will point to the byte after the tenth byte read.
 * You can also specify negative seek positions, which could be combined with the SeekOrigin.
 * End enumeration value to seek near the end of the file. The following seeks to the fifth 
 * byte from the end of the file:
 *      aFile.Seek(-5, SeekOrigin.End);
 * Files accessed in this manner are sometimes referred to as random access files because 
 * an application can access any position within the file. The StreamReader and StreamWriter 
 * classes described later access files sequentially and do not allow you to manipulate the 
 * file pointer in this way.
 * 
 * You can use Write() and format parameters to write comma-separated files:
        [StreamWriter object].Write($"{100},{"A nice product"},{10.50}");
 * 
 * 
 */
