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
	bool OpenForReading(char* filePath);

	// open the file for reading. If the file is currently open, it is closed.
	// if no file exists, 'false' is returned.
	bool OpenForReading(std::string filePath);

	// open for writing. No file is generated if it doesn't exist.
	bool OpenForWriting(char* filePath);

	// open for writing. Open to create the file if it doesn't exist yet.
	bool OpenForWriting(char* filePath, bool createFile);

	// opens a file for writing.
	bool OpenForWriting(std::string filePath);

	// open the file for writing. If the file is currently open, it is closed.
	// if the file doesn't exist, or if the file cannot be opened, 'false' is returned.
	// if 'createFile' is set to 'true', an empty file is made at the provided location if it cannot be foun.
	bool OpenForWriting(std::string filePath, bool createFile);

	// makes a copy of a string and passes it as a char array.
	static char* StringToCharArray(const std::string& str);

	// returns the file path.
	std::string GetFilePath() const;

	// returns the file path
	const char* GetFilePathAsCString() const;

	// gets the file path as a string
	std::string GetFilePathAsString() const;

	// gets the file path. This actually allocates non-constant data to do so.
	char* GetFilePathAsCharArray() const;

	// returns 'true' if the file is currently open.
	bool IsFileOpen() const;

	// returns 'true' if the file is open and is readable.
	bool IsReadable() const;

	// returns 'ture' if the file is open and is writable.
	bool IsWritable() const;

	// returns the record size (in bytes)
	int GetRecordSize() const;

	// sets the record size (in bytes).
	// this is used to determine how large each record is.
	// if not set, the largest record will serve as the size.
	void SetRecordSize(int size);

	// Record, WriteLine, and ReadLine functions will likely be deleted.

	// gets a line from the 
	// char[] GetLine(int index);

	// returns the line count.
	int GetRecordCount() const;

	// adds a line to be written to the file.
	// if the line length exceeds that of the record size, it is truncated upon being written.
	// set record size to 0 or less to have the record size be set to that of the longest record.
	void InsertRecord(char* arr, const int SIZE);

	// adds a line at the current index. 
	// if the index is less than 0, then it's placed at the start of the list.
	// if the index is greater than the amount of items in the list, it is placed at the end of the list.
	void AddRecord(char* arr, const int SIZE, int index);

	// removes a line based on its string
	void RemoveRecord(char* arr);

	// removes a line based on its index
	void RemoveRecord(int index);

	// returns the file path as a string
	std::string GetRecord(int index) const;

	// returns the line
	const char* GetRecordAsCString(int index) const;

	// returns the line as a string. This cannot be used as a DLL, since this data type does not transfer over.
	std::string GetRecordAsString(int index) const;

	// returns the record as a char array
	char* GetRecordAsCharArray(int index) const;

	// reads in all lines, saving them to variables. These lines can then be read in.
	void LoadAllRecords();

	// writes all lines for the file system. This clears all previous contents.
	void SaveAllRecords();

	// clears out all file contents. This does not clear existing lines.
	void ClearFileContents();

	// clears out all line data
	void ClearAllRecords();

	// closes the file
	void CloseFile();

	// this may not work for DLLs, so try to see if there's a way to get around this.
	// gets a line from the file.
	// const char* GetLine(int i);


private:
	// reads a line received from the file directly.
	char* ReadRecord(int size, int seekg);

	// saves a line to be written to the file.
	// this does not actually write the line. Call WriteAllLines to write all lines to the files.
	void WriteRecord(char* line, int size, int seekp);

	// keeps track of mode the file is in (0 = none, 1 = reading, 2 = writing)
	int mode = 0;

	// record size
	int recordSize = 0;

	// file name
	std::string filePath = "";

	// file
	std::fstream file;

	// vector of lines for the file
	std::vector<std::string> records;

protected:
};

