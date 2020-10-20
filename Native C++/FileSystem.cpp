// resource:
// http://www.cplusplus.com/doc/tutorial/files/

#include "FileSystem.h"
#include <iostream>

// constructor
FileSystem::FileSystem()
{
}

// destructor
FileSystem::~FileSystem()
{
    // closes file upon system termination if it's not closed already.
    file.close();

    // not open
    mode = 0;
}

// open for reading
bool FileSystem::OpenForReading(char* filePath)
{
    std::string str = std::string(filePath);
    delete[] filePath;
    return OpenForReading(str);
    
}

// opens a file for reading
bool FileSystem::OpenForReading(std::string filePath)
{
    // closes the file
    file.close();

    // if there is no period, there cannot be a file extension
    if (filePath.find(".") == std::string::npos)
        return false;

    // opens the file for reading
    file.open(filePath, std::ios::in | std::ios::binary);

    // if the file is not open, then a 'false' is returned. 
    if (!file)
        return false;

    // save file path
    this->filePath = filePath;

    // reading mode
    mode = 1;

    // returns 'true' since the file is now open.
    return true;
}

// opens a file for writing.
bool FileSystem::OpenForWriting(char* filePath)
{
    std::string str = std::string(filePath);
    delete[] filePath;
    return OpenForWriting(str, false);
}

// open for writing
bool FileSystem::OpenForWriting(char* filePath, bool createFile)
{
    std::string str = std::string(filePath);
    delete[] filePath;
    return OpenForWriting(str, createFile);
}

// opens a file for writing.
bool FileSystem::OpenForWriting(std::string filePath)
{
    return OpenForWriting(filePath, false);
}


// opens a file for writing.
bool FileSystem::OpenForWriting(std::string filePath, bool createFile)
{
    // closes the file
    file.close();

    // if there is no period, there cannot be a file extension
    if (filePath.find(".") == std::string::npos)
        return false;

    // checks if the file exists
    {
        // opens file for reading to see if it exists
        file.open(filePath, std::ios::in | std::ios::binary);

        if (!file && !createFile) // if the file cannot be used, and a new file should not be created.
        {
            file.close();
            return false;

        }

        file.close();
    }

    // opens the file for writing.
    file.open(filePath, std::ios::out | std::ios::binary);

    // if the file is not open, then a 'false' is returned. 
    if (!file) // file failed to open
    {
        if (createFile) // writes line to file.
        {
            // writes to the file and closes it.
            file.write("X", 1);
            file.close();

            // re-opens the file and clears out all contents.
            file.open(filePath, std::ios::out | std::ios::binary);
            ClearFileContents(); 
        }
        else
        {
            file.close();
            return false;
        }
    }

    // save file path
    this->filePath = filePath;

    // writing mode
    mode = 2;

    // returns 'true' since the file is now open.
    return true;
}

// makes a copy of a string and passes it as a char array
char* FileSystem::StringToCharArray(const std::string& str)
{
    // allocate space
    char* chs = new char[str.length()];

    // copies the memory
    memcpy(chs, str.c_str(), sizeof(char) * str.length());

    // return
    return chs;
}

// returns the file path
std::string FileSystem::GetFilePath() const
{
    return filePath;
}

// returns the file path
const char* FileSystem::GetFilePathAsCString() const
{
    return filePath.c_str();
}

// returns the file path as a string
std::string FileSystem::GetFilePathAsString() const
{
    return filePath;
}

// returns file path as a copy
char* FileSystem::GetFilePathAsCharArray() const
{
    return StringToCharArray(filePath);
}

// checks if the file is open.
bool FileSystem::IsFileOpen() const
{
    return file.is_open();
}

// returns 'true' if the file is open for reading.
bool FileSystem::IsReadable() const
{
    return (mode == 1);
}

// returns 'true' if the file is open for writing.
bool FileSystem::IsWritable() const
{
    return (mode == 2);
}

// gets the record size
int FileSystem::GetRecordSize() const
{
    return recordSize;
}

// sets the record size
void FileSystem::SetRecordSize(int size)
{
    recordSize = size;
}

// reads a line
char* FileSystem::ReadRecord(int size, int seekg)
{
    // size is invalid
    if (size <= 0)
        return nullptr;

    // seek line
    if (seekg >= 0)
        file.seekg(seekg, file.beg);

    char* data = new char[size];

    // reads file
    file.read(data, size);

    // saves the data
    std::string str = std::string(data);
    records.push_back(str);

    delete[] data;
}

// writes a line
void FileSystem::WriteRecord(char* line, int size, int seekp)
{
    // size is invalid
    if (size <= 0)
        return;

    // seek line
    if (seekp >= 0)
        file.seekp(seekp);

    file.write(line, size);
    file.write("\n", 1);

    // saves the data
    std::string str = std::string(line);
    records.push_back(str);

    delete[] line;
}

// gets the line count
int FileSystem::GetRecordCount() const
{
    return records.size();
}

// adds a line to the array
void FileSystem::InsertRecord(char* arr, const int SIZE)
{
    std::string str = std::string(arr);
    str.resize(SIZE); // remove garbage characters
    records.push_back(str);
    delete[] arr;
}

