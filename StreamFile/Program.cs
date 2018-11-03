using System;
using System.IO;
using System.Linq;

namespace FileClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            // Append all text lines to a file
            string dummyLines = "This is first line." + Environment.NewLine +
                    "This is second line." + Environment.NewLine +
                    "This is third line.";

            //Opens DummyFile.txt and append lines. If file is not exists then create and open.
            File.AppendAllLines(@"d:\DummyFile.txt", dummyLines.Split(Environment.NewLine.ToCharArray()).ToList<string>());
            Console.WriteLine("Opens DummyFile.txt and append lines. If file is not exists then create and open.");

            Console.WriteLine("_2-------------------------------------------------------------");
            //Append string to a file
            //Opens DummyFile.txt and append Text. If file is not exists then create and open.
            File.AppendAllText(@"d:\DummyFile.txt", "This is File testing");
            Console.WriteLine("Opens DummyFile.txt and append Text. If file is not exists then create and open.");

            Console.WriteLine("_3-------------------------------------------------------------");
            //Check whether file is exists or not at particular location
            bool isFileExists = File.Exists(@"d:\DummyFile.txt");
            Console.WriteLine("Whether DummyFile.txt is exists or not at d: " + isFileExists);

            Console.WriteLine("_4-------------------------------------------------------------");
            //Copy DummyFile.txt as new file DummyFileNew.txt
            File.Copy(@"d:\DummyFile.txt", @"D:\NewDummyFile.txt");
            Console.WriteLine("Copy DummyFile.txt as new file DummyFileNew.txt c/o");

            Console.WriteLine("_5-------------------------------------------------------------");
            //Get when the file was accessed last time 
            DateTime lastAccessTime = File.GetLastAccessTime(@"d:\DummyFile.txt");
            Console.WriteLine("DummyFile.txt was accessed last time at: " + lastAccessTime);

            Console.WriteLine("_6-------------------------------------------------------------");
            //get when the file was written last time
            DateTime lastWriteTime = File.GetLastWriteTime(@"d:\DummyFile.txt");
            Console.WriteLine("DummyFile.txt was written last time at: " + lastWriteTime);

            //Console.WriteLine("_7-------------------------------------------------------------");
            // Move file to new location
            //File.Move(@"d:\DummyFile.txt", @"D:\DummyFile.txt");

            //Open file and returns FileStream for reading bytes from the file
            //FileStream fs = File.Open(@"D:\DummyFile.txt", FileMode.OpenOrCreate);

            //Open file and return StreamReader for reading string from the file
            //StreamReader sr = File.OpenText(@"D:\DummyFile.txt");

            Console.ReadLine();

            Console.WriteLine("_8-------------------------------------------------------------");
            //Delete file
            File.Delete(@"d:\DummyFile.txt");
            File.Delete(@"d:\NewDummyFile.txt");
            Console.WriteLine("The files DummyFile.txt & NewDummyFile.txt deleted");

            //The same way, use static Directory class to work with physical directories.
        }
    }
}
/*
 * Reading and writing files is an essential way to get data into your C# program (input) 
 * and send data out of your program (output). Because files are used for input and output, 
 * the file classes are contained in the System.IO namespace. 
 * (IO is a common abbreviation for Input/Output.) 
 * System.IO contains the classes for reading and writing data to and from files
 * 
 * File System Access Classes
        CLASS               DESCRIPTION

        File                A static utility class that exposes many static methods for moving,
                            copying, and deleting files.
                            File is a static class that provides different functionalities like 
                            copy, create, move, delete, open for reading or /writing, encrypt 
                            or decrypt, check if a file exists, append lines or text to 
                            a file’s content, get last access time, etc.

        FileInfo            Represents a physical file on disk, and has methods to manipulate
                            this file. For any reading from and writing to the file, 
                            a Stream object must be created.
                            The FileInfo class provides the same functionality as a static 
                            File class. You have more control on how you do read/write 
                            operations on a file by writing code manually for reading 
                            or writing bytes from a file.

        Directory           A static utility class that exposes many static methods for moving,
                            copying, and deleting directories.

        DirectoryInfo       Represents a physical directory on disk and has methods to manipulate
                            this directory.
                            DirectoryInfo provides instance methods for creating, moving, 
                            deleting and accessing subdirectories.

        Path                A utility class used to manipulate path names.
                            Path is a static class that provides functionality such as retrieving 
                            the extension of a file, changing the extension of a file, retrieving 
                            the absolute physical path, and other path related functionalities.

        FileSystemInfo      Serves as the base class for both FileInfo and DirectoryInfo,
                            making it possible to deal with files and directories 
                            at the same time using polymorphism.

        FileSystemWatcher   The most advanced class you examine in this chapter. It is used to
                            monitor files and directories, and it exposes events that your 
                            application can catch when changes occur in these locations.
 * 
 * System.IO.Compression namespace, which enables you to read from and write to compressed 
 * files (.ZIP extension). In particular, you will look at the following two stream classes:
 *      ➤➤ DeflateStream—Represents a stream in which data is compressed automatically 
 *        when writing, or uncompressed automatically when reading. Compression is achieved 
 *        using the Deflate algorithm.
 *      ➤➤ GZipStream—Represents a stream in which data is compressed automatically when
 *        writing, or uncompressed automatically when reading. Compression is achieved using 
 *        the GZIP (GNU Zip) algorithm.
 * 
 * Important Methods of Static File Class
        Method	            Usage
        AppendAllLines	    Appends lines to a file, and then closes the file. If the specified 
                            file does not exist, this method creates a file, writes the specified 
                            lines to the file, and then closes the file.

        AppendAllText	    Opens a file, appends the specified string to the file, and then closes 
                            the file. If the file does not exist, this method creates a file, writes 
                            the specified string to the file, then closes the file.

        AppendText	        Creates a StreamWriter that appends UTF-8 encoded text to an existing 
                            file, or to a new file if the specified file does not exist.

        Copy	            Copies an existing file to a new file. Overwriting a file of the 
                            same name is not allowed.

        Create	            Creates or overwrites a file in the specified path.

        CreateText	        Creates or opens a file for writing UTF-8 encoded text.

        Decrypt	            Decrypts a file that was encrypted by the current account using the 
                            Encrypt method.

        Delete	            Deletes the specified file.

        Encrypt	            Encrypts a file so that only the account used to encrypt the file can 
                            decrypt it.

        Exists	            Determines whether the specified file exists.

        GetAccessControl	Gets a FileSecurity object that encapsulates the access control 
                            list (ACL) entries for a specified file.

        Move	            Moves a specified file to a new location, providing the option to 
                            specify a new file name.

        Open	            Opens a FileStream on the specified path with read/write access.

        ReadAllBytes	    Opens a binary file, reads the contents of the file into a byte array, 
                            and then closes the file.

        ReadAllLines	    Opens a text file, reads all lines of the file, and then closes the file.

        ReadAllText	        Opens a text file, reads all lines of the file, and then closes the file.

        Replace	            Replaces the contents of a specified file with the contents of another 
                            file, deleting the original file, and creating a backup of the replaced 
                            file.

        WriteAllBytes       Creates a new file, writes the specified byte array to the file, 
                            and then closes the file. If the target file already exists, 
                            it is overwritten.

        WriteAllLines	    Creates a new file, writes a collection of strings to the file, and 
                            then closes the file.

        WriteAllText	    Creates a new file, writes the specified string to the file, and then 
                            closes the file. If the target file already exists, it is overwritten.
 * 
 * Static Methods of the Directory Class
        METHOD                  DESCRIPTION

        CreateDirectory()       Creates a directory with the specified path.

        Delete()                Deletes the specified directory and all the files within it.

        GetDirectories()        Returns an array of string objects that represent the names
                                of the directories below the specified directory.

        EnumerateDirectories()  Like GetDirectories(), but returns an IEnumerable<string> 
                                collection of directory names.

        GetFiles()              Returns an array of string objects that represent the names
                                of the files in the specified directory.

        EnumerateFiles()        Like GetFiles(), but returns an IEnumerable<string> collection
                                of filenames.

        GetFileSystemEntries()  Returns an array of string objects that represent the names
                                of the files and directories in the specified directory.

        EnumerateFileSystemEntries() Like GetFileSystemEntries(), but returns an 
                                     IEnumerable<string> Collection of file and directory names.

        Move()                       Moves the specified directory to a new location. You can 
                                     specify A new name for the folder in the new location.
 * 
 * The Directory Class three EnumerateXxx() methods provide better performance than their 
 * GetXxx() counterparts when a large amount of files or directories exist.
 * 
 * Points to Remember :
 *  File is a static class to read\write from physical file with less coding.
 *  Static File class provides functionalities such as create, read\write, copy, move, delete and others for physical files.
 *  Static Directory class provides functionalities such as create, copy, move, delete etc for physical directories with less coding.
 *  FileInfo and DirectoryInfo class provides same functionality as static File and Directory class.
 * 
 * You can use the FileSystemWatcher class to monitor changes to file system data. 
 * You can monitor both files and directories, and provide a filter,
 * if required, to modify only those files that have a specific file extension.
 * FileSystemWatcher instances notify you of changes by raising events that you 
 * can handle in your code.
 * 
 * 
 * 
 * 
 * 
 * 
 */
