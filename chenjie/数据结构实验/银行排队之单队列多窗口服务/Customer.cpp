#include "Customer.h"



Customer::Customer()
{
	arrive_time = -1;
	handle_time = -1;
	wait_time = -1;
}

Customer::Customer(int arr_time, int han_time)
{
	arrive_time = arr_time;
	handle_time = han_time;
	wait_time = -1;
}


Customer::~Customer()
{
}


int Customer::getArriveTime()
{
	return arrive_time;
}

int Customer::getHandleTime()
{
	return handle_time;
}

void Customer::setWaitTime(int time)
{
	wait_time = time;
}

void Customer::operator=(Customer & another)
{
	this->arrive_time = another.arrive_time;
	this->handle_time = another.handle_time;
	this->wait_time = another.wait_time;
}

void Customer::operator=(int null)
{
	this->arrive_time = null;
	this->handle_time = null;
	this->wait_time = null;
}