// adds a line at hte current index
void FileSystem::AddRecord(char* arr, const int SIZE, int index)
{
    std::string str = std::string(arr);
    str.resize(SIZE); // remove garbage characters

    if (index < 0) // index is negative
    {
        records.insert(records.begin(), str);
    }
    else if (index >= records.size()) // index is greater than or equal to the amount of lines.
    {
        records.push_back(str);
    }
    else // insert at provided index
    {
        records.insert(records.begin() + index, str);
    }

    delete[] arr;
}

// removes a line
void FileSystem::RemoveRecord(char* arr)
{
    std::string str = std::string(arr);
    
    // finds value and deletes it.
    for (int i = 0; i < records.size(); i++)
    {
        if (records[i] == str) // line found
        {
            records.erase(records.begin() + i); // removed 
            break; // breaks out of loop
        }
    }

    delete[] arr;
}

// removes line based on index
void FileSystem::RemoveRecord(int index)
{
    // out of bounds
    if (index >= 0 && index < records.size())
        records.erase(records.begin() + index);
}

// returns record as a string
std::string FileSystem::GetRecord(int index) const
{
    if (index >= 0 && index < records.size())
        return records[index];

    return "";
}

// gets the line at the provided index
const char* FileSystem::GetRecordAsCString(int index) const
{
    return (index >= 0 && index < records.size()) ? records[index].c_str() : "";
}

// returns line as string
std::string FileSystem::GetRecordAsString(int index) const
{
    return (index >= 0 && index < records.size()) ? records[index] : "";
}

// returns the records as a char array
char* FileSystem::GetRecordAsCharArray(int index) const
{
    if (index >= 0 && index < records.size())
        return FileSystem::StringToCharArray(records[index]);
    else
        return nullptr;
}

// reads all lines
void FileSystem::LoadAllRecords()
{
    // if the file isn't open, or there's something wrong with reading from it.
    if (!file.is_open() || !file || mode != 1 || recordSize <= 0)
        return;

    std::string line; // line variable

    records.clear(); // clears out all existing lines
    file.seekg(std::ios::beg); // next character to be gotten

    
    // gets all lines (old)
    // while (std::getline(file, line)) // loops through all lines
    // {
    //     lines.push_back(line); // gets the line
    // }

    // while you are not at the end of the file.
    while (!file.eof())
    {
        // variables
        char* arr = new char[recordSize];
        std::string str = "";

        // read data, and save it to string
        file.read(arr, recordSize);
        str = std::string(arr);

        str.resize(recordSize); // get rid of garbage data

        // int nullIndex = str.find(" ");
        // if (nullIndex != std::string::npos) // there are null termination characters to get rid of.
        //     str.resize(nullIndex); // removes all null characters 

        // save to list and delete data
        if(!str.empty())
            records.push_back(str);

        delete[] arr;
    }

    // returns back to start of file.
    file.seekg(std::ios::beg);
}

// writes all lines in a file. This clears all previous contents.
void FileSystem::SaveAllRecords()
{
    // file isn't open, it's invalid, or it's not in write mode.
    if (!file.is_open() || !file || mode != 2)
        return;

    // no lines available
    if (records.empty())
        return;
    
    // clears out all file contents
    ClearFileContents();

    // record size has not been set.
    if (recordSize <= 0)
    {
        // finds the largest record
        int largestRecord = 0;

        // gets the largest record size
        for (int i = 0; i < records.size(); i++)
            largestRecord = records[i].length();

        // sets as record size
        recordSize = largestRecord;
    }

    // writes all lines in file
    for (int i = 0; i < records.size(); i++)
    {
        // std::string str = lines[i] + "\n"; // add new line character, which increases char count by 1.
        // 
        // file.write(str.c_str(), str.size());

        // original
        // file << lines[i];
        // 
        // // the final line shouldn't start a new line
        // if(i + 1 < lines.size())
        //     file << "\n";

        // new - resize line so that each record is of the same size
        // lines.resize(recordSize); // fills with null characters ('\0') automatically, which isn't what we want.
        records[i].resize(recordSize, ' '); // fill with spaces

        // file << lines[i];
        file.write(records[i].c_str(), recordSize);
    }

}

// clears out all file contents
void FileSystem::ClearFileContents()
{
    if (filePath == "")
        return;

    file.close();

    // opens the file and clears out the data.
    switch (mode)
    {
    case 1: // reading
        file.open(filePath, std::ios::in | std::ios::binary | std::ios::trunc);
        break;
    case 2: // writing
        file.open(filePath, std::ios::out | std::ios::binary | std::ios::trunc);
        break;
    default:
        mode = 0; // mode wasn't set
    }
}

// clears out all lines
void FileSystem::ClearAllRecords()
{
    records.clear();
}

// closes the file.
void FileSystem::CloseFile()
{
    file.close();
    mode = 0;
}

// const char* FileSystem::GetLine(int i)
// {
//     std::string temp = "x";
// 
//     return temp.c_str();
// }
