#include "Window.h"



Window::Window()
{
	this->remain_time = -1;
	this->status = false;
	this->serviceNumber = 0;
	this->customer = new Customer();
}

Window::~Window()
{
}

void Window::add(Customer & waiting_customer)
{
	*customer = waiting_customer;
}

void Window::pop(Customer & handling_customer)
{
	handling_customer = *this->customer;
	*this->customer = -1;
}

void Window::customerGoInTo(Customer & customer)
{
	// 更改窗口状态
	changeStatus();

	// 将窗口的剩余处理时间置为顾客处理时间
	if (customer.getHandleTime() > 60) {
		setRemainTime(60);
	}
	else {
		setRemainTime(customer.getHandleTime());
	}

	// 将顾客添加到窗口
	add(customer);

	// 服务顾客数增加
	serviceNumber++;
}

void Window::pop()
{
	*this->customer = -1;
}

void Window::setRemainTime(int time)
{
	remain_time = time;
}

int Window::getRemainTime()
{
	return remain_time;
}

int Window::getserviceNumber()
{
	return serviceNumber;
}

void Window::changeStatus()
{
	status = !status;
}

bool Window::isBusy()
{
	return status;
}

void Window::calculateserviceNumber()
{
	serviceNumber++;
}