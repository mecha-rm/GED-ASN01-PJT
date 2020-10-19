#pragma once

#include "PluginSettings.h"
#include <fstream>
#include <string>
#include <vector>

// TODO: the idea behind this system is that lines are passed in, and that when the user is finished they all get put into the file at once.
// as such, some functions own't be used.

// file system class
// this clears out the entire file and rewrites it entirely if set to write.
class PLUGIN_API FileSystem
{
public:
	// constructor
	FileSystem();

	// destructor
	~FileSystem();
	
	// open for reading
	bool OpenForReading(const char* filePath);

	// open the file for reading. If the file is currently open, it is closed.
	// if no file exists, 'false' is returned.
	bool OpenForReading(std::string filePath);

	// open for writing. No file is generated if it doesn't exist.
	bool OpenForWriting(const char* filePath);

	// open for writing. Open to create the file if it doesn't exist yet.
	bool OpenForWriting(const char* filePath, bool createFile);

	// opens a file for writing.
	bool OpenForWriting(std::string filePath);

	// open the file for writing. If the file is currently open, it is closed.
	// if the file doesn't exist, or if the file cannot be opened, 'false' is returned.
	// if 'createFile' is set to 'true', an empty file is made at the provided location if it cannot be foun.
	bool OpenForWriting(std::string filePath, bool createFile);

	// returns the file path
	const char* GetFilePath() const;

	// gets the file path as a string
	std::string GetFilePathAsString() const;

	// returns 'true' if the file is currently open.
	bool FileOpen() const;

	// returns 'true' if the file is open and is readable.
	bool IsReadable() const;

	// returns 'ture' if the file is open and is writable.
	bool IsWritable() const;

	// Record, WriteLine, and ReadLine functions will likely be deleted.

	// gets a line from the 
	// char[] GetLine(int index);

	// returns the line count.
	int GetLineCount() const;

	// adds a line to be written to the file.
	// this deletes the ch
	void AddLine(char* arr, const int SIZE);

	// adds a line at the current index. 
	// if the index is less than 0, then it's placed at the start of the list.
	// if the index is greater than the amount of items in the list, it is placed at the end of the list.
	void AddLine(char* arr, const int SIZE, int index);

	// removes a line based on its string
	void RemoveLine(char* arr);

	// removes a line based on its index
	void RemoveLine(int index);

	// returns the line
	const char* GetLine(int index) const;

	// returns the line as a string. This cannot be used as a DLL, since this data type does not transfer over.
	std::string GetLineAsString(int index);

	// reads in all lines, saving them to variables. These lines can then be read in.
	void ReadAllLines();

	// writes all lines for the file system. This clears all previous contents.
	void WriteAllLines();

	// clears out all file contents. This does not clear existing lines.
	void ClearFileContents();

	// clears out all line data
	void ClearAllLines();

	// closes the file
	void CloseFile();

	// this may not work for DLLs, so try to see if there's a way to get around this.
	// gets a line from the file.
	// const char* GetLine(int i);


private:
	// reads a line received from the file directly.
	char* ReadLine(int size, int seekg);

	// saves a line to be written to the file.
	// this does not actually write the line. Call WriteAllLines to write all lines to the files.
	void WriteLine(char* line, int size, int seekp);

	// keeps track of mode the file is in (0 = none, 1 = reading, 2 = writing)
	int mode = 0;

	// record size
	int recordSize = 1024;

	// file name
	std::string filePath = "";

	// file
	std::fstream file;

	// vector of lines for the file
	std::vector<std::string> lines;

protected:
};

