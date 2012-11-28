// GetReady.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

template<typename C>
void print2nd(const C& container)
{
	if (container.size() >= 2)
	{
		C::const_iterator iter(container.begin());
		++iter;
		int value = *iter;
		std::cout << value;
	}
}
int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

