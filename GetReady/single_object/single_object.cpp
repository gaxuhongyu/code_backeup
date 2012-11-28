// single_object.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

class PrintJob;
class Printer 
{
public:
	void submitJob(const PrintJob& job);
	void reset();
	void performSelfTest();
	friend Printer& thePrinter();
protected:
private:
	Printer()
	{
		count = 1;
	}
	Printer(const Printer& rhs);
	int count;
};

Printer& thePrinter()
{
	static Printer p;
	return p;
}

class PrintJob
{
public:
protected:
private:
};

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

