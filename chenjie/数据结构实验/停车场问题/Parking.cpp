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

// ��ջ
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

// ��ջ
bool Parking::pop(Car & newData)
{
	if (top == -1)
	{
		return false;
	}
	// ��ջ��Ԫ�ظ���newData
	newData = data[top];

	// ջ��Ԫ�����
	data[top] = NULL;
	top--;
	length--;

	return true;
}

void Parking::display()
{
	if (isEmpty())
	{
		cout << "### ͣ����Ϊ��" << endl;
	}

	for (int i = 0; i < top + 1; i++)
	{
		cout << "### ͣ��������������";
		cout << "��" << i + 1 << "�����ĳ��ƺ�Ϊ��" << data[i].number << endl;
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
