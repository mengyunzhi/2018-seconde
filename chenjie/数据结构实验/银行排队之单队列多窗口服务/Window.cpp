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
	// ���Ĵ���״̬
	changeStatus();

	// �����ڵ�ʣ�ദ��ʱ����Ϊ�˿ʹ���ʱ��
	if (customer.getHandleTime() > 60) {
		setRemainTime(60);
	}
	else {
		setRemainTime(customer.getHandleTime());
	}

	// ���˿���ӵ�����
	add(customer);

	// ����˿�������
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