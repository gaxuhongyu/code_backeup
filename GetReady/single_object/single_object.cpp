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

class FAS
{
public:
	static FAS * makeFAS();
	static FAS * makeFAS(const FAS& rhs);

protected:
private:
	FAS();
	FAS(const FAS& rhs);
};

FAS * FAS::makeFAS()
{
	return new FAS();
}
FAS * FAS::makeFAS(const FAS& rhs)
{
	return new FAS(rhs);
}
int _tmain(int argc, _TCHAR* argv[])
{
	const int n = 10, m = 20;
	char a[n][m];
	char (*p)[n];
// 	n = 20;
// 	m = 30;

	return 0;
}