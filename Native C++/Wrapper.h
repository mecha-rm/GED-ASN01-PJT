#pragma once

#include "FileSystem.h"

#ifdef __cplusplus
extern "C" // convert to C code.
{
#endif
	// open file for reading
	bool PLUGIN_API OpenForReading(char* filePath);

	// open file for writing
	// bool PLUGIN_API OpenForWriting(char* filePath);

	// open file for writing
	bool PLUGIN_API OpenForWriting(char* filePath, bool createFile);

	// gets the file path
	std::string PLUGIN_API GetFilePath();

	// is the file open
	bool PLUGIN_API IsFileOpen();

	// the file is readable
	bool PLUGIN_API IsReadable();

	// the file is writable
	bool PLUGIN_API IsWritable();

	// gets record size
	int PLUGIN_API GetRecordSize();

	// sets record size
	void PLUGIN_API SetRecordSize(int size);

	// returns the amount of records
	int PLUGIN_API GetRecordCount();

	// adds a record (SIZE is const in object function)
	void PLUGIN_API AddRecord(char* arr, int SIZE);

	// adds a record (SIZE is const in object function)
	void PLUGIN_API InsertRecord(char* arr, int SIZE, int index);

	// removes a record based on the provided data
	// void PLUGIN_API RemoveRecord(char* arr);

	// removes a record at the provided index
	void PLUGIN_API RemoveRecord(int index);

	// returns record at provided index
	std::string PLUGIN_API GetRecord(int index);

	// reads in all lines, saving them to variables. These lines can then be read in.
	void PLUGIN_API LoadAllRecords();

	// writes all lines for the file system. This clears all previous contents.
	void PLUGIN_API SaveAllRecords();

	// clears out all file contents. This does not clear existing lines.
	void PLUGIN_API ClearFileContents();

	// clears out all line data
	void PLUGIN_API ClearAllRecords();

	// closes the file
	void PLUGIN_API CloseFile();

#ifdef __cplusplus
}
#endif

