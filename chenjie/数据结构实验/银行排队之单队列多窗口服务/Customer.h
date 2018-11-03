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
	int arrive_time;								// 到达时间
	int handle_time;								// 处理时间
	int wait_time;									// 等待时间
	friend class Queue;
	friend class Window;
};

