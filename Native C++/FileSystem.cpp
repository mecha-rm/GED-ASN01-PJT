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
bool FileSystem::OpenForReading(const char* filePath)
{
    return OpenForReading(std::string(filePath));
    delete[] filePath;
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
    file.open(filePath, std::ios::in);

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
bool FileSystem::OpenForWriting(const char* filePath)
{
    return OpenForWriting(filePath, false);
}

// open for writing
bool FileSystem::OpenForWriting(const char* filePath, bool createFile)
{
    return OpenForWriting(std::string(filePath), createFile);
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
        file.open(filePath, std::ios::in);

        if (!file && !createFile) // if the file cannot be used, and a new file should not be created.
        {
            file.close();
            return false;

        }

        file.close();
    }

    // opens the file for writing.
    file.open(filePath, std::ios::out);

    // if the file is not open, then a 'false' is returned. 
    if (!file) // file failed to open
    {
        if (createFile) // writes line to file.
        {
            // writes to the file and closes it.
            file.write("X", 1);
            file.close();

            // re-opens the file and clears out all contents.
            file.open(filePath, std::ios::out);
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

// returns the file path
const char* FileSystem::GetFilePath() const
{
    return filePath.c_str();
}

// returns the file path as a string
std::string FileSystem::GetFilePathAsString() const
{
    return filePath;
}

// checks if the file is open.
bool FileSystem::FileOpen() const
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

// reads a line
char* FileSystem::ReadLine(int size, int seekg)
{
    // size is invalid
    if (size <= 0)
        return nullptr;

    // seek line
    if (seekg >= 0)
        file.seekg(seekg);

    char* data = new char[size];

    // reads file
    file.read(data, size);

    // saves the data
    std::string str = std::string(data);
    lines.push_back(str);

    delete[] data;
}

// writes a line
void FileSystem::WriteLine(char* line, int size, int seekp)
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
    lines.push_back(str);

    delete[] line;
}

// gets the line count
int FileSystem::GetLineCount() const
{
    return lines.size();
}

// adds a line to the array
void FileSystem::AddLine(char* arr, const int SIZE)
{
    std::string str = std::string(arr);
    str.resize(SIZE); // remove garbage characters
    lines.push_back(str);
    delete[] arr;
}

// adds a line at hte current index
void FileSystem::AddLine(char* arr, const int SIZE, int index)
{
    std::string str = std::string(arr);
    str.resize(SIZE); // remove garbage characters

    if (index < 0) // index is negative
    {
        lines.insert(lines.begin(), str);
    }
    else if (index >= lines.size()) // index is greater than or equal to the amount of lines.
    {
        lines.push_back(str);
    }
    else // insert at provided index
    {
        lines.insert(lines.begin() + index, str);
    }

    delete[] arr;
}

// removes a line
void FileSystem::RemoveLine(char* arr)
{
    std::string str = std::string(arr);
    
    // finds value and deletes it.
    for (int i = 0; i < lines.size(); i++)
    {
        if (lines[i] == str) // line found
        {
            lines.erase(lines.begin() + i); // removed 
            break; // breaks out of loop
        }
    }

    delete[] arr;
}

// removes line based on index
void FileSystem::RemoveLine(int index)
{
    // out of bounds
    if (index >= 0 && index < lines.size())
        lines.erase(lines.begin() + index);
}

// gets the line at the provided index
const char* FileSystem::GetLine(int index) const
{
    return (index >= 0 && index < lines.size()) ? lines[index].c_str() : "";
}

// returns line as string
std::string FileSystem::GetLineAsString(int index)
{
    return (index >= 0 && index < lines.size()) ? lines[index] : "";
}

// reads all lines
void FileSystem::ReadAllLines()
{
    // if the file isn't open, or there's something wrong with reading from it.
    if (!file.is_open() || !file || mode != 1)
        return;

    std::string line; // line variable

    lines.clear(); // clears out all existing lines
    file.seekg(std::ios::beg); // next character to be gotten

    while (std::getline(file, line)) // loops through all lines
    {
        lines.push_back(line); // gets the line
    }

    // returns back to start of file.
    file.seekg(std::ios::beg);
}

// writes all lines in a file. This clears all previous contents.
void FileSystem::WriteAllLines()
{
    // file isn't open, it's invalid, or it's not in write mode.
    if (!file.is_open() || !file || mode != 2)
        return;
    
    // clears out all file contents
    ClearFileContents();

    // writes all lines in file
    for (int i = 0; i < lines.size(); i++)
    {
        // std::string str = lines[i] + "\n"; // add new line character, which increases char count by 1.
        // 
        // file.write(str.c_str(), str.size());

        file << lines[i];

        // the final line shouldn't start a new line
        if(i + 1 < lines.size())
            file << "\n";
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
        file.open(filePath, std::ios::in | std::ios::trunc);
        break;
    case 2: // writing
        file.open(filePath, std::ios::out | std::ios::trunc);
        break;
    default:
        mode = 0; // mode wasn't set
    }
}

// clears out all lines
void FileSystem::ClearAllLines()
{
    lines.clear();
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
