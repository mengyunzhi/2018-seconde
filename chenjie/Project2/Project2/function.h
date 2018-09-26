#pragma once
#include <iostream>
using namespace std;
void test(int &sum)
{
	int x;
	cin >> x;
	if (x == 0)
	{
		sum = 0;
	}
	else
	{
		test(sum);
		sum += x;
		//cout << "sum= " << sum<<endl;

	}
	cout << "sum= " << sum << endl;
}
