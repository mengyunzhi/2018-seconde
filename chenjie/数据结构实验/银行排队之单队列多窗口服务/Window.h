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
	bool status;				// ����ռ��״̬��trueΪ���ˣ�falseΪ��
	int remain_time;			// ʣ�ദ��ʱ��
	int serviceNumber;			// �ѷ��������
	Customer *customer;
};