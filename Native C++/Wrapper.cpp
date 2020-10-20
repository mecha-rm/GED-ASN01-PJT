#include "Wrapper.h"

FileSystem fs;

// open file for reading
bool PLUGIN_API OpenForReading(char* filePath)
{
    return fs.OpenForReading(filePath);
}

// open file for writing
// bool PLUGIN_API OpenForWriting(char* filePath)
// {
//     return fs.OpenForWriting(filePath);
// }

// open for writing
bool PLUGIN_API OpenForWriting(char* filePath, bool createFile)
{
    return fs.OpenForWriting(filePath, createFile);
}

// get file path
std::string PLUGIN_API GetFilePath()
{
    // return fs.GetFilePathAsCString();
    return fs.GetFilePath();
}

// file is open
bool PLUGIN_API IsFileOpen()
{
    return fs.IsFileOpen();
}

// file is readable
bool PLUGIN_API IsReadable()
{
    return fs.IsReadable();
}

// file is writable
bool PLUGIN_API IsWritable()
{
    return fs.IsWritable();
}

// get record size
int PLUGIN_API GetRecordSize()
{
    return fs.GetRecordSize();
}

// set record size
void PLUGIN_API SetRecordSize(int size)
{
    fs.SetRecordSize(size);
}

// get record count
int PLUGIN_API GetRecordCount()
{
    return fs.GetRecordCount();
}

// adds a record
void PLUGIN_API AddRecord(char* arr, int SIZE)
{
    fs.InsertRecord(arr, SIZE);
}

// adds a record
void PLUGIN_API InsertRecord(char* arr, int SIZE, int index)
{
    return fs.AddRecord(arr, SIZE, index);
}

// remove record
// void PLUGIN_API RemoveRecord(char* arr)
// {
//     return fs.RemoveRecord(arr);
// }

// remove record
void PLUGIN_API RemoveRecord(int index)
{
    return fs.RemoveRecord(index);
}

// get record
std::string PLUGIN_API GetRecord(int index)
{
    // return fs.GetFilePathAsCString();
    return fs.GetFilePath();
}

// load all records
void PLUGIN_API LoadAllRecords()
{
    fs.LoadAllRecords();
}

// save all records
void PLUGIN_API SaveAllRecords()
{
    fs.SaveAllRecords();
}

// clear file contents
void PLUGIN_API ClearFileContents()
{
    return fs.ClearFileContents();
}

// clear all records
void PLUGIN_API ClearAllRecords()
{
    return fs.ClearAllRecords();
}

// close file
void PLUGIN_API CloseFile()
{
    return fs.CloseFile();
}
