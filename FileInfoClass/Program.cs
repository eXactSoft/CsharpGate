using System;
using System.IO;
using System.Text;

namespace FileInfoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Reading and writing bytes from and a file using FileStream 
            //without using a StreamReader or StreamWriter to perform these functions.
            //Create object of FileInfo for specified path            
            FileInfo fi = new FileInfo(@"D:\DummyFile.txt");

            //Open file for Read\Write
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            //create byte array of same size as FileStream length
            byte[] fileBytes = new byte[fs.Length];

            //define counter to check how much bytes to read. Decrease the counter as you read each byte
            int numBytesToRead = (int)fileBytes.Length;

            //Counter to indicate number of bytes already read
            int numBytesRead = 0;

            //iterate till all the bytes read from FileStream
            while (numBytesToRead > 0)
            {
                int n = fs.Read(fileBytes, numBytesRead, numBytesToRead);

                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            //Once you read all the bytes from FileStream, you can convert it into string using UTF8 encoding
            string filestring = Encoding.UTF8.GetString(fileBytes);

            Console.WriteLine(filestring);
        }
    }
}
/*
 * The FileInfo class provides the same functionality as the static File class but you have 
 * more control on read/write operations on files by writing code manually for reading or 
 * writing bytes from a file.
 * 
 * Unlike the File class, the FileInfo class is not static and does not have static methods. 
 * This class is useful only when instantiated. A FileInfo object represents a file on 
 * a disk or a network location, and you can create one by supplying a path to a file:
        FileInfo aFile = new FileInfo(@"C:\Log.txt");
 * 
 * Important Properties of FileInfo:
        Property	    Usage

        Directory	    Gets an instance of the parent directory.
                        Retrieves a DirectoryInfo object representing the directory 
                        containing the current file. This property is read-only.

        DirectoryName   Gets a string representing the directory's full path.
                        Returns the path to the file’s directory. This property is read-only.

        Exists	        Gets a value indicating whether a file exists.

        Extension	    Gets the string representing the extension part of the file.

        FullName	    Gets the full path of the directory or file.

        IsReadOnly	    Gets or sets a value that determines if the current file is read only.
                        Shortcut to the read-only attribute of the file. This property is 
                        also accessible via Attributes.

        LastAccessTime	Gets or sets the time the current file or directory was last accessed

        LastWriteTime	Gets or sets the time when the current file or directory was last 
                        written to.

        Length	        Gets the size, in bytes, of the current file.
                        Gets the size of the file in bytes, returned as a long value. 
                        This property is read-only.

        Name	        Gets the name of the file.

 * Important Methods of FileInfo:
        Method	            Usage

        AppendText	        Creates a StreamWriter that appends text to the file represented 
                            by this instance of the FileInfo.

        CopyTo	            Copies an existing file to a new file, disallowing the 
                            overwriting of an existing file.

        Create	            Creates a file.

        CreateText	        Creates a StreamWriter that writes a new text file.

        Decrypt	            Decrypts a file that was encrypted by the current account using 
                            the Encrypt method.

        Delete	            Deletes the specified file.

        Encrypt	            Encrypts a file so that only the account used to encrypt the file 
                            can decrypt it.

        GetAccessControl    Gets a FileSecurity object that encapsulates the access control list 
                            (ACL) entries for a specified file.

        MoveTo	            Moves a specified file to a new location, providing the option to 
                            specify a new file name.

        Open	            Opens a in the specified FileMode.

        OpenRead	        Creates a read-only FileStream.

        OpenText	        Creates a StreamReader with UTF8 encoding that reads from an existing
                            text file.

        OpenWrite	        Creates a write-only FileStream.

        Replace	            Replaces the contents of a specified file with the file described by 
                            the current FileInfo object, deleting the original file, 
                            and creating a backup of the replaced file.

        ToString	        Returns a path as string.
 * 
 * Many of the methods exposed by the FileInfo class are similar to those of the File class, 
 * but because File is a static class, it requires a string parameter that specifies the file
 * location for every method call. Therefore, the following calls do the same thing:
        FileInfo aFile = new FileInfo("Data.txt");
        if (aFile.Exists)
        WriteLine("File Exists");
 * same as 
        if (File.Exists("Data.txt"))
        WriteLine("File Exists");
 * In this code, a check is made to see whether the file Data.txt exists. Note that 
 * no directory information is specified here, which means that the current 
 * working directory is the only location examined.
 * This directory is the one containing the application that calls this code.
 * 
 * Most of the FileInfo methods mirror the File methods in this manner. In most cases 
 * it doesn’t matter which technique you use, although the following criteria can 
 * help you to decide which is more appropriate:
    ➤➤ It makes sense to use methods on the static File class if you are making only 
        a single method call—the single call will be faster because the .NET Framework 
        won’t have to go through the process of instantiating a new object and then 
        calling the method.
    ➤➤ If your application is performing several operations on a file, then it makes more 
        sense to instantiate a FileInfo object and use its methods—this saves time because 
        the object will already be referencing the correct file on the file system, 
        whereas the static class has to find it every time.
 * 
 * The FileInfo & DirectoryInfo classes inherit most of their properties from FileSystemInfo:
 * FileSystemInfo Properties
        PROPERTY            DESCRIPTION
        Attributes          Gets or sets the attributes of the current file or directory, 
                            using the FileAttributes enumeration.

        CreationTime,       Gets or sets the creation date and time of the current file, 
        CreationTimeUtc     available in coordinated universal time (UTC) and non-UTC versions.
        
        Extension           Retrieves the extension of the file. This property is read-only.

        Exists              Determines whether a file exists. This is a read-only abstract 
                            property, and is overridden in FileInfo and DirectoryInfo.
        
        FullName            Retrieves the full path of the file. This property is read-only.

        LastAccessTime,     Gets or sets the date and time that the current file was last 
        LastAccessTimeUtc   accessed, available in UTC and non-UTC versions.
        
        LastWriteTime,      Gets or sets the date and time that the current file was last 
        LastWriteTimeUtc    written to, available in UTC and non-UTC versions.
        
        Name                Retrieves the full path of the file. This is a read-only abstract
                            property, and is overridden in FileInfo and DirectoryInfo.
 * 
 * The DirectoryInfo class works exactly like the FileInfo class. It is an instantiated object 
 * that represents a single directory on a machine. Like the FileInfo class, many of the 
 * method calls are duplicated across Directory and DirectoryInfo. 
 * The guidelines for choosing whether to use the methods of File or FileInfo also 
 * apply to DirectoryInfo methods:
        ➤➤ If you are making a single call, use the static Directory class.
        ➤➤ If you are making a series of calls, use an instantiated DirectoryInfo object.
 * 
 * Properties Unique to the DirectoryInfo Class not at FileSystemInfo class
        PROPERTY DESCRIPTION
        Parent  Retrieves a DirectoryInfo object representing the directory containing 
                the current directory. This property is read-only.
        Root    Retrieves a DirectoryInfo object representing the root directory of 
                the current volume. for example, the C:\ directory. This property is read-only.
 * 
 * Relative path names are relative to a starting location. By using relative path names, 
 * no drive or known location needs to be specified. You saw this earlier, where 
 * the current working directory was the starting point, which is the default behavior 
 * for relative path names. For example, if your application is running in 
 * the C:\Development\FileDemo directory and uses the relative path LogFile .txt, 
 * the file references would be C:\Development\FileDemo\LogFile.txt. 
 * To move “up” a directory, the .. string is used. 
 * Thus, in the same application, the path ..\Log.txt points to the file C:\Development\Log.txt.
 * As shown earlier, the working directory is initially set to the directory in which your 
 * application is running. When you are developing with Visual Studio, this means the application 
 * is several directories beneath the project folder you created. It is usually located 
 * in ProjectName\bin\Debug. To access a file in the root folder of the project, 
 * then, you have to move up two directories with ..\..\.
 * 
 * You can determine the working directory by using Directory .GetCurrentDirectory(), 
 * or you can set it to a new path by using Directory .SetCurrentDirectory().
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
