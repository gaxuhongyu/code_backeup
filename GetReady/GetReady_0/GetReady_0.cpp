// GetReady_0.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

template<unsigned n>
struct Factorial {
	enum { value = n * Factorial<n -1>::value};
};
class Widget
{
public:
protected:
private:
	int a;
};
template<>
struct Factorial<0>
{
	enum { value = 1 };
};

template<typename IterT, typename DistT>
void advance(IterT& iter, DistT d)
{
	if (iter is random access iterator)
	{
		iter += d;
	}else
	{
		if (d >= 0)
		{
			while (d--)
			{
				++iter
			}
		}else
		{
			while (d++)
			{
				--iter;
			}
		}
	}
}

struct node
{
	int value;
	node* left;
	node* right;
};

void display(node* head)
{
	if (NULL == head)
	{
		return;
	}
	if (head->value > 31 || head->value < 41)
	{
		printf("This node value is : %d",head->value);
	}
	if (NULL != head->left)
	{
		display(head->left);
	} 
	if (NULL != head->right)
	{
		display(head->right);
	}
}

void outOfMem()
{
	std::cerr << "Unable to satisfy request for memory\n";
	std::abort();
}

istream operator>>(istream& s, Widget& w);
void passAndThrowWidget()
{
	Widget localWidget;
	cin >> localWidget;
	throw localWidget;
}
int _tmain(int argc, _TCHAR* argv[])
{
	cout << Factorial<5>::value;
	cout << Factorial<10>::value;

	set_new_handler(outOfMem);
	int array[10000];
	return 0;
}

