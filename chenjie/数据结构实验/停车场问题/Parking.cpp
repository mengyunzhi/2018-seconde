#include "Car.h"
#include "Parking.h"
#include <iostream>
using namespace std;


Parking::Parking()
{
	length = 0;
	top = -1;
	data = new Car[MaxSize];
}

Parking::~Parking()
{
}

// 入栈
bool Parking::push(Car & newData)
{
	if (isFull())
	{
		return false;
	}
	data[++top] = newData;
	length++;
	return true;
}

// 出栈
bool Parking::pop(Car & newData)
{
	if (top == -1)
	{
		return false;
	}
	// 将栈顶元素赋给newData
	newData = data[top];

	// 栈顶元素清空
	data[top] = NULL;
	top--;
	length--;

	return true;
}

void Parking::display()
{
	if (isEmpty())
	{
		cout << "### 停车场为空" << endl;
	}

	for (int i = 0; i < top + 1; i++)
	{
		cout << "### 停车场从里向外数";
		cout << "第" << i + 1 << "辆车的车牌号为：" << data[i].number << endl;
	}
}

bool Parking::isFull()
{
	return top == MaxSize - 1;
}

bool Parking::isEmpty()
{	
	return top == -1;
}

int Parking::getTop()
{
	return top;
}

int Parking::findPosition(int number)
{
	for (int i = 0; i < length; i++)
	{
		if (number == data[i].number)
		{
			return i + 1;
		}
	}
	return 0;
}

Car Parking::findByNumber(int number)
{
	for (int i = 0; i < length; i++)
	{
		if (number == data[i].number)
		{
			return data[i];		
		}
	}
}

bool Parking::isInParking(int number)
{

	for (int i = 0; i < length; i++)
	{
		if (number == data[i].number)
		{
			return true;
		}
	}
	return false;
}
