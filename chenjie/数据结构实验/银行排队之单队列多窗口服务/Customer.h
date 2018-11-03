#pragma once
#include "Queue.h"
#include "Window.h"
class Queue;
class Window;
class Customer
{
public:
	Customer();
	Customer(int arr_time, int han_time);
	~Customer();
	int getArriveTime();
	int getHandleTime();
	void setWaitTime(int);
	void operator =(Customer & another);
	void operator =(int);
private:
	int arrive_time;								// ����ʱ��
	int handle_time;								// ����ʱ��
	int wait_time;									// �ȴ�ʱ��
	friend class Queue;
	friend class Window;
};

