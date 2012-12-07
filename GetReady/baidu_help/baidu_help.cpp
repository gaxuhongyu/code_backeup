// baidu_help.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
// 
// 
// int _tmain(int argc, _TCHAR* argv[])
// {
// 	return 0;
// }
#include<stdio.h>
#include <math.h>

bool IsPrime(int i)
{
	if (0 == i)
	{
		return false;
	}
	int k;
	bool Prime = true;
	k = (int)sqrt((double)i);  
	for(int m = 2; m<= k && i <= 5000; m++)
	{
		if(i%m==0)
		{
			Prime = false;
			break;
		}
	}
	return Prime;
}
bool BitIsPrime(int i)
{
	int temp = i;
	int temp_sub = 0;
	int temp_aaa = 0;
	bool reslut = false;
	while(true)
	{
		temp_sub = temp % 10;
		switch (temp_sub)
		{
		case 1:
		case 2:
		case 3:
		case 5:
		case 7:
			reslut = true;
			break;
		default:
			return false;
			break;
		}
		temp_aaa = (temp - temp_sub)/10;
		temp = temp_aaa;
		if (0 == temp_aaa)
		{
			return reslut;
		}
	}
}
bool SubBitIsPrime(int i)
{
	int temp = i;
	int temp_sub = 0;
	bool result = true;
	while (true && result)
	{
		if (!IsPrime(temp))
		{
			result = false;
		}
		temp_sub = temp%10;
		temp = (temp - temp_sub)/10;
		if (0 == temp)
		{
			return result;
		}
	}
	return result;
}
void Prime(void)
{
	for(int i = 1; i <= 5000; i++)
	{
		if (IsPrime(i) && BitIsPrime(i) && SubBitIsPrime(i))
		{
			printf("Number:%d is match you condition.\n",i);
		}
	}
}

int main()
{
	Prime();
	return 0;
}