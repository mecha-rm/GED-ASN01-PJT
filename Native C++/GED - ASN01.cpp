// GED - ASN01.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "FileSystem.h"
#include <iostream>

// converts string to char array that allows for editing
char* StringToCharArray(const std::string& str)
{
    // allocate space
    char* chs = new char[str.length()];
    
    // copies the memory
    memcpy(chs, str.c_str(), sizeof(char) * str.length());

    // return
    return chs;
}

// converts a value to bytes
template<typename T>
char* ValueToBytes(T val)
{
    // array to hold value
    char* chs = new char[sizeof(val)];

    // copies data
    memcpy(chs, &val, sizeof(val));

    // returns data
    return chs;
}

int main()
{
    std::cout << "DLL Test: START" << std::endl;

    // const char data cannot be deleted, and does not get removed after leaving the function.

    FileSystem fs;
    bool fOpen = fs.OpenForWriting("test.txt", true); // this creates the file regardless. You need to fix that.
    // Open
    if(fOpen)
    {
        // const char data cannot be deleted. Since this is meant to work in a DLL, regular char data must be sent.
        // line 0
        {
            std::string str = "John";
            char* chrs = StringToCharArray(str);
            fs.AddLine(chrs, str.length());
        }

        // line 1
        {
            std::string str = "Jessie";
            char* chrs = StringToCharArray(str);
            fs.AddLine(chrs, str.length());
        }

        // line 2
        {
            std::string str = "Jessibelle";
            char* chrs = StringToCharArray(str);
            fs.AddLine(chrs, str.length());
        }

        // line 3 - store integer
        if(false)
        {
            int x = 12;
            char* chrs = ValueToBytes(x);
            
            // conversion works
            int y = 0;                    
            memcpy(&y, chrs, sizeof(int));

            // conversion does not work
            y = 0;
            fs.AddLine(chrs, sizeof(x));

            std::string str = fs.GetLine(fs.GetLineCount() - 1);
            memcpy(&y, str.c_str(), sizeof(int));
            y = y;

        }

        // store float
        {

        }

        fs.WriteAllLines();
        fs.CloseFile();
    }

    // Reading
    fOpen = fs.OpenForReading("test.txt");

    if(fOpen)
    {
        const int LINE_COUNT = fs.GetLineCount();
        
        // line 3 - get integer (comment out if not being used)
        // {
        //     std::string str = fs.GetLine(3);
        //     int x = 0;
        //     memcpy(&x, str.c_str(), sizeof(int));
        //     
        //     std::cout << "Int: " << x << std::endl;
        //     fs.RemoveLine(3);
        // }

        // prints all lines
        for (int i = 0; i < LINE_COUNT; i++)
        {
            std::cout << fs.GetLine(i) << std::endl;
        }
    }

    std::cout << "\nDLL Test: END" << std::endl;
    system("pause");
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
