#include "BaseTrack.h"



BaseTrack::BaseTrack()
{
	top = -1;
}


BaseTrack::~BaseTrack()
{
}

bool BaseTrack::push(char & newData)
{
	if (isFull()) {
		return false;
	}else { 
		data[++top] = newData;
		return true;
	}
}

bool BaseTrack::pop(char &emptyData)
{
	if (isEmpty()) {
		return false;
	}else {
		emptyData = data[top];
		data[top--] = NULL;
		return true;
	}
}

void BaseTrack::travelAll()
{
	if (isEmpty()) {
		cout << "!!! ���Ϊ�� !!!" << endl;
	}
	cout << "�������������Ϊ��" << endl;
	for (int i = 0; i < top + 1; i++)
	{	
		cout << data[i];
	}
	cout << endl;
}

bool BaseTrack::isEmpty()
{
	return top == -1;
}

bool BaseTrack::isFull()
{
	return top == MaxSize - 1;
}

int BaseTrack::getTop()
{
	return top;
}

bool BaseTrack::isTopEqualto(char value)
{
	return value == data[top];
}
