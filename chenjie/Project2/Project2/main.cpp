#include <iostream>
#include "Stack.h"
using namespace std;
int main()
{
	LinkStack<int> test;
	test.Add(1);
	cout << test.Top();
}