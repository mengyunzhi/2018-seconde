#pragma once
#include "Customer.h"
#include "Queue.h"
#include "Window.h"
#include <iostream>
#define MaxSize 10
using namespace std;

class Menu
{
public:
	Menu();
	~Menu();
	void cinArriveAndHandleTime(Queue &);					// ���뵽��ʱ���봦��ʱ��
	void cinWindowsNumber();								// ���봰����
	void StartWork(Queue &, Window(&)[10]);					// ��ʼ����
	void directToWindow(Customer &, Window(&)[10], int i);	// �޵ȴ���ֱ��ȥ���ڣ�iΪ����λ��
	void afterWaitToWindow(Customer &, Window(&)[10]);		// �����ȴ����봰��
	void timePass(Window(&windows)[10], int passTime);		// ʱ������
	void calculateTotalAndMaxWaitTime(int waitTime);		// �����ܵȴ�ʱ������ȴ�ʱ��
	void calculateFinalFinishTime(Window(&)[10]);			// ����������ʱ��
	void coutAverageAndMaxAndFinalTime();					// ���ƽ���ȴ�ʱ�䣨�����С�����1λ������ȴ�ʱ�䡢������ʱ��
	void coutServiceNumber(Window(&)[10]);					// ��ŵ���˳�����ÿ�����ڷ����˶������˿�
	bool isAllWindowsBusy(Window(&)[10]);
	int minRemainTime(Window(&)[10], int &);
private:
	int totalCustomerNumber;
	int totalWindowsNumber;
	int currentTime;
	float totalWaitingTime;
	float averageWaitingTime;
	int maxWaitingTime;
	int finalFinishTime;
};

