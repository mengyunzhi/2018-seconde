#pragma once
#include"Customer.h"
class Customer;
class Window
{
public:
	Window();
	~Window();
	void add(Customer &);
	void pop(Customer &);
	void pop();
	void customerGoInTo(Customer &);
	void setRemainTime(int);
	int getRemainTime();
	int getserviceNumber();
	void changeStatus();
	bool isBusy();
	void calculateserviceNumber();
private:
	bool status;				// 窗口占用状态，true为有人，false为空
	int remain_time;			// 剩余处理时间
	int serviceNumber;			// 已服务的人数
	Customer *customer;
};